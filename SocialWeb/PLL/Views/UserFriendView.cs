﻿using SocialWeb.BLL.Models;

namespace SocialWeb.PLL.Views
{
    public class UserFriendView
    {
        public void Show(IEnumerable<Friend> friends)
        {
            Console.WriteLine("Ваши друзья\n");

            if (friends.Count() == 0)
            {
                Console.WriteLine("У вас пока нет друзей");
                Console.ReadKey();
                Console.Clear();
                return;
            }

            Console.WriteLine($"{"Имя", -15}{"Фамилия", -15}Email\n");

            friends.ToList().ForEach(f =>
            {
                Console.WriteLine($"{f.FirstName, -15}{f.LastName, -15}{f.Email}");
            });

            Console.ReadKey();
            Console.Clear();
        }

    }
}
