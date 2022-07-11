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
        
        public static BindingList<Appointment> appointments = new BindingList<Appointment>();                   // This is the binding list wherein we'll store appointments        
        public static BindingList<Appointment> upcomingAppts = new BindingList<Appointment>();                  // This is the binding list wherein we'll store upcoming appointments
        public static BindingList<Task> tasks = new BindingList<Task>();                                        // This is the binding list wherein we'll store tasks
        public static BindingList<CalendarItem> calendarItems = new BindingList<CalendarItem>();                // This is the binding list wherein we'll store all calendar items
        public static BindingList<Customer> customers = new BindingList<Customer>();                            // This is the binding list wherein we'll store customers
        public static BindingList<AppointmentTypeByMonth> report1 = new BindingList<AppointmentTypeByMonth>();  // This is the binding list wherein we'll store the report data
        public static BindingList<AppointmentTypeByUser> report2 = new BindingList<AppointmentTypeByUser>();    // This is the binding list wherein we'll store the report data
        public static BindingList<ScheduleByUser> report3 = new BindingList<ScheduleByUser>();                  // This is the binding list wherein we'll store the report data

        public static int userId;                                                                               // Stores the user ID
        public static string userName;                                                                          // Stores the user name

        #region Db Admin Functions
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

        public static void FK()
        {
            string query = "set foreign_key_checks=0;";

            using (var command = new MySqlCommand(query, DbConnect()))
            {
                command.ExecuteNonQuery();                              // Executing the query
            }

        }

        public static void DbClose()
        {
            
        }
        #endregion

        public static BindingList<CalendarItem> GetAllCalendarItemsByUserId(int id = -1)
        {
            int outputId;                                                                   // This is the Id that we're going to use to get tasks
            tasks.Clear();                                                                  // Clearing the existing tasks

            // See if tasks are being requested for a different user
            if (id <= -1) { outputId = userId; }                                            // If no id is provided, then we assume that it's fort he current user id
            else { outputId = id; }                                                         // Otherwise we assign the output id to the id that was specified

            DataTable aDt = new DataTable();                                              // We're going to use a DataTable to hold the query results
            DataTable tDt = new DataTable();

            MySqlCommand getAppointmentsByUserIdCmd = new MySqlCommand(                     // Creating the appintments query
                $"select * from appointment where userId = {outputId};",
                DbConnect()                                                                 
            );

           MySqlCommand getTasksByUserIdCmd = new MySqlCommand(                                         // Creating the tasks query
                $"select * from task where userId = {outputId};",
                DbConnect()
            );

            using (DbConnect())                                                             // Using the connection we established...
            {
                using (getAppointmentsByUserIdCmd)                                          // And the query that we defined...
                {
                    MySqlDataReader reader = getAppointmentsByUserIdCmd.ExecuteReader();    // Initialize the data reader
                    aDt.Load(reader);                                                     // Execute the reader and load the data into the DataTable

                    if (aDt.Rows.Count > 0)                                               // If there are rows, then...
                    {
                        foreach (DataRow row in aDt.Rows)                                 // for each row...
                        {
                            Appointment newAppt = new Appointment();                        // Create a new appointment
                            newAppt.Id = (int)row[0];                                       // Set the parameters as appropriate
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

                            calendarItems.Add(newAppt);                      // Finally we add the appointments to the binding list
                        }
                    }
                }
                using (getTasksByUserIdCmd)                                                 // Using  the query that we defined...
                {
                    MySqlDataReader reader = getTasksByUserIdCmd.ExecuteReader();    // Initialize the data reader
                    tDt.Load(reader);                                                     // Execute the reader and load the data into the DataTable

                    if (tDt.Rows.Count > 0)                                               // If there are rows, then...
                    {
                        foreach (DataRow row in tDt.Rows)                                 // for each row...
                        {
                            Task newTask = new Task();              // Create a new task
                            newTask.Id = (int)row[0];               // Set the parameters as appropriate
                            newTask.userId = (int)row[1];
                            newTask.name = (string)row[2];
                            newTask.description = (string)row[3];
                            newTask.status = (string)row[4];
                            newTask.priority = (string)row[5];

                            // We convert the dates into a string. DateTime formatting is a pain, so I'll spell it out ...
                            // MM = Month, dd = day, yyy = Year. For example: "12/31/2018"
                            // hh = hour in 12-hour format (HH for 24-hour format), mmm = minute, tt indicates either AM or PM
                            // For example: "05:00 PM" 
                            // ConvertToLocalTime() returns a local DateTime object derived from specified rows
                            newTask.start = String.Format("{0:MM/dd/yyy hh:mmm tt}", ConvertToLocalTime((DateTime)row[6]));
                            newTask.end = String.Format("{0:MM/dd/yyy hh:mmm tt}", ConvertToLocalTime((DateTime)row[7]));

                            calendarItems.Add(newTask);                      // Finally we add the appointments to the binding list
                        }
                    }
                }
            }
            return calendarItems;
        }

        #region User Functions
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
                    usernameDataReader.Read();
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
        #endregion

        #region Customer Functions
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
            customers.Clear();

            DataTable customersDt = new DataTable();                            // We're going to use a DataTable to hold the query results
            MySqlCommand getAllUsersCmd =
                new MySqlCommand($"select * from customer;", DbConnect());      // Creating the query

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
                            newCust.createDate = (DateTime)row[4];
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

        public static void AddCustomer(Customer c)
        {
            DateTime create = ConvertToUtcTime(c.createDate);                           // Converting the local dates to UTC
            DateTime update = ConvertToUtcTime(c.lastUpdate);

            string query =                                                              // Setting the query to insert the customer
                $"insert into customer (customerName, addressId, " +
                $"active, createDate, createdBy, lastUpdate, " +
                $"lastUpdateBy) " +
                $"values ('{c.customerName}', {c.addressId}, {c.active}, " +
                $"@create, '{c.createdBy}', @update, " +
                $"'{c.lastUpdateBy}');";

            using (var command = new MySqlCommand(query, DbConnect()))                  // Using the command that we create...
            {
                command.Parameters.Add("@create", MySqlDbType.Datetime).Value = create; // Inserting parameters
                command.Parameters.Add("@update", MySqlDbType.Datetime).Value = update;

                command.ExecuteNonQuery();                                              // Execute the command
            }
        }
        
        public static void UpdateCustomer(Customer c)
        {
            DateTime create = ConvertToUtcTime(c.createDate);                           // Converting the local dates to UTC
            DateTime update = ConvertToUtcTime(c.lastUpdate);

            string query =                                                              // The update query. We're kinda brute-forcing it
                $"update customer " +                                                   // but that's okay
                $"set customerName = '{c.customerName}', " +
                    $"addressId = {c.addressId}, " +
                    $"active = {c.active}, " +
                    $"lastUpdate = @update, " +
                    $"lastUpdateBy = '{c.lastUpdateBy}' " +
                $"where customerId = {c.customerId};";

            using (var command = new MySqlCommand(query, DbConnect()))                  // Using the command that we create...
            {
                command.Parameters.Add("@update", MySqlDbType.Datetime).Value = update; // Inserting parameters
                command.ExecuteNonQuery();                                              // Execute the command
            }
        }

        public static void DeleteCustomer(Customer c)
        {
            string query =                                                  // Setting up the query to delete the given appointment
                $"delete from customer " +
                $"where customerId = {c.customerId};";

            using (var command = new MySqlCommand(query, DbConnect()))  // A shortcut to the two 'using' commands I've been using elsewhere
            {
                command.ExecuteNonQuery();                              // Executing the query
            }
        }
        #endregion

        #region Appointment Functions
        public static void AddAppointment(Appointment appt)
        {
            //Provide the ability to automatically adjust appointment times based on user time zones 

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
                            newAppt.Id = (int)row[0];                                       // Set the parameters as appropriate
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
                $"where appointmentId = {a.Id};";

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
        #endregion

        #region Task Functions

        public static void AddTask(Task task)
        {
            //Provide the ability to automatically adjust task times based on user time zones 

            DateTime startDt = ConvertToUtcTime(DateTime.Parse(task.start));                // Here we're (1) converting the start and end strings into
            DateTime endDt = ConvertToUtcTime(DateTime.Parse(task.end));                    // DateTime objects, and then (2) converting them into UTC
                                                                                            // time before we insert them into the database.
            string query =                                                                  // Keep in mind that userName and userId are already populated
                $"insert into task" +                                                       // This is our insert statement
                $"(userid, name, description, status, priority, " +
                $"start, end)" +
                $"values ({userId}, '{task.name}', '{task.description}', " +
                $"'{task.status}', '{task.priority}', @sdate, @edate);";

                using (var command = new MySqlCommand(query, DbConnect()))                  // Using the command that we create...
                {
                    command.Parameters.Add("@sdate", MySqlDbType.Datetime).Value = startDt; // Add in the start date and end date parameters
                    command.Parameters.Add("@edate", MySqlDbType.Datetime).Value = endDt;
                    command.ExecuteNonQuery();                                              // Execute the command
                }

                MessageBox.Show("Task Saved");                                              // Alert the user that the appointment has been saved
        }

        public static void UpdateTask(int taskId, Task task)
        {
            DateTime startDt = ConvertToUtcTime(DateTime.Parse(task.start));    // Here we're (1) converting the start and end strings into
            DateTime endDt = ConvertToUtcTime(DateTime.Parse(task.end));        // DateTime objects, and then (2) converting them into UTC
                                                                                // time before we insert them into the database.
            string query =                                                      // This is our update query
               $"update task " +
               $"set " +
                $"name = '{task.name}', " +
                $"description = '{task.description}', " +
                $"priority = '{task.priority}', " +
                $"status = '{task.status}', " +
                $"end = @edate " +
               $"where taskId = {taskId};";

            using (var command = new MySqlCommand(query, DbConnect()))                  // Using the command that we create...
            {
                command.Parameters.Add("@edate", MySqlDbType.Datetime).Value = endDt;   // Add in the end date parameters
                command.ExecuteNonQuery();                                              // Execute the command
            }

            MessageBox.Show("Task Saved");                                              // Alert the user that the appointment has been saved

        }

        public static BindingList<Task> GetTaskByUserId(int id = -1)
        {
            int outputId;                                           // This is the Id that we're going to use to get tasks
            tasks.Clear();                                          // Clearing the existing tasks

            // See if tasks are being requested for a different user
            if (id <= -1) { outputId = userId; }                    // If no id is provided, then we assume that it's fort he current user id
            else {  outputId = id; }                                // Otherwise we assign the output id to the id that was specified

            DataTable tasksDt = new DataTable();                    // We're going to use a DataTable to hold the query results
            MySqlCommand query = new MySqlCommand(                  // Creating the query
                $"select * from task where userId = {outputId};",
                DbConnect()
            );

            using (DbConnect())                                     // Using the connection we established...
            {
                using (query)                                       // And the query that we defined...
                {
                    MySqlDataReader reader = query.ExecuteReader(); // Initialize the data reader
                    tasksDt.Load(reader);                           // Execute the reader and load the data into the DataTable

                    if (tasksDt.Rows.Count > 0)                     // If there are rows (i.e. if the query returns results), then...
                    {
                        foreach (DataRow row in tasksDt.Rows)
                        {
                            Task newTask = new Task();              // Create a new task
                            newTask.Id = (int)row[0];               // Set the parameters as appropriate
                            newTask.userId = (int)row[1];
                            newTask.name = (string)row[2];
                            newTask.description = (string)row[3];
                            newTask.status = (string)row[4];
                            newTask.priority = (string)row[5];

                            // We convert the dates into a string. DateTime formatting is a pain, so I'll spell it out ...
                            // MM = Month, dd = day, yyy = Year. For example: "12/31/2018"
                            // hh = hour in 12-hour format (HH for 24-hour format), mmm = minute, tt indicates either AM or PM
                            // For example: "05:00 PM" 
                            // ConvertToLocalTime() returns a local DateTime object derived from specified rows
                            newTask.start = String.Format("{0:MM/dd/yyy hh:mmm tt}", ConvertToLocalTime((DateTime)row[6]));
                            newTask.end = String.Format("{0:MM/dd/yyy hh:mmm tt}", ConvertToLocalTime((DateTime)row[7]));

                            tasks.Add(newTask);                     // Finally, we add the task to the binding list                       
                        }
                    }
                }
            }
            return tasks;
        }

        public static void DeleteTask(Task task)
        {
            string query =                                                  // Setting up the query to delete the given appointment
                $"delete from task " +
                $"where taskId = {task.Id};";

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

        #endregion

        #region Country, City, Address Functions
        public static int AddCountry(Country c)
        {
            int cId = GetNextId("country");                                             // Getting the countryId

            DateTime create = ConvertToUtcTime(c.createDate);                           // Converting the local dates to UTC
            DateTime update = ConvertToUtcTime(c.lastUpdate);

            string query =                                                              // Setting the query
                $"insert into country (country, createDate, " +
                $"createdBy, lastUpdate, lastUpdateBy) " +
                $"values ('{c.country}', @create, " +
                $"'{c.createdBy}', @update, '{c.lastUpdateBy}');";

            using (var command = new MySqlCommand(query, DbConnect()))                  // Using the command that we create...
            {
                command.Parameters.Add("@create", MySqlDbType.Datetime).Value = create; // Inserting parameters
                command.Parameters.Add("@update", MySqlDbType.Datetime).Value = update;
                
                command.ExecuteNonQuery();                                              // Execute the command
            }
            return cId;                                                                 // Return the countryId
        }

        public static Country GetCountryById(int id)
        {
            Country c = new Country();                                      // Country object to hold the object we're going to select

            string query = $"select * from country where countryId = {id}"; // The query 

            using (var command = new MySqlCommand(query, DbConnect()))      // Using the command that we create...
            {
                MySqlDataReader r = command.ExecuteReader();                // Capture the query output

                while (r.Read())                                            // While reading the output...
                {
                    c.countryId = Convert.ToInt32(r[0]);                    // Setting the country parameters
                    c.country = r[1].ToString();
                    c.createDate = Convert.ToDateTime(r[2]);
                    c.createdBy = r[3].ToString();
                    c.lastUpdate = Convert.ToDateTime(r[4]);
                    c.lastUpdateBy = r[5].ToString();
                }
            }

            return c;                                                       // Return the country
        }

        public static int AddCity(City c)
        {
            int cId = GetNextId("city");                                // Get the next ID for the city table

            DateTime create = ConvertToUtcTime(c.createDate);           // Converting the local dates to UTC
            DateTime update = ConvertToUtcTime(c.lastUpdate);

            string query =                                              // Setting the query
                $"insert into city (city, countryId, createDate, " +
                $"createdBy, lastUpdate, lastUpdateBy) " +
                $"values ('{c.city}', {c.countryId}, @create, " +
                $"'{c.createdBy}', @update, '{c.lastUpdateBy}');";

            using (var command = new MySqlCommand(query, DbConnect()))  // Using the command that we create...
            {
                command.Parameters.Add("@create", MySqlDbType.Datetime).Value = create; // Inserting parameters
                command.Parameters.Add("@update", MySqlDbType.Datetime).Value = update;

                command.ExecuteNonQuery();                              // Execute the command
            }

            return cId;
        }

        public static City GetCityById(int id)
        {
            City c = new City();                                        // City object to hold the object we're going to select
            string query = $"select * from city where cityId = {id}";   // The query 

            using (var command = new MySqlCommand(query, DbConnect()))  // Using the command that we create...
            {
                MySqlDataReader r = command.ExecuteReader();            // Capture the query output

                while (r.Read())                                        // While reading the output...
                {
                    c.cityId = Convert.ToInt32(r[0]);                   // Setting the city parameters
                    c.city = r[1].ToString();
                    c.countryId = Convert.ToInt32(r[2]);
                    c.createDate = Convert.ToDateTime(r[3]);
                    c.createdBy = r[4].ToString();
                    c.lastUpdate = Convert.ToDateTime(r[5]);
                    c.lastUpdateBy = r[6].ToString();
                }
            }
            return c;                                                   // Return the city
        }

        public static int AddAddress(Address a)
        {
            int aId = GetNextId("address");                                             // Get the next ID for the address table

            DateTime create = ConvertToUtcTime(a.createDate);                           // Converting the local dates to UTC
            DateTime update = ConvertToUtcTime(a.lastUpdate);

            string add2;                                                                // Accounting for there not being a second address string

            if (a.address2 != null) { add2 = a.address2; }
            else { add2 = ""; }

            string query =                                                              // Setting the query
                $"insert into address (address, address2, " +
                    $"cityId, postalCode, phone, createDate, " +
                    $"createdBy, lastUpdate, lastUpdateBy) " +
                $"values ('{a.address}', '{add2}', {a.cityId}, " +
                    $"'{a.postalCode}', '{a.phone}', @create, " +
                    $"'{a.createdBy}', @update, '{a.lastUpdateBy}');"; 

            using (var command = new MySqlCommand(query, DbConnect()))                  // Using the command that we create...
            {
                command.Parameters.Add("@create", MySqlDbType.Datetime).Value = create; // Inserting parameters
                command.Parameters.Add("@update", MySqlDbType.Datetime).Value = update;

                command.ExecuteNonQuery();                                              // Execute the command
            }

            return aId;                                                                 // Return the Address ID
        }

        public static Address GetAddressById(int id)
        {
            Address a = new Address();                                          // Address object to hold the object we're going to select
            string query = $"select * from address where addressId = {id}";     // The query 

            using (var command = new MySqlCommand(query, DbConnect()))          // Using the command that we create...
            {
                MySqlDataReader r = command.ExecuteReader();                    // Capture the query output

                while (r.Read())                                                // While reading the output...
                {
                    a.addressId = Convert.ToInt32(r[0]);                        // Setting the address parameters
                    a.address = r[1].ToString();
                    a.address2 = r[2].ToString();
                    a.cityId = Convert.ToInt32(r[3]);
                    a.postalCode = Int32.Parse((string)r[4]);
                    a.phone = r[5].ToString();
                    a.createDate = Convert.ToDateTime(r[6]);
                    a.createdBy = r[7].ToString();
                    a.lastUpdate = Convert.ToDateTime(r[8]);
                    a.lastUpdateBy = r[9].ToString();
                }                
            }              
            return a;                                                           // Return the address
        }

        #endregion

        #region Report Functions

        public static BindingList<AppointmentTypeByMonth> GetApptTypePerMonth()
        {
            report1.Clear();                                                    // Cleear out the reports BindingList

            DataTable reportDt = new DataTable();                               // We're going to use a DataTable to hold the query results
            MySqlCommand query =                                                // Creating the query
                new MySqlCommand(                                               
                    $"select monthname(start), type, count(type) " +
                    $"from appointment " +
                    $"group by month(start), type", 
                    DbConnect()
                );      

            using (DbConnect())                                     // Using the connection
            {
                using (query)                                       // Using the query we created
                {
                    MySqlDataReader reader = query.ExecuteReader(); // Initialize the data reader
                    reportDt.Load(reader);                          // Execute the reader and load the data into the DataTable

                    if (reportDt.Rows.Count > 0)                    // If there are rows, then...
                    {
                        foreach (DataRow row in reportDt.Rows)      // for each row...
                        {
                            AppointmentTypeByMonth a = new AppointmentTypeByMonth();
                            a.Month = row[0].ToString();
                            a.Type = row[1].ToString();
                            a.Count = Int32.Parse(row[2].ToString());

                            report1.Add(a);
                        }
                    }
                }
            }
            return report1;
        }

        public static BindingList<AppointmentTypeByUser> ApptTypeByUser()
        {
            report2.Clear();                                                    // Cleear out the reports BindingList

            DataTable reportDt = new DataTable();                               // We're going to use a DataTable to hold the query results
            MySqlCommand query =                                                // Creating the query
                new MySqlCommand(
                    $"select userName, type " +
                    $"from user, appointment " +
                    $"where user.userId = appointment.userId " +
                    $"group by type",
                    DbConnect()
                );

            using (DbConnect())                                     // Using the connection
            {
                using (query)                                       // Using the query we created
                {
                    MySqlDataReader reader = query.ExecuteReader(); // Initialize the data reader
                    reportDt.Load(reader);                          // Execute the reader and load the data into the DataTable

                    if (reportDt.Rows.Count > 0)                    // If there are rows, then...
                    {
                        foreach (DataRow row in reportDt.Rows)      // for each row...
                        {
                            AppointmentTypeByUser a = new AppointmentTypeByUser();
                            a.Username = row[0].ToString();
                            a.Type = row[1].ToString();

                            report2.Add(a);
                        }
                    }
                }
            }
            return report2;
        }

        public static BindingList<ScheduleByUser> GetApptByUser(string username)
        {
            report3.Clear();                                                    // Cleear out the reports BindingList
            string un = username.ToLower();                                     // Normalizing the Username

            DataTable reportDt = new DataTable();                               // We're going to use a DataTable to hold the query results
            MySqlCommand query =                                                // Creating the query
                new MySqlCommand(
                    $"select start, end, customerName, type " +
                        $"from appointment, customer, user " +
                    $"where appointment.customerId = customer.customerId " +
                        $"and appointment.userId = user.userId " +
                        $"and userName = '{un}';",
                    DbConnect()
                );
                using (DbConnect())                                                 // Using the connection
                {
                    using (query)                                                   // Using the query we created
                    {
                        MySqlDataReader reader = query.ExecuteReader();             // Initialize the data reader
                        reportDt.Load(reader);                                      // Execute the reader and load the data into the DataTable

                        if (reportDt.Rows.Count > 0)                                // If there are rows, then...
                        {
                            foreach (DataRow row in reportDt.Rows)                  // for each row...
                            {
                                DateTime start = DateTime.Parse(row[0].ToString()); // Converting the start and end times to local times for display
                                DateTime end = DateTime.Parse(row[1].ToString());

                                ScheduleByUser s = new ScheduleByUser();
                                s.start = start;
                                s.end = end;
                                s.customerName = row[2].ToString();
                                s.type = row[3].ToString();

                                report3.Add(s);
                            }
                        }
                        else
                        {
                        MessageBox.Show("Appointments not found.");
                        }
                    }
                }            
            return report3;
        }

        #endregion

        #region Helper Functions
        private static int GetNextId(string table)
        {
            int id = -1;                                                    // Giving id a default value of -1
            string query = $"select max({table}id) from {table}";           // Get the highest index of the supplied table

            try
            {
                using (var command = new MySqlCommand(query, DbConnect()))  // Using the command that we create...
                {
                    MySqlDataReader r = command.ExecuteReader();            // Execute the command
                    while (r.Read())
                    {
                        id = Convert.ToInt32(r[0]);
                        id++;
                        return id;                                      // Add 1 to it and return
                    }
                    r.Close();
                    return id;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return id;
            }


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

        public static void CheckForAppointment()
        {
            // Alert if there is an appointment within 15 minutes of the user’s login

            upcomingAppts.Clear();                                                          // Clearing the existing appointments 

            DataTable appointmentsDt = new DataTable();                                     // We're going to use a DataTable to hold the query results
            MySqlCommand query  = new MySqlCommand(                                         // Creating the query
                $"select * from appointment " +
                $"where start >= now() - interval 15 minute",
                DbConnect()                                                                 // Since DbConnect already returns a connection, we'll use it
                );

            using (DbConnect())                                                             // Using the connection we established...
            {
                using (query)                                                               // And the query that we defined...
                {
                    MySqlDataReader reader = query.ExecuteReader();                         // Initialize the data reader
                    appointmentsDt.Load(reader);                                            // Execute the reader and load the data into the DataTable

                    if (appointmentsDt.Rows.Count > 0)                                      // If there are rows, then...
                    {
                        foreach (DataRow row in appointmentsDt.Rows)                        // for each row...
                        {
                            Appointment newAppt = new Appointment();                        // Create a new appointment
                            newAppt.Id = (int)row[0];                                       // Set the parameters as appropriate
                            newAppt.customerId = (int)row[1];
                            newAppt.customerName = GetCustomerNameById(newAppt.customerId);
                            newAppt.userId = (int)row[1];
                            newAppt.type = row[7].ToString();
                            newAppt.start = String.Format("{0:MM/dd/yyy hh:mmm tt}", 
                                ConvertToLocalTime((DateTime)row[9]));
                            newAppt.end = String.Format("{0:MM/dd/yyy hh:mmm tt}", 
                                ConvertToLocalTime((DateTime)row[10]));

                            upcomingAppts.Add(newAppt);                                     // Finally we add the appointments to the binding list

                            MessageBox.Show($"You have an appointment with " +
                                $"{newAppt.customerName} ({newAppt.start.ToString()})");    // Alerting the user to the upcoming meeting
                        }
                    }
                }
            }
        }

        #endregion
    }
}
