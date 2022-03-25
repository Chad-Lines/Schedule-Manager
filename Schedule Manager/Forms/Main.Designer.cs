namespace Schedule_Manager.Forms
{
    partial class Main
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExit = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabCalendar = new System.Windows.Forms.TabPage();
            this.btnMonth = new System.Windows.Forms.Button();
            this.btnWeek = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCalendar = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDeleteAppointment = new System.Windows.Forms.Button();
            this.btnEditAppointment = new System.Windows.Forms.Button();
            this.btnAddAppointments = new System.Windows.Forms.Button();
            this.tabCustomers = new System.Windows.Forms.TabPage();
            this.dgvCustomer = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnEditCustomer = new System.Windows.Forms.Button();
            this.btnAddCustomer = new System.Windows.Forms.Button();
            this.btnDeleteCustomer = new System.Windows.Forms.Button();
            this.tabReports = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.txtUsername = new System.Windows.Forms.TextBox();
            this.dgvReport = new System.Windows.Forms.DataGridView();
            this.label2 = new System.Windows.Forms.Label();
            this.btnApptUser = new System.Windows.Forms.Button();
            this.btnSchedUser = new System.Windows.Forms.Button();
            this.btnApptType = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.tabCalendar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendar)).BeginInit();
            this.tabCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.tabReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(964, 574);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 23;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCalendar);
            this.tabControl1.Controls.Add(this.tabCustomers);
            this.tabControl1.Controls.Add(this.tabReports);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1043, 539);
            this.tabControl1.TabIndex = 14;
            // 
            // tabCalendar
            // 
            this.tabCalendar.BackColor = System.Drawing.Color.Transparent;
            this.tabCalendar.Controls.Add(this.btnMonth);
            this.tabCalendar.Controls.Add(this.btnWeek);
            this.tabCalendar.Controls.Add(this.btnAll);
            this.tabCalendar.Controls.Add(this.label1);
            this.tabCalendar.Controls.Add(this.dgvCalendar);
            this.tabCalendar.Controls.Add(this.btnDeleteAppointment);
            this.tabCalendar.Controls.Add(this.btnEditAppointment);
            this.tabCalendar.Controls.Add(this.btnAddAppointments);
            this.tabCalendar.Location = new System.Drawing.Point(4, 22);
            this.tabCalendar.Name = "tabCalendar";
            this.tabCalendar.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalendar.Size = new System.Drawing.Size(1035, 513);
            this.tabCalendar.TabIndex = 0;
            this.tabCalendar.Text = "Calendar";
            // 
            // btnMonth
            // 
            this.btnMonth.Location = new System.Drawing.Point(177, 61);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(75, 23);
            this.btnMonth.TabIndex = 32;
            this.btnMonth.Text = "This Month";
            this.btnMonth.UseVisualStyleBackColor = true;
            this.btnMonth.Click += new System.EventHandler(this.btnMonth_Click);
            // 
            // btnWeek
            // 
            this.btnWeek.Location = new System.Drawing.Point(96, 61);
            this.btnWeek.Name = "btnWeek";
            this.btnWeek.Size = new System.Drawing.Size(75, 23);
            this.btnWeek.TabIndex = 34;
            this.btnWeek.Text = "This Week";
            this.btnWeek.UseVisualStyleBackColor = true;
            this.btnWeek.Click += new System.EventHandler(this.btnWeek_Click);
            // 
            // btnAll
            // 
            this.btnAll.Location = new System.Drawing.Point(15, 61);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(75, 23);
            this.btnAll.TabIndex = 33;
            this.btnAll.Text = "All";
            this.btnAll.UseVisualStyleBackColor = true;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 24);
            this.label1.TabIndex = 31;
            this.label1.Text = "Your Appointments";
            // 
            // dgvCalendar
            // 
            this.dgvCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalendar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column7,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvCalendar.Location = new System.Drawing.Point(15, 90);
            this.dgvCalendar.Name = "dgvCalendar";
            this.dgvCalendar.Size = new System.Drawing.Size(1008, 417);
            this.dgvCalendar.TabIndex = 24;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "start";
            this.Column1.HeaderText = "Appointment Start";
            this.Column1.Name = "Column1";
            this.Column1.Width = 200;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "end";
            this.Column2.HeaderText = "Appointment End";
            this.Column2.Name = "Column2";
            this.Column2.Width = 200;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "customerName";
            this.Column7.HeaderText = "Customer";
            this.Column7.Name = "Column7";
            this.Column7.Width = 200;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "type";
            this.Column3.HeaderText = "Appointment Type";
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "appointmentId";
            this.Column4.HeaderText = "Appointment ID";
            this.Column4.Name = "Column4";
            this.Column4.Visible = false;
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "customerId";
            this.Column5.HeaderText = "Customer ID";
            this.Column5.Name = "Column5";
            this.Column5.Visible = false;
            // 
            // Column6
            // 
            this.Column6.DataPropertyName = "userId";
            this.Column6.HeaderText = "User ID";
            this.Column6.Name = "Column6";
            this.Column6.Visible = false;
            // 
            // btnDeleteAppointment
            // 
            this.btnDeleteAppointment.Location = new System.Drawing.Point(948, 61);
            this.btnDeleteAppointment.Name = "btnDeleteAppointment";
            this.btnDeleteAppointment.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAppointment.TabIndex = 25;
            this.btnDeleteAppointment.Text = "Delete";
            this.btnDeleteAppointment.UseVisualStyleBackColor = true;
            this.btnDeleteAppointment.Click += new System.EventHandler(this.btnDeleteAppointment_Click);
            // 
            // btnEditAppointment
            // 
            this.btnEditAppointment.Location = new System.Drawing.Point(867, 61);
            this.btnEditAppointment.Name = "btnEditAppointment";
            this.btnEditAppointment.Size = new System.Drawing.Size(75, 23);
            this.btnEditAppointment.TabIndex = 27;
            this.btnEditAppointment.Text = "Edit...";
            this.btnEditAppointment.UseVisualStyleBackColor = true;
            this.btnEditAppointment.Click += new System.EventHandler(this.btnEditAppointment_Click);
            // 
            // btnAddAppointments
            // 
            this.btnAddAppointments.Location = new System.Drawing.Point(786, 61);
            this.btnAddAppointments.Name = "btnAddAppointments";
            this.btnAddAppointments.Size = new System.Drawing.Size(75, 23);
            this.btnAddAppointments.TabIndex = 26;
            this.btnAddAppointments.Text = "Add";
            this.btnAddAppointments.UseVisualStyleBackColor = true;
            this.btnAddAppointments.Click += new System.EventHandler(this.btnAddAppointments_Click);
            // 
            // tabCustomers
            // 
            this.tabCustomers.BackColor = System.Drawing.Color.Transparent;
            this.tabCustomers.Controls.Add(this.dgvCustomer);
            this.tabCustomers.Controls.Add(this.btnEditCustomer);
            this.tabCustomers.Controls.Add(this.btnAddCustomer);
            this.tabCustomers.Controls.Add(this.btnDeleteCustomer);
            this.tabCustomers.Location = new System.Drawing.Point(4, 22);
            this.tabCustomers.Name = "tabCustomers";
            this.tabCustomers.Padding = new System.Windows.Forms.Padding(3);
            this.tabCustomers.Size = new System.Drawing.Size(1035, 513);
            this.tabCustomers.TabIndex = 1;
            this.tabCustomers.Text = "Customers";
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCustomer.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column14,
            this.Column15});
            this.dgvCustomer.Location = new System.Drawing.Point(46, 41);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.Size = new System.Drawing.Size(1008, 469);
            this.dgvCustomer.TabIndex = 25;
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "customerId";
            this.Column8.HeaderText = "customerId";
            this.Column8.Name = "Column8";
            this.Column8.Visible = false;
            // 
            // Column9
            // 
            this.Column9.DataPropertyName = "customerName";
            this.Column9.HeaderText = "Customer Name";
            this.Column9.Name = "Column9";
            this.Column9.Width = 200;
            // 
            // Column10
            // 
            this.Column10.DataPropertyName = "addressId";
            this.Column10.HeaderText = "addressId";
            this.Column10.Name = "Column10";
            this.Column10.Visible = false;
            // 
            // Column11
            // 
            this.Column11.DataPropertyName = "active";
            this.Column11.HeaderText = "Active";
            this.Column11.Name = "Column11";
            this.Column11.Width = 75;
            // 
            // Column12
            // 
            this.Column12.DataPropertyName = "createdDate";
            this.Column12.HeaderText = "Created";
            this.Column12.Name = "Column12";
            // 
            // Column13
            // 
            this.Column13.DataPropertyName = "createdBy";
            this.Column13.HeaderText = "Created By";
            this.Column13.Name = "Column13";
            // 
            // Column14
            // 
            this.Column14.DataPropertyName = "lastUpdate";
            this.Column14.HeaderText = "Last Updated";
            this.Column14.Name = "Column14";
            this.Column14.Visible = false;
            this.Column14.Width = 200;
            // 
            // Column15
            // 
            this.Column15.DataPropertyName = "lastUpdatedBy";
            this.Column15.HeaderText = "Last Update User";
            this.Column15.Name = "Column15";
            this.Column15.Visible = false;
            this.Column15.Width = 200;
            // 
            // btnEditCustomer
            // 
            this.btnEditCustomer.Location = new System.Drawing.Point(867, 9);
            this.btnEditCustomer.Name = "btnEditCustomer";
            this.btnEditCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnEditCustomer.TabIndex = 18;
            this.btnEditCustomer.Text = "Edit...";
            this.btnEditCustomer.UseVisualStyleBackColor = true;
            this.btnEditCustomer.Click += new System.EventHandler(this.btnEditCustomer_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.Location = new System.Drawing.Point(786, 9);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnAddCustomer.TabIndex = 17;
            this.btnAddCustomer.Text = "Add";
            this.btnAddCustomer.UseVisualStyleBackColor = true;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.Location = new System.Drawing.Point(948, 9);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteCustomer.TabIndex = 16;
            this.btnDeleteCustomer.Text = "Delete";
            this.btnDeleteCustomer.UseVisualStyleBackColor = true;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            // 
            // tabReports
            // 
            this.tabReports.BackColor = System.Drawing.Color.Transparent;
            this.tabReports.Controls.Add(this.label5);
            this.tabReports.Controls.Add(this.txtUsername);
            this.tabReports.Controls.Add(this.dgvReport);
            this.tabReports.Controls.Add(this.label2);
            this.tabReports.Controls.Add(this.btnApptUser);
            this.tabReports.Controls.Add(this.btnSchedUser);
            this.tabReports.Controls.Add(this.btnApptType);
            this.tabReports.Location = new System.Drawing.Point(4, 22);
            this.tabReports.Name = "tabReports";
            this.tabReports.Size = new System.Drawing.Size(1035, 513);
            this.tabReports.TabIndex = 2;
            this.tabReports.Text = "Reports";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(641, 28);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Enter Consultant Name";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(644, 44);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(229, 20);
            this.txtUsername.TabIndex = 32;
            // 
            // dgvReport
            // 
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.Location = new System.Drawing.Point(12, 70);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.Size = new System.Drawing.Size(1011, 427);
            this.dgvReport.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(9, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 17);
            this.label2.TabIndex = 29;
            this.label2.Text = "Report Title";
            // 
            // btnApptUser
            // 
            this.btnApptUser.Location = new System.Drawing.Point(162, 41);
            this.btnApptUser.Name = "btnApptUser";
            this.btnApptUser.Size = new System.Drawing.Size(144, 23);
            this.btnApptUser.TabIndex = 28;
            this.btnApptUser.Text = "Appt. Types by Consultant";
            this.btnApptUser.UseVisualStyleBackColor = true;
            this.btnApptUser.Click += new System.EventHandler(this.btnApptUser_Click);
            // 
            // btnSchedUser
            // 
            this.btnSchedUser.Location = new System.Drawing.Point(879, 41);
            this.btnSchedUser.Name = "btnSchedUser";
            this.btnSchedUser.Size = new System.Drawing.Size(144, 23);
            this.btnSchedUser.TabIndex = 27;
            this.btnSchedUser.Text = "Schedule by Consultant";
            this.btnSchedUser.UseVisualStyleBackColor = true;
            this.btnSchedUser.Click += new System.EventHandler(this.btnSchedUser_Click);
            // 
            // btnApptType
            // 
            this.btnApptType.Location = new System.Drawing.Point(12, 41);
            this.btnApptType.Name = "btnApptType";
            this.btnApptType.Size = new System.Drawing.Size(144, 23);
            this.btnApptType.TabIndex = 26;
            this.btnApptType.Text = "Appt. Types by Month";
            this.btnApptType.UseVisualStyleBackColor = true;
            this.btnApptType.Click += new System.EventHandler(this.btnApptType_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 603);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnExit);
            this.Name = "Main";
            this.Text = "Main";
            this.tabControl1.ResumeLayout(false);
            this.tabCalendar.ResumeLayout(false);
            this.tabCalendar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendar)).EndInit();
            this.tabCustomers.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).EndInit();
            this.tabReports.ResumeLayout(false);
            this.tabReports.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabCalendar;
        private System.Windows.Forms.TabPage tabCustomers;
        private System.Windows.Forms.DataGridView dgvCalendar;
        private System.Windows.Forms.Button btnDeleteAppointment;
        private System.Windows.Forms.Button btnEditAppointment;
        private System.Windows.Forms.Button btnAddAppointments;
        private System.Windows.Forms.TabPage tabReports;
        private System.Windows.Forms.DataGridView dgvCustomer;
        private System.Windows.Forms.Button btnEditCustomer;
        private System.Windows.Forms.Button btnAddCustomer;
        private System.Windows.Forms.Button btnDeleteCustomer;
        private System.Windows.Forms.DataGridView dgvReport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnApptUser;
        private System.Windows.Forms.Button btnSchedUser;
        private System.Windows.Forms.Button btnApptType;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnMonth;
        private System.Windows.Forms.Button btnWeek;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtUsername;
    }
}