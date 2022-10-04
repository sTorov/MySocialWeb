using SocialWeb.BLL.Exceptions;
using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    /// <summary>
    /// Отображение процесса добавления друга по его почтовому адресу
    /// </summary>
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
            var friendRequestSendingData = new FriendRequestSendingData();

            Console.WriteLine("Введите почтовый адрес:");
            friendRequestSendingData.SearchEmail = Console.ReadLine();

            friendRequestSendingData.UserId = user.Id;

            try
            {
                friendService.AddingFriend(friendRequestSendingData);

                SuccessMessage.Show("Заявка успешно принята!");

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
                AlertMessage.Show("Произошла ошибка при добавлении!");
                return user;
            }
        }
    }
}
