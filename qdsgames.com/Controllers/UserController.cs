using qdsgames.com.Models;
using System.Web.Mvc;
using System.Web.Security;

namespace qdsgames.com.Controllers
{
    public class UserController : Controller
    {
        // Post: User
        /// <summary>
        /// Login Action. This is used for login tries. Everytime the user attempts to login the
        /// login button goes to here.
        /// </summary>
        /// <param name="username">The supposed username to be checked</param>
        /// <param name="password">The username to be checked</param>
        /// <returns>Returns to the view a user object.</returns>
        [HttpPost]
        public ActionResult Login(Users users, string ReturnUrl)
        {
            if(isUser(users))
            {
                FormsAuthentication.SetAuthCookie(users.Name, users.Rememberme);
                return Redirect(ReturnUrl);
            }
            else
            {
                return View(users);
            }
            
        }
        private bool isUser(Users users)
        {
            //Checks database for username and password
            UserDBAccess userDB = new UserDBAccess();
            //users =userDB.GetUserLogin(users.Name, users.Password);
            //For now the user will be authenticated
            if (users.Id == -1)
            {
                return false;
            }
            SessionVariables.UserData = users; //User authenticated
            ViewData["Username"] = SessionVariables.UserData.Name;
            return true;
        }
        // Get: User
        /// <summary>
        /// Login Action. This is used for login tries. Everytime the user attempts to login the
        /// login button goes to here.
        /// </summary>
        /// <param name="username">The supposed username to be checked</param>
        /// <param name="password">The username to be checked</param>
        /// <returns>Returns to the view a user object.</returns>
        [HttpGet]
        public ActionResult Login()
        {
            //users = new UserDBAccess().GetUserLogin(login.Username.ToString(), login.Password.ToString());
            
            
            
            
            
            return View();
        }

        //Post: NewUser
        /// <summary>
        /// This is called by the signup button. Creates a new user in the database.
        /// </summary>
        /// <returns>Redirects to login</returns>
        [HttpPost]
        public ActionResult NewUser(FormCollection form)
        {
            Users users = new Users
            {
                //New user db Access function
                //decimal principle = Convert.ToDecimal(form["txtAmount"].ToString());
                Name = form["Username"].ToString(),
                Email = form["Email"].ToString(),
                Phone = form["Phone"].ToString(),
                Address = form["Address"].ToString(),
                Password = form["Password"].ToString(),
                Repassword = form["RepeatPassword"].ToString(),
                Dob = System.Convert.ToDateTime(form["DOB"].ToString())
            };
            SessionVariables.UserData = users;
            ViewData["Username"] = SessionVariables.UserData.Name;
            return RedirectToAction("Login", users);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home/Index");
        }

        public ActionResult AccountEdit(Users users)
        {
            Users old_user = SessionVariables.UserData;

            return View(users);
        }

        public ActionResult IsLoggedIn()
        {
            ViewBag["UserLoggedIn"] = true;
            return Redirect("~/Home/Index.cshtml");
        }
    }
}