using SocialWeb.BLL.Exceptions;
using SocialWeb.BLL.Models;
using SocialWeb.DAL.Entities;
using SocialWeb.DAL.Repositories;

namespace SocialWeb.BLL.Services
{
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

        public FriendRequest FindInputRequest(FriendRequestData friendRequestData)
        {
            var findUserEntity = userRepository.FindByEmail(friendRequestData.FriendEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var findFriendRequest = friendRequestRepository.FindAllByRequestedUserId(friendRequestData.UserId)
                .FirstOrDefault(r => r.user_id == findUserEntity.id);
            if (findFriendRequest is null) throw new FriendRequestNotFoundException();

            return new FriendRequest(findFriendRequest.id, findUserEntity.email, findUserEntity.firstname, findUserEntity.lastname);
        }

        public FriendRequest FindOutputRequest(FriendRequestData friendRequestData)
        {
            var findUserEntity = userRepository.FindByEmail(friendRequestData.FriendEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            var findFriendRequest = friendRequestRepository.FindAllByUserId(friendRequestData.UserId)
                .FirstOrDefault(r => r.requested_user_id == findUserEntity.id);
            if (findFriendRequest is null) throw new FriendRequestNotFoundException();

            return new FriendRequest(findFriendRequest.id, findUserEntity.email, findUserEntity.firstname, findUserEntity.lastname);
        }

        public void SendRequest(FriendRequestData friendRequestData)
        {
            var findUserEntity = userRepository.FindByEmail(friendRequestData.FriendEmail);
            if (findUserEntity is null) throw new UserNotFoundException();

            if (friendRequestData.UserId == findUserEntity.id)
                throw new Exception();

            if (friendRequestRepository.FindAllByRequestedUserId(friendRequestData.UserId).FirstOrDefault(e => e.user_id == findUserEntity.id) != null)
                throw new ArgumentOutOfRangeException();

            if (friendRepository.FindByUserIdAndFriendId(friendRequestData.UserId, findUserEntity.id) != null)
                throw new ArgumentOutOfRangeException();

            var friendRequestEntity = new FriendRequestEntity()
            {
                user_id = friendRequestData.UserId,
                requested_user_id = findUserEntity.id
            };

            if (friendRequestRepository.Create(friendRequestEntity) == 0)
                throw new Exception();
        }

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
        /// 
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
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

        public void DeleteRequest(int id)
        {
            if (friendRequestRepository.FindById(id) == null)
                throw new FriendRequestNotFoundException();

            if (friendRequestRepository.Delete(id) == 0)
                throw new Exception();
        }
    }
}
