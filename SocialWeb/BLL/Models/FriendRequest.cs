namespace SocialWeb.BLL.Models
{
    public class FriendRequest
    {
        public int Id { get; }
        public string SenderEmail { get; }
        public string SenderFirstName { get; }
        public string SenderLastName { get; }
        public FriendRequest(int id, string userEmail, string userFirstName, string userLastName)
        {
            Id = id;
            SenderEmail = userEmail;
            SenderFirstName = userFirstName;
            SenderLastName = userLastName;            
        }
    }
}
