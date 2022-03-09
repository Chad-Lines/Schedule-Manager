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
    public partial class AddCustomer : Form
    {

        // Validation Variables
        public bool nameValid = false;


        public AddCustomer()
        {
            InitializeComponent();
        }

        public bool allowSave()
        {
            if (nameValid)                                      // This will hold all of the validation variables...
            {
                return true;                                    // If they're valid, we enable the Save button
            }
            else                                                // If they're not valid...
            {
                return false;                                   // Keep the Save button disabled
            }
        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtName.Text))
            {
                txtName.BackColor = System.Drawing.Color.Salmon;
                nameValid = false;
            }
            else
            {
                txtName.BackColor = System.Drawing.Color.White;
                nameValid = true;
            }
            btnSave.Enabled = allowSave();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
