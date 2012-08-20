using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookApplication.Models
{
    public class Friend
    {
        private string name;
        private long id;
        private string pictureSource;

        public Friend(dynamic friend)
        {
            this.name = friend.name;
            this.id = long.Parse(friend.id);
            this.pictureSource = friend.picture;
        }

        public string Name
        {
            get { return name; }
        }

        public long Id
        {
            get
            {
                return id;
            }
        }

        public string PictureSource
        {
            get
            {
                return pictureSource;
            }
        }

        
    }
}