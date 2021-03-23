using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HoursClocker
{
    public partial class HoursClocker : Form
    {
        /// <summary>
        /// whether or not the "Specify Date" item in the checked
        /// list box for previous times is checked
        /// </summary>
        private bool specifyDate = false;

        /// <summary>
        /// whether or not the "Specify Beginning and End" item in
        /// the checked list box for previous times is checked
        /// </summary>
        private bool specifyBeginEnd = false;

        /// <summary>
        /// whether we currently have groups enabled. Just a reference
        /// </summary>
        private bool groupsCurrentlyEnabled = true;

        /// <summary>
        /// default location for the groupbox that holds a bunch of
        /// groups.
        /// </summary>
        private Point uxGroupsDefaultLocation;

        /// <summary>
        /// default location of the groupbox for previously
        /// entered hours
        /// </summary>
        private Point uxHoursDefaultLocation;

        /// <summary>
        /// the time you clocked in
        /// </summary>
        private DateTime clockInTime;

        /// <summary>
        /// the time you clocked out
        /// </summary>
        private DateTime clockOutTime;

        public HoursClocker()
        {
            InitializeComponent();
            uxGroupsDefaultLocation = uxGroupsGroup.Location;
            uxHoursDefaultLocation = uxSavedHoursGroup.Location;

            clockInTime = DateTime.Now;
            clockOutTime = DateTime.Now;

            SystemTimeTimer.Enabled = true;
            SystemTimeTimer_Tick(null, null);
        }//end constructor

        private void uxListViewOptions_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            bool forcedUpdate = false;

            //update fields
            if (uxListViewOptions.Items.Count >= 2)
            {
                if (uxListViewOptions.Items[0] != null)
                {
                    specifyDate = uxListViewOptions.Items[0].Checked;
                    if(specifyDate && !specifyBeginEnd)
                    {
                        if (uxListViewOptions.Items[1] != null) uxListViewOptions.Items[1].Checked = true;
                        forcedUpdate = true;
                    }//end if we need to force some properties to conform
                }//end if we can get the specifyDate flag
                if (uxListViewOptions.Items[1] != null)
                {
                    specifyBeginEnd = uxListViewOptions.Items[1].Checked;
                    if(specifyDate && !specifyBeginEnd)
                    {
                        if (uxListViewOptions.Items[0] != null) uxListViewOptions.Items[1].Checked = true;
                        forcedUpdate = true;
                    }
                }//end if we can get the specifyBeginEnd flag
            }//end if we have enough things

            if(forcedUpdate == true)
            {
                //update object format
                uxStartDateTimePicker.Format = DateTimePickerFormat.Long;
                uxStartDateTimePicker.ShowUpDown = false;
                uxEndDateTimePicker.Format = DateTimePickerFormat.Long;
                uxEndDateTimePicker.ShowUpDown = false;

                //update labels
                uxStartDateTimeLbl.Text = "Start Date";
                uxEndDateTimeLbl.Text = "End Date";

                //update enabled-ness
                uxHoursLbl.Enabled = false;
                uxMinutesLbl.Enabled = false;
                uxPrevHourInputNUD.Enabled = false;
                uxPrevMinuteInputNUD.Enabled = false;

                uxStartDateTimeLbl.Enabled = true;
                uxEndDateTimeLbl.Enabled = true;
                uxStartDateTimePicker.Enabled = true;
                uxEndDateTimePicker.Enabled = true;
                return;
            }//end if we're forcing an update

            //handle format changes
            if (specifyDate)
            {
                //update object format
                uxStartDateTimePicker.Format = DateTimePickerFormat.Long;
                uxStartDateTimePicker.ShowUpDown = false;
                uxEndDateTimePicker.Format = DateTimePickerFormat.Long;
                uxEndDateTimePicker.ShowUpDown = false;

                //update labels
                uxStartDateTimeLbl.Text = "Start Date";
                uxEndDateTimeLbl.Text = "End Date";
            }//end if we should specify the date
            else
            {
                //update object format
                uxStartDateTimePicker.Format = DateTimePickerFormat.Time;
                uxStartDateTimePicker.ShowUpDown = true;
                uxEndDateTimePicker.Format = DateTimePickerFormat.Time;
                uxEndDateTimePicker.ShowUpDown = true;

                //update labels
                uxStartDateTimeLbl.Text = "Start Time";
                uxEndDateTimeLbl.Text = "End Time";
            }//end else we just want times
            if (specifyBeginEnd)
            {
                //update enabled-ness
                uxHoursLbl.Enabled = false;
                uxMinutesLbl.Enabled = false;
                uxPrevHourInputNUD.Enabled = false;
                uxPrevMinuteInputNUD.Enabled = false;

                uxStartDateTimeLbl.Enabled = true;
                uxEndDateTimeLbl.Enabled = true;
                uxStartDateTimePicker.Enabled = true;
                uxEndDateTimePicker.Enabled = true;
            }//end if we want beginning and ends
            else
            {
                //update enabled-ness
                uxHoursLbl.Enabled = true;
                uxMinutesLbl.Enabled = true;
                uxPrevHourInputNUD.Enabled = true;
                uxPrevMinuteInputNUD.Enabled = true;

                uxStartDateTimeLbl.Enabled = false;
                uxEndDateTimeLbl.Enabled = false;
                uxStartDateTimePicker.Enabled = false;
                uxEndDateTimePicker.Enabled = false;
            }//end else we just want a span of time
        }//end uxListViewOptions ItemChecked event handler

        private void uxToggleGroupsBtn_Click(object sender, EventArgs e)
        {
            //update a bunch of random variables
            bool groupsEnabledBefore = uxGroupsGroup.Enabled;
            uxGroupsGroup.Enabled = !groupsEnabledBefore;
            uxGroupsGroup.Visible = !groupsEnabledBefore;
            if (groupsEnabledBefore) uxSavedHoursGroup.Location = uxGroupsDefaultLocation;
            else uxSavedHoursGroup.Location = uxHoursDefaultLocation;

            //toggles groupsCurrentlyEnabled
            groupsCurrentlyEnabled = !groupsEnabledBefore;
        }//end uxToggleGroupsBtn Click event handler

        private void SystemTimeTimer_Tick(object sender, EventArgs e)
        {
            uxCurrentTimeTextBox.Text = DateTime.Now.ToString("T");
        }//end SystemTimeTimer Tick event

        private void uxClockInBtn_Click(object sender, EventArgs e)
        {
            clockInTime = DateTime.Now;
            uxElapsedTimeTimer.Enabled = true;
        }//end uxClockInBtn_Click

        private void uxElapsedTimeTimer_Tick(object sender, EventArgs e)
        {
            clockOutTime = DateTime.Now;
            uxCurrentTimeElapsedTextBox.Text = DateTime.Now.Subtract(clockInTime).ToString(@"hh\:mm\:ss");
        }//end uxElapsedTimeTimer Tick event
    }//end class
}//end namespace