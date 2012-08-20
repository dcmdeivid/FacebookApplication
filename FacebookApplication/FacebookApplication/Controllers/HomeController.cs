using Facebook;
using FacebookApplication.Dao;
using FacebookApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace FacebookApplication.Controllers
{
    public class HomeController : Controller
    {
        private FacebookAuthProvider facebookAuthProvider;

        public HomeController()
        {
            facebookAuthProvider = new FacebookAuthProvider();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();

        }

        public ActionResult Login()
        {
            Session["csrf_token"] = facebookAuthProvider.CrossSiteRequestForgeryToken;

            return Redirect(facebookAuthProvider.LoginUrl());
        }

        public ActionResult Callback(string code, string state)
        {
            string crsfToken = Session["csrf_token"] as string;

            if (!facebookAuthProvider.IsValidCsrfToken(state, crsfToken))
                return RedirectToAction("Index", "Home");

            Session["access_token"] = facebookAuthProvider.GetAcessToken(code);
            return RedirectToAction("Index", "User");

        }



    }
}
