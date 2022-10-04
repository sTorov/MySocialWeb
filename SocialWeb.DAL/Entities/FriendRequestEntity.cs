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

        public override bool Equals(object? obj)
        {
            if(obj is FriendRequestEntity entity)
            {
                if(entity.id != id) return false;
                if(entity.user_id != user_id) return false;
                return true;
            }
            return false;
        }
    }
}
