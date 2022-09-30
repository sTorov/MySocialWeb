namespace SocialWeb.DAL.Entities
{
    public class FriendRequestEntity
    {
        public int id { get; set; }
        public int user_id { get; set; }
        public int requested_user_id { get; set; }
    }
}
