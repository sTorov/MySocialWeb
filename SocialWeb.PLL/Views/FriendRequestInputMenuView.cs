using SocialWeb.BLL.Models;

namespace SocialWeb.PLL.Views
{
    public class FriendRequestInputMenuView
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
                Console.WriteLine("Отклонить все (нажмите 3)");
                Console.WriteLine("Отклонить заявку, указав email (нажмите 4)");
                Console.WriteLine("Назад (нажмите 5)\n");

                string keyValue = Console.ReadLine();

                if (keyValue == "5")
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
                    case "3":
                        user = Program.friendRequestDeletingAllView.Show(user.InputFriendRequests, user);
                        break;
                    case "4":
                        user = Program.friendRequestDeletingByEmailView.Show(user);
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }        
        }
    }
}
