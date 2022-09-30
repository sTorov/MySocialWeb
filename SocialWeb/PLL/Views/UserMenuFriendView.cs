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
                Console.WriteLine("Удалить контакт из друзей (нажмите 2)");
                Console.WriteLine("Запросить дружбу (нажмите 3)");
                Console.WriteLine("Обозреватель заявок (нажмите 4)");
                Console.WriteLine("Выйти из меню друзей (нажмите 5)\n");

                if(user.InputFriendRequests.Count() > 0)
                    AttentionMessage.Show($"Входящие заявки на дружбу: {user.InputFriendRequests.Count()}\n");
                if (user.OutputFriendRequests.Count() > 0)
                    AttentionMessage.Show($"Исходящие необработанные заявки на дружбу: {user.OutputFriendRequests.Count()}\n");


                string keyValue = Console.ReadLine();

                Console.Clear();

                if (keyValue == "5")
                    break;

                switch (keyValue)
                {
                    case "1":
                        Program.userFriendView.Show(user.Friends);
                        break;
                    case "2":
                        user = Program.friendDeleteView.Show(user);
                        break;
                    case "3":
                        user = Program.friendRequestSendingView.Show(user);
                        break;
                    case "4":
                        user = Program.userMenuFriendRequestView.Show(user);
                        break;
                }

            }

            return user;
        }
    }
}
