using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Schedule_Manager.Forms;

namespace Schedule_Manager
{
    public partial class Calendar : Form
    {
        public Calendar()
        {
            InitializeComponent();
            InitializeForm();

        }

        private void InitializeForm()
        {
            // Creating the other forms, but not initializing. 
            //Customers cust;
            //Reports report;

            btnCalendar.Enabled = false;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
