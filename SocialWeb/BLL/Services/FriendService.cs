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

        public void SendFriendRequest(FriendRequestData friendRequestData)
        {
            if (string.IsNullOrEmpty(friendRequestData.RecipientEmail))
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(friendRequestData.RecipientEmail))
                throw new ArgumentNullException();

            var findUserEntity = userRepository.FindByEmail(friendRequestData.RecipientEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var friendEntity = new FriendEntity()
            {
                user_id = friendRequestData.SenderId,
                friend_id = findUserEntity.id,
            };

            if (friendRepository.Create(friendEntity) == 0)
                throw new Exception();
        }
    }
}
