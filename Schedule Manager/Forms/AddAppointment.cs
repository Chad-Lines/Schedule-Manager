using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule_Manager.Forms
{
    public partial class AddAppointment : Form
    {
        private BindingList<Customer> allCustomers;   // This will hold our list of customers

        public AddAppointment()
        {
            InitializeComponent();
            InitializeForm();
        }

        public void InitializeForm()
        {
            // Setting up the BindingList
            if(allCustomers != null) { allCustomers.Clear(); }      // If there are customers in the list, then we clear it to prevent duplicates                                                                    
            allCustomers = DbManager.GetAllCustomers();             // Set allCustomers to the customer list from the database

            // Setting up the Customer Combo Box
            cbCustomers.DataSource = allCustomers;                  // Set the datasource to get all customers from the database
            cbCustomers.DropDownStyle = ComboBoxStyle.DropDownList; // Setting the style like this prevents users from entering new data.
                                                                    // If they need to add a new customer, we want them to use the AddCustomer
                                                                    // form. We provide a link below this box to open that form (see
                                                                    // lnkAddCustomer_LinkClicked())          
            // Setting up the Type Combo Box
            cbType.Items.Add("Scrum");                              // This combo box is much easier. We manuallly add in the types that are                                                                    
            cbType.Items.Add("Presentation");                       // already in use, but we also allow the user to add their own.

            // Setting up the Date Time Pickers
            dtpStart.Format = DateTimePickerFormat.Custom;          // We're going to use a custom format...
            dtpStart.CustomFormat = "MM/dd/yyyy hh:mm tt";          // The custom format is as shown. The 'hh' indicates 12-hour time format
            dtpEnd.Format = DateTimePickerFormat.Custom;            // (HH for 24-hour format), and the 'tt' will show AM/PM
            dtpEnd.CustomFormat = "MM/dd/yyyy hh:mm tt";
        }   

        private void lnkAddCustomer_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            AddCustomer addCust = new AddCustomer();
            addCust.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Customer selectedCustomer = (Customer)cbCustomers.SelectedItem; // Here we're capturing the selected customer as a Customer object
                                                                            // which let's us grab the customerId to associate with the
                                                                            // new appointment

            if (VerifyForm())                                               // Check that the form is valid, and if so...
            {
                Appointment newAppt = new Appointment();                    // Creating the new appointment using user-provided data
                newAppt.customerId = selectedCustomer.customerId;           // Here's where we associate the customerId
                newAppt.type = cbType.Text;                                 // Capture the appointment type
                newAppt.start = dtpStart.Value.ToString();                  // We're capturing these as strings for now. When we send them
                newAppt.end = dtpEnd.Value.ToString();                      // to DbManager, they'll be converted into UTC DateTime objects
                                                                            // It's important to recognize that we're capturing the VALUE of
                                                                            // the DateTime object and not the object itself
            
                DbManager.AddAppointment(newAppt);                          // Saving the new appointment to the database
                Main m = new Main();                                        // Instantiating Main so we can access the updateCalendarView()
                m.updateCalendarView();                                     // Updating the calendar view
                this.Close();                                               // Closing out this form
            }  
            else                                                            // If the form is not valid, then... 
            {
                return;                                                     // Simply do not submit the form
            }
        }

        private bool VerifyForm()
        {
            /* +--------------------------------------------------------------------------------------------------+
             * |                                                                                                  |
             * | REQUIREMENT F: (2/3) You may use the same mechanism of exception control more than once,         |
             * |                but you must incorporate at least two different mechanisms of exception           |
             * |                control.                                                                          |
             * |                                                                                                  |
             * |                [X] Scheduling an appointment outside business hours (1/4 Validation requiremets) |
             * |                [X] Scheduling overlapping appointments (2/4 Validation requiremets)              |
             * |                                                                                                  |
             * |                [x] If/ElseIf/Else                                                                |
             * +--------------------------------------------------------------------------------------------------+
             * 1/2 is in the LoginForm.cs file. 
             * 3/3 is in the AddCustomer.cs file.
             */

            // Check if "Type" has a value
            if (string.IsNullOrWhiteSpace(cbType.Text))
            {
                cbType.BackColor = System.Drawing.Color.Salmon;
                MessageBox.Show("ERROR: Please enter a meeting type");
                return false;
            }
            // Check if the start time is set after the end time
            else if (dtpStart.Value > dtpEnd.Value)
            {
                MessageBox.Show("ERROR: Start time must be before the end time.");
                return false;
            } 
            // Check if appointments are outside of business hours (7AM - 5PM)
            else if (dtpStart.Value.Hour < 7 || dtpStart.Value.Hour > 16 ||
                     dtpEnd.Value.Hour < 7 || dtpEnd.Value.Hour > 16)
            {
                MessageBox.Show("ERROR: Meetings must be scheduled between business hours: 7AM - 5PM");
                return false;
            }

            // Check if the appointment start/end times overlap with another appointments
            foreach (Appointment appt in DbManager.GetAppointmentsByUserId())   
            {
                if (dtpStart.Value > DateTime.Parse(appt.start) && dtpStart.Value < DateTime.Parse(appt.end))
                {
                    MessageBox.Show("ERROR: Cannot schedule overlapping meetings.");
                    return false;
                }
                else if (dtpEnd.Value > DateTime.Parse(appt.start) && dtpEnd.Value < DateTime.Parse(appt.end))
                {
                    MessageBox.Show("ERROR: Cannot schedule overlapping meetings.");
                    return false;
                }
            }

            return true;
        }

        private void cbType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If the cbType box is empty, display it as Salmon. Otherwise, leave it white. 
            if (string.IsNullOrWhiteSpace(cbType.Text)) { cbType.BackColor = System.Drawing.Color.Salmon; }
            else {  cbType.BackColor = System.Drawing.Color.White; }
        }
    }
}
