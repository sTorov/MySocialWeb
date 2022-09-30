using SocialWeb.BLL.Models;

namespace SocialWeb.PLL.Views
{
    public class UserOutcomingFriendRequestView
    {
        public void Show(User user)
        {
            if (user.OutputFriendRequests.Count() == 0)
            {
                Console.WriteLine("Нет исходящих заявок на добавление в друзья.");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.WriteLine($"Исходящие заявки\n\n{"Имя",-15}{"Фамилия",-15}Email\n");

            user.OutputFriendRequests.ToList().ForEach(r =>
            {
                Console.WriteLine($"{r.SenderFirstName,-15}{r.SenderLastName,-15}{r.SenderEmail}");
            });

            Console.ReadKey();
            Console.Clear();
        }

    }
}
