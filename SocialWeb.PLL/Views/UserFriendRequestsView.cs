using SocialWeb.BLL.Models;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    /// <summary>
    /// Отображение списков запросов на добавление в друзья
    /// </summary>
    public class UserFriendRequestsView
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
                Console.WriteLine($"{r.FirstName,-15}{r.LastName,-15}{r.Email}");
            });

            Console.WriteLine();
            return true;
        }

    }
}
