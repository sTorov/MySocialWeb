using SocialWeb.BLL.Exceptions;
using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    public class FriendRequestView
    {
        FriendService friendService;
        UserService userService;

        public FriendRequestView(FriendService friendService, UserService userService)
        {
            this.friendService = friendService;
            this.userService = userService;
        }

        public User Show(User user)
        {
            var friendRequestData = new FriendRequestData();

            Console.WriteLine("Введите почтовый адрес вашего нового друга:");
            friendRequestData.FriendEmail = Console.ReadLine();

            friendRequestData.UserId = user.Id;

            try
            {
                friendService.AddingFriend(friendRequestData);

                SuccessMessage.Show("Вы добавили нового друга!");

                return userService.FindById(user.Id);
            }
            catch(ArgumentNullException)
            {
                AlertMessage.Show("Введите корректный почтовый адрес!");
                return user;
            }
            catch(UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
                return user;
            }
            catch(ArgumentOutOfRangeException)
            {
                AlertMessage.Show("Вы уже добавили данного пользователя в друзья!");
                return user;
            }
            catch (Exception)
            {
                AlertMessage.Show("Поизошла ошиька при добавлении нового друга!");
                return user;
            }
        }
    }
}
