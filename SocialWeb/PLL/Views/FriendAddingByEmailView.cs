using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    public class FriendAddingByEmailView
    {
        FriendService friendService;
        UserService userService;

        public FriendAddingByEmailView(FriendService friendService, UserService userService)
        {
            this.friendService = friendService;
            this.userService = userService;
        }

        public User Show(User user)
        {
            var friendRequestData = new FriendRequestData();

            Console.WriteLine("Введите почтовый адрес отправителя для принятия заявки:");
            friendRequestData.FriendEmail = Console.ReadLine();

            friendRequestData.UserId = user.Id;

            try
            {
                friendService.AddingFriend(friendRequestData);

                SuccessMessage.Show("Заявка успешно принята!");

                return userService.FindById(user.Id);
            }
            catch (Exception)
            {
                AlertMessage.Show("Error");
                return user;
            }
        }
    }
}
