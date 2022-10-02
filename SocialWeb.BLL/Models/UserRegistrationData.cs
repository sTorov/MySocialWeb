namespace SocialWeb.BLL.Models
{
    /// <summary>
    /// Модель данных для регистрации пользователя
    /// </summary>
    public class UserRegistrationData
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    }
}
