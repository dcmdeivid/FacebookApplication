using FacebookApplication.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacebookApplication.Controllers
{
    public class FriendController : Controller
    {
        private string acessToken;

        public ActionResult All()
        {
            IFriendDao friendDao = new FriendDao(acessToken);
            return View(friendDao.All());
        }


        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            this.acessToken = Session["access_token"] as string;
        }
    }
}
