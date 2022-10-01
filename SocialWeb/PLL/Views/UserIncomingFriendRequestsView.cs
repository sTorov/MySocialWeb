using SocialWeb.BLL.Models;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    public class UserIncomingFriendRequestsView
    {
        public bool Show(User user)
        {
            if(user.InputFriendRequests.Count() == 0)
            {
                AlertMessage.Show("Нет входящих заявок.");
                return false;
            }

            Console.WriteLine($"Входящие заявки\n\n{"Имя", -15}{"Фамилия", -15}Email\n");

            user.InputFriendRequests.ToList().ForEach(r =>
            {
                Console.WriteLine($"{r.SenderFirstName, -15}{r.SenderLastName, -15}{r.SenderEmail}");
            });

            Console.WriteLine();
            return true;
        }
    }
}
