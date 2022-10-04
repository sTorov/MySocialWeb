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
        public static UserFriendsView userFriendsView;
        public static ActionMenuFriendsView actionMenuFriendsView;
        public static FriendDeletingView friendDeletingView;

        public static UserFriendRequestsView userFriendRequestsView;
        public static FriendRequestSendingView friendRequestSendingView;

        public static ActionMenuInputFriendRequestsView actionMenuInputFriendRequestsView;
        public static FriendAddingByEmailView friendAddingByEmailView;
        public static FriendsAddingAllView friendsAddingAllView;
        public static FriendRequestsRejectingAllView friendRequestsRejectingAllView;
        public static FriendRequestRejectingByEmailView friendRequestRejectingByEmailView;

        public static ActionMenuOutputFriendRequestsView actionMenuOutputFriendRequestsView;
        public static FriendRequestAbortingByEmailView friendRequestAbortingByEmailView;

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
            userFriendsView = new UserFriendsView();
            actionMenuFriendsView = new ActionMenuFriendsView();
            friendDeletingView = new FriendDeletingView(friendService, userService);
            
            userFriendRequestsView = new UserFriendRequestsView();
            friendRequestSendingView = new FriendRequestSendingView(friendRequestService, userService);

            actionMenuInputFriendRequestsView = new ActionMenuInputFriendRequestsView();
            friendsAddingAllView = new FriendsAddingAllView(friendService, userService);
            friendAddingByEmailView = new FriendAddingByEmailView(friendService, userService);
            friendRequestsRejectingAllView = new FriendRequestsRejectingAllView(friendRequestService, userService);
            friendRequestRejectingByEmailView = new FriendRequestRejectingByEmailView(friendRequestService, userService);

            actionMenuOutputFriendRequestsView = new ActionMenuOutputFriendRequestsView();
            friendRequestAbortingByEmailView = new FriendRequestAbortingByEmailView(friendRequestService, userService);

            while (true)
            {
                mainView.Show();
            }
        }
    }
}