using SocialWeb.BLL.Exceptions;
using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    /// <summary>
    /// Отображение процесса отклонения запроса на добавление в друзья по почтовому адресу отправителя запроса
    /// </summary>
    public class FriendRequestRejectingByEmailView
    {
        FriendRequestService friendRequestService;
        UserService userService;

        public FriendRequestRejectingByEmailView(FriendRequestService friendRequestService, UserService userService)
        {
            this.friendRequestService = friendRequestService;
            this.userService = userService;
        }

        public User Show(User user)
        {
            var friendRequestSendingData = new FriendRequestSendingData();

            Console.WriteLine("Введите почтовый адрес:");
            friendRequestSendingData.SearchEmail = Console.ReadLine();

            friendRequestSendingData.UserId = user.Id;

            try
            {
                var findRequest = friendRequestService.FindInputRequest(friendRequestSendingData);
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
