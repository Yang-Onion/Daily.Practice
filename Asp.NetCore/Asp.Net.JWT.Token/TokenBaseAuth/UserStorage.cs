using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.Net.JWT.Token.TokenBaseAuth
{
    public static class UserStorage
    {
        public static List<User> Users { get; set; } = new List<User> {
        new User {ID=Guid.NewGuid(),Username="user1",Password = "user1psd" },
        new User {ID=Guid.NewGuid(),Username="user2",Password = "user2psd" },
        new User {ID=Guid.NewGuid(),Username="user3",Password = "user3psd" }
    };
    }
}
