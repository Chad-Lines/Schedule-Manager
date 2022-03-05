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
        BindingList<Appointment> allAppts = DbManager.GetAppointmentsByUserId();
        BindingList<Appointment> visibleAppts = DbManager.GetAppointmentsByUserId();

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
            dgvCalendar.AutoGenerateColumns = false;
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

        private void rdoAll_CheckedChanged(object sender, EventArgs e)      // ALL APPOINTMENTS
        {
            if (rdoAll.Checked == true)
            {
                visibleAppts = allAppts;
                dgvCalendar.DataSource = allAppts;   // Adding the appointment list as the data source
            }
            else
            {
                return;
            }
            
        }

        private void rdoWeek_CheckedChanged(object sender, EventArgs e)     // WEEKLY APPOINTMENTS
        {

            if (rdoWeek.Checked == true)
            {
                DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;                                            // We get the current DateTimeFormatInfo
                System.Globalization.Calendar cal = dfi.Calendar;                                                   // Getting a calendar item (curse me for creating a "Calendar" class!)

                /* +-----------------------------------------------------------------------------------------------+
                 * |                                                                                               |
                 * | REQUIREMENT G: (2/2) Write two or more lambda expressions to make your program more efficient |
                 * |                                                                                               |
                 * +-----------------------------------------------------------------------------------------------+
                 * This lambda expression allows us to filter our appointment list in-line. I considered creating a
                 * separate function to handle this for both the week and month views, but using this lambda is much
                 * more convenient. It simplifies the code, in my oppinion, and reduces the lines of code written 
                 * while remaining readable. 
                 * 
                 * Lambda #1 is in LoginForm.cs. There's another lambda in rdoMonth_CheckedChanged() but it does 
                 * the same thing as this one, except it filters for month (and is thus simpler).
                */
                IEnumerable<Appointment> weeklyAppts = allAppts.Where(                                              // This is where we filter by...
                    a => cal.GetWeekOfYear(DateTime.Parse(a.start), dfi.CalendarWeekRule, dfi.FirstDayOfWeek) ==    // Get the week of the year (int) of the appointment, and...
                         cal.GetWeekOfYear(DateTime.Now, dfi.CalendarWeekRule, dfi.FirstDayOfWeek)                  // compare it agains the current week of the year (int)
                );

                for (int i = 0; i < visibleAppts.Count; i++)
                {
                    visibleAppts.Remove(visibleAppts[i]);
                }
                for (int i = 0; i < weeklyAppts.Count(); i++)
                {
                    visibleAppts.Add(visibleAppts[i]);
                }


                dgvCalendar.DataSource = visibleAppts;                                                               // Finally we add the filtered weekly appointments as the data source
            }
            else
            {
                return;
            }
                                                        
            
            
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

        



        #endregion


    }
}
