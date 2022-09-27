using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWeb.PLL.Views
{
    public class UserMenuView
    {
        UserService userService;

        public UserMenuView(UserService userService)
        {
            this.userService = userService;
        }

        public void Show(User user)
        {
            while (true)
            {
                Console.WriteLine($"Входящие сообщения: {user.IncomingMessages.Count()}");
                Console.WriteLine($"Исходящие сообщения: {user.OutgoingMessages.Count()}");

                Console.WriteLine("Просмотреть информацию о моём профиле (нажмите 1)");
                Console.WriteLine("Редактировать мой профиль (нажмите 2)");
                Console.WriteLine("Добавить в друзья (нажмите 3)");
                Console.WriteLine("Написать сообщение (нажмите 4)");
                Console.WriteLine("Просмотр входящих сообщений (нажмите 5)");
                Console.WriteLine("Просмотр исходящих сообщений (нажмите 6)");
                Console.WriteLine("Выйти из профиля (нажмите 7)");

                string keyValue = Console.ReadLine();

                Console.Clear();

                if (keyValue == "7") 
                    break;

                switch (keyValue)
                {
                    case "1":
                        Program.userInfoView.Show(user);
                        break;
                    case "2":
                        Program.userDataUpdateView.Show(user);
                        break;
                    case "4":
                        user = Program.messageSendingView.Show(user);
                        break;
                    case "5":
                        Program.userIncomingMessageView.Show(user.IncomingMessages);
                        break;
                    case "6":
                        Program.userOutcomingMessageView.Show(user.OutgoingMessages);
                        break;
                }
            }
        }
    }
}
