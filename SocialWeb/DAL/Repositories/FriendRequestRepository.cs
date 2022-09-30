using SocialWeb.DAL.Entities;

namespace SocialWeb.DAL.Repositories
{
    public class FriendRequestRepository : BaseRepository, IFriendRequestRepository
    {
        public int Create(FriendRequestEntity friendRequestEntity)
        {
            return Execute(@"insert into friend_requests(user_id,requested_user_id)
                            values(:user_id,:requested_user_id)",
                            friendRequestEntity);
        }

        public int Delete(int id)
        {
            return Execute(@"delete into friend_requests where id = :id_p", new { id_p = id });
        }

        public IEnumerable<FriendRequestEntity> FindAllByRequestedUserId(int requestedUserId)
        {
            return Query<FriendRequestEntity>(@"select * from friend_requests where requested_user_id = :requestedUserId_p", 
                                                new { requestedUserId_p = requestedUserId });
        }

        public FriendRequestEntity FindById(int id)
        {
            return QueryFirstOrDefault<FriendRequestEntity>(@"select * from friend_requests where id = :id_p", new { id_p = id });
        }
    }

    public interface IFriendRequestRepository
    {
        int Create(FriendRequestEntity friendRequestEntity);
        int Delete(int id);
        IEnumerable<FriendRequestEntity> FindAllByRequestedUserId(int requestedUserId);
        FriendRequestEntity FindById(int id);
    }
}
