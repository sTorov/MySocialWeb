using SocialWeb.BLL.Exceptions;
using SocialWeb.BLL.Models;
using SocialWeb.DAL.Entities;
using SocialWeb.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace SocialWeb.BLL.Services
{
    public class UserService
    {
        IUserRepository userRepository;
        MessageService messageService;

        public UserService()
        {
            userRepository = new UserRepository();
            messageService = new MessageService();
        }

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

        public User Authenticate(UserAuthenticationData userAuthenticationData)
        {
            var findUserEntity = userRepository.FindByEmail(userAuthenticationData.Email);

            if (findUserEntity is null) 
                throw new UserNotFoundException();

            if (findUserEntity.password != userAuthenticationData.Password)
                throw new WrongPasswordException();

            return ConstructUserModel(findUserEntity);
        }

        public User FindByEmai(string email)
        {
            var findUserEntity = userRepository.FindByEmail(email);
            if (findUserEntity is null) throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }

        public User FindById(int id)
        {
            var findUserEntity = userRepository.FindById(id);
            if (findUserEntity is null) throw new UserNotFoundException();

            return ConstructUserModel(findUserEntity);
        }

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

        private User ConstructUserModel(UserEntity userEntity)
        {
            var incomingMessage = messageService.GetIncomingMessagesByUserId(userEntity.id);
            var outgoingMessages = messageService.GetOutcomingMessagesByUserId(userEntity.id);

            return new User(userEntity.id,
                userEntity.firstname,
                userEntity.lastname,
                userEntity.password,
                userEntity.email,
                userEntity.photo,
                userEntity.favorite_movie,
                userEntity.favorite_book,
                incomingMessage,
                outgoingMessages
                );
        }
    }
}
