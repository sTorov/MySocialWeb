using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;

namespace SocialWeb.PLL.Views
{
    public class FriendMenuView
    {
        public User Show(User user)
        {
            while (true)
            {
                if (!Program.userFriendView.Show(user.Friends))
                    return user;

                Console.WriteLine("Написать сообщение (нажмите 1)");
                Console.WriteLine("Удалить контакт (нажмите 2)");
                Console.WriteLine("Назад (нажмите 3)\n");

                string keyValue = Console.ReadLine();

                if (keyValue == "3")
                {
                    Console.Clear();
                    return user;
                }

                switch (keyValue)
                {
                    case "1":
                        user = Program.messageSendingView.Show(user);
                        break;
                    case "2":
                        user = Program.friendDeleteView.Show(user);
                        break;
                }
            }
        }
    }
}
