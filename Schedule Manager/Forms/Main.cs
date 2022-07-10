using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;

namespace Schedule_Manager.Forms
{
    public partial class Main : Form
    {
        BindingList<Appointment> allAppts = DbManager.GetAppointmentsByUserId();                // Holds all appointments
        public static Appointment currentAppointment;                                           // Holds the currently select appointments

        BindingList<Task> allTasks = DbManager.GetTaskByUserId();                               // Holds all Tasks
        public static Task currentTask;                                                         // Holds the currently selected task

        BindingList<CalendarItem> allCalendarItems = DbManager.GetAllCalendarItemsByUserId();   // Holds all calendar items (appointments and tasks)
            
        BindingList<Customer> allCustomers;                                                     // Holds all customers
        public static Customer currentCustomer;                                                 // The current customers
        
        BindingList<string> Report;                                                             // Holds reports

        public bool CheckForMeeting = true;

        #region Initialization

        public Main()
        {
            InitializeComponent();
            InitializeForm();

        }

        private void InitializeForm()
        {
            ConfigureCalendarView();
            UpdateCustomerView();
            UpdateReportView();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #endregion

        #region CalendarTab
        private void ConfigureCalendarView()
        {
            updateCalendarView();
            btnAll.Enabled = false;
        }

        private void btnAddAppointments_Click(object sender, EventArgs e)
        {
            AddAppointment addAppt = new AddAppointment();
            addAppt.Show();
        }

        private void btnEditAppointment_Click(object sender, EventArgs e)
        {
            if (dgvCalendar.CurrentRow.DataBoundItem.GetType() == typeof(Appointment))
            {
                Appointment currentAppointment = (Appointment)dgvCalendar.CurrentRow.DataBoundItem; // Getting the appointment to edit 
                EditAppointment editAppt = new EditAppointment(currentAppointment);                 // Instantiating Edit form
                editAppt.Show();                                                                    // Showing the Edit form
            }
            else
            {
                MessageBox.Show("Please select a calendar item to edit");
            }

        }

        private void btnDeleteAppointment_Click(object sender, EventArgs e)
        {

            if (dgvCalendar.SelectedRows.Count > 0 &&
                dgvCalendar.CurrentRow.DataBoundItem.GetType() == typeof(Appointment))              // If the selected item is valid, then...
            {
                var option = MessageBox.Show("Are you sure you want to delete this appointment?",   // Ask the user to confirm the delete operation
                                "Confirm Delete", MessageBoxButtons.YesNo);

                if (option == DialogResult.Yes)                                                     // Assuming they say Yes, then...
                {
                    try                                                                             // Try to...
                    {
                        Appointment toDeleteAppointment =
                            (Appointment)dgvCalendar.CurrentRow.DataBoundItem;                      // Capture the appointment to delete
                        DbManager.DeleteAppointment(toDeleteAppointment);                           // Delete the appointment
                    }
                    catch (Exception ex)                                                            // If it doesn't work, then...
                    {
                        Console.WriteLine(ex.Message);                                              // Log the error to the console
                    }
                }
                else { return; }                                                                    // If the user answers "No", then don't delete it
            }
            else { MessageBox.Show("Select a calendar item to Delete"); }                            // If the item is not valid, let the user know
            ConfigureCalendarView();                                                                // Reload the calendar view
        }

        private void rdoMonth_CheckedChanged(object sender, EventArgs e)
        {
            IEnumerable<Appointment> appointments = DbManager.GetAppointmentsByUserId();    // We create an IEnumerable so we can easily iterate

            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;                        // We get the current DateTimeFormatInfo
            System.Globalization.Calendar cal = dfi.Calendar;                               // Getting a calendar item (curse me for creating a "Calendar" class!)

            IEnumerable<Appointment> monthlyAppts = appointments.Where(                     // This is where we filter by...
                a => DateTime.Parse(a.start).Month == DateTime.Now.Month                    // compare the month of an appointment against our current month
            );                                                                              // This is much easier than comparing the weeks.    

            dgvCalendar.DataSource = monthlyAppts;                                           // Finally we add the filtered weekly appointments as the data source
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            btnWeek.Enabled = true;
            btnAll.Enabled = false;
            btnMonth.Enabled = true;

            dgvCalendar.DataSource = null;
            dgvCalendar.DataSource = allAppts;   // Adding the appointment list as the data source
        }

        private void btnWeek_Click(object sender, EventArgs e)
        {
            btnWeek.Enabled = false;
            btnAll.Enabled = true;
            btnMonth.Enabled = true;
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;                                            // We get the current DateTimeFormatInfo
            System.Globalization.Calendar cal = dfi.Calendar;                                                   // Getting a calendar item (curse me for creating a "Calendar" class!)

            dgvCalendar.DataSource = null;
            dgvCalendar.DataSource = allAppts.Where(                                                            // This is where we filter by...
                a => cal.GetWeekOfYear(DateTime.Parse(a.start), dfi.CalendarWeekRule, dfi.FirstDayOfWeek) ==    // Get the week of the year (int) of the appointment, and...
                     cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek)                  // compare it agains the current week of the year (int)
            ).ToList();
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            // Button controls
            btnWeek.Enabled = true;
            btnAll.Enabled = true;
            btnMonth.Enabled = false;
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;                // We get the current DateTimeFormatInfo
            System.Globalization.Calendar cal = dfi.Calendar;                       // Getting a calendar item

            dgvCalendar.DataSource = null;
            dgvCalendar.DataSource = allAppts.Where(                                // This is where we filter by...
                a => DateTime.Parse(a.start).Month == DateTime.Now.Month            // Compare the appointment month to the current month
            ).ToList();
        }

        public void updateCalendarView()
        {
            allAppts = DbManager.GetAppointmentsByUserId();                             // Updates the appointments
            allTasks = DbManager.GetTaskByUserId();                                     // Updates the tasks

            // Combing all appointments and all tasks into a single binding list
            foreach (Appointment a in allAppts) { allCalendarItems.Add(a); }            // Add the appointments to allCalendarItems
            foreach (Task t in allTasks) { allCalendarItems.Add(t); }                   // Add the tasks to AllCalendarItems

            // Configuring the DataGridView Source and Parameters
            //dgvCalendar.DataSource = allAppts;                                        // Re-establishes the dgv source
            dgvCalendar.DataSource = allCalendarItems;                                  // Re-establishes the dgv source
            dgvCalendar.AutoGenerateColumns = false;
            dgvCalendar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;        // Full row select (rather than single cells)
            dgvCalendar.ReadOnly = true;                                                // Setting the data to "read only"
            dgvCalendar.MultiSelect = false;                                            // Disabling multi-select
            dgvCalendar.AllowUserToAddRows = false;                                     // Disallow adding new rows

            try
            {
                dgvCalendar.Sort(dgvCalendar.Columns[0], ListSortDirection.Ascending);  // Sorting the calendar by appointment start date
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        #endregion
                
        #region CustomerTab
        public void UpdateCustomerView()
        {
            allCustomers = null;
            allCustomers = DbManager.GetAllCustomers();

            // Configuring the DataGridView Source and Parameters
            dgvCustomer.DataSource = allCustomers;                                  // Re-establishes the dgv source
            dgvCustomer.AutoGenerateColumns = false;
            dgvCustomer.SelectionMode = DataGridViewSelectionMode.FullRowSelect;    // Full row sleect (rather than single cells)
            dgvCustomer.ReadOnly = true;                                            // Setting the data to "read only"
            dgvCustomer.MultiSelect = false;                                        // Disabling multi-select
            dgvCustomer.AllowUserToAddRows = false;                                 // Disallow adding new rows

        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            AddCustomer addCust = new AddCustomer();
            addCust.Show();
        }
        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            Customer cust = (Customer)dgvCustomer.CurrentRow.DataBoundItem;
            EditCustomer editCust = new EditCustomer(cust); 
            editCust.Show();
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            Customer c = (Customer)dgvCustomer.CurrentRow.DataBoundItem;    // Getting the selected customer
            DbManager.DeleteCustomer(c);                                    // Delete the customer
            MessageBox.Show("Customer Deleted");                            // Display that the customer has been deleted
            UpdateCustomerView();                                           // Refresh the customer view
        }
        #endregion

        #region ReportsTab

        public void UpdateReportView()
        {
            dgvReport.DataSource = Report;
        }

        #endregion

        private void btnApptType_Click(object sender, EventArgs e)
        {
            dgvReport.DataSource = DbManager.GetApptTypePerMonth();
        }

        private void btnApptUser_Click(object sender, EventArgs e)
        {
            dgvReport.DataSource = DbManager.ApptTypeByUser();
        }

        private void btnSchedUser_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Please enter the name of a Consultant.");
            }
            else
            {
                string u = txtUsername.Text;
                dgvReport.DataSource = DbManager.GetApptByUser(u);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dgvCalendar.CurrentRow.DataBoundItem.GetType() == typeof(Appointment))
            {
                Appointment currentAppointment = (Appointment)dgvCalendar.CurrentRow.DataBoundItem; // Getting the appointment to edit 
                AppointmentDetail apptDetail = new AppointmentDetail(currentAppointment);                 // Instantiating Edit form
                apptDetail.Show();                                                                    // Showing the Edit form
            }
            else
            {
                MessageBox.Show("Please select a calendar item to view");
            }
        }
    }
}
