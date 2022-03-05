using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.ComponentModel;
using System.Data;

namespace Schedule_Manager
{
    static class DbManager
    {
        // This is the database connection string 
        public static readonly string constr = ConfigurationManager.ConnectionStrings["localdb"].ConnectionString;
        
        public static BindingList<Appointment> appointments = new BindingList<Appointment>();   // This is the binding list wherein we'll store appointements
        private static int userId;                                                              // Stores the user ID
        private static string userName;                                                         // Stores the user name

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
            userId = id;                                                           

            // Based on the user ID we can set the username. Doing so this way helps us prevent
            // the username and user ID not matching up, which may cause issues down the line.
            MySqlCommand getUsernameCmd = new MySqlCommand(                         
                $"select username from user where userId = '{userId}';");
            getUsernameCmd.Connection = DbConnect();
            MySqlDataReader usernameDataReader = getUsernameCmd.ExecuteReader();    
            usernameDataReader.Read();
            SetUsername(usernameDataReader[0].ToString());
        }

        public static int GetUserID()
        {
            return userId;
        }

        public static string GetUsername()
        {
            return userName;
        }

        public static void SetUsername(string username)
        {
            userName = username;
        }

        public static BindingList<Appointment> GetAppointmentsByUserId(int id = -1)
        {
            int outputId;                                                                   // This is the id that we're going to use to get appointments
            appointments.Clear();                                                           // Clearing the existing appointments 

            if (id <= -1) { outputId = userId; }                                            // If no id is provided, then we assume that it's for the current user id
            else { outputId = id; }                                                         // Otherwise we assign the output id to the id that was specified

            DataTable appointmentsDt = new DataTable();                                     // We're going to use a DataTable to hold the query results
            MySqlCommand getAppointmentsByUserIdCmd = new MySqlCommand(                     // Creating the query
                $"select * from appointment;select appointmentId, customerId, " +
                $"type, start, end from appointment where userId = {outputId};",
                DbConnect()                                                                 // Since DbConnect already returns a connection, we'll use it
                );

            using (DbConnect())                                                             // Using the connection we established...
            {           
                using (getAppointmentsByUserIdCmd)                                          // And the query that we defined...
                {
                    //appointmentConn.Open();                                               // Open the connection
                    MySqlDataReader reader = getAppointmentsByUserIdCmd.ExecuteReader();    // Initialize the data reader
                    appointmentsDt.Load(reader);                                            // Execute the reader

                    if (appointmentsDt.Rows.Count > 0)                                      // If there are rows, then...
                    {
                        foreach (DataRow row in appointmentsDt.Rows)                        // for each row...
                        {                            
                            Appointment newAppt = new Appointment();                        // Create a new appointment
                            newAppt.appointmentId = (int)row[0];                            // Set the parameters as appropriate
                            newAppt.customerId = (int)row[1];
                            newAppt.userId = (int)row[1];
                            newAppt.type = row[7].ToString();

                            // We convert the dates into a string. DateTime formatting is a pain, so I'll spell it out ...
                            // MM = Month, dd = day, yyy = Year. For example: "12/31/2018"
                            // hh = hour in 12-hour format (HH for 24-hour format), mmm = minute, tt indicates either AM or PM
                            // For example: "05:00 PM" 
                            // ConvertToLocalTime() returns a local DateTime object derived from specified rows
                            newAppt.start = String.Format("{0:MM/dd/yyy hh:mmm tt}", ConvertToLocalTime((DateTime)row[9]));  
                            newAppt.end = String.Format("{0:MM/dd/yyy hh:mmm tt}", ConvertToLocalTime((DateTime)row[10]));

                            appointments.Add(newAppt);                      // Finally we add the appointments to the binding list
                        }                        
                    }
                }
            }
            return appointments;                                            // Return the binding list
        }

        public static DateTime ConvertToLocalTime(DateTime dt)
        {
            /* +-------------------------------------------------------------------------------------------------------------+
            * |                                                                                                             |
            * | REQUIREMENT E: (1/n) Provide the ability to automatically adjust appointment times based on user time zones |
            * |                                                                                                             |
            * +-------------------------------------------------------------------------------------------------------------+
            */
            DateTime localTime = dt.ToLocalTime();
            return localTime;
        }

        public static DateTime ConvertToUtcTime(DateTime dt)
        {
            /* +-------------------------------------------------------------------------------------------------------------+
            * |                                                                                                             |
            * | REQUIREMENT E: (2/n) Provide the ability to automatically adjust appointment times based on user time zones |
            * |                                                                                                             |
            * +-------------------------------------------------------------------------------------------------------------+
            */
            DateTime dateTime = dt.ToUniversalTime();
            return dateTime;
        }
    }
}
