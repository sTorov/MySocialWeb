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
                Console.WriteLine("Добавить в друзья (нажмите 1)");
                Console.WriteLine("Отклонить заявку (нажмите 2)");    
                Console.WriteLine("Отменить исходящую заявку (нажмите 3)");
                Console.WriteLine("Назад (нажмите 4)\n");

                if (user.InputFriendRequests.Count() > 0)
                    AttentionMessage.Show($"Входящие заявки: {user.InputFriendRequests.Count()}\n");
                if (user.OutputFriendRequests.Count() > 0)
                    AttentionMessage.Show($"Исходящие заявки: {user.OutputFriendRequests.Count()}\n");

                string keyValue = Console.ReadLine();

                Console.Clear();

                if(keyValue == "4")
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
                        user = Program.friendRequestAbortMenuView.Show(user);
                        break;
                }
            }
        }
    }
}
