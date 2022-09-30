using SocialWeb.BLL.Exceptions;
using SocialWeb.BLL.Models;
using SocialWeb.DAL.Entities;
using SocialWeb.DAL.Repositories;
using System.ComponentModel.DataAnnotations;

namespace SocialWeb.BLL.Services
{
    public class FriendRequestService
    {
        IFriendRequestRepository friendRequestRepository;
        IUserRepository userRepository;

        public FriendRequestService()
        {
            friendRequestRepository = new FriendRequestRepository();
            userRepository = new UserRepository();
        }

        public void SendRequest(FriendRequestData friendRequestData)
        {
            if (string.IsNullOrEmpty(friendRequestData.FriendEmail))
                throw new ArgumentNullException();

            if (!new EmailAddressAttribute().IsValid(friendRequestData.FriendEmail))
                throw new ArgumentNullException();

            var findUserEntity = userRepository.FindByEmail(friendRequestData.FriendEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var friendRequestEntity = new FriendRequestEntity()
            {
                user_id = friendRequestData.UserId,
                requested_user_id = findUserEntity.id
            };

            if (friendRequestRepository.Create(friendRequestEntity) == 0)
                throw new Exception();
        }

        public IEnumerable<FriendRequest> FindAllRequestByUserId(int userId)
        {
            var friendRequests = new List<FriendRequest>();

            friendRequestRepository.FindAllByRequestedUserId(userId).ToList().ForEach(r =>
            {
                var findUserEntity = userRepository.FindById(r.user_id);

                friendRequests.Add(new FriendRequest(r.id, findUserEntity.email, findUserEntity.firstname, findUserEntity.lastname));
            });

            return friendRequests;
        }

        public void DeleteRequest(int id)
        {
            if (friendRequestRepository.Delete(id) == 0)
                throw new Exception();
        }
    }
}
