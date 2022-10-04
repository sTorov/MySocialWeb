using Dapper;
using System.Data;
using System.Data.SQLite;

namespace SocialWeb.DAL.Repositories
{
    /// <summary>
    /// Основной репозиторий
    /// </summary>
    public class BaseRepository
    {
        /// <summary>
        /// Получение сущности типа <typeparamref name="T"/>.
        /// </summary>
        protected T QueryFirstOrDefault<T>(string sql, object parameters = null)
        {
            using(var connection = CreateConnection())
            {
                connection.Open();
                return connection.QueryFirstOrDefault<T>(sql, parameters);
            }
        }

        /// <summary>
        /// Получение списка сущностей типа <typeparamref name="T"/>.
        /// </summary>
        protected List<T> Query<T>(string sql, object parameters = null)
        {
            using(var connection = CreateConnection())
            {
                connection.Open();
                return connection.Query<T>(sql, parameters).ToList();
            }
        }

        /// <summary>
        /// Выполнение SQL запроса.
        /// </summary>
        protected int Execute(string sql, object parameters = null)
        {
            using (var connection = CreateConnection())
            {
                connection.Open();
                return connection.Execute(sql, parameters);
            }
        }

        /// <summary>
        /// Создание подключения к базе данных.
        /// </summary>
        private IDbConnection CreateConnection()
        {
            return new SQLiteConnection("Data Source = DB/social_network.db; Version = 3");
        }
    }
}
