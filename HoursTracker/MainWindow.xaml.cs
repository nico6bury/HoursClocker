/*
 * Author: Nicholas Sixbury
 * Files: HourTracker.xaml, HourTracker.xaml.cs
 * Purpose: Serves as the view for the Hour Tracker application.
 */

using HoursClockerLibrary;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Threading;

namespace HourTracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// The timer we use for updating the system clock.
        /// </summary>
        protected DispatcherTimer clock = new DispatcherTimer();
        /// <summary>
        /// Backer variable for Manager.
        /// </summary>
        protected TimeGroupManager manager = new TimeGroupManager();
        /// <summary>
        /// The manager for all of the times. Even if you change this, you'll
        /// probably want to still call UpdateViewWithManager()
        /// </summary>
        protected TimeGroupManager Manager
        {
            get => manager;
            set {
                manager = value;
                if (ManagerUpdatesView) UpdateViewWithManager();
            }//end setter
        }//end Manager
        /// <summary>
        /// Whether or not an update to the manager should update the view automatically.
        /// </summary>
        protected bool ManagerUpdatesView = true;
        /// <summary>
        /// Backer variable for countedSeconds.
        /// </summary>
        protected ulong countedSeconds = 0;
        /// <summary>
        /// Seconds counted since some particular starting point.
        /// </summary>
        protected ulong CountedSeconds
        {
            get => countedSeconds;
            set {
                countedSeconds = value;
                // trigger the binding so that it shows up
                TimeElapsedBox.Text = CountedSecondsFormatted;
            }//end setter
        }//end CountedSeconds
        /// <summary>
        /// The number of elapsed seconds, formatted as a string to be displayed.
        /// </summary>
        protected string CountedSecondsFormatted {
            get {
                if (!countingTimeRN) return "Timer Stopped";
                else {
                    TimeSpan span = new TimeSpan(0, 0, (int)countedSeconds);
                    return span.ToString(@"hh\:mm\:ss");
                }//end else
            }//end getter
        }//end CountedSeconds
        /// <summary>
        /// Whether or not we're tring to count time atm.
        /// </summary>
        protected bool countingTimeRN = false;

        /// <summary>
        /// Constructor for the MainWindow class.
        /// </summary>
        public MainWindow() {
            // initialize GUI
            InitializeComponent();
            // set up system clock
            clock.Start();
            clock.Interval = new TimeSpan(0, 0, 1);
            clock.Tick += clockElapsedEvent;
            // set defaults
            PrevHoursCount.Minimum = 0;
            PrevHoursCount.Value = 0;
            PrevMinutesCount.Minimum = 0;
            PrevMinutesCount.Value = 0;
            PreviousStartPicker.Value = DateTime.Now;
            PreviousEndPicker.Value = DateTime.Now;
            // set source for lists
            GroupsListView.ItemsSource = Manager.Groups;
            HoursListView.ItemsSource = Manager.Times;
            CollectionView view = (CollectionView)CollectionViewSource
                .GetDefaultView(HoursListView.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("CurrentGroupName");
            view.GroupDescriptions.Add(groupDescription);
        }//end constructor

        /// <summary>
        /// Event that occurs every interval of clock. Generally intended to just
        /// update displayed clock to user.
        /// </summary>
        protected void clockElapsedEvent(object sender, EventArgs e)
        { ClockBox.Text = DateTime.Now.ToString(@"hh\:mm\:ss"); CountedSeconds++; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        protected void AddTime(DateTime start, DateTime end){
            string instanceName = InstanceNameBox.Text;
            string groupName = CurGroupName.Text;

            // Ensure group name isn't just white space
            bool foundNonSpace = false;
            foreach (char chr in groupName){
                if (!Char.IsWhiteSpace(chr)){
                    foundNonSpace = true;
                    break;
                }//end if this is not white space
            }//end foreach
            // make changes if it is just white space
            if (!foundNonSpace) groupName = "Ungrouped";

            // make the time instance
            TimedInstance time = new TimedInstance(start, end);
            time.InstanceName = instanceName;
            // add it to the group
            Manager.AddTime(time, groupName);
            // update the view
            UpdateViewWithManager();
        }//end AddTime(start, end)

        /// <summary>
        /// Updates lists in the view based off of information in the manager.
        /// </summary>
        protected void UpdateViewWithManager() {
            BuildGroupsList(manager.Groups);
            BuildTimeList(manager.Times);
        }//end UpdateViewWithManager()

        /// <summary>
        /// Builds a list of groups into the view based off provided groups.
        /// </summary>
        /// <param name="groups">The list of groups to build.</param>
        /// <remarks>This method is currently only needed because I don't
        /// have the bindings properly set up for the TimeGrouping class.
        /// If I can get the INotifyCollectionChanged interface fully working,
        /// then this should theoretically not be needed, but that will
        /// probably take awhile to do, and the trusty set the source to
        /// null and then set it to what you want everytime it updates will
        /// also work about as well in the meantime</remarks>
        protected void BuildGroupsList(List<TimeGrouping> groups) {
            GroupsListView.ItemsSource = null;
            GroupsListView.ItemsSource = groups;
        }//end BuildGroupsList()

        /// <summary>
        /// Builds a list of timed instances into teh view based off provided list.
        /// </summary>
        protected void BuildTimeList(List<TimedInstance> times) {
            HoursListView.ItemsSource = null;
            HoursListView.ItemsSource = times;

            CollectionView view = (CollectionView)CollectionViewSource
                .GetDefaultView(HoursListView.ItemsSource);
            PropertyGroupDescription groupDescription = new PropertyGroupDescription("CurrentGroupName");
            view.GroupDescriptions.Add(groupDescription);
        }//end BuildTimeList()

        /// <summary>
        /// Click event for the button clicked by the user to finalize
        /// adding in a previous time.
        /// </summary>
        protected void FinalizePrevTime(object sender, EventArgs e)
        {
            if (sender is Button button){
                if((string)button.Tag == "Finalize") {
                    // Grab all the data we need from the form
                    DateTime start = (DateTime)PreviousStartPicker.Value;
                    DateTime end = (DateTime)PreviousEndPicker.Value;
                    // Use the Add method to add stuff to our manager
                    AddTime(start, end);
                }//end if proper tag is found
            }//end if sender is a button
            else MessageBox.Show("Invalid Sender Type. Expected Button.");
        }//end FinalizePrevTime click event handler

        /// <summary>
        /// React to timing buttons
        /// </summary>
        protected void ClockedTimeButtonClick(object sender, EventArgs e) {
            if (sender is Button button){
                switch (button.Tag) {
                    case "ClockIn":
                        countingTimeRN = true;
                        CountedSeconds = 0;
                        clock.Stop(); clock.Start();
                        break;
                    case "CancelClock":
                        countingTimeRN = false;
                        break;
                    case "ClockOut":
                        // get time from the form and add it to manager
                        DateTime currentTime = DateTime.Now;
                        DateTime startTime = currentTime.AddSeconds(-1 * (int)countedSeconds);
                        AddTime(startTime, currentTime);
                        // reset some things
                        countingTimeRN = false;
                        break;
                    default:
                        MessageBox.Show("Button Tag Not Recognized");
                        break;
                }//end switch case
            }//end if sender is a button
            else MessageBox.Show("Invalid Sender Type. Expected Button.");
        }//end ClockedTimeButtonClick(sender, e)
    }//end class
}//end namespace