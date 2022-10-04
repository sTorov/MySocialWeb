using SocialWeb.BLL.Interfaces;

namespace SocialWeb.BLL.Models
{
    /// <summary>
    /// Объект пользователя
    /// </summary>
    public class User : ICloneable<User>
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Photo { get; set; }
        public string FavoriteMovie { get; set; }
        public string FavoriteBook { get; set; }

        public IEnumerable<Message> IncomingMessages { get; }
        public IEnumerable<Message> OutgoingMessages { get; }

        public IEnumerable<FriendRequest> InputFriendRequests { get; }
        public IEnumerable<FriendRequest> OutputFriendRequests { get; }


        public IEnumerable<Friend> Friends { get; }

        public User(
            int id,
            string firstname,
            string lastname,
            string password,
            string email,
            string photo,
            string favoriteMovie,
            string favoriteBook,
            IEnumerable<Message> incomingMessages,
            IEnumerable<Message> outgoingMessages,
            IEnumerable<Friend> friends,
            IEnumerable<FriendRequest> inputFriendRequests,
            IEnumerable<FriendRequest> outputFriendRequest
            )
        {
            Id = id;
            FirstName = firstname;
            LastName = lastname;
            Password = password;
            Email = email;
            Photo = photo;
            FavoriteMovie = favoriteMovie;
            FavoriteBook = favoriteBook;
            IncomingMessages = incomingMessages;
            OutgoingMessages = outgoingMessages;
            Friends = friends;
            InputFriendRequests = inputFriendRequests;
            OutputFriendRequests = outputFriendRequest;
        }

        public override bool Equals(object? obj)
        {
            if(obj is User user)
            {
                if(Id != user.Id) return false;
                if(FirstName != user.FirstName) return false;
                if(LastName != user.LastName) return false;
                if(Password != user.Password) return false;
                if(Email != user.Email) return false;
                if(Photo != user.Photo) return false;
                if(FavoriteMovie != user.FavoriteMovie) return false;
                if(FavoriteBook != user.FavoriteBook) return false;
                if(!IncomingMessages.SequenceEqual(user.IncomingMessages)) return false;
                if(!OutgoingMessages.SequenceEqual(user.OutgoingMessages)) return false;
                if(!Friends.SequenceEqual(user.Friends)) return false;
                if(!InputFriendRequests.SequenceEqual(user.InputFriendRequests)) return false;
                if(!OutputFriendRequests.SequenceEqual(user.OutputFriendRequests)) return false;
                return true;
            }

            return false;
        }

        public User Clone()
        {
            return new User(Id, FirstName, LastName, Password, Email, Photo, FavoriteMovie, FavoriteBook,
                IncomingMessages, OutgoingMessages, Friends, InputFriendRequests, OutputFriendRequests);
        }
    }
}
