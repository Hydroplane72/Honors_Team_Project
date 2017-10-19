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
        
        //To convert C# date time to sql datetime
        //string sqlFormattedDate = myDateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");

        public Users()
        {
        }
        [Key]
        [ForeignKey("SecurityO")]
        public int Id { get; set; }
        
        [Display(Name = "Username")]
        public string Name { get; set; }
        [Required]
        [Display(Name = "Date of Birth")]
        [DataType(DataType.Date)]
        public DateTime Dob { get; set; }
        
        [Display(Name = "Email")]
        [EmailAddress]
        public string Email { get; set; }
        

        [Display(Name = "Phone")]
        [Phone]
        public string Phone { get; set; }
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Compare("Password", ErrorMessage = "Passwords mismatch")]
        public string Repassword { get; set; }
        public int Usertype { get; set; }
        public bool Ban { get; set; }
        
        /// <summary>
        /// For the remember me check boxes
        /// </summary>
        public bool Rememberme { get; set; }


        /// <summary>
        /// The to string method for this class. This is used to get the name in views.
        /// </summary>
        /// <returns>The users name</returns>
        override
        public string ToString()
        {
            return Name;
        }
    }
}