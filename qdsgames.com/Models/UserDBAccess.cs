using qdsgames.com.Models.DBAO_DBO;
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
                "FROM USERS WHERE name = @name;";

            SqlConnection connection = new SqlConnection(GetConnectionString());
            SqlCommand command = new SqlCommand(selectMethod, connection);
            connection.Open();
            command.Parameters.AddWithValue("name", name.ToUpper());
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
        /// Searches for the Users ID by username and password. If found then
        /// </summary>
        /// <param name="username">The username parameter. A String.</param>
        /// <param name="password">The password parameter. A String.</param>
        /// <returns>The user object</returns>
        [DataObjectMethod(DataObjectMethodType.Select)]
        public Users GetUserLogin(string username, string password)
        {
            //checks and makes sure that this is a user if not return user id number as -1
            bool check = false;
            //Get Users ID from password and Username
            String selectMethod = "SELECT *" +
                "FROM Security " +
                "WHERE Username = @name" +
                " AND Password = @password;";

            //Get Users info by ID
            String selectMethod2 = "SELECT * FROM USERS " +
                "WHERE ID = @ID;";

            //Get connection
            SqlConnection connection = new SqlConnection(GetConnectionString());

            //New User and Security
            Users user = new Users();
            SecurityO sec = new SecurityO();
            //default error number
            sec.ID = -100;
            //Take userName to Uppercase
            string u = username.ToUpper();

            //Input command and connection
            SqlCommand command = new SqlCommand(selectMethod, connection);

            //add parameters input
            command.Parameters.AddWithValue("name", u);
            command.Parameters.AddWithValue("password", password.ToString());

            //Open connection
            connection.Open();

            //Execute command
            SqlDataReader datareader2 = command.ExecuteReader();

            //Read input
            while (datareader2.Read())
            {
                check = true;
                sec.ID = Convert.ToInt32(datareader2["ID"].ToString());
                sec.Username = username;
                sec.Password = password;
            }
            datareader2.Close();

            //Make sure the ID was found. If not found close connection
            if (sec.ID>0)
            {
                //Input new command
                command = new SqlCommand(selectMethod2, connection);
                //add parameters
                command.Parameters.AddWithValue("ID", sec.ID);

                SqlDataReader datareader = command.ExecuteReader();
                //Read input of User Info
                while (datareader.Read())
                {
                    check = true;
                    user.Name = datareader["NAME"].ToString();

                    user.Dob = Convert.ToDateTime(datareader["DOB"].ToString());
                    user.Email = datareader["Email"].ToString();
                    user.Phone = datareader["PHONE"].ToString();
                    user.Address = datareader["ADDRESS"].ToString();
                    user.Usertype = Convert.ToInt32(datareader["USERTYPE"].ToString());
                    user.Ban = Convert.ToBoolean(datareader["BAN"].ToString());
                    user.Id = Convert.ToInt32(datareader["ID"].ToString()); //return the users id
                }
                datareader.Close();
            }
            else
            {
                connection.Close();
                user.Id = -1;
                return user;
            }

            //For performance purposes close now
            connection.Close();
            if(user.Ban==true)
            {
                user.Id = -23;//Ban the User
            }
            if (check == false) //Check failed user either does not exsist or input wrong password.
            {
                user.Id = -1;
                return user;
            }

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
        public static bool CreateUserAccount(Users user, SecurityO sec)
        {
            string ins = "INSERT INTO USERS " +
            " (ID, Name, DOB, email, phone, address) " +
            " Values (@ID, @Username, @dob, @email, @phone, @address);";

            string ins2 = "INSERT INTO Security " +
                " (username, password) " +
                " Values (@username, @password);";

            //+ user.Name + ", " + user.Dob + ", " + user.Email + ", " +
            //user.Phone + ", " + user.Address + ", " + "0" + ", false;";

            //Checks if there is a user already if so return false
            
            int userCheck = UserDBAccess.GetUserID(sec.Username, sec.Password);
            if (userCheck>=0) //find out if there is already a user with that username ad password
            {
                return false;
            }
            using (SqlConnection con = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand(ins2, con))//Create User ID, username, and password
                {
                    cmd.Parameters.AddWithValue("username", sec.Username.ToUpper());
                    cmd.Parameters.AddWithValue("password", sec.Password);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                //Get the new User's ID
                sec.ID = GetUserID(sec.Username, sec.Password);

                using (SqlCommand cmd = new SqlCommand(ins, con)) //Create User Info
                {
                    cmd.Parameters.AddWithValue("ID", sec.ID);
                    cmd.Parameters.AddWithValue("Username", user.Name.ToUpper().Trim());
                    cmd.Parameters.AddWithValue("dob", user.Dob.ToString());
                    cmd.Parameters.AddWithValue("email", user.Email);
                    cmd.Parameters.AddWithValue("phone", user.Phone);
                    cmd.Parameters.AddWithValue("address", user.Address);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }
            return true;
        }

        /// <summary>
        /// Gets the user's ID from the security table and returns it for the Users table
        /// </summary>
        /// <param name="username">User's username</param>
        /// <param name="password">User's password</param>
        /// <returns></returns>
        private static int GetUserID(string username, string password)
        {
            //checks and makes sure that this is a user if not return user id number as -1
            bool check = false;
            //Get Users ID from password and Username
            String selectMethod = "SELECT *" +
                "FROM Security " +
                "WHERE Username = @name" +
                " AND password = @password;";

            //Get connection
            SqlConnection connection = new SqlConnection(GetConnectionString());

            //New User and Security
            Users user = new Users();
            SecurityO sec = new SecurityO();

            //To know something is wrong
            sec.ID = -100;

            //Take userName to Uppercase
            string u = username.ToUpper();

            //Input command and connection
            SqlCommand command = new SqlCommand(selectMethod, connection);

            //add parameters input
            command.Parameters.AddWithValue("name", u);
            command.Parameters.AddWithValue("password", password.ToString());

            //Open connection
            connection.Open();

            //Execute command
            SqlDataReader datareader2 = command.ExecuteReader();

            //Read input
            while (datareader2.Read())
            {
                check = true;
                sec.ID = Convert.ToInt32(datareader2["ID"].ToString());
                sec.Username = username;
                sec.Password = password;
            }
            datareader2.Close();
            //For performance purposes close now
            connection.Close();
            if (check == false) //Check failed user either does not exsist or input wrong password.
            {
                sec.ID = -1;
                return sec.ID;
            }

            return sec.ID;
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