using SocialWeb.BLL.Exceptions;
using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    public class FriendRequestDeletingByEmailView
    {
        FriendRequestService friendRequestService;
        UserService userService;

        public FriendRequestDeletingByEmailView(FriendRequestService friendRequestService, UserService userService)
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
                var findRequest = friendRequestService.FindInputRequest(friendRequestData);
                friendRequestService.DeleteRequest(findRequest.Id);

                SuccessMessage.Show("Заявка успешно отклонена!");

                return userService.FindById(user.Id);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
                return user;
            }
            catch (FriendRequestNotFoundException)
            {
                AlertMessage.Show("Заявка не найдена!");
                return user;
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при отклонении заявки!");
                return user;
            }
        }

    }
}
