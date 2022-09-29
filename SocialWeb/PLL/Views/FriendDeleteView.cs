using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    public class FriendDeleteView
    {
        FriendService friendService;
        UserService userService;

        public FriendDeleteView(FriendService friendService, UserService userService)
        {
            this.friendService = friendService;
            this.userService = userService;
        }

        public User Show(User user)
        {
            Console.WriteLine("Введите почтовый адрес удаляемого контакта:");
            string email = Console.ReadLine();

            var deletingFriend = user.Friends.FirstOrDefault(f => f.Email == email);

            if (deletingFriend != null)
            {
                friendService.DeleteFriendById(deletingFriend.Id);

                SuccessMessage.Show("Удаление прошло успешно!");

                user = userService.FindById(user.Id);
            }
            else
                AlertMessage.Show("У вас не такого контакта в друзьях!");

            return user;
        }
    }
}
