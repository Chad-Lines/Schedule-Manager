using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;

namespace Schedule_Manager
{
    static class DbManager
    {
        public static readonly string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
        private static int _userId;
        private static string _userName;

        public static MySqlConnection DbConnect()
        {
            MySqlConnection conn = new MySqlConnection(constr); // Create the connection using the connection string in the DataBase class
            conn.Open();                                        // Open the database connection
            return conn;                                        // Return the connection
        }

        public static void DbClose()
        {
            
        }

        public static void SetUserID(int id)
        {
            // Setting the current user ID
            _userId = id;                                                           

            // Based on the user ID we can set the username. Doing so this way helps us prevent
            // the username and user ID not matching up, which may cause issues down the line.
            MySqlCommand getUsernameCmd = new MySqlCommand(                         
                $"select username from user where userId = '{_userId}';");
            getUsernameCmd.Connection = DbConnect();
            MySqlDataReader usernameDataReader = getUsernameCmd.ExecuteReader();    
            usernameDataReader.Read();
            SetUsername(usernameDataReader[0].ToString());
        }

        public static int GetUserID()
        {
            return _userId;
        }

        public static string GetUsername()
        {
            return _userName;
        }

        public static void SetUsername(string username)
        {
            _userName = username;
        }
    }
}
