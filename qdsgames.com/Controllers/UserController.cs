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
            ViewData["loginModal"] = -100;
            int model = users.Id; //Gets the users id - this is used to figure out if the request came from login modal
            string modelUrl = users.Phone; //The return url string for login modal
            if (model == -100)
            {
                users.Repassword = users.Password;
            }
            if (IsUser(users))
            {
                FormsAuthentication.SetAuthCookie(users.Name, users.Rememberme);
                if (model == -100)
                {
                    return Redirect(modelUrl);
                }

                return Redirect(ReturnUrl);
            }
            else
            {
                return View(users);
            }
        }

        private bool IsUser(Users users)
        {
            //Checks database for username and password
            UserDBAccess userDB = new UserDBAccess();
            users = userDB.GetUserLogin(users.Name, users.Password);

            if (users.Id == -1)
            {
                return false;
            }
            if (users.Id == -2)
            {
                ViewData["LoginFail"] = "Username or password is incorrect.";
                return false;
            }
            else
            {
                ViewData["LoginFail"] = null;
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
            ViewData["loginModal"] = -100;
            if (User.Identity.Name == "") //No user is logged into the authentication
            {
                ViewData["UserKnown"] = false;
                return View();
            }
            else //User has logged in before.
            {
                ViewData["Username"] = User.Identity.Name; //Add username to viewdata to auto fill login
                ViewData["UserKnown"] = true;
                return View();
            }
        }

        //Post: NewUser
        /// <summary>
        /// This is called by the signup button. Creates a new user in the database.
        /// </summary>
        /// <returns>Redirects to login</returns>
        [HttpPost]
        public ActionResult NewUser(FormCollection form, Users userss)
        {
            ViewData["loginModal"] = -100;
            Users users = new Users();
            //New user db Access function

            users.Name = form["Username"].ToString();
            users.Email = form["Email"].ToString();
            users.Phone = form["Phone"].ToString();
            users.Address = form["Address"].ToString();
            users.Password = form["Password"].ToString();
            users.Repassword = form["RepeatPassword"].ToString();
            users.Dob = System.Convert.ToDateTime(form["DOB"].ToString());
            users.Rememberme = userss.Rememberme;

            //Create user in Database
            bool correct = UserDBAccess.CreateUserAccount(users);
            if (correct)
            {
                SessionVariables.UserData = users;
                ViewData["Username"] = SessionVariables.UserData.Name;
                FormsAuthentication.SetAuthCookie(users.Name, users.Rememberme); //Add user to authentication
            }
            else
            {
                ModelState.AddModelError("Username", "Username Already exists");
                ViewData["LoginFail"] = "Name Already exists";
                return RedirectToAction("Login", ViewData);
            }

            return RedirectToAction("Login", users);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home");
        }

        public ActionResult AccountEdit()
        {
            ViewData["UserUpdate"] = "";
            //Logged In functionality
            //check if user has been authenticated and actually allowed on page
            if (User.Identity.IsAuthenticated)
            {
                if (User.Identity.Name != null) //Check and make sure User's identity authentication has a name
                {
                    UserDBAccess access = new UserDBAccess();

                    Users old_user = SessionVariables.UserData;

                    old_user = access.GetUserInfoByName(User.Identity.Name);//Set user database info to the user info
                                                                            //Set Session info to user info
                    SessionVariables.UserData = old_user; //Will be used to help update user account
                    
                }
                else
                {//If the User.name is null but authenticated then the user needs to be signed out and relogin

                    FormsAuthentication.SignOut();
                    return Redirect("/User/Login");
                }
                //User.name has a name other wise code would have de authenticated and redirected to login page
                //For the login modal
                ViewData["loginModal"] = -100;
                ViewData["Username"] = User.Identity.Name;

                //Get the user's info and return it to the view
                if (SessionVariables.UserData != null)
                {
                    //Get user info- primary ID
                    Users old_user = SessionVariables.UserData;
                    UserDBAccess access = new UserDBAccess();
                    old_user = access.GetUserInfo(old_user.Id);//Set user database info to the user info
                                                               //Set Session info to user info
                    SessionVariables.UserData = old_user; //Will be used to help update user account

                    return View(old_user);
                }
                else
                {

                    return Redirect("/User/Login");
                }
            }
            else
            {
                //user is not authenticated to be going to this page
                ViewData["Username"] = null;
                //redirect to login page
                return Redirect("/User/Login");
            }
        }

        [HttpPost]
        public ActionResult AccountEdit(Users users)
        {
            //User Logged In functionality
            if (User.Identity.IsAuthenticated)
            {
                //For login modal
                ViewData["loginModal"] = -100;
                ViewData["Username"] = User.Identity.Name;

               //Make sure form is valid
                if (ModelState.IsValid)
                {
                    //Get the users name
                    string name = User.Identity.Name;
                    UserDBAccess access = new UserDBAccess();
                    access.UpdateUserAccount(SessionVariables.UserData, users); //update user info in database
                    SessionVariables.UserData = users;//Update Session Data
                                                      //Successfull update
                    ViewData["UserUpdate"] = "Account details have been successfully updated";
                    return Redirect("/Home/Index");
                }
            }
            else
            {

                ViewData["Username"] = null;
            }

            

            return View(users);
        }

        public ActionResult IsLoggedIn()
        {
            ViewData["loginModal"] = -100;
            ViewBag["UserLoggedIn"] = true;
            return Redirect("~/Home/Index.cshtml");
        }
    }
}