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

                if (user.InputFriendRequests.Count() > 0)
                {
                    Console.Write("Входящие заявки (нажмите 1)   ");
                    AttentionMessage.Show($"Заявки: {user.InputFriendRequests.Count()}\n");
                }
                else
                    Console.WriteLine("Входящие заявки (нажмите 1)");
                
                if (user.OutputFriendRequests.Count() > 0)
                {
                    Console.Write("Исходящие заявки (нажмите 2)   ");
                    AttentionMessage.Show($"Заявки: {user.OutputFriendRequests.Count()}\n");
                }
                else
                    Console.WriteLine("Исходящие заявки (нажмите 2)");    
                
                Console.WriteLine("Назад (нажмите 3)\n");

                string keyValue = Console.ReadLine();

                Console.Clear();

                if(keyValue == "3")
                    return user;

                switch (keyValue)
                {
                    case "1":
                        user = Program.friendRequestInputMenuView.Show(user);
                        break;
                    case "2":
                        user = Program.friendRequestAbortMenuView.Show(user);
                        break;
                }
            }
        }
    }
}
