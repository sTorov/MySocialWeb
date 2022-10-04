using SocialWeb.BLL.Exceptions;
using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    /// <summary>
    /// Отображение процесса добавления друзей по всем запросам на добавление в друзья
    /// </summary>
    public class FriendsAddingAllView
    {
        FriendService friendService;
        UserService userService;

        public FriendsAddingAllView(FriendService friendService, UserService userService)
        {
            this.friendService = friendService;
            this.userService = userService;
        }

        public User Show(User user)
        {
            if(user.InputFriendRequests.Count() == 0)
            {
                AlertMessage.Show("Заявки отсутствуют!");
                return user;
            }

            var friendRequestSendingData = new FriendRequestSendingData();

            try
            {
                user.InputFriendRequests.ToList().ForEach(r =>
                {
                    friendRequestSendingData.SearchEmail = r.Email;
                    friendRequestSendingData.UserId = user.Id;

                    friendService.AddingFriend(friendRequestSendingData);
                });

                SuccessMessage.Show("Все заявки приняты!");

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
