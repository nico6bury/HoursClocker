/*
 * Author: Nicholas Sixbury
 * Files: HourTracker.xaml, HourTracker.xaml.cs
 * Purpose: Serves as the view for the Hour Tracker application.
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
        }//end constructor

        /// <summary>
        /// Event that occurs every interval of clock. Generally intended to just
        /// update displayed clock to user.
        /// </summary>
        protected void clockElapsedEvent(object sender, EventArgs e)
        { ClockBox.Text = DateTime.Now.ToString(@"hh\:mm\:ss"); }
    }//end class
}//end namespace