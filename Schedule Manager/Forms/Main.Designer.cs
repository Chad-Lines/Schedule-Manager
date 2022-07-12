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
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tbTaskSearch = new System.Windows.Forms.TextBox();
            this.btnSearchTasks = new System.Windows.Forms.Button();
            this.tbAppointmentSearch = new System.Windows.Forms.TextBox();
            this.btnSearchAppointments = new System.Windows.Forms.Button();
            this.btnDeleteTask = new System.Windows.Forms.Button();
            this.btnTaskDetail = new System.Windows.Forms.Button();
            this.btnAddTask = new System.Windows.Forms.Button();
            this.btnEditTask = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnDeleteAppointment = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dgvTasks = new System.Windows.Forms.DataGridView();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.start = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.taskId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CIId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.userId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnAddAppointments = new System.Windows.Forms.Button();
            this.btnMonth = new System.Windows.Forms.Button();
            this.btnEditAppointment = new System.Windows.Forms.Button();
            this.btnWeek = new System.Windows.Forms.Button();
            this.btnAll = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvCalendar = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.type = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabCustomers = new System.Windows.Forms.TabPage();
            this.label8 = new System.Windows.Forms.Label();
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
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendar)).BeginInit();
            this.tabCustomers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCustomer)).BeginInit();
            this.tabReports.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReport)).BeginInit();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.IndianRed;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnExit.Location = new System.Drawing.Point(964, 557);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(75, 23);
            this.btnExit.TabIndex = 23;
            this.btnExit.Text = "Exit";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabCalendar);
            this.tabControl1.Controls.Add(this.tabCustomers);
            this.tabControl1.Controls.Add(this.tabReports);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1043, 539);
            this.tabControl1.TabIndex = 14;
            // 
            // tabCalendar
            // 
            this.tabCalendar.BackColor = System.Drawing.Color.White;
            this.tabCalendar.Controls.Add(this.label7);
            this.tabCalendar.Controls.Add(this.label6);
            this.tabCalendar.Controls.Add(this.tbTaskSearch);
            this.tabCalendar.Controls.Add(this.btnSearchTasks);
            this.tabCalendar.Controls.Add(this.tbAppointmentSearch);
            this.tabCalendar.Controls.Add(this.btnSearchAppointments);
            this.tabCalendar.Controls.Add(this.btnDeleteTask);
            this.tabCalendar.Controls.Add(this.btnTaskDetail);
            this.tabCalendar.Controls.Add(this.btnAddTask);
            this.tabCalendar.Controls.Add(this.btnEditTask);
            this.tabCalendar.Controls.Add(this.label4);
            this.tabCalendar.Controls.Add(this.label3);
            this.tabCalendar.Controls.Add(this.btnDeleteAppointment);
            this.tabCalendar.Controls.Add(this.button1);
            this.tabCalendar.Controls.Add(this.dgvTasks);
            this.tabCalendar.Controls.Add(this.btnAddAppointments);
            this.tabCalendar.Controls.Add(this.btnMonth);
            this.tabCalendar.Controls.Add(this.btnEditAppointment);
            this.tabCalendar.Controls.Add(this.btnWeek);
            this.tabCalendar.Controls.Add(this.btnAll);
            this.tabCalendar.Controls.Add(this.label1);
            this.tabCalendar.Controls.Add(this.dgvCalendar);
            this.tabCalendar.Location = new System.Drawing.Point(4, 22);
            this.tabCalendar.Name = "tabCalendar";
            this.tabCalendar.Padding = new System.Windows.Forms.Padding(3);
            this.tabCalendar.Size = new System.Drawing.Size(1035, 513);
            this.tabCalendar.TabIndex = 0;
            this.tabCalendar.Text = "Calendar";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label7.Location = new System.Drawing.Point(910, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(113, 13);
            this.label7.TabIndex = 47;
            this.label7.Text = "Search by Task Name";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label6.Location = new System.Drawing.Point(383, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 13);
            this.label6.TabIndex = 46;
            this.label6.Text = "Search by Customer Name";
            // 
            // tbTaskSearch
            // 
            this.tbTaskSearch.Location = new System.Drawing.Point(904, 66);
            this.tbTaskSearch.Name = "tbTaskSearch";
            this.tbTaskSearch.Size = new System.Drawing.Size(119, 20);
            this.tbTaskSearch.TabIndex = 45;
            // 
            // btnSearchTasks
            // 
            this.btnSearchTasks.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearchTasks.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchTasks.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnSearchTasks.Location = new System.Drawing.Point(847, 64);
            this.btnSearchTasks.Name = "btnSearchTasks";
            this.btnSearchTasks.Size = new System.Drawing.Size(51, 23);
            this.btnSearchTasks.TabIndex = 44;
            this.btnSearchTasks.Text = "Search";
            this.btnSearchTasks.UseVisualStyleBackColor = false;
            this.btnSearchTasks.Click += new System.EventHandler(this.btnSearchTasks_Click);
            // 
            // tbAppointmentSearch
            // 
            this.tbAppointmentSearch.Location = new System.Drawing.Point(397, 66);
            this.tbAppointmentSearch.Name = "tbAppointmentSearch";
            this.tbAppointmentSearch.Size = new System.Drawing.Size(119, 20);
            this.tbAppointmentSearch.TabIndex = 43;
            // 
            // btnSearchAppointments
            // 
            this.btnSearchAppointments.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSearchAppointments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSearchAppointments.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnSearchAppointments.Location = new System.Drawing.Point(340, 64);
            this.btnSearchAppointments.Name = "btnSearchAppointments";
            this.btnSearchAppointments.Size = new System.Drawing.Size(51, 23);
            this.btnSearchAppointments.TabIndex = 24;
            this.btnSearchAppointments.Text = "Search";
            this.btnSearchAppointments.UseVisualStyleBackColor = false;
            this.btnSearchAppointments.Click += new System.EventHandler(this.btnSearchAppointments_Click);
            // 
            // btnDeleteTask
            // 
            this.btnDeleteTask.BackColor = System.Drawing.Color.DarkGray;
            this.btnDeleteTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteTask.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnDeleteTask.Location = new System.Drawing.Point(948, 479);
            this.btnDeleteTask.Name = "btnDeleteTask";
            this.btnDeleteTask.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteTask.TabIndex = 39;
            this.btnDeleteTask.Text = "Delete";
            this.btnDeleteTask.UseVisualStyleBackColor = false;
            this.btnDeleteTask.Click += new System.EventHandler(this.btnDeleteTask_Click);
            // 
            // btnTaskDetail
            // 
            this.btnTaskDetail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTaskDetail.Location = new System.Drawing.Point(786, 479);
            this.btnTaskDetail.Name = "btnTaskDetail";
            this.btnTaskDetail.Size = new System.Drawing.Size(75, 23);
            this.btnTaskDetail.TabIndex = 42;
            this.btnTaskDetail.Text = "View";
            this.btnTaskDetail.UseVisualStyleBackColor = true;
            this.btnTaskDetail.Click += new System.EventHandler(this.btnTaskDetail_Click);
            // 
            // btnAddTask
            // 
            this.btnAddTask.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTask.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnAddTask.Location = new System.Drawing.Point(705, 479);
            this.btnAddTask.Name = "btnAddTask";
            this.btnAddTask.Size = new System.Drawing.Size(75, 23);
            this.btnAddTask.TabIndex = 40;
            this.btnAddTask.Text = "Add";
            this.btnAddTask.UseVisualStyleBackColor = false;
            this.btnAddTask.Click += new System.EventHandler(this.btnAddTask_Click);
            // 
            // btnEditTask
            // 
            this.btnEditTask.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditTask.Location = new System.Drawing.Point(867, 479);
            this.btnEditTask.Name = "btnEditTask";
            this.btnEditTask.Size = new System.Drawing.Size(75, 23);
            this.btnEditTask.TabIndex = 41;
            this.btnEditTask.Text = "Edit...";
            this.btnEditTask.UseVisualStyleBackColor = true;
            this.btnEditTask.Click += new System.EventHandler(this.btnEditTask_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label4.Location = new System.Drawing.Point(720, 28);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 24);
            this.label4.TabIndex = 38;
            this.label4.Text = "Your Tasks";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 16);
            this.label3.TabIndex = 37;
            this.label3.Text = "Sort By:";
            // 
            // btnDeleteAppointment
            // 
            this.btnDeleteAppointment.BackColor = System.Drawing.Color.DarkGray;
            this.btnDeleteAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteAppointment.ForeColor = System.Drawing.SystemColors.Window;
            this.btnDeleteAppointment.Location = new System.Drawing.Point(440, 479);
            this.btnDeleteAppointment.Name = "btnDeleteAppointment";
            this.btnDeleteAppointment.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteAppointment.TabIndex = 25;
            this.btnDeleteAppointment.Text = "Delete";
            this.btnDeleteAppointment.UseVisualStyleBackColor = false;
            this.btnDeleteAppointment.Click += new System.EventHandler(this.btnDeleteAppointment_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(278, 479);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "View";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dgvTasks
            // 
            this.dgvTasks.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvTasks.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTasks.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column16,
            this.start,
            this.taskId,
            this.CIId,
            this.userId,
            this.Column17,
            this.description,
            this.Column18,
            this.Column19});
            this.dgvTasks.GridColor = System.Drawing.SystemColors.Control;
            this.dgvTasks.Location = new System.Drawing.Point(521, 93);
            this.dgvTasks.Name = "dgvTasks";
            this.dgvTasks.Size = new System.Drawing.Size(502, 380);
            this.dgvTasks.TabIndex = 36;
            // 
            // Column16
            // 
            this.Column16.DataPropertyName = "end";
            this.Column16.HeaderText = "Due";
            this.Column16.Name = "Column16";
            this.Column16.Width = 124;
            // 
            // start
            // 
            this.start.DataPropertyName = "start";
            this.start.HeaderText = "start";
            this.start.Name = "start";
            this.start.Visible = false;
            // 
            // taskId
            // 
            this.taskId.DataPropertyName = "taskId";
            this.taskId.HeaderText = "taskId";
            this.taskId.Name = "taskId";
            this.taskId.Visible = false;
            // 
            // CIId
            // 
            this.CIId.DataPropertyName = "Id";
            this.CIId.HeaderText = "CIId";
            this.CIId.Name = "CIId";
            this.CIId.Visible = false;
            // 
            // userId
            // 
            this.userId.DataPropertyName = "userId";
            this.userId.HeaderText = "userId";
            this.userId.Name = "userId";
            this.userId.Visible = false;
            // 
            // Column17
            // 
            this.Column17.DataPropertyName = "name";
            this.Column17.HeaderText = "Task";
            this.Column17.Name = "Column17";
            this.Column17.Width = 130;
            // 
            // description
            // 
            this.description.DataPropertyName = "description";
            this.description.HeaderText = "description";
            this.description.Name = "description";
            this.description.Visible = false;
            // 
            // Column18
            // 
            this.Column18.DataPropertyName = "status";
            this.Column18.HeaderText = "Status";
            this.Column18.Name = "Column18";
            // 
            // Column19
            // 
            this.Column19.DataPropertyName = "priority";
            this.Column19.HeaderText = "Priority";
            this.Column19.Name = "Column19";
            // 
            // btnAddAppointments
            // 
            this.btnAddAppointments.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddAppointments.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAppointments.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnAddAppointments.Location = new System.Drawing.Point(197, 479);
            this.btnAddAppointments.Name = "btnAddAppointments";
            this.btnAddAppointments.Size = new System.Drawing.Size(75, 23);
            this.btnAddAppointments.TabIndex = 26;
            this.btnAddAppointments.Text = "Add";
            this.btnAddAppointments.UseVisualStyleBackColor = false;
            this.btnAddAppointments.Click += new System.EventHandler(this.btnAddAppointments_Click);
            // 
            // btnMonth
            // 
            this.btnMonth.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMonth.Location = new System.Drawing.Point(236, 64);
            this.btnMonth.Name = "btnMonth";
            this.btnMonth.Size = new System.Drawing.Size(75, 23);
            this.btnMonth.TabIndex = 32;
            this.btnMonth.Text = "This Month";
            this.btnMonth.UseVisualStyleBackColor = true;
            this.btnMonth.Click += new System.EventHandler(this.btnMonth_Click);
            // 
            // btnEditAppointment
            // 
            this.btnEditAppointment.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditAppointment.Location = new System.Drawing.Point(359, 479);
            this.btnEditAppointment.Name = "btnEditAppointment";
            this.btnEditAppointment.Size = new System.Drawing.Size(75, 23);
            this.btnEditAppointment.TabIndex = 27;
            this.btnEditAppointment.Text = "Edit...";
            this.btnEditAppointment.UseVisualStyleBackColor = true;
            this.btnEditAppointment.Click += new System.EventHandler(this.btnEditAppointment_Click);
            // 
            // btnWeek
            // 
            this.btnWeek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnWeek.Location = new System.Drawing.Point(155, 64);
            this.btnWeek.Name = "btnWeek";
            this.btnWeek.Size = new System.Drawing.Size(75, 23);
            this.btnWeek.TabIndex = 34;
            this.btnWeek.Text = "This Week";
            this.btnWeek.UseVisualStyleBackColor = true;
            this.btnWeek.Click += new System.EventHandler(this.btnWeek_Click);
            // 
            // btnAll
            // 
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Location = new System.Drawing.Point(74, 64);
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
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label1.Location = new System.Drawing.Point(200, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 24);
            this.label1.TabIndex = 31;
            this.label1.Text = "Your Calendar";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // dgvCalendar
            // 
            this.dgvCalendar.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvCalendar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCalendar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.type,
            this.Id,
            this.Column2,
            this.Column7,
            this.Column4,
            this.Column5,
            this.Column6});
            this.dgvCalendar.GridColor = System.Drawing.SystemColors.Control;
            this.dgvCalendar.Location = new System.Drawing.Point(15, 93);
            this.dgvCalendar.Name = "dgvCalendar";
            this.dgvCalendar.Size = new System.Drawing.Size(500, 380);
            this.dgvCalendar.TabIndex = 24;
            // 
            // Column1
            // 
            this.Column1.DataPropertyName = "start";
            this.Column1.HeaderText = "Start Time";
            this.Column1.Name = "Column1";
            this.Column1.Width = 150;
            // 
            // type
            // 
            this.type.DataPropertyName = "type";
            this.type.HeaderText = "type";
            this.type.Name = "type";
            this.type.Visible = false;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.Visible = false;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "end";
            this.Column2.HeaderText = "End Time";
            this.Column2.Name = "Column2";
            this.Column2.Width = 150;
            // 
            // Column7
            // 
            this.Column7.DataPropertyName = "customerName";
            this.Column7.HeaderText = "Customer";
            this.Column7.Name = "Column7";
            this.Column7.Width = 150;
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
            // tabCustomers
            // 
            this.tabCustomers.BackColor = System.Drawing.Color.White;
            this.tabCustomers.Controls.Add(this.label8);
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
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label8.Location = new System.Drawing.Point(42, 24);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(109, 24);
            this.label8.TabIndex = 26;
            this.label8.Text = "Customers";
            // 
            // dgvCustomer
            // 
            this.dgvCustomer.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
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
            this.dgvCustomer.GridColor = System.Drawing.SystemColors.Control;
            this.dgvCustomer.Location = new System.Drawing.Point(46, 92);
            this.dgvCustomer.Name = "dgvCustomer";
            this.dgvCustomer.Size = new System.Drawing.Size(977, 401);
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
            this.btnEditCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEditCustomer.Location = new System.Drawing.Point(867, 63);
            this.btnEditCustomer.Name = "btnEditCustomer";
            this.btnEditCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnEditCustomer.TabIndex = 18;
            this.btnEditCustomer.Text = "Edit...";
            this.btnEditCustomer.UseVisualStyleBackColor = true;
            this.btnEditCustomer.Click += new System.EventHandler(this.btnEditCustomer_Click);
            // 
            // btnAddCustomer
            // 
            this.btnAddCustomer.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnAddCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddCustomer.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnAddCustomer.Location = new System.Drawing.Point(786, 63);
            this.btnAddCustomer.Name = "btnAddCustomer";
            this.btnAddCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnAddCustomer.TabIndex = 17;
            this.btnAddCustomer.Text = "Add";
            this.btnAddCustomer.UseVisualStyleBackColor = false;
            this.btnAddCustomer.Click += new System.EventHandler(this.btnAddCustomer_Click);
            // 
            // btnDeleteCustomer
            // 
            this.btnDeleteCustomer.BackColor = System.Drawing.Color.DarkGray;
            this.btnDeleteCustomer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteCustomer.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnDeleteCustomer.Location = new System.Drawing.Point(948, 63);
            this.btnDeleteCustomer.Name = "btnDeleteCustomer";
            this.btnDeleteCustomer.Size = new System.Drawing.Size(75, 23);
            this.btnDeleteCustomer.TabIndex = 16;
            this.btnDeleteCustomer.Text = "Delete";
            this.btnDeleteCustomer.UseVisualStyleBackColor = false;
            this.btnDeleteCustomer.Click += new System.EventHandler(this.btnDeleteCustomer_Click);
            // 
            // tabReports
            // 
            this.tabReports.BackColor = System.Drawing.Color.White;
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
            this.label5.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label5.Location = new System.Drawing.Point(641, 46);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(116, 13);
            this.label5.TabIndex = 33;
            this.label5.Text = "Enter Consultant Name";
            // 
            // txtUsername
            // 
            this.txtUsername.Location = new System.Drawing.Point(644, 67);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.Size = new System.Drawing.Size(229, 20);
            this.txtUsername.TabIndex = 32;
            // 
            // dgvReport
            // 
            this.dgvReport.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            this.dgvReport.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReport.GridColor = System.Drawing.SystemColors.Control;
            this.dgvReport.Location = new System.Drawing.Point(46, 93);
            this.dgvReport.Name = "dgvReport";
            this.dgvReport.Size = new System.Drawing.Size(977, 404);
            this.dgvReport.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.WindowFrame;
            this.label2.Location = new System.Drawing.Point(42, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 24);
            this.label2.TabIndex = 29;
            this.label2.Text = "Reports";
            // 
            // btnApptUser
            // 
            this.btnApptUser.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnApptUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApptUser.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnApptUser.Location = new System.Drawing.Point(196, 65);
            this.btnApptUser.Name = "btnApptUser";
            this.btnApptUser.Size = new System.Drawing.Size(144, 23);
            this.btnApptUser.TabIndex = 28;
            this.btnApptUser.Text = "Appt. Types by Consultant";
            this.btnApptUser.UseVisualStyleBackColor = false;
            this.btnApptUser.Click += new System.EventHandler(this.btnApptUser_Click);
            // 
            // btnSchedUser
            // 
            this.btnSchedUser.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSchedUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSchedUser.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnSchedUser.Location = new System.Drawing.Point(879, 64);
            this.btnSchedUser.Name = "btnSchedUser";
            this.btnSchedUser.Size = new System.Drawing.Size(144, 23);
            this.btnSchedUser.TabIndex = 27;
            this.btnSchedUser.Text = "Schedule by Consultant";
            this.btnSchedUser.UseVisualStyleBackColor = false;
            this.btnSchedUser.Click += new System.EventHandler(this.btnSchedUser_Click);
            // 
            // btnApptType
            // 
            this.btnApptType.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnApptType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnApptType.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.btnApptType.Location = new System.Drawing.Point(46, 64);
            this.btnApptType.Name = "btnApptType";
            this.btnApptType.Size = new System.Drawing.Size(144, 23);
            this.btnApptType.TabIndex = 26;
            this.btnApptType.Text = "Appt. Types by Month";
            this.btnApptType.UseVisualStyleBackColor = false;
            this.btnApptType.Click += new System.EventHandler(this.btnApptType_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1067, 595);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.btnExit);
            this.Name = "Main";
            this.Text = "Main";
            this.tabControl1.ResumeLayout(false);
            this.tabCalendar.ResumeLayout(false);
            this.tabCalendar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTasks)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvCalendar)).EndInit();
            this.tabCustomers.ResumeLayout(false);
            this.tabCustomers.PerformLayout();
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
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnDeleteTask;
        private System.Windows.Forms.Button btnTaskDetail;
        private System.Windows.Forms.Button btnAddTask;
        private System.Windows.Forms.Button btnEditTask;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgvTasks;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn start;
        private System.Windows.Forms.DataGridViewTextBoxColumn taskId;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIId;
        private System.Windows.Forms.DataGridViewTextBoxColumn userId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn description;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column19;
        private System.Windows.Forms.TextBox tbTaskSearch;
        private System.Windows.Forms.Button btnSearchTasks;
        private System.Windows.Forms.TextBox tbAppointmentSearch;
        private System.Windows.Forms.Button btnSearchAppointments;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}