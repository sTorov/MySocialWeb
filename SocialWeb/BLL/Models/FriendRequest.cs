namespace SocialWeb.BLL.Models
{
    public class FriendRequest
    {
        public int Id { get; }
        public string UserEmail { get; }
        public string UserFirstName { get; }
        public string UserLastName { get; }
        public FriendRequest(int id, string userEmail, string userFirstName, string userLastName)
        {
            Id = id;
            UserEmail = userEmail;
            UserFirstName = userFirstName;
            UserLastName = userLastName;            
        }
    }
}
