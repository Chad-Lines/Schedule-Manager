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
    public partial class AddAppointment : Form
    {
        private BindingList<Customer> allCustomers = DbManager.GetAllCustomers();   // Getting our list of customers

        public AddAppointment()
        {
            InitializeComponent();
            InitializeForm();
        }

        public void InitializeForm()
        {
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
            Appointment newAppt = new Appointment();                        // Creating the new appointment using user-provided data
            newAppt.customerId = selectedCustomer.customerId;               // Here's where we associate the customerId
            newAppt.type = cbType.Text;                                     // Capture the appointment type
            newAppt.start = dtpStart.Value.ToString("yyyy-MM-dd H:mm:ss");  // We're capturing these as strings for now. When we send them
            newAppt.end = dtpEnd.Value.ToString("yyyy-MM-dd H:mm:ss");      // to DbManager, they'll be converted into UTC DateTime objects
                                                                            // It's important to recognize that we're capturing the VALUE of
                                                                            // the DateTime object and not the object itself

            DbManager.AddAppointment(newAppt);                              // Saving the new appointment to the database
            Main m = new Main();                                            // Instantiating Main so we can access the updateCalendarView()
            m.updateCalendarView();                                         // Updating the calendar view
            this.Close();                                                   // Closing out this form
        }
    }
}
