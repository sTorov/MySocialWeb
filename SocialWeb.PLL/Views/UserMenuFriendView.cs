using SocialWeb.BLL.Models;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    public class UserMenuFriendView
    {
        public User Show(User user)
        {
            while(true)
            {
                Console.WriteLine("Просмотреть список друзей (нажмите 1)");
                Console.WriteLine("Запросить дружбу (нажмите 2)");
                Console.WriteLine("Обозреватель заявок (нажмите 3)");
                Console.WriteLine("Назад (нажмите 4)\n");

                if(user.InputFriendRequests.Count() > 0)
                    AttentionMessage.Show($"Входящие заявки на дружбу: {user.InputFriendRequests.Count()}\n");
                if (user.OutputFriendRequests.Count() > 0)
                    AttentionMessage.Show($"Исходящие необработанные заявки на дружбу: {user.OutputFriendRequests.Count()}\n");


                string keyValue = Console.ReadLine();

                Console.Clear();

                if (keyValue == "4")
                    break;

                switch (keyValue)
                {
                    case "1":
                        user = Program.friendMenuView.Show(user);
                        break;
                    case "2":
                        user = Program.friendRequestSendingView.Show(user);
                        break;
                    case "3":
                        user = Program.userMenuFriendRequestView.Show(user);
                        break;
                }

            }

            return user;
        }
    }
}
