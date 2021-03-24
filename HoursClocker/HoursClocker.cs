using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Author: Nicholas Sixbury
 * File: HourClocker.cs
 * Purpose: To handle all the view and controller aspects of this
 * application, which essentially just tracks the amount of time
 * someone spends doing various things.
 */

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

        private TimeGroupManager groupManager;

        public HoursClocker()
        {
            InitializeComponent();
            uxGroupsDefaultLocation = uxGroupsGroup.Location;
            uxHoursDefaultLocation = uxSavedHoursGroup.Location;

            clockInTime = DateTime.Now;
            clockOutTime = DateTime.Now;

            groupManager = new TimeGroupManager();

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
            else
            {
                uxSavedHoursGroup.Location = uxHoursDefaultLocation;
                //update any changes made to the groups
                UpdateListViews(true);
            }//end else we're enabling the group display
            //toggles groupsCurrentlyEnabled
            groupsCurrentlyEnabled = !groupsEnabledBefore;

            //update groupView
            UpdateListViews(true);
        }//end uxToggleGroupsBtn Click event handler

        private void SystemTimeTimer_Tick(object sender, EventArgs e)
        {
            uxCurrentTimeTextBox.Text = DateTime.Now.ToString("t");
        }//end SystemTimeTimer Tick event

        private void uxClockInBtn_Click(object sender, EventArgs e)
        {
            clockInTime = DateTime.Now;
            uxElapsedTimeTimer.Enabled = true;
        }//end uxClockInBtn_Click

        private void uxClockOutBtn_Click(object sender, EventArgs e)
        {
            //update display
            uxElapsedTimeTimer.Enabled = false;
            uxCurrentTimeElapsedTextBox.ResetText();

            //save the new time
            clockOutTime = DateTime.Now;
            TimedInstance time = new TimedInstance(clockInTime, clockOutTime);
            if (uxGroupsGroup.Visible)
            {
                string groupText = uxGroupNameTextBox.Text;

                //figure out if it's just white space
                bool foundNonSpace = false;
                foreach(char chr in groupText)
                {
                    if (!Char.IsWhiteSpace(chr))
                    {
                        foundNonSpace = true;
                        break;
                    }//end if this is not white space
                }//end foreach

                //make changes if it is just white space
                if (!foundNonSpace) groupText = "Ungrouped";

                //actually add this time to a group
                groupManager.AddTime(time, groupText);
                UpdateListViews(true);
            }//end if we should specify a group
            else
            {
                groupManager.AddTime(time, "Ungrouped");
                UpdateListViews(false);
            }//end else we just do a unspecified group
        }//end uxClockOutBtn Click event handler

        private void uxElapsedTimeTimer_Tick(object sender, EventArgs e)
        {
            clockOutTime = DateTime.Now;
            uxCurrentTimeElapsedTextBox.Text = DateTime.Now.Subtract(clockInTime).ToString(@"hh\:mm\:ss");
        }//end uxElapsedTimeTimer Tick event

        /// <summary>
        /// just decrement the clockIn DateTime for debugging purposes
        /// </summary>
        private void uxCurrentTimeElapsedTextBox_Click(object sender, EventArgs e)
        {
            clockInTime = clockInTime.AddMinutes(-1);
        }//end uxCurrentTimeElapsedTextBox click event handler

        /// <summary>
        /// updates the listviews to display entered hours.
        /// </summary>
        /// <param name="updateGroupDisplay">whether to update the groups view</param>
        private void UpdateListViews(bool updateGroupDisplay)
        {
            //reset uxSavedHoursView
            uxSavedHoursView.Items.Clear();
            uxSavedHoursView.Groups.Clear();

            //start updating uxSavedHoursView
            foreach(TimeGrouping group in groupManager.Groups)
            {
                //initialize our group
                ListViewGroup viewGroup = new ListViewGroup(group.GroupName);
                uxSavedHoursView.Groups.Add(viewGroup);
                foreach(TimedInstance time in group.Times)
                {
                    //add new item with proper text and group
                    ListViewItem item = new ListViewItem(FormatInstancesForSavedView(time), viewGroup);
                    uxSavedHoursView.Items.Add(item);
                }//end looping over all the times in group
            }//end looping over each group in the manager

            //maybe we'll update the groupDisplay too
            if (updateGroupDisplay)
            {
                uxGroupsView.Items.Clear();
                foreach(TimeGrouping group in groupManager.Groups)
                {
                    ListViewItem item = new ListViewItem(FormatInstancesForGroupView(group.Times, group.GroupName));
                    uxGroupsView.Items.Add(item);
                }//end adding each group to the listview
            }//end if we're actually going to update the Group Display
        }//end UpdateListViews(updateGroupDisplay

        /// <summary>
        /// makes a string array for displaying one group of TimedInstances
        /// </summary>
        private string[] FormatInstancesForGroupView(List<TimedInstance> times, string groupName)
        {
            string[] output = new string[3];

            output[0] = groupName;

            output[1] = times.Count.ToString();

            double hours = 0;
            
            foreach(TimedInstance time in times)
            {
                hours += time.TimeSpan.TotalHours;
            }//end adding up all the hours

            output[2] = hours.ToString("N2");

            return output;
        }//end FormatInstancesForGroupView(times)

        /// <summary>
        /// makes string array for displaying one TimedInstance across a row in a ListView
        /// </summary>
        private string[] FormatInstancesForSavedView(TimedInstance time)
        {
            string[] output = new string[4];

            //name of instance?
            output[0] = time.Start.ToString("t");

            //number of whole hours
            output[1] = time.TimeSpan.Hours.ToString();

            //number of minutes in addition to hours
            output[2] = time.TimeSpan.Minutes.ToString();

            //date for this instance
            if(time.printDate || time.handleSpecificBeginEnd)
            {
                output[3] = time.Start.ToString("d");
            }//end if we should print the date
            else
            {
                output[3] = "NA";
            }//end else we aren't printing the data

            return output;
        }//end FormatInstancesForSavedView(time)

        
    }//end class
}//end namespace