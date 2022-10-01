using SocialWeb.BLL.Models;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    public class UserOutcomingFriendRequestView
    {
        public bool Show(User user)
        {
            if (user.OutputFriendRequests.Count() == 0)
            {
                AlertMessage.Show("Нет исходящих заявок.");
                return false;
            }

            Console.WriteLine($"Исходящие заявки\n\n{"Имя",-15}{"Фамилия",-15}Email\n");

            user.OutputFriendRequests.ToList().ForEach(r =>
            {
                Console.WriteLine($"{r.SenderFirstName,-15}{r.SenderLastName,-15}{r.SenderEmail}");
            });

            Console.WriteLine();
            return true;
        }

    }
}
