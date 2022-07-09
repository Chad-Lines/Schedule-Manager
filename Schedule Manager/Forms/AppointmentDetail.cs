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

    public partial class AppointmentDetail : Form
    {
        private static Appointment _appointment;    // Variable to store the current appointment

        public AppointmentDetail(Appointment currentAppointment)
        {
            InitializeComponent();

            // Setting the variable to the current appointment
            _appointment = currentAppointment;      

            // Setting the label values appropriately
            CustomerLabel.Text = _appointment.customerName;
            TypeLabel.Text = _appointment.type;
            StartLabel.Text = _appointment.start.ToString();
            EndLabel.Text = _appointment.end.ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // Instantiating and showing the edit form
            EditAppointment editAppt = new EditAppointment(_appointment);
            this.Close();
            editAppt.Show();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
