using SocialWeb.BLL.Exceptions;
using SocialWeb.BLL.Models;
using SocialWeb.DAL.Entities;
using SocialWeb.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace SocialWeb.BLL.Services
{
    /// <summary>
    /// Сервис пользователя
    /// </summary>
    public class UserService
    {
        IUserRepository userRepository;
        MessageService messageService;
        FriendService friendService;
        FriendRequestService friendRequestService;

        public UserService()
        {
            userRepository = new UserRepository();
            messageService = new MessageService();
            friendService = new FriendService();
            friendRequestService = new FriendRequestService();
        }

        /// <summary>
        /// Регистрация нового пользователя. 
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public void Register(UserRegistrationData userRegistrationData)
        {
            if (string.IsNullOrEmpty(userRegistrationData.FirstName))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(userRegistrationData.LastName))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(userRegistrationData.Password))
                throw new ArgumentNullException();

            if (string.IsNullOrEmpty(userRegistrationData.Email))
                throw new ArgumentNullException();

            if (userRegistrationData.Password.Length < 8)
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(userRegistrationData.Email))
                throw new ArgumentNullException();

            if (userRepository.FindByEmail(userRegistrationData.Email) != null)
                throw new ArgumentNullException();

            var userEntity = new UserEntity()
            {
                firstname = userRegistrationData.FirstName,
                lastname = userRegistrationData.LastName,
                password = userRegistrationData.Password,
                email = userRegistrationData.Email
            };

            if (userRepository.Create(userEntity) == 0)
                throw new Exception();
        }

        /// <summary>
        /// Авторизация пользователя.
        /// </summary>
        /// <exception cref="UserNotFoundException"></exception>
        /// <exception cref="WrongPasswordException"></exception>
        public User Authenticate(UserAuthenticationData userAuthenticationData)
        {
            var findUserEntity = userRepository.FindByEmail(userAuthenticationData.Email);

            if (findUserEntity is null) 
                throw new UserNotFoundException();

            if (findUserEntity.password != userAuthenticationData.Password)
                throw new WrongPasswordException();

            return ConstructUserModel(findUserEntity);
        }

        /// <summary>
        /// Поиск пользователя по его почтовому адресу.
        /// </summary>
        /// <exception cref="UserNotFoundException"></exception>
        public User FindByEmail(string email)
        {
            var findUserEntity = userRepository.FindByEmail(email);
            if (findUserEntity is null) throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }

        /// <summary>
        /// Поиск пользователя по его ID
        /// </summary>
        /// <exception cref="UserNotFoundException"></exception>
        public User FindById(int id)
        {
            var findUserEntity = userRepository.FindById(id);
            if (findUserEntity is null) throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }

        /// <summary>
        /// Обновление информации пользователя.
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Update(User user)
        {
            var updatableUserEntity = new UserEntity()
            {
                id = user.Id,
                firstname = user.FirstName,
                lastname = user.LastName,
                password = user.Password,
                email = user.Email,
                photo = user.Photo,
                favorite_movie = user.FavoriteMovie,
                favorite_book = user.FavoriteBook
            };

            if (userRepository.Update(updatableUserEntity) == 0)
                throw new Exception();
        }

        /// <summary>
        /// Создание нового объекта пользователя.
        /// </summary>
        /// <returns></returns>
        private User ConstructUserModel(UserEntity userEntity)
        {
            var incomingMessage = messageService.GetIncomingMessagesByUserId(userEntity.id);
            var outgoingMessages = messageService.GetOutcomingMessagesByUserId(userEntity.id);

            var userFriends = friendService.GetAllFriendsByUserId(userEntity.id);

            var inputFriendRequests = friendRequestService.FindAllInputRequestByUserId(userEntity.id);
            var outputFriendRequests = friendRequestService.FindAllOutputRequestByUserId(userEntity.id);

            return new User(userEntity.id,
                userEntity.firstname,
                userEntity.lastname,
                userEntity.password,
                userEntity.email,
                userEntity.photo,
                userEntity.favorite_movie,
                userEntity.favorite_book,
                incomingMessage,
                outgoingMessages,
                userFriends,
                inputFriendRequests,
                outputFriendRequests
                );
        }

        /// <summary>
        /// Получение списка всех пользователей
        /// </summary>
        public IEnumerable<User> GetAllUsers()
        {
            User user;
            var users = new List<User>();

            userRepository.FindAll().ToList().ForEach(e =>
            {
                user = ConstructUserModel(e);

                users.Add(user);
            });

            return users;
        }

        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <exception cref="Exception"></exception>
        public void Delete(User user)
        {
            if (userRepository.DeleteById(user.Id) == 0)
                throw new Exception();
        }
    }
}
