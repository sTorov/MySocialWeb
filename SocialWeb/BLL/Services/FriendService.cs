using SocialWeb.BLL.Exceptions;
using SocialWeb.BLL.Models;
using SocialWeb.DAL.Entities;
using SocialWeb.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace SocialWeb.BLL.Services
{
    public class FriendService
    {
        IFriendRepository friendRepository;
        IUserRepository userRepository;

        public FriendService()
        {
            friendRepository = new FriendRepository();
            userRepository = new UserRepository();
        }

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

        public void DeleteFriend(FriendRequestData friendRequestData)
        {
            if (string.IsNullOrEmpty(friendRequestData.FriendEmail))
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(friendRequestData.FriendEmail))
                throw new ArgumentNullException();

            var deletingFriendEntity = userRepository.FindByEmail(friendRequestData.FriendEmail);
            if (deletingFriendEntity is null) throw new UserNotFoundException();

            Delete(friendRequestData.UserId, deletingFriendEntity.id);
            Delete(deletingFriendEntity.id, friendRequestData.UserId);
        }

        private void Delete(int userId, int friendId)
        {
            var friendEntityForFriend = friendRepository.FindByUserIdAndFriendId(userId, friendId);
            if (friendEntityForFriend is null) throw new EntityNotFoundException();

            if (friendRepository.Delete(friendEntityForFriend.id) == 0)
                throw new Exception();
        }

        public void SendFriendRequest(FriendRequestData friendRequestData)
        {
            if (string.IsNullOrEmpty(friendRequestData.FriendEmail))
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(friendRequestData.FriendEmail))
                throw new ArgumentNullException();

            var findUserEntity = userRepository.FindByEmail(friendRequestData.FriendEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            Create(friendRequestData.UserId, findUserEntity.id);
            Create(findUserEntity.id, friendRequestData.UserId);
        }

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
