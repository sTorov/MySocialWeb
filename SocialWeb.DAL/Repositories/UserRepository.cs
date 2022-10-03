using SocialWeb.DAL.Entities;

namespace SocialWeb.DAL.Repositories
{
    /// <summary>
    /// Репозиторий пользователей
    /// </summary>
    public class UserRepository : BaseRepository, IUserRepository
    {
        public int Create(UserEntity userEntity)
        {
            return Execute(@"insert into users(firstname,lastname,password,email)
                            values(:firstname,:lastname,:password,:email)", userEntity);
        }

        public int DeleteById(int id)
        {
            return Execute("delete from users where id = :id_p", new { id_p = id });
        }

        public IEnumerable<UserEntity> FindAll()
        {
            return Query<UserEntity>("select * from users");
        }

        public UserEntity FindByEmail(string email)
        {
            return QueryFirstOrDefault<UserEntity>("select * from users where email = :email_p", new { email_p = email });
        }

        public UserEntity FindById(int id)
        {
            return QueryFirstOrDefault<UserEntity>("select * from users where id = :id_p", new { id_p = id });
        }

        public int Update(UserEntity userEntity)
        {
            return Execute(@"update users set firstname = :firstname, lastname = :lastname, 
                            password = :password, email = :email, photo = :photo, 
                            favorite_movie = :favorite_movie, favorite_book = :favorite_book where id = :id",
                            userEntity);
        }
    }

    /// <summary>
    /// Интерфейс репозитория пользователей
    /// </summary>
    public interface IUserRepository
    {
        /// <summary>
        /// Создание записи в базе данных.
        /// </summary>
        int Create(UserEntity userEntity);
        /// <summary>
        /// Поиск записи по почтовому адресу.
        /// </summary>
        UserEntity FindByEmail(string email);
        /// <summary>
        /// Получение списка всех пользователей.
        /// </summary>
        IEnumerable<UserEntity> FindAll();
        /// <summary>
        /// Поиск записи по ID записи.
        /// </summary>
        UserEntity FindById(int id);
        /// <summary>
        /// Обновление записи.
        /// </summary>
        int Update(UserEntity userEntity);
        /// <summary>
        /// Удаление записи по ID записи.
        /// </summary>
        int DeleteById(int id);
    }
}
