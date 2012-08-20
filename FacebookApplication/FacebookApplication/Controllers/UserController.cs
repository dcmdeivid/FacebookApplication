using FacebookApplication.Dao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FacebookApplication.Controllers
{
    public class UserController : Controller
    {
        private string acessToken;

        public ActionResult Index()
        {
            IUserDao userDao = new UserDao(acessToken);
            return View(userDao.Current());
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            this.acessToken = Session["access_token"] as string;
        }




    }
}
