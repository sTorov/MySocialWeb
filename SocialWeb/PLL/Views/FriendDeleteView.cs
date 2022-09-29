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
            FriendRequestData friendRequestData = new FriendRequestData(); 

            Console.WriteLine("Введите почтовый адрес удаляемого контакта:");
            friendRequestData.FriendEmail = Console.ReadLine();

            friendRequestData.UserId = user.Id;

            try
            {
                friendService.DeleteFriend(friendRequestData);
                
                SuccessMessage.Show("Удаление прошло успешно!");

                return userService.FindById(user.Id);
            }
            catch(ArgumentNullException)
            {
                AlertMessage.Show("Введите верное значение!");
                return user;
            }
            catch(UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
                return user;
            }
            catch(EntityNotFoundException)
            {
                AlertMessage.Show("Данный пользователь не является вашим другом!");
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
