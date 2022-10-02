using SocialWeb.BLL.Models;

namespace SocialWeb.PLL.Views
{
    public class FriendRequestAbortMenuView
    {
        public User Show(User user)
        {
            while (true)
            {
                Console.WriteLine("Исходящие заявки\n");

                if (!Program.userFriendRequestView.Show(user.OutputFriendRequests))
                    return user;

                Console.WriteLine("Отменить все (нажмите 1)");
                Console.WriteLine("Отменить заявку, указав email (нажмите 2)");
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
                        user = Program.friendRequestDeletingAllView.Show(user.OutputFriendRequests, user);
                        break;
                    case "2":
                        user = Program.friendRequestAbortByEmailView.Show(user);
                        break;
                    default:
                        Console.Clear();
                        break;
                }
            }
        }
    }
}
