using SocialWeb.BLL.Models;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    public class UserMenuFriendRequestView
    {        
        public User Show(User user)
        {      
            while(true)
            {
                Console.WriteLine("Для добавления или удаления необходимо указать почтовый адрес отправителя зяавки.");
                Console.WriteLine("Узнать его можно в списке заявок.\n");

                Console.WriteLine("Добавить в друзья (нажмите 1)");
                Console.WriteLine("Отклонить заявку (нажмите 2)");               

                if(user.InputFriendRequests.Count() > 0)
                {
                    Console.Write("Список входящих заявок (нажмите 3)    ");
                    AttentionMessage.Show($"Заявок: {user.InputFriendRequests.Count()}\n");
                }
                else
                    Console.WriteLine("Список входящих заявок (нажмите 3)");

                if (user.OutputFriendRequests.Count() > 0)
                {
                    Console.Write("Список исходящих заявок (нажмите 4)    ");
                    AttentionMessage.Show($"Заявок: {user.OutputFriendRequests.Count()}\n");
                }
                else
                    Console.WriteLine("Список исходящих заявок (нажмите 4)");

                Console.WriteLine("Выйти из обозревателя заявок (нажмите 5)");

                string keyValue = Console.ReadLine();

                Console.Clear();

                if(keyValue == "5")
                    return user;

                switch (keyValue)
                {
                    case "1":
                        user = Program.friendAddingMenuView.Show(user);
                        break;
                    case "2":
                        user = Program.friendRequestDeletingMenuView.Show(user);
                        break;
                    case "3":
                        Program.userIncomingFriendRequestsView.Show(user);
                        break;
                    case "4":
                        Program.userOutcomingFriendRequestView.Show(user);
                        break;
                }
            }
        }
    }
}
