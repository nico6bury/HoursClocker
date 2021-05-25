using BrightIdeasSoftware;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
    public partial class HoursTracker : Form
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

        private TypedObjectListView<TimeGrouping> typedGroupView;

        private TypedObjectListView<TimedInstance> typedTimeView;

        public HoursTracker()
        {
            InitializeComponent();
            uxGroupsDefaultLocation = uxGroupsGroup.Location;
            uxHoursDefaultLocation = uxSavedHoursGroup.Location;

            clockInTime = DateTime.Now;
            clockOutTime = DateTime.Now;

            groupManager = new TimeGroupManager();

            SystemTimeTimer.Enabled = true;
            SystemTimeTimer_Tick(null, null);

            //Do some whack ObjectListView things

            //set up the typed olvs
            typedGroupView = new TypedObjectListView<TimeGrouping>(this.uxGroupsView);
            typedTimeView = new TypedObjectListView<TimedInstance>(this.uxSavedHoursView);

            //set up weird delegate things
            for(int i = 0; i < uxSavedHoursView.Columns.Count; i++)
            {
                typedTimeView.GetColumn(i).GroupKeyGetter = delegate (TimedInstance timedInstance)
                {
                    TimedInstance time = timedInstance;
                    return time.CurrentGroup;
                };
            }//end setting all columns to use group name as group key

            typedTimeView.GetColumn(0).GroupKeyGetter = delegate (TimedInstance time)
            {
                return time.CurrentGroup;
            };
            uxInstanceColumn.GroupKeyToTitleConverter = delegate (object groupKey)
            {
                if (groupKey == null) return "No Group Found";
                TimeGrouping groupObj = (TimeGrouping)groupKey;
                return groupObj.GroupName;
            };
            uxInstanceColumn.GroupFormatter = (OLVGroup group,
                GroupingParameters parms) =>
            {
                TimeGrouping groupObj = (TimeGrouping)group.Key;
                //set default ID
                group.Id = -1;
                //try to determine ID based off date and time
                DateTime earliestTime = DateTime.Now;
                foreach(TimedInstance time in groupObj.Times)
                {
                    if (time.printDate && time.handleSpecificBeginEnd)
                    {
                        if(time.Start.Ticks < earliestTime.Ticks)
                        {
                            earliestTime = time.Start;
                            break;
                        }//end if we found an earlier time
                    }//end if we have a date on this one
                }//end looping for each time in the group
                parms.GroupComparer = Comparer<OLVGroup>.Create
                (
                    (x, y) => (x.Id.CompareTo(y.Id))
                );

            };
            //uxSavedHoursView.GetColumn(0).AspectPutter = delegate (object rowObject, object newValue)
            //{

            //};//end aspect putter for row name
        }//end constructor

        /// <summary>
        /// handler for adding previous times from the stuff
        /// </summary>
        private void uxAddPrevTimeBtn_Click(object sender, EventArgs e)
        {
            DateTime start;
            DateTime end;

            DateTime startDate;
            DateTime endDate;

            TimeSpan startTime;
            TimeSpan endTime;

            TimedInstance timedInstance;

            

            if (specifyDate)
            {
                //get our stuff from DateTimePickers
                startDate = uxStartDatePicker.Value.Date;
                endDate = uxEndDatePicker.Value.Date;
                startTime = uxStartTimePicker.Value.TimeOfDay;
                endTime = uxEndTimePicker.Value.TimeOfDay;
                
                //put that stuff into start and end DateTimes
                start = startDate.Add(startTime);
                end = endDate.Add(endTime);

                //make sure we don't have a negative
                while (start.Ticks > end.Ticks)
                    end = end.AddDays(1);

                //create our timed instance
                timedInstance = new TimedInstance(start, end)
                {
                    printDate = true
                };
            }//end if we're specifying the date
            else
            {
                if (specifyBeginEnd)
                {
                    //get our stuff from DateTimePickers
                    startDate = DateTime.Now;
                    endDate = DateTime.Now;
                    startTime = uxStartTimePicker.Value.TimeOfDay;
                    endTime = uxEndTimePicker.Value.TimeOfDay;

                    //put that stuff into start and end DateTimes
                    start = startDate.Add(startTime);
                    end = endDate.Add(endTime).AddMinutes(1);

                    //make sure we don't have a negative
                    while (start.Ticks > end.Ticks)
                        end = end.AddDays(1);

                    //create our timed instance
                    timedInstance = new TimedInstance(start, end)
                    {
                        printDate = false
                    };
                }//end if we care about the beginning and end
                else
                {
                    //create our timed instance
                    timedInstance = new TimedInstance((int)uxPrevHourInputNUD.Value, (int)uxPrevMinuteInputNUD.Value)
                    {
                        printDate = false
                    };
                }//end else we don't care about beginning and end
            }//end else we don't care about the date

            //get the name of the instance
            timedInstance.InstanceName = uxTimeNameTextBox.Text == "" ? "Unnamed Instance" : uxTimeNameTextBox.Text;
            //reset text in the textbox
            uxTimeNameTextBox.ResetText();

            if (uxGroupsGroup.Visible)
            {
                string groupText = uxGroupNameTextBox.Text;

                //figure out if it's just white space
                bool foundNonSpace = false;
                foreach (char chr in groupText)
                {
                    if (!Char.IsWhiteSpace(chr))
                    {
                        foundNonSpace = true;
                        break;
                    }//end if this is not white space
                }//end foreach

                //make changes if it is just white space
                if (!foundNonSpace) groupText = "Ungrouped";

                groupManager.AddTime(timedInstance, groupText);

                UpdateListViews(true);
            }//end if we're doing groups right now
            else
            {
                groupManager.AddTime(timedInstance, "Ungrouped");

                UpdateListViews(false);
            }//end else we aren't doing groups rn
        }//end uxAddPrevTimeBtn Click event handler

        /// <summary>
        /// handles enabledness of things when the options checked list is changed by the user
        /// </summary>
        private void uxListViewOptions_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            /// <summary>
            /// whether or not we needed to force an update of the one
            /// of the checkboxes. This seems to always trigger on form opening
            /// </summary>
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
                uxStartDatePicker.Format = DateTimePickerFormat.Long;
                uxStartDatePicker.ShowUpDown = false;
                uxEndDatePicker.Format = DateTimePickerFormat.Long;
                uxEndDatePicker.ShowUpDown = false;

                //update labels
                uxStartDateTimeLbl.Text = "Start Date";
                uxEndDateTimeLbl.Text = "End Date";

                //update enabled-ness
                uxHoursLbl.Enabled = false;
                uxMinutesLbl.Enabled = false;
                uxPrevHourInputNUD.Enabled = false;
                uxPrevMinuteInputNUD.Enabled = false;

                uxStartDateTimeLbl.Enabled = true;
                uxStartTimeLbl.Enabled = true;
                uxEndDateTimeLbl.Enabled = true;
                uxEndDateTimeLbl.Enabled = true;
                uxStartDatePicker.Enabled = true;
                uxStartTimePicker.Enabled = true;
                uxEndDatePicker.Enabled = true;
                uxEndTimePicker.Enabled = true;
                return;
            }//end if we're forcing an update

            //handle format changes
            if (specifyDate)
            {
                uxStartDateTimeLbl.Enabled = true;
                uxEndDateTimeLbl.Enabled = true;
                uxStartTimeLbl.Enabled = true;
                uxEndTimeLbl.Enabled = true;
                uxStartDatePicker.Enabled = true;
                uxEndDatePicker.Enabled = true;
                uxStartTimePicker.Enabled = true;
                uxEndTimePicker.Enabled = true;
            }//end if we should specify the date
            else
            {
                uxStartDateTimeLbl.Enabled = false;
                uxEndDateTimeLbl.Enabled = false;
                uxStartTimeLbl.Enabled = false;
                uxEndTimeLbl.Enabled = false;
                uxStartDatePicker.Enabled = false;
                uxEndDatePicker.Enabled = false;
                uxStartTimePicker.Enabled = false;
                uxEndTimePicker.Enabled = false;
            }//end else we just want times
            if (specifyBeginEnd)
            {
                //update enabled-ness
                uxHoursLbl.Enabled = false;
                uxMinutesLbl.Enabled = false;
                uxPrevHourInputNUD.Enabled = false;
                uxPrevMinuteInputNUD.Enabled = false;

                uxStartTimePicker.Enabled = true;
                uxEndTimePicker.Enabled = true;
            }//end if we want beginning and ends
            else
            {
                //update enabled-ness
                uxHoursLbl.Enabled = true;
                uxMinutesLbl.Enabled = true;
                uxPrevHourInputNUD.Enabled = true;
                uxPrevMinuteInputNUD.Enabled = true;

                uxStartTimePicker.Enabled = false;
                uxEndTimePicker.Enabled = false;
            }//end else we just want a span of time
        }//end uxListViewOptions ItemChecked event handler

        /// <summary>
        /// happens the users wants to toggle groups on or off
        /// </summary>
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

            //get the name for that time
            time.InstanceName = uxTimeNameTextBox.Text == "" ? "Unnamed Instance" : uxTimeNameTextBox.Text;
            //reset text in the textbox
            uxTimeNameTextBox.ResetText();

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
            //clockInTime = clockInTime.AddMinutes(-1);
        }//end uxCurrentTimeElapsedTextBox click event handler

        private void uxCancelTime_Click(object sender, EventArgs e)
        {
            //update display
            uxElapsedTimeTimer.Enabled = false;
            uxCurrentTimeElapsedTextBox.ResetText();
        }//end uxCancelTime click event handler

        /// <summary>
        /// updates the listviews to display entered hours.
        /// </summary>
        /// <param name="updateGroupDisplay">whether to update the groups view</param>
        private void UpdateListViews(bool updateGroupDisplay)
        {
            //reset uxSavedHoursView
            uxSavedHoursView.SetObjects(groupManager.Times);

            ////maybe we'll update the groupDisplay too
            uxGroupsView.SetObjects(groupManager.Groups);
        }//end UpdateListViews(updateGroupDisplay

        /// <summary>
        /// occurs when the form loads up. loads information from a file
        /// </summary>
        private void HoursClocker_Load(object sender, EventArgs e)
        {
            //set up our directory and get the filename
            string configFilename = SetUpDirectory("HourClockerDataFiles", "Hour Clocker Data");

            //initialize list of lines
            List<string> linesFromFile = new List<string>();

            //read lines with a stream reader
            using(StreamReader reader = new StreamReader(configFilename))
            {
                while (!reader.EndOfStream)
                {
                    linesFromFile.Add(reader.ReadLine());
                }//end looping while there are still more lines
            }//end use of reader

            //now we need to process them
            if (groupManager.ReadFileData(linesFromFile))
            {
                UpdateListViews(true);
            }//end we must have read everything successfully
            else
            {
                MessageBox.Show("File Parse Error", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }//end else there must have been a problem
        }//end Form Loading event handler

        /// <summary>
        /// occurs when the form is about to close. saves information to a file
        /// </summary>
        private void HoursClocker_FormClosing(object sender, FormClosingEventArgs e)
        {
            //get the lines we need to write from the manager
            List<string> lines = groupManager.GenerateFileData();

            //set up directory and get our filename
            string configFilename = SetUpDirectory("HourClockerDataFiles", "Hour Clocker Data");

            //write all our junk to the file
            using (StreamWriter scribe = new StreamWriter(configFilename))
            {
                foreach(string line in lines)
                {
                    scribe.WriteLine(line);
                }//end looping over each line
            }//end use of scribe
        }//end Form Closing event handler

        /// <summary>
        /// sets stuff up to put a filename in a new folder
        /// </summary>
        /// <param name="filename">the name of the file</param>
        /// <param name="foldername">the name of the folder</param>
        /// <returns>returns the path of the file which now exists</returns>
        private string SetUpDirectory(string filename, string foldername)
        {
            //gets the directory we're currently in
            string currentDirectory = Directory.GetCurrentDirectory();

            //make our new directory
            string dataDirectory = $"{currentDirectory}{Path.DirectorySeparatorChar}{foldername}";

            //make the directory exist
            Directory.CreateDirectory(dataDirectory);

            //make file name
            string configFilename = $"{dataDirectory}{Path.DirectorySeparatorChar}{filename}.txt";

            //make sure the file exists
            if (!File.Exists(configFilename)) File.Create(configFilename).Close();

            //return our filename
            return configFilename;
        }//end SetUpDirectory

        private void uxRemoveTime_Click(object sender, EventArgs e)
        {
            List<int> ints = new List<int>();
            foreach (int index in uxSavedHoursView.SelectedIndices)
            {
                ints.Add(index);
            }//end getting all the selected indices

            List<TimedInstance> times = new List<TimedInstance>();
            if (times == null) return;
            foreach(int index in ints)
            {
                times.Add(groupManager[index]);
            }//end looping over the indices

            StringBuilder sb = new StringBuilder("\n");
            foreach(TimedInstance time in times)
            {
                sb.AppendLine(time.ToString());
            }//end adding all the times to a stringbuilder

            if(DialogResult.Yes == MessageBox.Show($"Do you want to delete the following times?{sb}", "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                groupManager.RemoveTimes(ints);
                UpdateListViews(true);
            }//end if they want to delete the lines
        }//end event handler for when the user wants to remove a time

        private void uxRemoveGroup_Click(object sender, EventArgs e)
        {
            List<int> ints = new List<int>();
            foreach (int index in uxGroupsView.SelectedIndices)
            {
                ints.Add(index);
            }//end getting all the selected indices

            List<TimeGrouping> groups = new List<TimeGrouping>();
            foreach(int index in ints)
            {
                groupManager.Groups[index].GroupName = "Ungrouped";
            }//end getting the groups

            groupManager.MergeEqualGroups();
            UpdateListViews(true);
        }//end event handler for when the user wants to remove a group

        /// <summary>
        /// just make sure to update the views when we edit things
        /// </summary>
        private void uxGroupsView_CellEditFinished(object sender, CellEditEventArgs e)
        {
            UpdateListViews(true);
        }//end uxGroupsView_CellEditFinished event handler

        /// <summary>
        /// just make sure to update the views when we edit things
        /// </summary>
        private void uxSavedHoursView_CellEditFinished(object sender, CellEditEventArgs e)
        {
            //grab the instance we're editing out of those args
            TimedInstance time = (TimedInstance)e.RowObject;

            //if we couldn't find it, break out of method
            if (time == null) return;

            if(e.Column == uxInstanceColumn)
            {
                time.InstanceName = (string)e.NewValue;
            }//end if we're editing the name
            else if(e.Column == uxHoursColumn)
            {
                time.Hours = (int)e.NewValue;
            }//end if we're editing the hours
            else if(e.Column == uxMinutesColumn)
            {
                time.Minutes = (int)e.NewValue;
            }//end else if we're editing the minutes
            else if(e.Column == uxDateColumn)
            {
                try
                {
                    time.Start = DateTime.Parse((string)e.NewValue);
                }//end trying to do the conversion
                catch (FormatException)
                {
                    MessageBox.Show("Date Format Not Recognized", "Invalid Date", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }//end catching format error
            }//end else if we're editing the date

            UpdateGroupManager(typedTimeView, groupManager);

            UpdateListViews(true);
        }//end uxGroupView_CellEditFinished event handler

        /// <summary>
        /// Updates the group manager based off of a list of timedInstances
        /// </summary>
        private void UpdateGroupManager(TypedObjectListView<TimedInstance> times,
            TimeGroupManager timeGroupManager)
        {
            TimeGroupManager newManager = new TimeGroupManager();

            foreach(TimedInstance time in times.Objects)
            {
                newManager.AddTime(time, time.CurrentGroup.GroupName);
            }//end looping over all the times from the listview

            timeGroupManager = newManager;
        }//end UpdateGroupManager
    }//end class
}//end namespace