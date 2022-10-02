namespace SocialWeb.BLL.Models
{
    /// <summary>
    /// Объект запроса на добавление в друзья
    /// </summary>
    public class FriendRequest
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

        public FriendRequest(int id, string email, string firstName, string lastName)
        {
            Id = id;
            Email = email;
            FirstName = firstName;
            LastName = lastName;            
        }
    }
}
