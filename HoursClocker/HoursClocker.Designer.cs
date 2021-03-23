﻿
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
            this.uxNewClockInGroup = new System.Windows.Forms.GroupBox();
            this.uxPrevHourGroup = new System.Windows.Forms.GroupBox();
            this.uxPrevInputOptionsChkLst = new System.Windows.Forms.CheckedListBox();
            this.uxAddPrevTimeBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.uxEndDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.uxStartDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.uxPrevHourInputNUD = new System.Windows.Forms.NumericUpDown();
            this.uxPrevMinuteInputNUD = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.uxCurrentTimeElapsedTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.uxClockInBtn = new System.Windows.Forms.Button();
            this.uxClockOutBtn = new System.Windows.Forms.Button();
            this.uxSaveCurrentTimeBtn = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.uxCurrentTimeTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.listView1 = new System.Windows.Forms.ListView();
            this.uxInstanceHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxHoursHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxMinutesHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxDateHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxGroupsGroup = new System.Windows.Forms.GroupBox();
            this.uxFormMenuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolstriptools = new System.Windows.Forms.ToolStripMenuItem();
            this.uxToggleGroupsBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.listView2 = new System.Windows.Forms.ListView();
            this.uxGroupNameHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxCountHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxTotalTimeHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxNewClockInGroup.SuspendLayout();
            this.uxPrevHourGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.uxPrevHourInputNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxPrevMinuteInputNUD)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.uxGroupsGroup.SuspendLayout();
            this.uxFormMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // uxNewClockInGroup
            // 
            this.uxNewClockInGroup.BackColor = System.Drawing.Color.Honeydew;
            this.uxNewClockInGroup.Controls.Add(this.uxCurrentTimeTextBox);
            this.uxNewClockInGroup.Controls.Add(this.label6);
            this.uxNewClockInGroup.Controls.Add(this.uxSaveCurrentTimeBtn);
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
            // uxPrevHourGroup
            // 
            this.uxPrevHourGroup.BackColor = System.Drawing.Color.MintCream;
            this.uxPrevHourGroup.Controls.Add(this.label4);
            this.uxPrevHourGroup.Controls.Add(this.label3);
            this.uxPrevHourGroup.Controls.Add(this.uxPrevMinuteInputNUD);
            this.uxPrevHourGroup.Controls.Add(this.uxPrevHourInputNUD);
            this.uxPrevHourGroup.Controls.Add(this.uxStartDateTimePicker);
            this.uxPrevHourGroup.Controls.Add(this.uxEndDateTimePicker);
            this.uxPrevHourGroup.Controls.Add(this.label2);
            this.uxPrevHourGroup.Controls.Add(this.label1);
            this.uxPrevHourGroup.Controls.Add(this.uxAddPrevTimeBtn);
            this.uxPrevHourGroup.Controls.Add(this.uxPrevInputOptionsChkLst);
            this.uxPrevHourGroup.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxPrevHourGroup.Location = new System.Drawing.Point(293, 27);
            this.uxPrevHourGroup.Name = "uxPrevHourGroup";
            this.uxPrevHourGroup.Size = new System.Drawing.Size(262, 177);
            this.uxPrevHourGroup.TabIndex = 1;
            this.uxPrevHourGroup.TabStop = false;
            this.uxPrevHourGroup.Text = "Add Previous Hours";
            // 
            // uxPrevInputOptionsChkLst
            // 
            this.uxPrevInputOptionsChkLst.BackColor = System.Drawing.Color.GhostWhite;
            this.uxPrevInputOptionsChkLst.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxPrevInputOptionsChkLst.FormattingEnabled = true;
            this.uxPrevInputOptionsChkLst.Items.AddRange(new object[] {
            "Specify Date",
            "Specify Beginning and End"});
            this.uxPrevInputOptionsChkLst.Location = new System.Drawing.Point(6, 19);
            this.uxPrevInputOptionsChkLst.Name = "uxPrevInputOptionsChkLst";
            this.uxPrevInputOptionsChkLst.Size = new System.Drawing.Size(155, 34);
            this.uxPrevInputOptionsChkLst.TabIndex = 0;
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
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LightCyan;
            this.label1.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label1.Location = new System.Drawing.Point(6, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(248, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Start Date";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LightCyan;
            this.label2.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label2.Location = new System.Drawing.Point(6, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(248, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "End Date";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxEndDateTimePicker
            // 
            this.uxEndDateTimePicker.CalendarForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxEndDateTimePicker.CalendarMonthBackground = System.Drawing.Color.MintCream;
            this.uxEndDateTimePicker.CalendarTitleBackColor = System.Drawing.Color.SteelBlue;
            this.uxEndDateTimePicker.CalendarTitleForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxEndDateTimePicker.CalendarTrailingForeColor = System.Drawing.Color.DarkSlateBlue;
            this.uxEndDateTimePicker.Location = new System.Drawing.Point(6, 150);
            this.uxEndDateTimePicker.Name = "uxEndDateTimePicker";
            this.uxEndDateTimePicker.Size = new System.Drawing.Size(248, 20);
            this.uxEndDateTimePicker.TabIndex = 4;
            // 
            // uxStartDateTimePicker
            // 
            this.uxStartDateTimePicker.CalendarForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxStartDateTimePicker.CalendarMonthBackground = System.Drawing.Color.MintCream;
            this.uxStartDateTimePicker.CalendarTitleBackColor = System.Drawing.Color.SteelBlue;
            this.uxStartDateTimePicker.CalendarTitleForeColor = System.Drawing.Color.DarkSlateGray;
            this.uxStartDateTimePicker.CalendarTrailingForeColor = System.Drawing.Color.DarkSlateBlue;
            this.uxStartDateTimePicker.Location = new System.Drawing.Point(6, 111);
            this.uxStartDateTimePicker.Name = "uxStartDateTimePicker";
            this.uxStartDateTimePicker.Size = new System.Drawing.Size(248, 20);
            this.uxStartDateTimePicker.TabIndex = 5;
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
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LightCyan;
            this.label3.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label3.Location = new System.Drawing.Point(6, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(122, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Hours";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LightCyan;
            this.label4.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.label4.Location = new System.Drawing.Point(131, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(120, 13);
            this.label4.TabIndex = 9;
            this.label4.Text = "Minutes";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // uxCurrentTimeElapsedTextBox
            // 
            this.uxCurrentTimeElapsedTextBox.BackColor = System.Drawing.Color.GhostWhite;
            this.uxCurrentTimeElapsedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxCurrentTimeElapsedTextBox.ForeColor = System.Drawing.Color.SeaGreen;
            this.uxCurrentTimeElapsedTextBox.Location = new System.Drawing.Point(6, 42);
            this.uxCurrentTimeElapsedTextBox.Name = "uxCurrentTimeElapsedTextBox";
            this.uxCurrentTimeElapsedTextBox.ReadOnly = true;
            this.uxCurrentTimeElapsedTextBox.Size = new System.Drawing.Size(263, 26);
            this.uxCurrentTimeElapsedTextBox.TabIndex = 0;
            this.uxCurrentTimeElapsedTextBox.TabStop = false;
            this.uxCurrentTimeElapsedTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // 
            // uxClockOutBtn
            // 
            this.uxClockOutBtn.BackColor = System.Drawing.Color.Honeydew;
            this.uxClockOutBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxClockOutBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.uxClockOutBtn.Location = new System.Drawing.Point(191, 74);
            this.uxClockOutBtn.Name = "uxClockOutBtn";
            this.uxClockOutBtn.Size = new System.Drawing.Size(78, 34);
            this.uxClockOutBtn.TabIndex = 11;
            this.uxClockOutBtn.Text = "Clock Out";
            this.uxClockOutBtn.UseVisualStyleBackColor = false;
            // 
            // uxSaveCurrentTimeBtn
            // 
            this.uxSaveCurrentTimeBtn.BackColor = System.Drawing.Color.Honeydew;
            this.uxSaveCurrentTimeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.uxSaveCurrentTimeBtn.ForeColor = System.Drawing.Color.SeaGreen;
            this.uxSaveCurrentTimeBtn.Location = new System.Drawing.Point(89, 74);
            this.uxSaveCurrentTimeBtn.Name = "uxSaveCurrentTimeBtn";
            this.uxSaveCurrentTimeBtn.Size = new System.Drawing.Size(96, 34);
            this.uxSaveCurrentTimeBtn.TabIndex = 12;
            this.uxSaveCurrentTimeBtn.Text = "Save Current";
            this.uxSaveCurrentTimeBtn.UseVisualStyleBackColor = false;
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
            // uxCurrentTimeTextBox
            // 
            this.uxCurrentTimeTextBox.BackColor = System.Drawing.Color.GhostWhite;
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
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.Color.MistyRose;
            this.groupBox3.Controls.Add(this.listView1);
            this.groupBox3.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox3.Location = new System.Drawing.Point(12, 387);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(543, 168);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Saved Hours";
            // 
            // listView1
            // 
            this.listView1.BackColor = System.Drawing.Color.SeaShell;
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uxInstanceHeader,
            this.uxHoursHeader,
            this.uxMinutesHeader,
            this.uxDateHeader});
            this.listView1.ForeColor = System.Drawing.Color.Maroon;
            this.listView1.FullRowSelect = true;
            this.listView1.GridLines = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(6, 19);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(526, 143);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
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
            this.uxGroupsGroup.Controls.Add(this.listView2);
            this.uxGroupsGroup.Controls.Add(this.label7);
            this.uxGroupsGroup.Controls.Add(this.textBox1);
            this.uxGroupsGroup.ForeColor = System.Drawing.Color.Indigo;
            this.uxGroupsGroup.Location = new System.Drawing.Point(12, 210);
            this.uxGroupsGroup.Name = "uxGroupsGroup";
            this.uxGroupsGroup.Size = new System.Drawing.Size(543, 171);
            this.uxGroupsGroup.TabIndex = 1;
            this.uxGroupsGroup.TabStop = false;
            this.uxGroupsGroup.Text = "Groups";
            // 
            // uxFormMenuStrip
            // 
            this.uxFormMenuStrip.BackColor = System.Drawing.Color.GhostWhite;
            this.uxFormMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolstriptools});
            this.uxFormMenuStrip.Location = new System.Drawing.Point(0, 0);
            this.uxFormMenuStrip.Name = "uxFormMenuStrip";
            this.uxFormMenuStrip.Size = new System.Drawing.Size(564, 24);
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
            this.uxToggleGroupsBtn.Size = new System.Drawing.Size(180, 22);
            this.uxToggleGroupsBtn.Text = "Toggle Groups";
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.GhostWhite;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Indigo;
            this.textBox1.Location = new System.Drawing.Point(6, 36);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(531, 26);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // listView2
            // 
            this.listView2.BackColor = System.Drawing.Color.LavenderBlush;
            this.listView2.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.uxGroupNameHeader,
            this.uxCountHeader,
            this.uxTotalTimeHeader});
            this.listView2.ForeColor = System.Drawing.Color.Indigo;
            this.listView2.GridLines = true;
            this.listView2.HideSelection = false;
            this.listView2.LabelEdit = true;
            this.listView2.Location = new System.Drawing.Point(6, 68);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(531, 97);
            this.listView2.TabIndex = 2;
            this.listView2.UseCompatibleStateImageBehavior = false;
            this.listView2.View = System.Windows.Forms.View.Details;
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
            // HoursClocker
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.Linen;
            this.ClientSize = new System.Drawing.Size(564, 562);
            this.Controls.Add(this.uxGroupsGroup);
            this.Controls.Add(this.groupBox3);
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
            this.uxNewClockInGroup.ResumeLayout(false);
            this.uxNewClockInGroup.PerformLayout();
            this.uxPrevHourGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.uxPrevHourInputNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.uxPrevMinuteInputNUD)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.uxGroupsGroup.ResumeLayout(false);
            this.uxGroupsGroup.PerformLayout();
            this.uxFormMenuStrip.ResumeLayout(false);
            this.uxFormMenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox uxNewClockInGroup;
        private System.Windows.Forms.TextBox uxCurrentTimeTextBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button uxSaveCurrentTimeBtn;
        private System.Windows.Forms.Button uxClockOutBtn;
        private System.Windows.Forms.Button uxClockInBtn;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox uxCurrentTimeElapsedTextBox;
        private System.Windows.Forms.GroupBox uxPrevHourGroup;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown uxPrevMinuteInputNUD;
        private System.Windows.Forms.NumericUpDown uxPrevHourInputNUD;
        private System.Windows.Forms.DateTimePicker uxStartDateTimePicker;
        private System.Windows.Forms.DateTimePicker uxEndDateTimePicker;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button uxAddPrevTimeBtn;
        private System.Windows.Forms.CheckedListBox uxPrevInputOptionsChkLst;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader uxInstanceHeader;
        private System.Windows.Forms.ColumnHeader uxHoursHeader;
        private System.Windows.Forms.ColumnHeader uxMinutesHeader;
        private System.Windows.Forms.ColumnHeader uxDateHeader;
        private System.Windows.Forms.GroupBox uxGroupsGroup;
        private System.Windows.Forms.MenuStrip uxFormMenuStrip;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolstriptools;
        private System.Windows.Forms.ToolStripMenuItem uxToggleGroupsBtn;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.ColumnHeader uxGroupNameHeader;
        private System.Windows.Forms.ColumnHeader uxCountHeader;
        private System.Windows.Forms.ColumnHeader uxTotalTimeHeader;
    }
}

