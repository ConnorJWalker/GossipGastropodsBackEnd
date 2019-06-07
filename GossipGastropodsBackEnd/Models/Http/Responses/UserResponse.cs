using System;
using GossipGastropodsBackEnd.Entities;

namespace GossipGastropodsBackEnd.Models.Http.Responses
{
    public class UserResponse
    {
        public Guid Guid { get; set; }
        public UsersNames Names { get; set; }
        public string ProfileURL { get; set; }
        public string ProfilePicture { get; set; }

        public UserResponse(User user)
        {
            Guid = user.GUID;
            Names = new UsersNames(user);
            ProfileURL = "Todo";
            ProfilePicture = user.ProfilePicture;
        }

        public UserResponse(CurrentUser user)
        {
            Guid = user.GUID;
            Names = new UsersNames(user);
            ProfileURL = "Todo";
            ProfilePicture = user.ProfilePicture;
        }

        public class UsersNames
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string FullName { get; set; }

            public UsersNames(User user)
            {
                FirstName = user.FirstName;
                LastName = user.LastName;
                FullName = FirstName + " " + LastName;
            }

            public UsersNames(CurrentUser user)
            {
                FirstName = user.FirstName;
                LastName = user.LastName;
                FullName = FirstName + " " + LastName;
            }
        }
    }
}