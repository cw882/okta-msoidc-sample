﻿using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OpenIdConnect;
using System.Web;
using System.Web.Mvc;


namespace Okta.Samples.OpenIDConnect.CodeFlow.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Claims()
        {
            ViewBag.Message = "Your claims.";

            return View();
        }


        public ActionResult SignOut()
        {
            Request.GetOwinContext().Authentication.SignOut(OpenIdConnectAuthenticationDefaults.AuthenticationType, CookieAuthenticationDefaults.AuthenticationType);

            return View();
        }

        [HttpPost]
        public ActionResult OpenIDConnect(FormCollection form)
        {
            if (form["error"] != null)
            { //we fall here when Okta is the Authorization server
                string error = form["error"];
                string desc = form["error_description"];
            }
            else if (form["code"] != null)
            {//we fall here when IdentityServer is the Authorization server
                string authCode = form["code"];
                string state = form["state"];

            }

            return View();
        }

    }
}