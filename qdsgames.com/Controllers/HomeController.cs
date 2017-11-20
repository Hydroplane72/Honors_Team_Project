using qdsgames.com.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;

namespace qdsgames.com.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public ActionResult Index()
        {
            ViewData["loginModal"] = -100;
            ViewData["Username"] = User.Identity.Name;
            if (User.Identity.Name == null)
            {
                FormsAuthentication.SignOut();
            }
            
            UsersDatabaseEntities entity = new UsersDatabaseEntities();
            
            UserDBAccess db = new UserDBAccess();

            //If the user's data is null

            //In other words auto logged in

            if (SessionVariables.UserData == null)

            {
                //get the user's data

                SessionVariables.UserData = db.GetUserInfoByName(User.Identity.Name);
            }

            //set the users id
            int id = SessionVariables.UserData.Id;
            //check term of use agreements
            //0 = false 1=true
            int agree = Convert.ToInt32(entity.AgreedTermsUseFunc(id).FirstOrDefault());
            //redirect to agree to terms of use
            if (agree ==0)
            {
                return Redirect("/User/TermsAgree");
            }
            //check for friend requests
            var requests = entity.CheckFriendRequests(id);
            //Search for user friends and return their info by the user's id
            var data = entity.GetUserFriends(id).ToList();

            //Get links data
            List<GetUserSocialLinks_Result> links = entity.GetUserSocialLinks(id).ToList();
            
            //Set view Data
            ViewBag.requests = requests;
            ViewBag.friends = data;
            ViewBag.Links = links;
            return View();
        }

        public ActionResult About()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewData["loginModal"] = -100;
                ViewData["Username"] = User.Identity.Name;
                ViewBag.Message = "Your application description page.";
            }
            else
            {
                ViewData["Username"] = null;
            }
            return View();
        }

        public ActionResult Contact()
        {
            if (User.Identity.IsAuthenticated)
            {
                ViewData["loginModal"] = -100;
                ViewData["Username"] = User.Identity.Name;
                ViewBag.Message = "Your application description page.";
            }
            else
            {
                ViewData["Username"] = null;
            }

            return View();
        }

        //Becuase the _Layout go directly to Home
        public ActionResult Logout()
        {
            ViewData["loginModal"] = -100;
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }

        public ActionResult AccountEdit()
        {
            return Redirect("/User/AccountEdit");
        }

        public ActionResult SearchUser()
        {
            return Redirect("/User/Index");
        }
    }
}