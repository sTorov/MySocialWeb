using SocialWeb.BLL.Exceptions;
using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    /// <summary>
    /// Отображение процесса отклонения всех входящих запросов на дружбу
    /// </summary>
    public class FriendRequestsRejectingAllView
    {
        FriendRequestService friendRequestService;
        UserService userService;

        public FriendRequestsRejectingAllView(FriendRequestService friendRequestService, UserService userService)
        {
            this.friendRequestService = friendRequestService;
            this.userService = userService;
        }

        public User Show(IEnumerable<FriendRequest> friendRequests, int userId)
        {
            if (friendRequests.Count() == 0)
            {
                AlertMessage.Show("Заявки отсутствуют!");
                return userService.FindById(userId);
            }

            try
            {
                friendRequests.ToList().ForEach(r =>
                {
                    friendRequestService.DeleteRequest(r.Id);
                });

                SuccessMessage.Show("Процесс завершен успешно!");

                return userService.FindById(userId);
            }
            catch (UserNotFoundException)
            {
                AlertMessage.Show("Пользователь не найден!");
                return userService.FindById(userId);
            }
            catch (FriendRequestNotFoundException)
            {
                AlertMessage.Show("Заявка не найдена!");
                return userService.FindById(userId);
            }
            catch (Exception)
            {
                AlertMessage.Show("Произошла ошибка при отмене заявки!");
                return userService.FindById(userId);
            }

        }
    }
}
