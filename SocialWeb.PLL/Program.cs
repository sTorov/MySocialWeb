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

        public static UserMenuFriendView userMenuFriendView;
        public static FriendMenuView friendMenuView;
        public static UserFriendView userFriendView;
        public static FriendDeleteView friendDeleteView;

        public static UserMenuFriendRequestView userMenuFriendRequestView;
        public static FriendRequestSendingView friendRequestSendingView;
        public static UserFriendRequestView userFriendRequestView;

        public static FriendRequestInputMenuView friendRequestInputMenuView;
        public static FriendAddingByEmailView friendAddingByEmailView;
        public static FriendAddingAllView friendAddingAllView;
        public static FriendRequestDeletingAllView friendRequestDeletingAllView;
        public static FriendRequestDeletingByEmailView friendRequestDeletingByEmailView;

        public static FriendRequestAbortMenuView friendRequestAbortMenuView;
        public static FriendRequestAbortByEmailView friendRequestAbortByEmailView;

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
            
            userMenuFriendView = new UserMenuFriendView();
            friendMenuView = new FriendMenuView();
            userFriendView = new UserFriendView();
            friendDeleteView = new FriendDeleteView(friendService, userService);
            
            userMenuFriendRequestView = new UserMenuFriendRequestView();
            userFriendRequestView = new UserFriendRequestView();
            friendRequestSendingView = new FriendRequestSendingView(friendRequestService, userService);

            friendRequestInputMenuView = new FriendRequestInputMenuView();
            friendAddingAllView = new FriendAddingAllView(friendService, userService);
            friendAddingByEmailView = new FriendAddingByEmailView(friendService, userService);
            friendRequestDeletingAllView = new FriendRequestDeletingAllView(friendRequestService, userService);
            friendRequestDeletingByEmailView = new FriendRequestDeletingByEmailView(friendRequestService, userService);

            friendRequestAbortMenuView = new FriendRequestAbortMenuView();
            friendRequestAbortByEmailView = new FriendRequestAbortByEmailView(friendRequestService, userService);

            while (true)
            {
                mainView.Show();
            }
        }
    }
}