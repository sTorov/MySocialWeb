namespace SocialWeb.BLL.Models
{
    /// <summary>
    /// Модель данных для отправки сообщения
    /// </summary>
    public class MessageSendingData
    {
        public int SenderId { get; set; }
        public string Content { get; set; }
        public string RecipientEmail { get; set; }
    }
}
