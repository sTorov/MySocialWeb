using SocialWeb.DAL.Entities;

namespace SocialWeb.DAL.Repositories
{
    /// <summary>
    /// Репозиторий друзей
    /// </summary>
    public class FriendRepository : BaseRepository, IFriendRepository
    {
        public int Create(FriendEntity friendEntity)
        {
            return Execute(@"insert into friends(user_id,friend_id)
                            values(:user_id,:friend_id)", friendEntity);
        }

        public int Delete(int id)
        {
            return Execute(@"delete from friends where id = :id_p", new { id_p = id });
        }

        public FriendEntity FindByUserIdAndFriendId(int userId, int friendId)
        {
            return QueryFirstOrDefault<FriendEntity>(@"select * from friends where user_id = @userID and friend_id = @friendID", new { userID = userId, friendID = friendId });
        }

        public IEnumerable<FriendEntity> FindAllByUserId(int userId)
        {
            return Query<FriendEntity>(@"select * from friends where user_id = :user_id", new { user_id = userId });
        }
    }

    /// <summary>
    /// Интерфейс репозитория друзей
    /// </summary>
    public interface IFriendRepository
    {
        /// <summary>
        /// Создание записи в базе данных.
        /// </summary>
        int Create(FriendEntity friendEntity);
        /// <summary>
        /// Поиск всех записей по ID пользователя
        /// </summary>
        IEnumerable<FriendEntity> FindAllByUserId(int userId);
        /// <summary>
        /// Удаление записи из базы данных.
        /// </summary>
        int Delete(int id);
        /// <summary>
        /// Поиск записи в базе данных по ID пользователя и по ID друга
        /// </summary>
        FriendEntity FindByUserIdAndFriendId(int userId, int friendId);
    }
}
