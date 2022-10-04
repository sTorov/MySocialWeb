using SocialWeb.BLL.Exceptions;
using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    /// <summary>
    /// Отображение процесса отправки запроса на добавление в друзья
    /// </summary>
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
            var friendRequestSendingData = new FriendRequestSendingData();

            Console.WriteLine("Для отправки заявки введите почтовый адрес пользователя:");
            friendRequestSendingData.SearchEmail = Console.ReadLine();

            friendRequestSendingData.UserId = user.Id;

            try
            {
                friendRequestService.SendRequest(friendRequestSendingData);

                SuccessMessage.Show("Заявка отправлена!");

                return userService.FindById(user.Id);
            }
            catch(UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
                return user;
            }
            catch (FriendFoundException)
            {
                AlertMessage.Show("Пользователь уже является вашим другом!");
                return user;
            }
            catch (ArgumentNullException)
            {
                AlertMessage.Show("Невозможно отправить заявку самому себе!");
                return user;
            }
            catch (ArgumentOutOfRangeException)
            {
                AlertMessage.Show("Заявка уже отправлена!");
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
