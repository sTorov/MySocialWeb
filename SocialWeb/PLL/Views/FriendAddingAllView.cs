using SocialWeb.BLL.Models;
using SocialWeb.BLL.Services;
using SocialWeb.PLL.Helpers;

namespace SocialWeb.PLL.Views
{
    public class FriendAddingAllView
    {
        FriendService friendService;
        UserService userService;

        public FriendAddingAllView(FriendService friendService, UserService userService)
        {
            this.friendService = friendService;
            this.userService = userService;
        }

        public User Show(User user)
        {
            if(user.InputFriendRequests.Count() == 0)
            {
                Console.WriteLine("Заявки отсутствуют!");
                Console.ReadKey();
                Console.Clear();
                return user;
            }

            var friendRequestData = new FriendRequestData();

            try
            {
                user.InputFriendRequests.ToList().ForEach(r =>
                {
                    friendRequestData.FriendEmail = r.SenderEmail;
                    friendRequestData.UserId = user.Id;

                    friendService.AddingFriend(friendRequestData);
                });

                SuccessMessage.Show("Все заявки приняты!");

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
