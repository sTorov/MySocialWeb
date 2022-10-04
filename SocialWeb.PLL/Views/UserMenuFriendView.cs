using SocialWeb.BLL.Models;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    /// <summary>
    /// Отображение меню друзей для пользователя 
    /// </summary>
    public class UserMenuFriendView
    {
        public User Show(User user)
        {
            while(true)
            {
                Console.WriteLine("Просмотреть список друзей (нажмите 1)");
                Console.WriteLine("Запросить дружбу (нажмите 2)");

                if (user.InputFriendRequests.Count() > 0)
                {
                    Console.Write("Входящие заявки (нажмите 3)   ");
                    AttentionMessage.Show($"Заявки: {user.InputFriendRequests.Count()}\n");
                }
                else
                    Console.WriteLine("Входящие заявки (нажмите 3)");

                if (user.OutputFriendRequests.Count() > 0)
                {
                    Console.Write("Исходящие заявки (нажмите 4)   ");
                    AttentionMessage.Show($"Заявки: {user.OutputFriendRequests.Count()}\n");
                }
                else
                    Console.WriteLine("Исходящие заявки (нажмите 4)");

                Console.WriteLine("Назад (нажмите 5)\n");

                string keyValue = Console.ReadLine();

                Console.Clear();

                if (keyValue == "5")
                    break;

                switch (keyValue)
                {
                    case "1":
                        user = Program.actionMenuFriendsView.Show(user);
                        break;
                    case "2":
                        user = Program.friendRequestSendingView.Show(user);
                        break;
                    case "3":
                        user = Program.actionMenuInputFriendRequestsView.Show(user);
                        break;
                    case "4":
                        user = Program.actionMenuOutputFriendRequestsView.Show(user);
                        break;
                }

            }

            return user;
        }
    }
}
