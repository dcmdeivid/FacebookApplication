using Facebook;
using FacebookApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookApplication.Dao
{
    public class FriendDao : IFriendDao
    {
        private FacebookClient client;
        private IList<Friend> friends;

        public FriendDao(string token)
        {
            client = new FacebookClient(token);
        }


        public IList<Friend> All()
        {
            this.friends = new List<Friend>();

            dynamic graphApiRequest = client.Get("me/friends?fields=id,name,picture");
            JsonArray friendsJson = graphApiRequest["data"];

            foreach (dynamic friend in friendsJson)
            {
                friends.Add(new Friend(friend));
            }

            return friends;

        }


    }
}