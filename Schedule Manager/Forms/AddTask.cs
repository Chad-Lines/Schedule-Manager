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
    public partial class AddTask : Form
    {
        public AddTask()
        {
            InitializeComponent();

            // Setting up the Priority Combo Box options
            cbPriority.Items.Add("Low");                                                                            
            cbPriority.Items.Add("Medium"); 
            cbPriority.Items.Add("High");

            // Setting up the Status Combo Box options
            cbStatus.Items.Add("Up Coming");
            cbStatus.Items.Add("Planning");
            cbStatus.Items.Add("In Progress");
            cbStatus.Items.Add("On Hold");
            cbStatus.Items.Add("Completed");
            cbStatus.Items.Add("Archived");

            dtpEnd.Format = DateTimePickerFormat.Custom;    // (HH for 24-hour format), and the 'tt' will show AM/PM
            dtpEnd.CustomFormat = "MM/dd/yyyy hh:mm tt";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();   // close the form
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            // Verify the form
            if (VerifyForm() == true)
            {
                // Adding the new task based on user-provided data
                Task newTask = new Task();
                newTask.name = tbName.Text;
                newTask.priority = cbPriority.Text;
                newTask.status = cbStatus.Text;
                newTask.start = DateTime.Now.ToString();
                newTask.end = dtpEnd.Value.ToString();
                newTask.description = tbDescription.Text;

                DbManager.AddTask(newTask);                 // Add the new task to the database
                Main m = new Main();                        // Instantiating Main so we can access the updateCalendarView()
                m.updateCalendarView();                     // Updating the calendar view
                this.Close();                               // Closing out this form
            }
            else
            {
                return;
            }

        }

        private bool VerifyForm()
        {
            // Check the name field
            if (string.IsNullOrWhiteSpace(tbName.Text))
            {
                MessageBox.Show("ERROR: Please enter a task name.");
                return false;
            }
            // Check the priority field
            else if (string.IsNullOrWhiteSpace(cbPriority.Text))
            {
                MessageBox.Show("ERROR: Please enter a task name.");
                return false;
            }
            // Check the status field
            else if (string.IsNullOrWhiteSpace(cbStatus.Text))
            {
                MessageBox.Show("ERROR: Please select a status.");
                return false;
            }
            // Check the due date field
            else if (dtpEnd.Value.ToString() == "")
            {
                MessageBox.Show("ERROR: Please select a due date.");
                return false;
            }
            // If all checks are good, then we return true
            else
            {
                return true;
            }            
        }
    }
}
