using SocialWeb.BLL.Exceptions;
using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    public class FriendRequestSendingView
    {
        FriendRequestService friendRequestService;
        UserService userService;

        public FriendRequestSendingView(FriendRequestService friendRequestService, UserService userService)
        {
            this.friendRequestService = friendRequestService;
            this.userService = userService;
        }

        public User Show(User user)
        {
            var friendRequestData = new FriendRequestData();

            Console.WriteLine("Для отправки заявки введите почтовый адрес пользователя:");
            friendRequestData.FriendEmail = Console.ReadLine();

            friendRequestData.UserId = user.Id;

            try
            {
                friendRequestService.SendRequest(friendRequestData);

                SuccessMessage.Show("Заявка отправлена!");

                return userService.FindById(user.Id);
            }
            catch(UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
                return user;
            }
            catch(ArgumentOutOfRangeException)
            {
                AlertMessage.Show("Вы уже добавили данного пользователя в друзья, либо заявка уже отправлена!");
                return user;
            }
            catch (Exception)
            {
                AlertMessage.Show("Поизошла ошибка при отправке заявки!");
                return user;
            }
        }
    }
}
