namespace SocialWeb.BLL.Models
{
    /// <summary>
    /// Модель данных для манипуляции запросами на добавление в друзья
    /// </summary>
    public class FriendRequestSendingData
    {
        public int UserId { get; set; }
        public string SearchEmail { get; set; }
    }
}
