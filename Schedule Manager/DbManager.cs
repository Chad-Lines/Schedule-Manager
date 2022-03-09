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
        public static BindingList<Customer> customers = new BindingList<Customer>();            // This is the binding list wherein we'll store customers

        private static int userId;                                                              // Stores the user ID
        private static string userName;                                                         // Stores the user name

        public static MySqlConnection DbConnect()
        {
            MySqlConnection conn = new MySqlConnection(constr); // Create the connection using the connection string in the DataBase class
            try
            {
                conn.Open();                                    // Open the database connection
                                                                
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);                      // Display any errors
            }

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
            using (getUsernameCmd.Connection)
            {
                using (usernameDataReader)
                {
                    //usernameDataReader.Read();
                    SetUsername(usernameDataReader[0].ToString());
                }
            }
            
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

        public static string GetCustomerNameById(int id)
        {
            string customerName = "";                                                   // The string to be returned

            MySqlCommand getCustomerNameByIdCmd = new MySqlCommand(                     // Creating the query
                $"select customerName from customer where customerid = {id}",           // The actual query we'll run
                DbConnect()                                                             // Since DbConnect already returns a connection, we'll use it
                );

            using (DbConnect())                                                         // Using the connection...
            {
                using (getCustomerNameByIdCmd)                                          // Using the query...
                {
                    MySqlDataReader reader = getCustomerNameByIdCmd.ExecuteReader();    // Execute the query
                    while (reader.Read())                                               // Reading the results
                    {
                        customerName = reader.GetString(0);                             // Assign the result of cell 0 ot the customerName variable
                    }
                }
            }
            return customerName;                                                        // Return the customerName
        }

        public static BindingList<Customer> GetAllCustomers()
        {
            DataTable customersDt = new DataTable();                            // We're going to use a DataTable to hold the query results
            MySqlCommand getAllUsersCmd =
                new MySqlCommand($"select  from customer;", DbConnect());      // Creating the query

            using (DbConnect())                                                 // Using the connection
            {
                using (getAllUsersCmd)                                          // Using the query we created
                {
                    MySqlDataReader reader = getAllUsersCmd.ExecuteReader();    // Initialize the data reader
                    customersDt.Load(reader);                                   // Execute the reader and load the data into the DataTable

                    if (customersDt.Rows.Count > 0)                             // If there are rows, then...
                    {
                        foreach (DataRow row in customersDt.Rows)               // for each row...
                        {
                            Customer newCust = new Customer();                  // Create the new customer
                            newCust.customerId = (int)row[0];                   // Set the parameters as appropriate
                            newCust.customerName = row[1].ToString();
                            newCust.addressId = (int)row[2];
                            newCust.active = (bool)row[3];
                            newCust.createdDate = (DateTime)row[4];
                            newCust.createdBy = row[5].ToString();
                            newCust.lastUpdate = (DateTime)row[6];
                            newCust.lastUpdateBy = row[7].ToString();

                            customers.Add(newCust);                             // Add the new customers to the customers list
                        }
                    }
                }
            }
            return customers;                                                   // Return the customers list
        }

        public static void AddAppointment(Appointment appt)
        {
            /* +-------------------------------------------------------------------------------------------------------------+
            * |                                                                                                             |
            * | REQUIREMENT E: (3/n) Provide the ability to automatically adjust appointment times based on user time zones |
            * |                                                                                                             |
            * +-------------------------------------------------------------------------------------------------------------+
            */
            DateTime startDt = ConvertToUtcTime(DateTime.Parse(appt.start));    // Here we're (1) converting the start and end strings into
            DateTime endDt = ConvertToUtcTime(DateTime.Parse(appt.end));        // DateTime objects, and then (2) converting them into UTC
                                                                                // time before we insert them into the database.
            int customerId = appt.customerId;                                   // Capture the customer ID
            string type = appt.type;                                            // Capture the appointment type
            string sDefault = "not needed";                                     // This is for the fields that are not unnecessary

            string query =                                                      // Keep in mind that userName and userId are already populated
                $"insert into appointment" +                                    // This is our insert statement
                $"(customerId, userId, title, description, location, contact, " +
                $"type, url, start, end, createDate, createdBy, lastUpdate, lastUpdateBy)" +
                $"values ({customerId}, {userId}, '{sDefault}', '{sDefault}', " +
                $"'{sDefault}', '{sDefault}', '{type}', '{sDefault}', " +
                $" @sdate, @edate, @sdate, '{userName}', @sdate, '{userName}' );";

            using (var command = new MySqlCommand(query, DbConnect()))                  // Using the command that we create...
            {
                command.Parameters.Add("@sdate", MySqlDbType.Datetime).Value = startDt; // Add in the start date and end date parameters
                command.Parameters.Add("@edate", MySqlDbType.Datetime).Value = endDt;
                command.ExecuteNonQuery();                                              // Execute the command
            }

            MessageBox.Show("Appointment Saved");                                       // Alert the user that the appointment has been saved
        }

        public static void UpdateAppointment(int apptId, Appointment appt)
        {
            DateTime startDt = ConvertToUtcTime(DateTime.Parse(appt.start));    // Here we're (1) converting the start and end strings into
            DateTime endDt = ConvertToUtcTime(DateTime.Parse(appt.end));        // DateTime objects, and then (2) converting them into UTC
                                                                                // time before we insert them into the database.
            int customerId = appt.customerId;                                   // Capture the customer ID
            string type = appt.type;                                            // Capture the appointment type
            string query =                                                      // This is our update query
               $"update appointment " +
               $"set " +
                $"customerId = {appt.customerId}," +
                $"type = '{appt.type}'," +
                $"start = @sdate," +
                $"end = @edate " +
               $"where appointmentId = {apptId};";

            using (var command = new MySqlCommand(query, DbConnect()))                  // Using the command that we create...
            {
                command.Parameters.Add("@sdate", MySqlDbType.Datetime).Value = startDt; // Add in the start date and end date parameters
                command.Parameters.Add("@edate", MySqlDbType.Datetime).Value = endDt;
                command.ExecuteNonQuery();                                              // Execute the command
            }

            MessageBox.Show("Appointment Saved");                                       // Alert the user that the appointment has been saved
        }

        public static BindingList<Appointment> GetAppointmentsByUserId(int id = -1)
        {
            int outputId;                                                                   // This is the id that we're going to use to get appointments
            appointments.Clear();                                                           // Clearing the existing appointments 

            if (id <= -1) { outputId = userId; }                                            // If no id is provided, then we assume that it's for the current user id
            else { outputId = id; }                                                         // Otherwise we assign the output id to the id that was specified

            DataTable appointmentsDt = new DataTable();                                     // We're going to use a DataTable to hold the query results
            MySqlCommand getAppointmentsByUserIdCmd = new MySqlCommand(                     // Creating the query
                $"select * from appointment where userId = {outputId};",
                DbConnect()                                                                 // Since DbConnect already returns a connection, we'll use it
                );

            using (DbConnect())                                                             // Using the connection we established...
            {           
                using (getAppointmentsByUserIdCmd)                                          // And the query that we defined...
                {
                    MySqlDataReader reader = getAppointmentsByUserIdCmd.ExecuteReader();    // Initialize the data reader
                    appointmentsDt.Load(reader);                                            // Execute the reader and load the data into the DataTable

                    if (appointmentsDt.Rows.Count > 0)                                      // If there are rows, then...
                    {
                        foreach (DataRow row in appointmentsDt.Rows)                        // for each row...
                        {                            
                            Appointment newAppt = new Appointment();                        // Create a new appointment
                            newAppt.appointmentId = (int)row[0];                            // Set the parameters as appropriate
                            newAppt.customerId = (int)row[1];
                            newAppt.customerName = GetCustomerNameById(newAppt.customerId); 
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

        public static void DeleteAppointment(Appointment a)
        {
            string query =                                                  // Setting up the query to delete the given appointment
                $"delete from appointment " +
                $"where appointmentId = {a.appointmentId};";

            try                                                             // Try to delete the appointment from the database
            {
                using (var command = new MySqlCommand(query, DbConnect()))  // A shortcut to the two 'using' commands I've been using elsewhere
                {
                    command.ExecuteNonQuery();                              // Executing the query
                }
            }
            catch (Exception ex)                                            // If the deletion doesn't work...
            {
                Console.WriteLine(ex.Message);                              // Send the error to the console
            }
            
        }
        
        public static BindingList<String> GetAllTypes()
        {
            BindingList<String> types = new BindingList<String>();
            DataTable typeDt = new DataTable();
            MySqlCommand getDistinctTypeCmd = 
                new MySqlCommand("select distinct type from appointment;",
                DbConnect());

            using (DbConnect())
            {
                using (getDistinctTypeCmd)
                {
                    MySqlDataReader reader = getDistinctTypeCmd.ExecuteReader();
                    typeDt.Load(reader);

                    if (typeDt.Rows.Count > 0)
                    {
                        foreach (DataRow d in typeDt.Rows)
                        {
                            types.Add(d[0].ToString());
                        }
                        
                    }

                }
            }

            return types;
        }
        
        // HELPER FUNCTIONS ---------------------------------------------------------------

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
