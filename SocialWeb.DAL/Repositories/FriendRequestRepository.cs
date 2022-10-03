using SocialWeb.DAL.Entities;

namespace SocialWeb.DAL.Repositories
{
    /// <summary>
    /// Репозиторий запросов на добавление в друзья
    /// </summary>
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
            return Execute(@"delete from friend_requests where id = :id_p", new { id_p = id });
        }

        public IEnumerable<FriendRequestEntity> FindAllByRequestedUserId(int requestedUserId)
        {
            return Query<FriendRequestEntity>(@"select * from friend_requests where requested_user_id = :requestedUserId_p", 
                                                new { requestedUserId_p = requestedUserId });
        }

        public IEnumerable<FriendRequestEntity> FindAllByUserId(int userId)
        {
            return Query<FriendRequestEntity>(@"select * from friend_requests where user_id = :userID_p",
                                                new { userID_p = userId });
        }

        public FriendRequestEntity FindById(int id)
        {
            return QueryFirstOrDefault<FriendRequestEntity>(@"select * from friend_requests where id = :id_p", new { id_p = id });
        }
    }

    /// <summary>
    /// Интерфейс репозитория запросов на добавление в друзья
    /// </summary>
    public interface IFriendRequestRepository
    {
        /// <summary>
        /// Создание записи в базе данных.
        /// </summary>
        int Create(FriendRequestEntity friendRequestEntity);
        /// <summary>
        /// Удаление записи из базы данных.
        /// </summary>
        int Delete(int id);
        /// <summary>
        /// Поиск всех записей в базе данных по ID получателя.
        /// </summary>
        IEnumerable<FriendRequestEntity> FindAllByRequestedUserId(int requestedUserId);
        /// <summary>
        /// Поиск всех записей в базе данных по ID пользователя. 
        /// </summary>
        IEnumerable<FriendRequestEntity> FindAllByUserId(int userId);
        /// <summary>
        /// Поиск записи по ID записи.
        /// </summary>
        FriendRequestEntity FindById(int id);
    }
}
