using SocialWeb.BLL.Models;

namespace SocialWeb.PLL.Views
{
    public class FriendAddingMenuView
    {
        public User Show(User user)
        {
            while (true)
            {
                Console.WriteLine("Входящие заявки\n");

                if(!Program.userFriendRequestView.Show(user.InputFriendRequests))
                    return user;

                Console.WriteLine("Принять все (нажмите 1)");
                Console.WriteLine("Принять заявку, указав email (нажмите 2)");
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
                        user = Program.friendAddingAllView.Show(user);
                        break;
                    case "2":
                        user = Program.friendAddingByEmailView.Show(user);
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }        
        }
    }
}
