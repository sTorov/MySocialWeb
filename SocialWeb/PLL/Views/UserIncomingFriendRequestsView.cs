using SocialWeb.BLL.Models;

namespace SocialWeb.PLL.Views
{
    public class UserIncomingFriendRequestsView
    {
        public void Show(User user)
        {
            if(user.InputFriendRequests.Count() == 0)
            {
                Console.WriteLine("Нет входящих заявок на добавление в друзья.");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.WriteLine($"Входящие заявки\n\n{"Имя", -15}{"Фамилия", -15}Email\n");

            user.InputFriendRequests.ToList().ForEach(r =>
            {
                Console.WriteLine($"{r.SenderFirstName, -15}{r.SenderLastName, -15}{r.SenderEmail}");
            });

            Console.ReadKey();
            Console.Clear();
        }
    }
}
