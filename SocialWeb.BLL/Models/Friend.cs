namespace SocialWeb.BLL.Models
{
    /// <summary>
    /// Объект друга
    /// </summary>
    public class Friend
    {
        public int Id { get; }
        public string FirstName { get; }
        public string LastName { get; }
        public string Email { get; }

        public Friend(int id, string firstName, string lastName, string email)
        {
            Id = id;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }
    }
}
