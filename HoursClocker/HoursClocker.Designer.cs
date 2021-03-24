
namespace HoursClocker
{
    partial class HoursClocker
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "Specify Date"}, -1, System.Drawing.Color.Empty, System.Drawing.Color.MintCream, null);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem("Specify Beginning and End");
            this.uxNewClockInGroup = new System.Windows.Forms.GroupBox();
            this.uxCurrentTimeTextBox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.uxCancelTime = new System.Windows.Forms.Button();
            this.uxClockOutBtn = new System.Windows.Forms.Button();
            this.uxClockInBtn = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.uxCurrentTimeElapsedTextBox = new System.Windows.Forms.TextBox();
            this.uxPrevHourGroup = new System.Windows.Forms.GroupBox();
            this.uxEndTimePicker = new System.Windows.Forms.DateTimePicker();
            this.uxEndTimeLbl = new System.Windows.Forms.Label();
            this.uxStartTimePicker = new System.Windows.Forms.DateTimePicker();
            this.uxStartTimeLbl = new System.Windows.Forms.Label();
            this.uxListViewOptions = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxMinutesLbl = new System.Windows.Forms.Label();
            this.uxHoursLbl = new System.Windows.Forms.Label();
            this.uxPrevMinuteInputNUD = new System.Windows.Forms.NumericUpDown();
            this.uxPrevHourInputNUD = new System.Windows.Forms.NumericUpDown();
            this.uxStartDatePicker = new System.Windows.Forms.DateTimePicker();
            this.uxEndDatePicker = new System.Windows.Forms.DateTimePicker();
            this.uxEndDateTimeLbl = new System.Windows.Forms.Label();
            this.uxStartDateTimeLbl = new System.Windows.Forms.Label();
            this.uxAddPrevTimeBtn = new System.Windows.Forms.Button();
            this.uxSavedHoursGroup = new System.Windows.Forms.GroupBox();
            this.uxSavedHoursView = new System.Windows.Forms.ListView();
            this.uxInstanceHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxHoursHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxMinutesHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxDateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxGroupsGroup = new System.Windows.Forms.GroupBox();
            this.uxGroupsView = new System.Windows.Forms.ListView();
            this.uxGroupNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxCountHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxTotalTimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label7 = new System.Windows.Forms.Label();
            this.uxGroupNameTextBox = new System.Windows.Forms.TextBox();
            this.uxFormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstriptools = new System.Windows.Forms.ToolStripMenuItem();
            this.uxToggleGroupsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.SystemTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.uxElapsedTimeTimer = new System.Windows.Forms.Timer(this.components);
            this.uxTimeInstanceOptions = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.uxRemoveTime = new System.Windows.Forms.ToolStripMenuItem();
            this.uxNewClockInGroup.SuspendLayout();
            this.uxPrevHourGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxPrevMinuteInputNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxPrevHourInputNUD)).BeginInit();
            this.uxSavedHoursGroup.SuspendLayout();
            this.uxGroupsGroup.SuspendLayout();
            this.uxFormMenuStrip.SuspendLayout();
            this.uxTimeInstanceOptions.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxNewClockInGroup
            // 
            this.uxNewClockInGroup.BackColor = System.Drawing.Color.Honeydew;
            this.uxNewClockInGroup.Controls.Add(this.uxCurrentTimeTextBox);
            this.uxNewClockInGroup.Controls.Add(this.label6);
            this.uxNewClockInGroup.Controls.Add(this.uxCancelTime);
            this.uxNewClockInGroup.Controls.Add(this.uxClockOutBtn);
            this.uxNewClockInGroup.Controls.Add(this.uxClockInBtn);
            this.uxNewClockInGroup.Controls.Add(this.label5);
            this.uxNewClockInGroup.Controls.Add(this.uxCurrentTimeElapsedTextBox);
            this.uxNewClockInGroup.ForeColor = System.Drawing.Color.SeaGreen;
            this.uxNewClockInGroup.Location = new System.Drawing.Point(12, 27);
            this.uxNewClockInGroup.Name = "uxNewClockInGroup";
            this.uxNewClockInGroup.Size = new System.Drawing.Size(275, 177);
            this.uxNewClockInGroup.TabIndex = 0;
            this.uxNewClockInGroup.TabStop = false;
            this.uxNewClockInGroup.Text = "New Clock In";
            // 
            // uxCurrentTimeTextBox
            // 
            this.uxCurrentTimeTextBox.BackColor = System.Drawing.Color.GhostWhite;
            this.uxCurrentTimeTextBox.Enabled = false;
            this.uxCurrentTimeTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCurrentTimeTextBox.ForeColor = System.Drawing.Color.SeaGreen;
            this.uxCurrentTimeTextBox.Location = new System.Drawing.Point(6, 144);
            this.uxCurrentTimeTextBox.Name = "uxCurrentTimeTextBox";
            this.uxCurrentTimeTextBox.ReadOnly = true;
            this.uxCurrentTimeTextBox.Size = new System.Drawing.Size(263, 26);
            this.uxCurrentTimeTextBox.TabIndex = 14;
            this.uxCurrentTimeTextBox.TabStop = false;
            this.uxCurrentTimeTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Ivory;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.SeaGreen;
            this.label6.Location = new System.Drawing.Point(6, 118);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(263, 23);
            this.label6.TabIndex = 13;
            this.label6.Text = "Current System Time";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxCancelTime
            // 
            this.uxCancelTime.BackColor = System.Drawing.Color.Honeydew;
            this.uxCancelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCancelTime.ForeColor = System.Drawing.Color.SeaGreen;
            this.uxCancelTime.Location = new System.Drawing.Point(98, 74);
            this.uxCancelTime.Name = "uxCancelTime";
            this.uxCancelTime.Size = new System.Drawing.Size(77, 34);
            this.uxCancelTime.TabIndex = 12;
            this.uxCancelTime.Text = "Cancel";
            this.uxCancelTime.UseVisualStyleBackColor = false;
            this.uxCancelTime.Click += new System.EventHandler(this.uxCancelTime_Click);
            // 
            // uxClockOutBtn
            // 
            this.uxClockOutBtn.BackColor = System.Drawing.Color.Honeydew;
            this.uxClockOutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxClockOutBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.uxClockOutBtn.Location = new System.Drawing.Point(192, 74);
            this.uxClockOutBtn.Name = "uxClockOutBtn";
            this.uxClockOutBtn.Size = new System.Drawing.Size(77, 34);
            this.uxClockOutBtn.TabIndex = 11;
            this.uxClockOutBtn.Text = "Clock Out";
            this.uxClockOutBtn.UseVisualStyleBackColor = false;
            this.uxClockOutBtn.Click += new System.EventHandler(this.uxClockOutBtn_Click);
            // 
            // uxClockInBtn
            // 
            this.uxClockInBtn.BackColor = System.Drawing.Color.Honeydew;
            this.uxClockInBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxClockInBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.uxClockInBtn.Location = new System.Drawing.Point(6, 74);
            this.uxClockInBtn.Name = "uxClockInBtn";
            this.uxClockInBtn.Size = new System.Drawing.Size(77, 34);
            this.uxClockInBtn.TabIndex = 10;
            this.uxClockInBtn.Text = "Clock In";
            this.uxClockInBtn.UseVisualStyleBackColor = false;
            this.uxClockInBtn.Click += new System.EventHandler(this.uxClockInBtn_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Ivory;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.SeaGreen;
            this.label5.Location = new System.Drawing.Point(6, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(263, 23);
            this.label5.TabIndex = 1;
            this.label5.Text = "Current Elapsed Time";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxCurrentTimeElapsedTextBox
            // 
            this.uxCurrentTimeElapsedTextBox.BackColor = System.Drawing.Color.GhostWhite;
            this.uxCurrentTimeElapsedTextBox.Enabled = false;
            this.uxCurrentTimeElapsedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCurrentTimeElapsedTextBox.ForeColor = System.Drawing.Color.SeaGreen;
            this.uxCurrentTimeElapsedTextBox.Location = new System.Drawing.Point(6, 42);
            this.uxCurrentTimeElapsedTextBox.Name = "uxCurrentTimeElapsedTextBox";
            this.uxCurrentTimeElapsedTextBox.ReadOnly = true;
            this.uxCurrentTimeElapsedTextBox.Size = new System.Drawing.Size(263, 26);
            this.uxCurrentTimeElapsedTextBox.TabIndex = 0;
            this.uxCurrentTimeElapsedTextBox.TabStop = false;
            this.uxCurrentTimeElapsedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uxCurrentTimeElapsedTextBox.Click += new System.EventHandler(this.uxCurrentTimeElapsedTextBox_Click);
            // 
            // uxPrevHourGroup
            // 
            this.uxPrevHourGroup.BackColor = System.Drawing.Color.MintCream;
            this.uxPrevHourGroup.Controls.Add(this.uxEndTimePicker);
            this.uxPrevHourGroup.Controls.Add(this.uxEndTimeLbl);
            this.uxPrevHourGroup.Controls.Add(this.uxStartTimePicker);
            this.uxPrevHourGroup.Controls.Add(this.uxStartTimeLbl);
            this.uxPrevHourGroup.Controls.Add(this.uxListViewOptions);
            this.uxPrevHourGroup.Controls.Add(this.uxMinutesLbl);
            this.uxPrevHourGroup.Controls.Add(this.uxHoursLbl);
            this.uxPrevHourGroup.Controls.Add(this.uxPrevMinuteInputNUD);
            this.uxPrevHourGroup.Controls.Add(this.uxPrevHourInputNUD);
            this.uxPrevHourGroup.Controls.Add(this.uxStartDatePicker);
            this.uxPrevHourGroup.Controls.Add(this.uxEndDatePicker);
            this.uxPrevHourGroup.Controls.Add(this.uxEndDateTimeLbl);
            this.uxPrevHourGroup.Controls.Add(this.uxStartDateTimeLbl);
            this.uxPrevHourGroup.Controls.Add(this.uxAddPrevTimeBtn);
            this.uxPrevHourGroup.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxPrevHourGroup.Location = new System.Drawing.Point(293, 27);
            this.uxPrevHourGroup.Name = "uxPrevHourGroup";
            this.uxPrevHourGroup.Size = new System.Drawing.Size(262, 254);
            this.uxPrevHourGroup.TabIndex = 1;
            this.uxPrevHourGroup.TabStop = false;
            this.uxPrevHourGroup.Text = "Add Previous Hours";
            // 
            // uxEndTimePicker
            // 
            this.uxEndTimePicker.CalendarForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxEndTimePicker.CalendarMonthBackground = System.Drawing.Color.MintCream;
            this.uxEndTimePicker.CalendarTitleBackColor = System.Drawing.Color.SteelBlue;
            this.uxEndTimePicker.CalendarTitleForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxEndTimePicker.CalendarTrailingForeColor = System.Drawing.Color.DarkSlateBlue;
            this.uxEndTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.uxEndTimePicker.Location = new System.Drawing.Point(6, 150);
            this.uxEndTimePicker.Name = "uxEndTimePicker";
            this.uxEndTimePicker.ShowUpDown = true;
            this.uxEndTimePicker.Size = new System.Drawing.Size(248, 20);
            this.uxEndTimePicker.TabIndex = 13;
            // 
            // uxEndTimeLbl
            // 
            this.uxEndTimeLbl.BackColor = System.Drawing.Color.LightCyan;
            this.uxEndTimeLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxEndTimeLbl.Location = new System.Drawing.Point(6, 134);
            this.uxEndTimeLbl.Name = "uxEndTimeLbl";
            this.uxEndTimeLbl.Size = new System.Drawing.Size(248, 13);
            this.uxEndTimeLbl.TabIndex = 12;
            this.uxEndTimeLbl.Text = "End Time";
            this.uxEndTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxStartTimePicker
            // 
            this.uxStartTimePicker.CalendarForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxStartTimePicker.CalendarMonthBackground = System.Drawing.Color.MintCream;
            this.uxStartTimePicker.CalendarTitleBackColor = System.Drawing.Color.SteelBlue;
            this.uxStartTimePicker.CalendarTitleForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxStartTimePicker.CalendarTrailingForeColor = System.Drawing.Color.DarkSlateBlue;
            this.uxStartTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.uxStartTimePicker.Location = new System.Drawing.Point(6, 111);
            this.uxStartTimePicker.Name = "uxStartTimePicker";
            this.uxStartTimePicker.ShowUpDown = true;
            this.uxStartTimePicker.Size = new System.Drawing.Size(248, 20);
            this.uxStartTimePicker.TabIndex = 11;
            // 
            // uxStartTimeLbl
            // 
            this.uxStartTimeLbl.BackColor = System.Drawing.Color.LightCyan;
            this.uxStartTimeLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxStartTimeLbl.Location = new System.Drawing.Point(6, 95);
            this.uxStartTimeLbl.Name = "uxStartTimeLbl";
            this.uxStartTimeLbl.Size = new System.Drawing.Size(248, 13);
            this.uxStartTimeLbl.TabIndex = 10;
            this.uxStartTimeLbl.Text = "Start Time";
            this.uxStartTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxListViewOptions
            // 
            this.uxListViewOptions.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.uxListViewOptions.AutoArrange = false;
            this.uxListViewOptions.BackColor = System.Drawing.Color.MintCream;
            this.uxListViewOptions.CheckBoxes = true;
            this.uxListViewOptions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.uxListViewOptions.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxListViewOptions.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxListViewOptions.GridLines = true;
            this.uxListViewOptions.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.uxListViewOptions.HideSelection = false;
            listViewItem7.Checked = true;
            listViewItem7.StateImageIndex = 1;
            listViewItem8.Checked = true;
            listViewItem8.StateImageIndex = 1;
            this.uxListViewOptions.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem7,
            listViewItem8});
            this.uxListViewOptions.Location = new System.Drawing.Point(6, 19);
            this.uxListViewOptions.Name = "uxListViewOptions";
            this.uxListViewOptions.Scrollable = false;
            this.uxListViewOptions.ShowGroups = false;
            this.uxListViewOptions.Size = new System.Drawing.Size(155, 34);
            this.uxListViewOptions.TabIndex = 4;
            this.uxListViewOptions.UseCompatibleStateImageBehavior = false;
            this.uxListViewOptions.View = System.Windows.Forms.View.Details;
            this.uxListViewOptions.ItemChecked += new System.Windows.Forms.ItemCheckedEventHandler(this.uxListViewOptions_ItemChecked);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 300;
            // 
            // uxMinutesLbl
            // 
            this.uxMinutesLbl.BackColor = System.Drawing.Color.LightCyan;
            this.uxMinutesLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxMinutesLbl.Location = new System.Drawing.Point(131, 56);
            this.uxMinutesLbl.Name = "uxMinutesLbl";
            this.uxMinutesLbl.Size = new System.Drawing.Size(120, 13);
            this.uxMinutesLbl.TabIndex = 9;
            this.uxMinutesLbl.Text = "Minutes";
            this.uxMinutesLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxHoursLbl
            // 
            this.uxHoursLbl.BackColor = System.Drawing.Color.LightCyan;
            this.uxHoursLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxHoursLbl.Location = new System.Drawing.Point(6, 56);
            this.uxHoursLbl.Name = "uxHoursLbl";
            this.uxHoursLbl.Size = new System.Drawing.Size(122, 13);
            this.uxHoursLbl.TabIndex = 8;
            this.uxHoursLbl.Text = "Hours";
            this.uxHoursLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxPrevMinuteInputNUD
            // 
            this.uxPrevMinuteInputNUD.BackColor = System.Drawing.Color.MintCream;
            this.uxPrevMinuteInputNUD.Location = new System.Drawing.Point(134, 72);
            this.uxPrevMinuteInputNUD.Maximum = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.uxPrevMinuteInputNUD.Name = "uxPrevMinuteInputNUD";
            this.uxPrevMinuteInputNUD.Size = new System.Drawing.Size(120, 20);
            this.uxPrevMinuteInputNUD.TabIndex = 7;
            this.uxPrevMinuteInputNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uxPrevMinuteInputNUD.ThousandsSeparator = true;
            // 
            // uxPrevHourInputNUD
            // 
            this.uxPrevHourInputNUD.BackColor = System.Drawing.Color.MintCream;
            this.uxPrevHourInputNUD.Location = new System.Drawing.Point(6, 72);
            this.uxPrevHourInputNUD.Maximum = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.uxPrevHourInputNUD.Name = "uxPrevHourInputNUD";
            this.uxPrevHourInputNUD.Size = new System.Drawing.Size(122, 20);
            this.uxPrevHourInputNUD.TabIndex = 6;
            this.uxPrevHourInputNUD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.uxPrevHourInputNUD.ThousandsSeparator = true;
            // 
            // uxStartDatePicker
            // 
            this.uxStartDatePicker.CalendarForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxStartDatePicker.CalendarMonthBackground = System.Drawing.Color.MintCream;
            this.uxStartDatePicker.CalendarTitleBackColor = System.Drawing.Color.SteelBlue;
            this.uxStartDatePicker.CalendarTitleForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxStartDatePicker.CalendarTrailingForeColor = System.Drawing.Color.DarkSlateBlue;
            this.uxStartDatePicker.Location = new System.Drawing.Point(6, 189);
            this.uxStartDatePicker.Name = "uxStartDatePicker";
            this.uxStartDatePicker.Size = new System.Drawing.Size(248, 20);
            this.uxStartDatePicker.TabIndex = 5;
            // 
            // uxEndDatePicker
            // 
            this.uxEndDatePicker.CalendarForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxEndDatePicker.CalendarMonthBackground = System.Drawing.Color.MintCream;
            this.uxEndDatePicker.CalendarTitleBackColor = System.Drawing.Color.SteelBlue;
            this.uxEndDatePicker.CalendarTitleForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxEndDatePicker.CalendarTrailingForeColor = System.Drawing.Color.DarkSlateBlue;
            this.uxEndDatePicker.Location = new System.Drawing.Point(6, 228);
            this.uxEndDatePicker.Name = "uxEndDatePicker";
            this.uxEndDatePicker.Size = new System.Drawing.Size(248, 20);
            this.uxEndDatePicker.TabIndex = 4;
            // 
            // uxEndDateTimeLbl
            // 
            this.uxEndDateTimeLbl.BackColor = System.Drawing.Color.LightCyan;
            this.uxEndDateTimeLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxEndDateTimeLbl.Location = new System.Drawing.Point(6, 212);
            this.uxEndDateTimeLbl.Name = "uxEndDateTimeLbl";
            this.uxEndDateTimeLbl.Size = new System.Drawing.Size(248, 13);
            this.uxEndDateTimeLbl.TabIndex = 3;
            this.uxEndDateTimeLbl.Text = "End Date";
            this.uxEndDateTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxStartDateTimeLbl
            // 
            this.uxStartDateTimeLbl.BackColor = System.Drawing.Color.LightCyan;
            this.uxStartDateTimeLbl.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxStartDateTimeLbl.Location = new System.Drawing.Point(6, 173);
            this.uxStartDateTimeLbl.Name = "uxStartDateTimeLbl";
            this.uxStartDateTimeLbl.Size = new System.Drawing.Size(248, 13);
            this.uxStartDateTimeLbl.TabIndex = 2;
            this.uxStartDateTimeLbl.Text = "Start Date";
            this.uxStartDateTimeLbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxAddPrevTimeBtn
            // 
            this.uxAddPrevTimeBtn.BackColor = System.Drawing.Color.MintCream;
            this.uxAddPrevTimeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxAddPrevTimeBtn.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxAddPrevTimeBtn.Location = new System.Drawing.Point(167, 19);
            this.uxAddPrevTimeBtn.Name = "uxAddPrevTimeBtn";
            this.uxAddPrevTimeBtn.Size = new System.Drawing.Size(87, 34);
            this.uxAddPrevTimeBtn.TabIndex = 1;
            this.uxAddPrevTimeBtn.Text = "Finalize";
            this.uxAddPrevTimeBtn.UseVisualStyleBackColor = false;
            this.uxAddPrevTimeBtn.Click += new System.EventHandler(this.uxAddPrevTimeBtn_Click);
            // 
            // uxSavedHoursGroup
            // 
            this.uxSavedHoursGroup.BackColor = System.Drawing.Color.MistyRose;
            this.uxSavedHoursGroup.Controls.Add(this.uxSavedHoursView);
            this.uxSavedHoursGroup.ForeColor = System.Drawing.Color.Maroon;
            this.uxSavedHoursGroup.Location = new System.Drawing.Point(12, 464);
            this.uxSavedHoursGroup.Name = "uxSavedHoursGroup";
            this.uxSavedHoursGroup.Size = new System.Drawing.Size(543, 168);
            this.uxSavedHoursGroup.TabIndex = 2;
            this.uxSavedHoursGroup.TabStop = false;
            this.uxSavedHoursGroup.Text = "Saved Hours";
            // 
            // uxSavedHoursView
            // 
            this.uxSavedHoursView.BackColor = System.Drawing.Color.SeaShell;
            this.uxSavedHoursView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uxInstanceHeader,
            this.uxHoursHeader,
            this.uxMinutesHeader,
            this.uxDateHeader});
            this.uxSavedHoursView.ContextMenuStrip = this.uxTimeInstanceOptions;
            this.uxSavedHoursView.ForeColor = System.Drawing.Color.Maroon;
            this.uxSavedHoursView.FullRowSelect = true;
            this.uxSavedHoursView.GridLines = true;
            this.uxSavedHoursView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.uxSavedHoursView.HideSelection = false;
            this.uxSavedHoursView.Location = new System.Drawing.Point(6, 19);
            this.uxSavedHoursView.Name = "uxSavedHoursView";
            this.uxSavedHoursView.Size = new System.Drawing.Size(526, 143);
            this.uxSavedHoursView.TabIndex = 0;
            this.uxSavedHoursView.UseCompatibleStateImageBehavior = false;
            this.uxSavedHoursView.View = System.Windows.Forms.View.Details;
            // 
            // uxInstanceHeader
            // 
            this.uxInstanceHeader.Text = "Instance";
            this.uxInstanceHeader.Width = 122;
            // 
            // uxHoursHeader
            // 
            this.uxHoursHeader.Text = "Hours";
            this.uxHoursHeader.Width = 112;
            // 
            // uxMinutesHeader
            // 
            this.uxMinutesHeader.Text = "Minutes";
            this.uxMinutesHeader.Width = 114;
            // 
            // uxDateHeader
            // 
            this.uxDateHeader.Text = "Date";
            this.uxDateHeader.Width = 128;
            // 
            // uxGroupsGroup
            // 
            this.uxGroupsGroup.BackColor = System.Drawing.Color.Lavender;
            this.uxGroupsGroup.Controls.Add(this.uxGroupsView);
            this.uxGroupsGroup.Controls.Add(this.label7);
            this.uxGroupsGroup.Controls.Add(this.uxGroupNameTextBox);
            this.uxGroupsGroup.ForeColor = System.Drawing.Color.Indigo;
            this.uxGroupsGroup.Location = new System.Drawing.Point(12, 287);
            this.uxGroupsGroup.Name = "uxGroupsGroup";
            this.uxGroupsGroup.Size = new System.Drawing.Size(543, 171);
            this.uxGroupsGroup.TabIndex = 1;
            this.uxGroupsGroup.TabStop = false;
            this.uxGroupsGroup.Text = "Groups";
            // 
            // uxGroupsView
            // 
            this.uxGroupsView.BackColor = System.Drawing.Color.LavenderBlush;
            this.uxGroupsView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uxGroupNameHeader,
            this.uxCountHeader,
            this.uxTotalTimeHeader});
            this.uxGroupsView.ForeColor = System.Drawing.Color.Indigo;
            this.uxGroupsView.GridLines = true;
            this.uxGroupsView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.uxGroupsView.HideSelection = false;
            this.uxGroupsView.LabelEdit = true;
            this.uxGroupsView.Location = new System.Drawing.Point(6, 68);
            this.uxGroupsView.Name = "uxGroupsView";
            this.uxGroupsView.Size = new System.Drawing.Size(531, 97);
            this.uxGroupsView.TabIndex = 2;
            this.uxGroupsView.UseCompatibleStateImageBehavior = false;
            this.uxGroupsView.View = System.Windows.Forms.View.Details;
            // 
            // uxGroupNameHeader
            // 
            this.uxGroupNameHeader.Text = "Name";
            this.uxGroupNameHeader.Width = 193;
            // 
            // uxCountHeader
            // 
            this.uxCountHeader.Text = "Time Count";
            this.uxCountHeader.Width = 113;
            // 
            // uxTotalTimeHeader
            // 
            this.uxTotalTimeHeader.Text = "Total Time";
            this.uxTotalTimeHeader.Width = 97;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.LavenderBlush;
            this.label7.ForeColor = System.Drawing.Color.Indigo;
            this.label7.Location = new System.Drawing.Point(6, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(531, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "Current Group Name";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // uxGroupNameTextBox
            // 
            this.uxGroupNameTextBox.BackColor = System.Drawing.Color.GhostWhite;
            this.uxGroupNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxGroupNameTextBox.ForeColor = System.Drawing.Color.Indigo;
            this.uxGroupNameTextBox.Location = new System.Drawing.Point(6, 36);
            this.uxGroupNameTextBox.Name = "uxGroupNameTextBox";
            this.uxGroupNameTextBox.Size = new System.Drawing.Size(531, 26);
            this.uxGroupNameTextBox.TabIndex = 0;
            this.uxGroupNameTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // uxFormMenuStrip
            // 
            this.uxFormMenuStrip.BackColor = System.Drawing.Color.GhostWhite;
            this.uxFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolstriptools});
            this.uxFormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.uxFormMenuStrip.Name = "uxFormMenuStrip";
            this.uxFormMenuStrip.Size = new System.Drawing.Size(567, 24);
            this.uxFormMenuStrip.TabIndex = 3;
            this.uxFormMenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.ForeColor = System.Drawing.Color.Black;
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // toolstriptools
            // 
            this.toolstriptools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxToggleGroupsBtn});
            this.toolstriptools.ForeColor = System.Drawing.Color.Black;
            this.toolstriptools.Name = "toolstriptools";
            this.toolstriptools.Size = new System.Drawing.Size(46, 20);
            this.toolstriptools.Text = "Tools";
            // 
            // uxToggleGroupsBtn
            // 
            this.uxToggleGroupsBtn.BackColor = System.Drawing.Color.Transparent;
            this.uxToggleGroupsBtn.ForeColor = System.Drawing.Color.Black;
            this.uxToggleGroupsBtn.Name = "uxToggleGroupsBtn";
            this.uxToggleGroupsBtn.Size = new System.Drawing.Size(150, 22);
            this.uxToggleGroupsBtn.Text = "Toggle Groups";
            this.uxToggleGroupsBtn.Click += new System.EventHandler(this.uxToggleGroupsBtn_Click);
            // 
            // SystemTimeTimer
            // 
            this.SystemTimeTimer.Interval = 1000;
            this.SystemTimeTimer.Tick += new System.EventHandler(this.SystemTimeTimer_Tick);
            // 
            // uxElapsedTimeTimer
            // 
            this.uxElapsedTimeTimer.Interval = 250;
            this.uxElapsedTimeTimer.Tick += new System.EventHandler(this.uxElapsedTimeTimer_Tick);
            // 
            // uxTimeInstanceOptions
            // 
            this.uxTimeInstanceOptions.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uxRemoveTime});
            this.uxTimeInstanceOptions.Name = "uxTimeInstanceOptions";
            this.uxTimeInstanceOptions.Size = new System.Drawing.Size(147, 26);
            // 
            // uxRemoveTime
            // 
            this.uxRemoveTime.Name = "uxRemoveTime";
            this.uxRemoveTime.Size = new System.Drawing.Size(180, 22);
            this.uxRemoveTime.Text = "Remove Time";
            this.uxRemoveTime.Click += new System.EventHandler(this.uxRemoveTime_Click);
            // 
            // HoursClocker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(567, 648);
            this.Controls.Add(this.uxGroupsGroup);
            this.Controls.Add(this.uxSavedHoursGroup);
            this.Controls.Add(this.uxPrevHourGroup);
            this.Controls.Add(this.uxNewClockInGroup);
            this.Controls.Add(this.uxFormMenuStrip);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.uxFormMenuStrip;
            this.MaximizeBox = false;
            this.Name = "HoursClocker";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Hour Clocker";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HoursClocker_FormClosing);
            this.Load += new System.EventHandler(this.HoursClocker_Load);
            this.uxNewClockInGroup.ResumeLayout(false);
            this.uxNewClockInGroup.PerformLayout();
            this.uxPrevHourGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxPrevMinuteInputNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxPrevHourInputNUD)).EndInit();
            this.uxSavedHoursGroup.ResumeLayout(false);
            this.uxGroupsGroup.ResumeLayout(false);
            this.uxGroupsGroup.PerformLayout();
            this.uxFormMenuStrip.ResumeLayout(false);
            this.uxFormMenuStrip.PerformLayout();
            this.uxTimeInstanceOptions.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox uxNewClockInGroup;
        private System.Windows.Forms.TextBox uxCurrentTimeTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button uxCancelTime;
        private System.Windows.Forms.Button uxClockOutBtn;
        private System.Windows.Forms.Button uxClockInBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uxCurrentTimeElapsedTextBox;
        private System.Windows.Forms.GroupBox uxPrevHourGroup;
        private System.Windows.Forms.Label uxMinutesLbl;
        private System.Windows.Forms.Label uxHoursLbl;
        private System.Windows.Forms.NumericUpDown uxPrevMinuteInputNUD;
        private System.Windows.Forms.NumericUpDown uxPrevHourInputNUD;
        private System.Windows.Forms.DateTimePicker uxStartDatePicker;
        private System.Windows.Forms.DateTimePicker uxEndDatePicker;
        private System.Windows.Forms.Label uxEndDateTimeLbl;
        private System.Windows.Forms.Label uxStartDateTimeLbl;
        private System.Windows.Forms.Button uxAddPrevTimeBtn;
        private System.Windows.Forms.GroupBox uxSavedHoursGroup;
        private System.Windows.Forms.ListView uxSavedHoursView;
        private System.Windows.Forms.ColumnHeader uxInstanceHeader;
        private System.Windows.Forms.ColumnHeader uxHoursHeader;
        private System.Windows.Forms.ColumnHeader uxMinutesHeader;
        private System.Windows.Forms.ColumnHeader uxDateHeader;
        private System.Windows.Forms.GroupBox uxGroupsGroup;
        private System.Windows.Forms.MenuStrip uxFormMenuStrip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox uxGroupNameTextBox;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolstriptools;
        private System.Windows.Forms.ToolStripMenuItem uxToggleGroupsBtn;
        private System.Windows.Forms.ListView uxGroupsView;
        private System.Windows.Forms.ColumnHeader uxGroupNameHeader;
        private System.Windows.Forms.ColumnHeader uxCountHeader;
        private System.Windows.Forms.ColumnHeader uxTotalTimeHeader;
        private System.Windows.Forms.ListView uxListViewOptions;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.Timer SystemTimeTimer;
        private System.Windows.Forms.Timer uxElapsedTimeTimer;
        private System.Windows.Forms.DateTimePicker uxEndTimePicker;
        private System.Windows.Forms.Label uxEndTimeLbl;
        private System.Windows.Forms.DateTimePicker uxStartTimePicker;
        private System.Windows.Forms.Label uxStartTimeLbl;
        private System.Windows.Forms.ContextMenuStrip uxTimeInstanceOptions;
        private System.Windows.Forms.ToolStripMenuItem uxRemoveTime;
    }
}

