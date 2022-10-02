using SocialWeb.BLL.Exceptions;
using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;
using SocialWeb.PLL.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialWeb.PLL.Views
{
    public class FriendRequestDeletingAllView
    {
        FriendRequestService friendRequestService;
        UserService userService;

        public FriendRequestDeletingAllView(FriendRequestService friendRequestService, UserService userService)
        {
            this.friendRequestService = friendRequestService;
            this.userService = userService;
        }

        public User Show(IEnumerable<FriendRequest> friendRequests, User user)
        {
            if (friendRequests.Count() == 0)
            {
                AlertMessage.Show("Заявки отсутствуют!");
                return user;
            }

            try
            {
                friendRequests.ToList().ForEach(r =>
                {
                    friendRequestService.DeleteRequest(r.Id);
                });

                SuccessMessage.Show("Процесс завершен успешно!");

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
                AlertMessage.Show("Произошла ошибка при отмене заявки!");
                return user;
            }

        }
    }
}
