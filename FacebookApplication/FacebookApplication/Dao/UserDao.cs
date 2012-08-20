using Facebook;
using FacebookApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookApplication.Dao
{
    public class UserDao : IUserDao
    {
        private FacebookClient client;

        public UserDao(string token)
        {
            client = new FacebookClient(token);
        }
        public User Current()
        {
            dynamic graphApiRequest = client.Get("me?fields=id,name,picture");

            return new User(graphApiRequest);
        }
    }
}