using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    /// <summary>
    /// Отображение процесса обновления песональных данных пользователя
    /// </summary>
    public class UserDataUpdateView
    {
        UserService userService;

        public UserDataUpdateView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            Console.WriteLine($"Меня зовут:");
            user.FirstName = Console.ReadLine();

            Console.WriteLine($"Моя фамилия:");
            user.LastName = Console.ReadLine();

            Console.WriteLine($"Ссылка на моё фото:");
            user.Photo = Console.ReadLine();

            Console.WriteLine($"Мой любимый фильм:");
            user.FavoriteMovie = Console.ReadLine();

            Console.WriteLine($"Моя любимая книга:");
            user.FavoriteBook = Console.ReadLine();

            userService.Update(user);

            SuccessMessage.Show("Ваш профиль успешно обновлён!");
        }
    }
}
