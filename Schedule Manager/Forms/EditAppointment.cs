﻿using System;
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
        private BindingList<Customer> allCustomers;                         // This will hold our list of customers
        private BindingList<String> allTypes;                               // 
        private Appointment currentAppointment = Main.currentAppointment;   // This is the appointment selected, that we're going to edit

        public EditAppointment(Appointment currentAppointment)
        {
            InitializeComponent();

            // Setting up the BindingList
            if (allCustomers != null) { allCustomers.Clear(); }         // If there are customers in the list, then we clear it to prevent duplicates                                                                    
            allCustomers = DbManager.GetAllCustomers();                 // Set allCustomers to the customer list from the database

            if (allTypes != null) { allTypes.Clear(); }
            allTypes = DbManager.GetAllTypes();

            // Setting up the Customer Combo Box
            cbCustomers.DataSource = allCustomers;                      // Set the datasource to get all customers from the database
            cbCustomers.DropDownStyle = ComboBoxStyle.DropDownList;     // Setting the style like this prevents users from entering new data.
            cbCustomers.Text = currentAppointment.customerName;         //

            cbType.DataSource = allTypes;                               // already in use, but we also allow the user to add their own.
            cbType.Text = currentAppointment.type;

            // Setting up the Date Time Pickers
            dtpStart.Format = DateTimePickerFormat.Custom;              // We're going to use a custom format...
            dtpStart.CustomFormat = "MM/dd/yyyy hh:mm tt";              // The custom format is as shown. The 'hh' indicates 12-hour time format
            dtpEnd.Format = DateTimePickerFormat.Custom;                // (HH for 24-hour format), and the 'tt' will show AM/PM
            dtpEnd.CustomFormat = "MM/dd/yyyy hh:mm tt";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
