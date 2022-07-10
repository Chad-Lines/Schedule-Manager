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
    public partial class TaskDetail : Form
    {
        private static Task _task;    // Variable to store the current appointment

        public TaskDetail(Task currentTask)
        {
            InitializeComponent();

            // Setting the variable to the current appointment
            _task = currentTask;

            // Setting the label values appropriately
            NameLabel.Text = _task.name;
            StatusLabel.Text = _task.status;
            PriorityLabel.Text = _task.priority;
            EndLabel.Text = _task.end.ToString();
            DescriptionTextBox.Text = _task.description;
        }        

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Instantiating and showing the edit form
            //EditTask editTask = new EditTask(_task);
            //this.Close();
            //editTask.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Close the page
            this.Close();
        }
    }
}
