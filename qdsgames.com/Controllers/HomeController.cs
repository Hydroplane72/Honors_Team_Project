using System.Web.Mvc;
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
            return View();
        }

        public ActionResult About()
        {
            if(User.Identity.IsAuthenticated)
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
    }
}