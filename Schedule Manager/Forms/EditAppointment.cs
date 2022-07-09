using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Schedule_Manager.Forms
{
    public partial class EditAppointment : Form
    {
        private BindingList<Customer> allCustomers;                                 // This will hold our list of customers
        private BindingList<String> allTypes;                                       // This will hold our list of types (this allows us to add new types)
        private static Appointment currentAppointment = Main.currentAppointment;    // This is the appointment selected, that we're going to edit
        private int apptId;

        public EditAppointment(Appointment currentAppointment)
        {
            InitializeComponent();

            apptId = currentAppointment.Id;

            // Setting up the BindingLists
            if (allCustomers != null) { allCustomers.Clear(); }         
            allCustomers = DbManager.GetAllCustomers();                 

            if (allTypes != null) { allTypes.Clear(); }
            allTypes = DbManager.GetAllTypes();

            // Setting up the Customer Combo Box
            cbCustomers.DataSource = allCustomers;                      
            cbCustomers.DropDownStyle = ComboBoxStyle.DropDownList;     
            cbCustomers.Text = currentAppointment.customerName;         

            // Setting up the Type Combo Box
            cbType.DataSource = allTypes;                               
            cbType.Text = currentAppointment.type;

            // Setting up the Date Time Pickers
            dtpStart.Format = DateTimePickerFormat.Custom;              
            dtpStart.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dtpStart.Value = DateTime.Parse(currentAppointment.start);  // Setting the start time to the currentAppointment start time
            dtpEnd.Format = DateTimePickerFormat.Custom;                
            dtpEnd.CustomFormat = "MM/dd/yyyy hh:mm tt";
            dtpEnd.Value = DateTime.Parse(currentAppointment.end);      // Setting the end time to the currentAppointment end time
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Customer selectedCustomer = (Customer)cbCustomers.SelectedItem;

            if (VerifyForm())                                               // Check that the form is valid, and if so...
            {
                Appointment newAppt = new Appointment();                    // Creating the new appointment using user-provided data
                newAppt.customerId = selectedCustomer.customerId;           // Here's where we associate the customerId
                newAppt.type = cbType.Text;                                 // Capture the appointment type
                newAppt.start = dtpStart.Value.ToString();                  // We're capturing these as strings for now. When we send them
                newAppt.end = dtpEnd.Value.ToString();                      // to DbManager, they'll be converted into UTC DateTime objects
                                                                            // It's important to recognize that we're capturing the VALUE of
                                                                            // the DateTime object and not the object itself

                DbManager.UpdateAppointment(apptId, newAppt);               // Saving the new appointment to the database
                Main m = new Main();                                        // Instantiating Main so we can access the updateCalendarView()
                m.updateCalendarView();                                     // Updating the calendar view
                this.Close();                                               // Closing out this form
            }
            else                                                            // If the form is not valid, then... 
            {
                return;                                                     // simply do not submit the form
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
             * -- This is just a copy-paste of the verification in AddAppointment, so I'm not considering it as
             * -- filling Requirement F
             * 
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

    }
}
