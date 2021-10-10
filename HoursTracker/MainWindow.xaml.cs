/*
 * Author: Nicholas Sixbury
 * Files: HourTracker.xaml, HourTracker.xaml.cs
 * Purpose: Serves as the view for the Hour Tracker application.
 */

using HoursClockerLibrary;
using System;
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
        /// The manager for all of the times.
        /// </summary>
        protected TimeGroupManager manager = new TimeGroupManager();
        /// <summary>
        /// Seconds counted since some particular starting point.
        /// </summary>
        protected ulong countedSeconds = 0;
        protected ulong CountedSeconds
        {
            get { return countedSeconds; }
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
        public MainWindow()
        {
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
            manager.AddTime(time, groupName);
        }//end AddTime(start, end)

        /// <summary>
        /// Add previous time from form to the 
        /// </summary>
        protected void AddPreviousTime()
        {
            // Grab all the data we need from the form
            DateTime start = (DateTime)PreviousStartPicker.Value;
            DateTime end = (DateTime)PreviousEndPicker.Value;
            // Use the Add method to add stuff to our manager
            AddTime(start, end);
        }//end AddPreviousTime()

        /// <summary>
        /// React to timing buttons
        /// </summary>
        protected void ClockedTimeButtonClick(object sender, EventArgs e)
        {
            if (sender is Button button){
                switch (button.Tag)
                {
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
            else MessageBox.Show("Invalid Sender Type");
        }//end ClockedTimeButtonClick(sender, e)
    }//end class
}//end namespace