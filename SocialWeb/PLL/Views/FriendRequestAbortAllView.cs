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
    public class FriendRequestAbortAllView
    {
        FriendRequestService friendRequestService;
        UserService userService;

        public FriendRequestAbortAllView(FriendRequestService friendRequestService, UserService userService)
        {
            this.friendRequestService = friendRequestService;
            this.userService = userService;
        }

        public User Show(User user)
        {
            if (user.OutputFriendRequests.Count() == 0)
            {
                AlertMessage.Show("Заявки отсутствуют!");
                return user;
            }

            try
            {
                user.OutputFriendRequests.ToList().ForEach(r =>
                {
                    friendRequestService.DeleteRequest(r.Id);
                });

                SuccessMessage.Show("Все заявки отменены!");

                return userService.FindById(user.Id);
            }
            catch (Exception)
            {
                AlertMessage.Show("Error");
                return user;
            }

        }
    }
}
