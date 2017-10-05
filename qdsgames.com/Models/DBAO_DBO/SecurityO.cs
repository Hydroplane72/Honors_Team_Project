using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qdsgames.com.Models.DBAO_DBO
{
    public class SecurityO
    {
        

        public SecurityO()
        {

        }

        [Required]
        public int ID
        {
            get;
            set;
        }
        [Required]
        [Display(Name ="Username")]
        public string Username
        {
            get;
            set;
        }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password
        {
            get;
            set;
        }
    }
}