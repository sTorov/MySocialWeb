namespace SocialWeb.DAL.Entities
{
    /// <summary>
    /// Сущность запроса на добавление в друзья
    /// </summary>
    public class FriendRequestEntity
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int requested_user_id { get; set; }
    }
}
