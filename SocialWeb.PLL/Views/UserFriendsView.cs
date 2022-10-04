using SocialWeb.BLL.Models;

namespace SocialWeb.PLL.Views
{
    /// <summary>
    /// Отображение списка друзей пользователя
    /// </summary>
    public class UserFriendsView
    {
        public bool Show(IEnumerable<Friend> friends)
        {
            Console.WriteLine("Ваши друзья\n");

            if (friends.Count() == 0)
            {
                Console.WriteLine("У вас пока нет друзей");
                Console.ReadKey();
                Console.Clear();
                return false;
            }

            Console.WriteLine($"{"Имя", -15}{"Фамилия", -15}Email\n");

            friends.ToList().ForEach(f =>
            {
                Console.WriteLine($"{f.FirstName, -15}{f.LastName, -15}{f.Email}");
            });

            Console.WriteLine();
            return true;
        }

    }
}
