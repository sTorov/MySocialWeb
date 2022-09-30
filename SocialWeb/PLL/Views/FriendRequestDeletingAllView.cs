using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;
using SocialWeb.PLL.Helpers;

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

        public User Show(User user)
        {
            if (user.InputFriendRequests.Count() == 0)
            {
                Console.WriteLine("Заявки отсутствуют!");
                Console.ReadKey();
                Console.Clear();
                return user;
            }

            try
            {
                user.InputFriendRequests.ToList().ForEach(r =>
                {
                    friendRequestService.DeleteRequest(r.Id);
                });

                SuccessMessage.Show("Все заявки отклонены!");

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
