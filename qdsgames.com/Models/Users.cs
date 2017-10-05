using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace qdsgames.com.Models
{
    [Table("Users")]
    public class Users
    {
        private int id;
        private string name;
        private DateTime dob;
        private string email;
        private string phone;
        private string address;
        private int usertype;
        private bool ban;
        private string password;
        private string repassword;
        private bool rememberme;
        //To convert C# date time to sql datetime
        //string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

        public Users()
        {
        }
        [Key]
        [ForeignKey("SecurityO")]
        public int Id { get => id; set => id = value; }
        
        [Display(Name = "Username")]
        public string Name { get => name; set => name = value; }
        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime Dob { get => dob; set => dob = value; }
        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get => email; set => email = value; }
        [Required]
        [Display(Name = "Phone")]
        [Phone]
        public string Phone { get => phone; set => phone = value; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get => address; set => address = value; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get => password; set => password = value; }
        [Compare("Password", ErrorMessage = "Passwords mismatch")]
        public string Repassword { get => repassword; set => repassword = value; }
        public int Usertype { get => usertype; set => usertype = value; }
        public bool Ban { get => ban; set => ban = value; }
        
        /// <summary>
        /// For the remember me check boxes
        /// </summary>
        public bool Rememberme { get => rememberme; set => rememberme = value; }


        /// <summary>
        /// The to string method for this class. This is used to get the name in views.
        /// </summary>
        /// <returns>The users name</returns>
        override
        public string ToString()
        {
            return name;
        }
    }
}