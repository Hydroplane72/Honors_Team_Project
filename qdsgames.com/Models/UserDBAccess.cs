using System;
using System.ComponentModel;
using System.Configuration;
using System.Data.SqlClient;

namespace qdsgames.com.Models
{
    public class UserDBAccess
    {
        /// <summary>
        /// Gets the users info according to user ID number. This can be used to get the users info
        /// for them to manipulate. This can also be used to find other users and their infos.
        /// </summary>
        /// <param name="ID">
        /// The ID of each user. There should only be one ID to each user. and each ID should be
        /// Unique in the column.
        /// </param>
        /// <returns>Returns a Object USERS class to the method that called it.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public Users GetUserInfo(int ID)
        {
            string selectMethod = "SELECT name, dob, email, phone, address, usertype, ban " +
                "FROM USERS WHERE ID =@ID;";

            SqlConnection connection = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand(selectMethod, connection);
            connection.Open();
            command.Parameters.AddWithValue("ID", ID);
            SqlDataReader datareader = command.ExecuteReader();
            Users user = new Users();
            
            while (datareader.Read())
            {
                user.Name = datareader["NAME"].ToString();
                
                user.Dob = Convert.ToDateTime(datareader["dob"]);
                user.Email = datareader["Email"].ToString();
                user.Phone = datareader["PHONE"].ToString();
                user.Address = datareader["ADDRESS"].ToString();
                user.Usertype = Convert.ToInt32(datareader["USERTYPE"].ToString());
                user.Ban = Convert.ToBoolean(datareader["BAN"].ToString());
                user.Id = ID;
            }
            datareader.Close();
            connection.Close();
            return user;
        }

        /// <summary>
        /// Gets the users info according to user ID number. This can be used to get the users info
        /// for them to manipulate. This can also be used to find other users and their infos.
        /// </summary>
        /// <param name="ID">
        /// The ID of each user. There should only be one ID to each user. and each ID should be
        /// Unique in the column.
        /// </param>
        /// <returns>Returns a Object USERS class to the method that called it.</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public Users GetUserInfoByName(string name)
        {
            string selectMethod = "SELECT id, name, dob, email, phone, address, usertype, ban " +
                "FROM USERS WHERE name =@name;";

            SqlConnection connection = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand(selectMethod, connection);
            connection.Open();
            command.Parameters.AddWithValue("name", name);
            SqlDataReader datareader = command.ExecuteReader();
            Users user = new Users();
            
            while (datareader.Read())
            {
                user.Name = datareader["NAME"].ToString();
                user.Dob = Convert.ToDateTime(datareader["dob"]);
                user.Email = datareader["Email"].ToString();
                user.Phone = datareader["PHONE"].ToString();
                user.Address = datareader["ADDRESS"].ToString();
                user.Usertype = Convert.ToInt32(datareader["USERTYPE"].ToString());
                user.Ban = Convert.ToBoolean(datareader["BAN"].ToString());
                user.Id = Convert.ToInt32(datareader["ID"].ToString());
            }
            datareader.Close();
            connection.Close();
            return user;
        }

        /// <summary>
        /// Searches for a user's username and password. If both match up the method returns the
        /// users info. If not the method returns the user ID as -1. This will then set off an effect
        /// of user login fail
        /// </summary>
        /// <param name="username">The username parameter. A String.</param>
        /// <param name="password">The password parameter. A String.</param>
        /// <returns>The user object</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public Users GetUserLogin(string username, string password)
        {
            //checks and makes sure that this is a user if not return user id number as -1
            bool check = false;

            String selectMethod = "SELECT *" +
                "FROM USERS " +
                "WHERE name = @name" +
                " AND password = @password;";
            SqlConnection connection = new SqlConnection(GetConnectionString());
            Users user = new Users();
            string u = username.ToUpper();
            SqlCommand command = new SqlCommand(selectMethod, connection);
            command.Parameters.AddWithValue("name", u);
            command.Parameters.AddWithValue("password", password.ToString());
            connection.Open();
            SqlDataReader datareader = command.ExecuteReader();
            
            string date;
            while (datareader.Read())
            {
                check = true;
                user.Name = datareader["NAME"].ToString();
                date = datareader.ToString();
                user.Dob = Convert.ToDateTime(datareader["DOB"].ToString());
                user.Email = datareader["Email"].ToString();
                user.Phone = datareader["PHONE"].ToString();
                user.Address = datareader["ADDRESS"].ToString();
                user.Usertype = Convert.ToInt32(datareader["USERTYPE"].ToString());
                user.Ban = Convert.ToBoolean(datareader["BAN"].ToString());
                user.Id = Convert.ToInt32(datareader["ID"].ToString()); //return the users id
            }
            if (check == false) //Check failed user either does not exsist or input wrong password.
            {
                datareader.Close();
                connection.Close();
                user.Id = -1;
                return user;
            }
            datareader.Close();
            connection.Close();
            return user;
        }

        /// <summary>
        /// Updates and edits the Users account info
        /// </summary>
        /// <param name="original_user">The User's Original Info</param>
        /// <param name="user">The User's New Info</param>
        [DataObjectMethod(DataObjectMethodType.Update)]
        public int UpdateUserAccount(Users original_user, Users user)
        {
            int rowUpdateCheck = 0;
            String update = "UPDATE Users "
               + "SET Name = @Name,"
                   + "Dob = @Dob,"
                   + "Email = @Email,"
                   + "Phone = @Phone,"
                   + "Address = @Address "
               + "WHERE Id = @Id";
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(update, con))
                {
                    //call command with parameters for new info
                    cmd.Parameters.AddWithValue("Name", user.Name.ToUpper());
                    cmd.Parameters.AddWithValue("Dob", user.Dob);
                    cmd.Parameters.AddWithValue("Email", user.Email);
                    cmd.Parameters.AddWithValue("Phone", user.Phone);
                    cmd.Parameters.AddWithValue("Address", user.Address);
                    //Call command with parameters for old info
                    cmd.Parameters.AddWithValue("Id", original_user.Id);
                    con.Open();
                    rowUpdateCheck = cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return rowUpdateCheck;
        }

        /// <summary>
        /// Creates a new user
        /// </summary>
        /// <param name="user">The class user. Contains all info needed to make new user.</param>
        /// <returns>Returns true if insert/create account worked. If not then returns false.</returns>
        [DataObjectMethod(DataObjectMethodType.Insert)]
        public static bool CreateUserAccount(Users user)
        {
            string ins = "INSERT INTO USERS " +
            " (Name, DOB, email, phone, address, usertype, ban, password) " +
            " Values (@Username, @dob, @email, @phone, @address, @type, @ban, @password);";

            //+ user.Name + ", " + user.Dob + ", " + user.Email + ", " +
            //user.Phone + ", " + user.Address + ", " + "0" + ", false;";

            try
            {
                //
                using (SqlConnection con = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand(ins, con))
                    {
                        cmd.Parameters.AddWithValue("Username", user.Name.ToUpper());
                        cmd.Parameters.AddWithValue("dob", user.Dob);
                        cmd.Parameters.AddWithValue("email", user.Email);
                        cmd.Parameters.AddWithValue("phone", user.Phone);
                        cmd.Parameters.AddWithValue("address", user.Address);
                        cmd.Parameters.AddWithValue("type", 0);
                        cmd.Parameters.AddWithValue("ban", false);
                        cmd.Parameters.AddWithValue("password", user.Password);
                        con.Open();
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
            }
            catch { return false; }

            return true;
        }

        /// <summary>
        /// Obtains the user connection string for the database.
        /// </summary>
        /// <returns>the connection string for the user.</returns>
        private static string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings
                ["QDSServerConnectionString"].ConnectionString;
        }
    }
}