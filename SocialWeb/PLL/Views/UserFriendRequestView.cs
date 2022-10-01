using SocialWeb.BLL.Models;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    public class UserFriendRequestView
    {
        public bool Show(IEnumerable<FriendRequest> friendRequests)
        {
            if (friendRequests.Count() == 0)
            {
                AlertMessage.Show("Заявки отсутствуют.");
                return false;
            }

            Console.WriteLine($"{"Имя",-15}{"Фамилия",-15}Email\n");

            friendRequests.ToList().ForEach(r =>
            {
                Console.WriteLine($"{r.SenderFirstName,-15}{r.SenderLastName,-15}{r.SenderEmail}");
            });

            Console.WriteLine();
            return true;
        }

    }
}
