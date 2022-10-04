using SocialWeb.BLL.Exceptions;
using SocialWeb.BLL.Models;
using SocialWeb.DAL.Entities;
using SocialWeb.DAL.Repositories;

namespace SocialWeb.BLL.Services
{
    /// <summary>
    /// Сервис друзей
    /// </summary>
    public class FriendService
    {
        IFriendRepository friendRepository;
        IFriendRequestRepository friendRequestRepository;
        IUserRepository userRepository;

        public FriendService()
        {
            friendRepository = new FriendRepository();
            friendRequestRepository = new FriendRequestRepository();
            userRepository = new UserRepository();
        }

        /// <summary>
        /// Получить список всех друзей текущего пользователя по его ID.
        /// </summary>
        public IEnumerable<Friend> GetAllFriendsByUserId(int userId)
        {
            var friends = new List<Friend>();

            friendRepository.FindAllByUserId(userId).ToList().ForEach(f =>
            {
                var friendUserEntity = userRepository.FindById(f.friend_id);

                friends.Add(new Friend(f.id, friendUserEntity.firstname, friendUserEntity.lastname, friendUserEntity.email));
            });

            return friends;
        }

        /// <summary>
        /// Удаление пользователей из списка друзей.<br/>
        /// У текущего пользователя удаляется информация о искомом пользователе, и<br/>
        /// у искомого пользователя удаляется информация о текущем.
        /// </summary>
        /// <exception cref="UserNotFoundException"></exception>
        public void DeleteFriend(FriendRequestSendingData friendRequestSendingData)
        {
            var deletingFriendEntity = userRepository.FindByEmail(friendRequestSendingData.SearchEmail);
            if (deletingFriendEntity is null) throw new UserNotFoundException();

            Delete(friendRequestSendingData.UserId, deletingFriendEntity.id);
            Delete(deletingFriendEntity.id, friendRequestSendingData.UserId);
        }

        /// <summary>
        /// Удаление пользователя из списка друзей.
        /// </summary>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        private void Delete(int userId, int friendId)
        {
            var findFriendEntity = friendRepository.FindByUserIdAndFriendId(userId, friendId);
            if (findFriendEntity is null) throw new ArgumentNullException();

            if (friendRepository.Delete(findFriendEntity.id) == 0)
                throw new Exception();
        }

        /// <summary>
        /// Добавление пользователей в списки друзей.<br/>
        /// У текущего пользователя добавляется информация о искомом пользователе, и<br/>
        /// у искомого пользователя добавляется информация о текущем.
        /// </summary>
        /// <exception cref="UserNotFoundException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public void AddingFriend(FriendRequestSendingData friendRequestSendingData)
        {
            var findUserEntity = userRepository.FindByEmail(friendRequestSendingData.SearchEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var findFriendRequestEntity = friendRequestRepository
                .FindAllByRequestedUserId(friendRequestSendingData.UserId)
                .FirstOrDefault(r => r.user_id == findUserEntity.id);
            if (findFriendRequestEntity is null) throw new ArgumentNullException();

            if (friendRequestRepository.Delete(findFriendRequestEntity.id) == 0)
                throw new Exception();

            Create(friendRequestSendingData.UserId, findUserEntity.id);
            Create(findUserEntity.id, friendRequestSendingData.UserId);
        }

        /// <summary>
        /// Добавление пользователя в список друзей.
        /// </summary>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="Exception"></exception>
        private void Create(int userId, int friendId)
        {
            if (friendRepository.FindByUserIdAndFriendId(userId, friendId) != null)
                throw new ArgumentOutOfRangeException();

            var friendEntityFriend = new FriendEntity()
            {
                user_id = userId,
                friend_id = friendId,
            };

            if (friendRepository.Create(friendEntityFriend) == 0)
                throw new Exception();
        }
    }
}
