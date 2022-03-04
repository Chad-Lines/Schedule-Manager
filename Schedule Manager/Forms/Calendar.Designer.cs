namespace Schedule_Manager
{
    partial class Calendar
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
            System.Windows.Forms.Label label1;
            this.dgvAppointments = new System.Windows.Forms.DataGridView();
            this.btnDeleteAppointment = new System.Windows.Forms.Button();
            this.btnAddAppointments = new System.Windows.Forms.Button();
            this.btnEditAppointment = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnAllAppointments = new System.Windows.Forms.Button();
            this.btnWeekAppointments = new System.Windows.Forms.Button();
            this.btnMonthAppointments = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnReports = new System.Windows.Forms.Button();
            this.btnCustomers = new System.Windows.Forms.Button();
            this.btnCalendar = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            label1.Location = new System.Drawing.Point(247, 12);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(73, 20);
            label1.TabIndex = 9;
            label1.Text = "Calendar";
            // 
            // dgvAppointments
            // 
            this.dgvAppointments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAppointments.Location = new System.Drawing.Point(251, 81);
            this.dgvAppointments.Name = "dgvAppointments";
            this.dgvAppointments.Size = new System.Drawing.Size(802, 469);
            this.dgvAppointments.TabIndex = 1;
            // 
            // btnDeleteAppointment
            // 
            this.btnDeleteAppointment.Location = new System.Drawing.Point(978, 52);
            this.btnDeleteAppointment.Name = "btnDeleteAppointment";
            this.btnDeleteAppointment.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAppointment.TabIndex = 2;
            this.btnDeleteAppointment.Text = "Delete";
            this.btnDeleteAppointment.UseVisualStyleBackColor = true;
            // 
            // btnAddAppointments
            // 
            this.btnAddAppointments.Location = new System.Drawing.Point(816, 52);
            this.btnAddAppointments.Name = "btnAddAppointments";
            this.btnAddAppointments.Size = new System.Drawing.Size(75, 23);
            this.btnAddAppointments.TabIndex = 3;
            this.btnAddAppointments.Text = "Add";
            this.btnAddAppointments.UseVisualStyleBackColor = true;
            // 
            // btnEditAppointment
            // 
            this.btnEditAppointment.Location = new System.Drawing.Point(897, 52);
            this.btnEditAppointment.Name = "btnEditAppointment";
            this.btnEditAppointment.Size = new System.Drawing.Size(75, 23);
            this.btnEditAppointment.TabIndex = 4;
            this.btnEditAppointment.Text = "Edit...";
            this.btnEditAppointment.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(978, 568);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnAllAppointments
            // 
            this.btnAllAppointments.Location = new System.Drawing.Point(251, 52);
            this.btnAllAppointments.Name = "btnAllAppointments";
            this.btnAllAppointments.Size = new System.Drawing.Size(75, 23);
            this.btnAllAppointments.TabIndex = 6;
            this.btnAllAppointments.Text = "All";
            this.btnAllAppointments.UseVisualStyleBackColor = true;
            // 
            // btnWeekAppointments
            // 
            this.btnWeekAppointments.Location = new System.Drawing.Point(332, 52);
            this.btnWeekAppointments.Name = "btnWeekAppointments";
            this.btnWeekAppointments.Size = new System.Drawing.Size(75, 23);
            this.btnWeekAppointments.TabIndex = 7;
            this.btnWeekAppointments.Text = "Week";
            this.btnWeekAppointments.UseVisualStyleBackColor = true;
            // 
            // btnMonthAppointments
            // 
            this.btnMonthAppointments.Location = new System.Drawing.Point(413, 52);
            this.btnMonthAppointments.Name = "btnMonthAppointments";
            this.btnMonthAppointments.Size = new System.Drawing.Size(75, 23);
            this.btnMonthAppointments.TabIndex = 8;
            this.btnMonthAppointments.Text = "Month";
            this.btnMonthAppointments.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnReports);
            this.groupBox1.Controls.Add(this.btnCustomers);
            this.groupBox1.Controls.Add(this.btnCalendar);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(203, 579);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            // 
            // btnReports
            // 
            this.btnReports.Location = new System.Drawing.Point(6, 169);
            this.btnReports.Name = "btnReports";
            this.btnReports.Size = new System.Drawing.Size(191, 44);
            this.btnReports.TabIndex = 13;
            this.btnReports.Text = "Reports";
            this.btnReports.UseVisualStyleBackColor = true;
            // 
            // btnCustomers
            // 
            this.btnCustomers.Location = new System.Drawing.Point(6, 119);
            this.btnCustomers.Name = "btnCustomers";
            this.btnCustomers.Size = new System.Drawing.Size(191, 44);
            this.btnCustomers.TabIndex = 12;
            this.btnCustomers.Text = "Customers";
            this.btnCustomers.UseVisualStyleBackColor = true;
            // 
            // btnCalendar
            // 
            this.btnCalendar.Location = new System.Drawing.Point(6, 69);
            this.btnCalendar.Name = "btnCalendar";
            this.btnCalendar.Size = new System.Drawing.Size(191, 44);
            this.btnCalendar.TabIndex = 11;
            this.btnCalendar.Text = "Calendar";
            this.btnCalendar.UseVisualStyleBackColor = true;
            // 
            // Calendar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1065, 603);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(label1);
            this.Controls.Add(this.btnMonthAppointments);
            this.Controls.Add(this.btnWeekAppointments);
            this.Controls.Add(this.btnAllAppointments);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnEditAppointment);
            this.Controls.Add(this.btnAddAppointments);
            this.Controls.Add(this.btnDeleteAppointment);
            this.Controls.Add(this.dgvAppointments);
            this.Name = "Calendar";
            this.Text = "Calendar";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAppointments)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView dgvAppointments;
        private System.Windows.Forms.Button btnDeleteAppointment;
        private System.Windows.Forms.Button btnAddAppointments;
        private System.Windows.Forms.Button btnEditAppointment;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnAllAppointments;
        private System.Windows.Forms.Button btnWeekAppointments;
        private System.Windows.Forms.Button btnMonthAppointments;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnReports;
        private System.Windows.Forms.Button btnCustomers;
        private System.Windows.Forms.Button btnCalendar;
    }
}

