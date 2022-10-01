using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    public class FriendRequestAbortByEmailView
    {
        FriendRequestService friendRequestService;
        UserService userService;

        public FriendRequestAbortByEmailView(FriendRequestService friendRequestService, UserService userService)
        {
            this.friendRequestService = friendRequestService;
            this.userService = userService;
        }

        public User Show(User user)
        {
            var friendRequestData = new FriendRequestData();

            Console.WriteLine("Введите почтовый адрес:");
            friendRequestData.FriendEmail = Console.ReadLine();

            friendRequestData.UserId = user.Id;

            try
            {
                var findRequest = friendRequestService.FindOutputRequest(friendRequestData);
                friendRequestService.DeleteRequest(findRequest.Id);

                SuccessMessage.Show("Заявка успешно отменена!");

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
