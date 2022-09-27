namespace SocialWeb.BLL.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string FavoriteMovie { get; set; }
        public string FavoriteBook { get; set; }

        public User(
            int id,
            string firstname,
            string lastname,
            string password,
            string email,
            string photo,
            string favoriteMovie,
            string favoriteBook)
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Password = password;
            Email = email;
            Photo = photo;
            FavoriteMovie = favoriteMovie;
            FavoriteBook = favoriteBook;
        }
    }
}
