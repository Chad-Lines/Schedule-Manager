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
            int outputId;                           // This is the id that we're going to use to get appointments
            appointments.Clear();                   // Clearing the existing appointments 
            if (id <= -1) { outputId = userId; }    // If no id is provided, then we assume that it's for the current user id
            else { outputId = id; }                 // Otherwise we assin the output id to the id that was specified

            /* NOTE TO SELF
             * Do some error checking to make sure that an int out of range cannot be used, and will default to the current user
             * and/or throw an error.
             */

            MySqlCommand getAppointmentsByUserIdCmd = new MySqlCommand(                                     // Here's the query we're going to run
                $"select * from appointment;select appointmentId, customerId, type, start, end " +
                $"from appointment where userId = {outputId};"
                );
            getAppointmentsByUserIdCmd.Connection = DbConnect();                                            // We set the connection
            MySqlDataReader appointmentsByUserIdDataReader = getAppointmentsByUserIdCmd.ExecuteReader();    // Setting up the reader
            appointmentsByUserIdDataReader.Read();                                                          // Executing the query

            THIS DOESNT WORK, NEED TO REVISIT

            if (appointmentsByUserIdDataReader.HasRows)                 // If there are rows returned
            {
                foreach (DataRow row in appointmentsByUserIdDataReader) // For each row...
                {
                    Appointment newAppt = new Appointment();            // Create a new appointment
                    newAppt.userId = outputId;                          // Setting the userId
                    newAppt.type = (string)row[2];                      // Setting the type
                    newAppt.start = (DateTime)row[3];                   // Setting the start date and time
                    newAppt.end = (DateTime)row[4];                     // Setting the end date and time

                    appointments.Add(newAppt);                          // Add the new appointment to the appointments list
                }
            }
            else
            {
                Console.WriteLine("No records found.");                 // If there are no rows, then alert
            }
            return appointments;                                        // Return the appointments
        }
    }
}
