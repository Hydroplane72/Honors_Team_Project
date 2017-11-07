using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace qdsgames.com.Models.Security
{
    /// <summary>
    /// All user inputs are put through a filter.
    /// Checks user input for malicious code.
    /// </summary>
    public sealed class UserValid
    {
        
        public Boolean UserInputValidation(Users users, String url)
        {
            if(IsValidString(users.Name)&& IsValidString(users.Email) 
                    && IsValidPhone(users.Phone) && IsValidString(users.Address) 
                    && IsValidString(users.Password) && IsValidString(users.Repassword)
                    && IsValidString(url))
            {
                return true;
            }
            return false;
        }
        public Boolean UserInputValidation(Users users)
        {
            if (IsValidString(users.Name) && IsValidString(users.Email)
                    && IsValidPhone(users.Phone) && IsValidString(users.Address)
                    && IsValidString(users.Password) && IsValidString(users.Repassword))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Checks the string's input. if the string has any of these within them then the function returns false. 
        /// This leads to the program throwing an error saying that that input is not allowed.
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private Boolean IsValidString(String input)
        {
            if (input != null) //if null then it will not present a threat
            {
                //Makes it easier to  check individual letters
                input = input.ToUpper();
                if (input.Contains("(") || input.Contains(")")
                    || input.Contains("?") || input.Contains("=")
                    || input.Contains("[") || input.Contains("]")
                    || input.Contains("{") || input.Contains("}")
                    || input.Contains("INSERT") || input.Contains("SELECT"))

                {
                    return false;
                }
            }
            return true;
        }
        private Boolean IsValidPhone(String input)
        {
            if(input != null)
            {
                if (input.Length <= 17 && !input.Contains("=")
                                && !input.Contains("INSERT") && !input.Contains("SELECT"))
                {
                    return true;
                }
            }
            else
            {
                return true;
            }
            
            return false;
        }
        public Boolean IsValidUrl(String input)
        {
            if(input!=null)
            {
                if(input.Contains("(") || input.Contains(")")
                    || input.Contains("[") || input.Contains("]")
                    || input.Contains("{") || input.Contains("}")
                    || input.Contains("INSERT") || input.Contains("SELECT"))
                {
                    return false;
                }
            }
            return true;
        }
    }
}