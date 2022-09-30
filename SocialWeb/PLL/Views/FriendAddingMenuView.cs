using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;

namespace SocialWeb.PLL.Views
{
    public class FriendAddingMenuView
    {
        public User Show(User user)
        {
            while (true)
            {
                Console.WriteLine("Принять все (нажмите 1)");
                Console.WriteLine("Принять заявку от пользователя, указав email (нажмите 2)");
                Console.WriteLine("Назад (нажмите 3)");

                string keyValue = Console.ReadLine();

                Console.Clear();

                if (keyValue == "3")
                    return user;

                switch (keyValue)
                {
                    case "1":
                        user = Program.friendAddingAllView.Show(user);
                        break;
                    case "2":
                        user = Program.friendAddingByEmailView.Show(user);
                        break;
                }
            }        
        }
    }
}
