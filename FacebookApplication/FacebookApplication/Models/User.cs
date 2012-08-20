using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacebookApplication.Models
{
    public class User
    {
        private string name;
        private long id;
        private string pictureSource;

        public User(dynamic user)
        {
            this.name = user.name;
            this.id = long.Parse(user.id);
            this.pictureSource = user.picture;
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