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
    public partial class Main : Form
    {
        

        public Main()
        {
            InitializeComponent();
            InitializeForm();
        }

        private void InitializeForm()
        {
            ConfigureCalendarView();
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        

        #region CalendarTab
        private void ConfigureCalendarView()
        {
            // Selecting the default view
            rdoAll.Checked = true;

            // Configuring the DataGridView Source and Parameters
            dgvCalendar.DataSource = DbManager.GetAppointmentsByUserId();           // Adding the appointment list as the data source
            dgvCalendar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;    // Full row sleect (rather than single cells)
            dgvCalendar.ReadOnly = true;                                            // Setting the data to "read only"
            dgvCalendar.MultiSelect = false;                                        // Disabling multi-select
            dgvCalendar.AllowUserToAddRows = false;                                 // Disallow adding new rows
        }

        private void btnAddAppointments_Click(object sender, EventArgs e)
        {
            AddAppointment addAppt = new AddAppointment();
            addAppt.Show();
        }

        #endregion


    }
}
