using Newtonsoft.Json.Linq;
using qdsgames.com.Models;
using qdsgames.com.Models.DBAO_DBO;
using qdsgames.com.Models.Security;
using qdsgames.com.Models.UserEdit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;

namespace qdsgames.com.Controllers
{
    public class UserController : Controller
    {
        //For user validation
        private UserValid inputValidation = new UserValid();

        //keep track of num user links
        private LinkEdit linkEdit = new LinkEdit();

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

            users.Repassword = users.Password;
            if (inputValidation.UserInputValidation(users, ReturnUrl))//Checks user input
            {
                if (IsUser(users)) //True if login successfull
                {
                    //Send message to user
                    ViewData["UserLog"] = true;
                    FormsAuthentication.SetAuthCookie(users.Name, users.Rememberme);

                    if (model == -100)
                    {
                        return Redirect(modelUrl);
                    }
                    if (ReturnUrl == null)
                    {
                        return Redirect("/Home/Index/");
                    }
                    return Redirect(ReturnUrl);
                }
                else
                {
                    return View(users);
                }
            }
            else
            {
                return View(users);
            }
        }

        private bool IsUser(Users users)
        {
            //Check previous user input again for code
            if (inputValidation.UserInputValidation(users))
            {
                //Checks database for username and password
                UserDBAccess userDB = new UserDBAccess();

                //Check username and password are correct otherwise return back to login
                if (users.Name == null || users.Password == null || users.Repassword == null || users.Repassword != users.Password)
                {
                    return false;
                }

                users = userDB.GetUserLogin(users.Name, users.Password);

                if (users.Id == -1)
                {
                    ViewData["LoginFail"] = "Username or password is incorrect.";
                    return false;
                }
                else if (users.Id == -2)
                {
                    ViewData["LoginFail"] = "Username or password is incorrect.";
                    return false;
                }
                else if (users.Id == -23)
                {
                    ViewData["LoginFail"] = "You've been banned.";
                    return false;
                }
                else
                {
                    ViewData["LoginFail"] = null;
                }
                users.Id = users.Id;
                SessionVariables.UserData = users; //User authenticated
                ViewData["Username"] = SessionVariables.UserData.Name;
                return true;
            }
            else
            {
                return false;
            }
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
            if (User.Identity.Name == "" || User.Identity.Name == null) //No user is logged into the authentication
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
            var response = Request["g-recaptcha-response"];
            string secretKey = "6LcH-TQUAAAAAPKXLLGq65vU3yo06BZ2FgGyiWxs";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");

            //ViewBag.Message = status ? "Google reCaptcha validation success" : "Google reCaptcha validation failed";
            ViewData["loginModal"] = -100;
            Users users = new Users();
            if (status)
            {
                //New user db Access function

                users.Name = form["Username"].ToString();
                users.Email = form["Email"].ToString();
                users.Phone = form["Phone"].ToString();
                users.Address = form["Address"].ToString();
                users.Password = form["Password"].ToString();
                users.Repassword = form["RepeatPassword"].ToString();
                users.Dob = System.Convert.ToDateTime(form["DOB"].ToString());
                users.Rememberme = userss.Rememberme;

                //Check user input
                if (inputValidation.UserInputValidation(users) && inputValidation.UserInputValidation(userss))
                {
                    SecurityO sec = new SecurityO();
                    sec.Username = users.Name;
                    sec.Password = users.Password;

                    //Create user in Database
                    bool correct = UserDBAccess.CreateUserAccount(users, sec);
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
                }
                else
                {
                    ModelState.AddModelError("Username", "You input an invalid character into the text box");
                }
            }
            return RedirectToAction("Login", users);
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return Redirect("/Home");
        }

        [HttpGet]
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
                    if (old_user.Id == 0)
                    {
                        old_user = access.GetUserInfoByName(User.Identity.Name);
                    }
                    old_user = access.GetUserInfo(old_user.Id);//Set user database info to the user info

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
            if (inputValidation.UserInputValidation(users))
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
                        if (users.Name == null)
                        {
                            users.Name = User.Identity.Name;
                        }
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
            }
            else
            {
                ViewData["Username"] = "Invalid data was entered into one of the text fields";
            }

            return View(users);
        }

        public ActionResult IsLoggedIn()
        {
            ViewData["loginModal"] = -100;
            ViewBag["UserLoggedIn"] = true;
            return Redirect("~/Home/Index.cshtml");
        }

        [Authorize]
        [HttpGet]
        public ActionResult Search()
        {
            ViewData["loginModal"] = -100;
            ViewData["UserLog"] = true;
            if (User.Identity.Name != null || User.Identity.Name != "")
            {
                ViewData["UserLoggedIn"] = true;
                ViewData["Username"] = User.Identity.Name;
            }
            else
            {
                ViewData["Username"] = null;
            }
            UserDBAccess db = new UserDBAccess();
            SessionVariables.UserData = db.GetUserInfoByName(User.Identity.Name);
            UsersDataEntities entity = new UsersDataEntities();

            var data = entity.GetAllUsers(SessionVariables.UserData.Id).ToList();

            ViewBag.userdetails = data;
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult Search(string searchUser)
        {
            ViewData["loginModal"] = -100;
            ViewData["UserLog"] = true;
            if (User.Identity.Name != null || User.Identity.Name != "")
            {
                ViewData["UserLoggedIn"] = true;
                ViewData["Username"] = User.Identity.Name;
            }
            else
            {
                ViewData["Username"] = null;
            }
            UsersDataEntities entity = new UsersDataEntities();
            //Search for user
            var data = entity.SearchUser(searchUser).ToList();

            ViewBag.userdetails = data;
            return View();
        }

        [Authorize]
        public ActionResult AddFriend(string UserID)
        {
            UsersDataEntities entity = new UsersDataEntities();
            UserDBAccess db = new UserDBAccess();
            //create new friend
            FUID friend = new FUID();
            friend.BLOCK = false;
            friend.FRIENDID = Convert.ToInt32(UserID);
            int userID = db.GetUserInfoByName(User.Identity.Name).Id;
            friend.USERID = userID;
            friend.Confirmed = 1;
            entity.AddNewFriend(friend.FRIENDID, friend.BLOCK, friend.USERID);
            Users users = new Users
            {
                Id = friend.USERID
            };
            SessionVariables.UserData = users;

            return Redirect("/User/Friends/");
        }

        [Authorize]
        public ActionResult Friends()
        {
            ViewData["loginModal"] = -100;
            ViewData["UserLog"] = true;
            if (User.Identity.Name != null || User.Identity.Name != "")
            {
                ViewData["UserLoggedIn"] = true;
                ViewData["Username"] = User.Identity.Name;
            }
            else
            {
                ViewData["Username"] = null;
            }
            UsersDataEntities entity = new UsersDataEntities();

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
            //Search for user friends and return their info by the user's id
            var data = entity.GetUserFriends(id).ToList();
            ViewBag.friends = data;
            return View();
        }

        [Authorize]
        public ActionResult RequestResponsePositive(int ids)
        {
            int idF = Convert.ToInt32(ids);
            UsersDataEntities entity = new UsersDataEntities();
            UserDBAccess db = new UserDBAccess();

            if (SessionVariables.UserData == null)
            {
                //get the user's data

                SessionVariables.UserData = db.GetUserInfoByName(User.Identity.Name);
            }

            //set the users id
            int id = SessionVariables.UserData.Id;
            GetUserRequesterFunction_Result requester=  (GetUserRequesterFunction_Result) entity.GetUserRequesterFunction(idF, id);
            if (Convert.ToInt32(requester.Request)== 2)//if user accepting is also the one that requested
            {
                return Redirect("/Home");
            }
            entity.AcceptFriendProc(idF, id);
            return Redirect("/Home");
        }

        [Authorize]
        public ActionResult RequestResponseNegative(String ids)
        {
            int idF = Convert.ToInt32(ids);
            UsersDataEntities entity = new UsersDataEntities();
            UserDBAccess db = new UserDBAccess();

            if (SessionVariables.UserData == null)
            {
                //get the user's data

                SessionVariables.UserData = db.GetUserInfoByName(User.Identity.Name);
            }

            //set the users id
            int id = SessionVariables.UserData.Id;
            entity.DenyFriendProc(idF, id);
            return Redirect("/Home");
        }

        [Authorize]
        [HttpGet]
        public ActionResult EditUserLinks()
        {
            ViewData["loginModal"] = -100;
            ViewData["UserLog"] = true;
            if (User.Identity.Name != null || User.Identity.Name != "")
            {
                ViewData["UserLoggedIn"] = true;
                ViewData["Username"] = User.Identity.Name;
            }
            else
            {
                ViewData["Username"] = null;
            }
            UsersDataEntities entities = new UsersDataEntities();

            //Make dropdown list of MSLID
            List<Medias> idsList = new List<Medias>();
            var num = entities.GetMSLIDCount().FirstOrDefault().num;
            int number = Convert.ToInt32(num);
            Medias m;
            for (int i = 1; i <= number; i++)
            {
                m = new Medias();

                String name = entities.GetMSLIDName(i).FirstOrDefault().c1;
                m.Text = name;
                m.Value = i.ToString();
                m.Id = i;
                idsList.Add(m);
            }
            ViewBag.idsList = idsList;

            UserDBAccess db = new UserDBAccess();
            //Populate and sequence through User populated info.
            //get user's id
            int userID = db.GetUserInfoByName(User.Identity.Name).Id;
            //get users links by id
            var info = entities.GetUserLinks(userID);
            List<GetUserLinks_Result> result = info.ToList();

            //To count the number of links a user has
            linkEdit.NumLinks = result.Count;
            ViewBag.UserLinks = result;
            TempData["UserLinks"] = result.Count;

            //Gets the range of link ids to send to postback
            int count = 1;
            foreach (GetUserLinks_Result r in result)
            {
                TempData["UserLinkIdRange_"+count] = r.id;
                count++;
            }
            
            
            
            if (result.Count < 3)
            {
                ViewBag.AllowNewLinks = true;
            }
            else
            {
                ViewBag.AllowNewLinks = false;
            }

            return View();
        }

        [HttpPost]
        public ActionResult EditUserLinks(FormCollection form, String link)
        {
            ViewData["loginModal"] = -100;
            ViewData["UserLog"] = true;
            if (User.Identity.Name != null || User.Identity.Name != "")
            {
                ViewData["UserLoggedIn"] = true;
                ViewData["Username"] = User.Identity.Name;
            }
            else
            {
                ViewData["Username"] = null;
            }
            //get user's id
            UserDBAccess db = new UserDBAccess();
            UsersDataEntities entities = new UsersDataEntities();
            int userID = db.GetUserInfoByName(User.Identity.Name).Id;
            //check user input
            Boolean check;
            string input;
            int mslid;
            

            //get temp data
            List<int> userIds = new List<int>();
            int data;
            for(int i = 1; i<=3; i++)
            {
                //get int
                data = (int)TempData["UserLinkIdRange_" + i];
                //Set int to list
                userIds.Add(data);
            }
            foreach(int i in userIds) //Go through each of the links a user has set up
            {
                //make sure link is valid
                check = inputValidation.IsValidUrl(link);
                if (check) //check is good
                {
                    if (form["userId_" + i].ToString() != null)
                        check = inputValidation.IsValidUrl(form["userId_" + i].ToString());
                    else
                        check = false;
                }
                if (!check) //Check failed at some point
                {
                    return Redirect("/Home/Index");
                }

                //url input of user and mslid selection
                input = form["userId_" + i].ToString();
                mslid = Convert.ToInt32(form["list_" + i].ToString());
                /*
                 * This creates a new row if not already made. This also updates an mslid if already in database.
                 */
                if (mslid == 2 && input.Length <= 60)
                {
                    string backup = input;
                    input = "https://player.twitch.tv/?channel=" + input + "&muted=true";
                    //check and make sure ...again that input does not double up http
                    if(input.Length > 60)
                    {
                        input = backup;
                    }
                }
                entities.UpdateCreateUCLTProc(userID, mslid, input);
            }
            return Redirect("/Home/Index");
        }

        [HttpPost]
        public ActionResult NewUserLink(FormCollection form)
        {
            ViewData["loginModal"] = -100;
            ViewData["UserLog"] = true;
            if (User.Identity.Name != null || User.Identity.Name != "")
            {
                ViewData["UserLoggedIn"] = true;
                ViewData["Username"] = User.Identity.Name;
            }
            else
            {
                ViewData["Username"] = null;
            }
            UserDBAccess db = new UserDBAccess();
            UsersDataEntities entities = new UsersDataEntities();
            int userID = db.GetUserInfoByName(User.Identity.Name).Id;
            //check user input
            Boolean check;
            string input;
            int mslid;
            linkEdit.NumLinks++;

            //make sure link is valid
            if (form["Url"].ToString() != null)
                check = inputValidation.IsValidUrl(form["Url"].ToString());
            else
                check = false;

            //url input of user and mslid selection
            input = form["Url"].ToString();
            mslid = Convert.ToInt32(form["Social"].ToString());
            /*
             * This creates a new row if not already made. 
             * This also updates an mslid if already in database.
             */
            entities.UpdateCreateUCLTProc(userID, mslid, input);
            return Redirect("/Home/Index");
        }
    }
}