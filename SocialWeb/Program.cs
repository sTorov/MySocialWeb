using SocialWeb.BLL.Services;
using SocialWeb.PLL.Views;
using System.Text;

namespace SocialWeb
{
    class Program
    {
        static UserService userService;
        static MessageService messageService;
        static FriendService friendService;
        static FriendRequestService friendRequestService;
        public static MainView mainView;
        public static RegistrationView registrationView;
        public static AutheticationView autheticationView;
        public static UserMenuView userMenuView;
        public static UserInfoView userInfoView;
        public static UserDataUpdateView userDataUpdateView;
        public static MessageSendingView messageSendingView;
        public static UserIncomingMessageView userIncomingMessageView;
        public static UserOutcomingMessageView userOutcomingMessageView;

        public static FriendRequestSendingView friendRequestSendingView;
        public static UserFriendView userFriendView;
        public static UserMenuFriendView userMenuFriendView;
        public static FriendDeleteView friendDeleteView;
        public static UserMenuFriendRequestView userMenuFriendRequestView;
        public static UserIncomingFriendRequestsView userIncomingFriendRequestsView;
        public static UserOutcomingFriendRequestView userOutcomingFriendRequestView;
        public static FriendAddingMenuView friendAddingMenuView;
        public static FriendAddingByEmailView friendAddingByEmailView;
        public static FriendAddingAllView friendAddingAllView;
        public static FriendRequestDeletingMenuView friendRequestDeletingMenuView;
        public static FriendRequestDeletingAllView friendRequestDeletingAllView;
        public static FriendRequestDeletingByEmailView friendRequestDeletingByEmailView;

        private static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.Unicode;

            userService = new UserService();
            messageService = new MessageService();
            friendService = new FriendService();
            friendRequestService = new FriendRequestService();

            mainView = new MainView();
            registrationView = new RegistrationView(userService);
            autheticationView = new AutheticationView(userService);
            userMenuView = new UserMenuView(userService);
            userInfoView = new UserInfoView();
            userDataUpdateView = new UserDataUpdateView(userService);
            messageSendingView = new MessageSendingView(userService, messageService);
            userIncomingMessageView = new UserIncomingMessageView();
            userOutcomingMessageView = new UserOutcomingMessageView();

            friendRequestSendingView = new FriendRequestSendingView(friendRequestService, userService);
            userFriendView = new UserFriendView();
            userMenuFriendView = new UserMenuFriendView();
            friendDeleteView = new FriendDeleteView(friendService, userService);
            userMenuFriendRequestView = new UserMenuFriendRequestView();
            userIncomingFriendRequestsView = new UserIncomingFriendRequestsView();
            userOutcomingFriendRequestView = new UserOutcomingFriendRequestView();
            friendAddingMenuView = new FriendAddingMenuView();
            friendAddingAllView = new FriendAddingAllView(friendService, userService);
            friendAddingByEmailView = new FriendAddingByEmailView(friendService, userService);
            friendRequestDeletingMenuView = new FriendRequestDeletingMenuView();
            friendRequestDeletingAllView = new FriendRequestDeletingAllView(friendRequestService, userService);
            friendRequestDeletingByEmailView = new FriendRequestDeletingByEmailView(friendRequestService, userService);

            while (true)
            {
                mainView.Show();
            }
        }
    }
}