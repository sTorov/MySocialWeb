using SocialWeb.BLL.Models;

namespace SocialWeb.PLL.Views
{
    public class UserMenuFriendView
    {
        public User Show(User user)
        {
            while(true)
            {
                Console.WriteLine("Просмотреть список друзей (нажмите 1)");
                Console.WriteLine("Удалить контакт из друзей (нажмите 2)");
                Console.WriteLine("Запросить дружбу (нажмите 3)");
                Console.WriteLine("Выйти из меню друзей (нажмите 4)");

                string keyValue = Console.ReadLine();

                Console.Clear();

                if (keyValue == "4")
                    break;

                switch (keyValue)
                {
                    case "1":
                        Program.userFriendView.Show(user.Friends);
                        break;
                    case "2":
                        user = Program.friendDeleteView.Show(user);
                        break;
                    case "3":
                        user = Program.friendRequestView.Show(user);
                        break;
                }

            }

            return user;
        }
    }
}
