namespace SocialWeb.DAL.Entities
{
    /// <summary>
    /// Сущность друга
    /// </summary>
    public class FriendEntity
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int friend_id { get; set; }
    }
}
