using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qdsgames.com.Models
{
    public static class SessionVariables
    {
        /// <summary>
        /// This is used for the User that is logged in.
        /// </summary>
        public static Users UserData
        {
            get { return HttpContext.Current.Session["UserData"] as Users; }
            set { HttpContext.Current.Session["UserData"] = value; }
        }
        /// <summary>
        /// This is used for the account page of the user that is logged in
        /// </summary>
        public static Users UserPage
        {
            get { return HttpContext.Current.Session["UserPage"] as Users; }
            set { HttpContext.Current.Session["UserPage"] = value; }
        }

    }
}