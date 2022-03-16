﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace Schedule_Manager.Forms
{
    public partial class AddCustomer : Form
    {

        // Validation Variables
        public bool nameValid = false;
        public bool addressValid = false;
        public bool cityValid = false;
        public bool countryValid = false;
        public bool phoneValid = false;
        public bool zipValid = false;

        public AddCustomer()
        {
            InitializeComponent();
            btnSave.Enabled = false;
        }

        #region Helper Functions
        public bool allowSave()
        {
            if (                    // Checking the validation variables
                nameValid &&
                addressValid &&
                cityValid &&
                countryValid &&
                phoneValid &&
                zipValid
                )      
            {
                return true;        // If they're valid, we enable the Save button
            }
            else                    // If they're not valid...
            {
                return false;       // Keep the Save button disabled
            }
        }

        #endregion

        #region Form Fields

        private void txtName_TextChanged(object sender, EventArgs e)
        {
            // These functions are all similar, so only this one is commented.

            if (String.IsNullOrWhiteSpace(txtName.Text))            // If the text area is empty, then...
            {
                txtName.BackColor = System.Drawing.Color.Salmon;    // Color the field red to indicate that it's required
                nameValid = false;                                  // Set the field variable to invalid so that the user can't save
            }
            else                                                    // If the field is NOT empty, then...
            {
                txtName.BackColor = System.Drawing.Color.White;     // Set the background color to white
                nameValid = true;                                   // And mark the field variable as valid
            }
            btnSave.Enabled = allowSave();                          // Either way, we check if the user can save
        }

        private void txtAddress_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtAddress.Text))
            {
                txtAddress.BackColor = System.Drawing.Color.Salmon;
                addressValid = false;
            }
            else
            {
                txtAddress.BackColor = System.Drawing.Color.White;
                addressValid = true;
            }
            btnSave.Enabled = allowSave();
        }

        private void txtAddress2_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtAddress2.Text))
            {
                txtAddress2.Text = "";
            }
            else
            {
                return;
            }
        }

        private void txtCity_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCity.Text))
            {
                txtCity.BackColor = System.Drawing.Color.Salmon;
                cityValid = false;
            }
            else
            {
                txtCity.BackColor = System.Drawing.Color.White;
                cityValid = true;
            }
            btnSave.Enabled = allowSave();
        }

        private void txtZip_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtZip.Text))
            {
                txtZip.BackColor = System.Drawing.Color.Salmon;
                zipValid = false;
            }
            else
            {
                txtZip.BackColor = System.Drawing.Color.White;
                zipValid = true;
            }
            btnSave.Enabled = allowSave();
        }

        private void txtCountry_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtCountry.Text))
            {
                txtCountry.BackColor = System.Drawing.Color.Salmon;
                countryValid = false;
            }
            else
            {
                txtCountry.BackColor = System.Drawing.Color.White;
                countryValid = true;
            }
            btnSave.Enabled = allowSave();
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtPhone.Text))
            {
                txtPhone.BackColor = System.Drawing.Color.Salmon;
                phoneValid = false;
            }
            else
            {
                txtPhone.BackColor = System.Drawing.Color.White;
                phoneValid = true;
            }
            btnSave.Enabled = allowSave();
        }

        #endregion

        #region Buttons
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string username = DbManager.GetUsername();
            DateTime timestamp = DbManager.ConvertToUtcTime(DateTime.Now);
            string t = timestamp.ToString(); 

            // Setting up the Country
            Country ct = new Country();
            ct.country = txtCountry.Text;
            ct.createDate = timestamp;
            ct.createdBy = DbManager.GetUsername();
            ct.lastUpdate = timestamp;
            ct.lastUpdateBy = DbManager.GetUsername();
            int countryId = DbManager.AddCountry(ct);

            City c = new City();
            c.city = txtCity.Text;
            c.createDate = timestamp;
            c.createdBy = DbManager.GetUsername();
            c.lastUpdate = timestamp;
            c.lastUpdateBy = DbManager.GetUsername();
            c.countryId = countryId;
            int cityId = DbManager.AddCity(c);

            // Setting up the Address
            Address a = new Address();            
            a.address = txtAddress.Text;
            a.address2 = txtAddress2.Text;
            a.postalCode = Int32.Parse(txtZip.Text);
            a.phone = txtPhone.Text;
            a.createDate = timestamp;
            a.createdBy = DbManager.GetUsername();
            a.lastUpdate = timestamp;
            a.lastUpdateBy = DbManager.GetUsername();
            a.cityId = cityId;
            int addressId = DbManager.AddAddress(a);

            // Setting up the Customer
            Customer cust = new Customer();
            cust.customerName = txtName.Text;
            cust.addressId = addressId;
            cust.active = true;
            cust.createdDate = timestamp;
            cust.createdBy = DbManager.GetUsername();
            cust.lastUpdate = timestamp;
            cust.lastUpdateBy = DbManager.GetUsername();

            DbManager.AddCustomer(cust);


        }
        #endregion

        #region Create Functions
        
        
        private void CreateCustomer()
        {
            Customer customer = new Customer();
            customer.customerName = txtName.Text;
            customer.createdDate = DateTime.Now;
            customer.createdBy = DbManager.GetUsername();
            customer.lastUpdate = DateTime.Now;
            customer.lastUpdateBy = DbManager.GetUsername();
        }

        #endregion

        
    }
}
