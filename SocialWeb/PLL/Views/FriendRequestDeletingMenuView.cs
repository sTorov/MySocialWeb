using SocialWeb.BLL.Models;

namespace SocialWeb.PLL.Views
{
    public class FriendRequestDeletingMenuView
    {
        public User Show(User user)
        {
            while (true)
            {
                Console.WriteLine("Отклонить все (нажмите 1)");
                Console.WriteLine("Отклонить заявку от пользователя, указав email (нажмите 2)");
                Console.WriteLine("Назад (нажмите 3)");

                string keyValue = Console.ReadLine();

                Console.Clear();

                if (keyValue == "3")
                    return user;

                switch (keyValue)
                {
                    case "1":
                        user = Program.friendRequestDeletingAllView.Show(user);
                        break;
                    case "2":
                        user = Program.friendRequestDeletingByEmailView.Show(user);
                        break;
                }

            }
        }
    }
}
