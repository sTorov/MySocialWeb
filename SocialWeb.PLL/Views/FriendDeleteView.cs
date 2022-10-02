using SocialWeb.BLL.Exceptions;
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
            FriendRequestSendingData friendRequestSendingData = new FriendRequestSendingData(); 

            Console.WriteLine("Введите почтовый адрес:");
            friendRequestSendingData.RecipientEmail = Console.ReadLine();

            friendRequestSendingData.UserId = user.Id;

            try
            {
                friendService.DeleteFriend(friendRequestSendingData);
                
                SuccessMessage.Show("Удаление прошло успешно!");

                return userService.FindById(user.Id);
            }
            catch(UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
                return user;
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при удалении!");
                return user;
            }
        }
    }
}
