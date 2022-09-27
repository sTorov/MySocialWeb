namespace SocialWeb.BLL.Models
{
    public class Message
    {
        public int Id { get; }
        public string Content { get; }
        public string SenderEmail { get; }
        public string RecipientEmail { get; set; }

        public Message(int id, string content, string senderEmail, string recipientEmail)
        {
            Id = id;
            Content = content;
            SenderEmail = senderEmail;
            RecipientEmail = recipientEmail;
        }
    }
}
