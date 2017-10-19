using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace qdsgames.com.Models.UserUtil
{
    public class UserSearch
    {
        
        [Display(Name ="User ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Username")]
        public string username { get; set; }
    }
}