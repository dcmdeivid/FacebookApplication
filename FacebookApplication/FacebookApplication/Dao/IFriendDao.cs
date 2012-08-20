using FacebookApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FacebookApplication.Dao
{
    interface IFriendDao
    {
        IList<Friend> All();
    }
}
