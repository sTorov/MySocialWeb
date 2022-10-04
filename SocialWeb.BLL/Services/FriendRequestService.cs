using SocialWeb.BLL.Exceptions;
using SocialWeb.BLL.Models;
using SocialWeb.DAL.Entities;
using SocialWeb.DAL.Repositories;

namespace SocialWeb.BLL.Services
{
    /// <summary>
    /// Сервис запросов на добавление в друзья
    /// </summary>
    public class FriendRequestService
    {
        IFriendRequestRepository friendRequestRepository;
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendRequestService()
        {
            friendRequestRepository = new FriendRequestRepository();
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }

        /// <summary>
        /// Конструктор для тестирования
        /// </summary>
        public FriendRequestService(
            IFriendRequestRepository friendRequestRepository,
            IFriendRepository friendRepository,
            IUserRepository userRepository)
        {
            this.friendRequestRepository = friendRequestRepository;
            this.friendRepository = friendRepository;
            this.userRepository = userRepository;
        }

        /// <summary>
        /// Поиск входящего запроса. 
        /// </summary>
        /// <exception cref="UserNotFoundException"></exception>
        /// <exception cref="FriendRequestNotFoundException"></exception>
        public FriendRequest FindInputRequest(FriendRequestSendingData friendRequestSendingData)
        {
            var findUserEntity = userRepository.FindByEmail(friendRequestSendingData.SearchEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var findFriendRequest = friendRequestRepository.FindAllByRequestedUserId(friendRequestSendingData.UserId)
                .FirstOrDefault(r => r.user_id == findUserEntity.id);
            if (findFriendRequest is null) throw new FriendRequestNotFoundException();

            return new FriendRequest(findFriendRequest.id, findUserEntity.email, findUserEntity.firstname, findUserEntity.lastname);
        }

        /// <summary>
        /// Поиск исходящего запроса.
        /// </summary>
        /// <exception cref="UserNotFoundException"></exception>
        /// <exception cref="FriendRequestNotFoundException"></exception>
        public FriendRequest FindOutputRequest(FriendRequestSendingData friendRequestSendingData)
        {
            var findUserEntity = userRepository.FindByEmail(friendRequestSendingData.SearchEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var findFriendRequest = friendRequestRepository.FindAllByUserId(friendRequestSendingData.UserId)
                .FirstOrDefault(r => r.requested_user_id == findUserEntity.id);
            if (findFriendRequest is null) throw new FriendRequestNotFoundException();

            return new FriendRequest(findFriendRequest.id, findUserEntity.email, findUserEntity.firstname, findUserEntity.lastname);
        }

        /// <summary>
        /// Отправка запроса.
        /// </summary>
        /// <exception cref="UserNotFoundException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="FriendFoundException"></exception>
        /// <exception cref="Exception"></exception>
        public void SendRequest(FriendRequestSendingData friendRequestSendingData)
        {
            var findUserEntity = userRepository.FindByEmail(friendRequestSendingData.SearchEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            if (friendRequestSendingData.UserId == findUserEntity.id)
                throw new ArgumentNullException();

            if (friendRequestRepository.FindAllByUserId(friendRequestSendingData.UserId)
                .FirstOrDefault(e => e.requested_user_id == findUserEntity.id) != null)
                throw new ArgumentOutOfRangeException();

            if (friendRequestRepository.FindAllByRequestedUserId(friendRequestSendingData.UserId)
                .FirstOrDefault(e => e.user_id == findUserEntity.id) != null)
                throw new ArgumentOutOfRangeException();

            if (friendRepository.FindByUserIdAndFriendId(friendRequestSendingData.UserId, findUserEntity.id) != null)
                throw new FriendFoundException();

            var friendRequestEntity = new FriendRequestEntity()
            {
                user_id = friendRequestSendingData.UserId,
                requested_user_id = findUserEntity.id
            };

            if (friendRequestRepository.Create(friendRequestEntity) == 0)
                throw new Exception();
        }

        /// <summary>
        /// Получение всех входящих запросов для текущего пользователя по его ID
        /// </summary>
        public IEnumerable<FriendRequest> FindAllInputRequestByUserId(int userId)
        {
            var friendRequests = new List<FriendRequest>();

            friendRequestRepository.FindAllByRequestedUserId(userId).ToList().ForEach(r =>
            {
                var findUserEntity = userRepository.FindById(r.user_id);

                friendRequests.Add(new FriendRequest(r.id, findUserEntity.email, findUserEntity.firstname, findUserEntity.lastname));
            });

            return friendRequests;
        }

        /// <summary>
        /// Получение всех исходящих запросов для текущего пользователя по его ID
        /// </summary>
        public IEnumerable<FriendRequest> FindAllOutputRequestByUserId(int userId)
        {
            var friendRequests = new List<FriendRequest>();

            friendRequestRepository.FindAllByUserId(userId).ToList().ForEach(r =>
            {
                var findUserEntity = userRepository.FindById(r.requested_user_id);

                friendRequests.Add(new FriendRequest(r.id, findUserEntity.email, findUserEntity.firstname, findUserEntity.lastname));
            });

            return friendRequests;
        }

        /// <summary>
        /// Удаление запроса
        /// </summary>
        /// <exception cref="FriendRequestNotFoundException"></exception>
        /// <exception cref="Exception"></exception>
        public void DeleteRequest(int id)
        {
            if (friendRequestRepository.FindById(id) == null)
                throw new FriendRequestNotFoundException();

            if (friendRequestRepository.Delete(id) == 0)
                throw new Exception();
        }
    }
}
