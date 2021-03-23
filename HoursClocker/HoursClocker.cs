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

        public HoursClocker()
        {
            InitializeComponent();
            uxGroupsDefaultLocation = uxGroupsGroup.Location;
            uxHoursDefaultLocation = uxSavedHoursGroup.Location;
        }//end constructor

        private void uxListViewOptions_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            specifyDate = uxListViewOptions.Items[0].Checked;
            specifyBeginEnd = uxListViewOptions.Items[1].Checked;
        }//end uxListViewOptions ItemChecked event handler

        private void uxToggleGroupsBtn_Click(object sender, EventArgs e)
        {
            bool groupsEnabledBefore = uxGroupsGroup.Enabled;
            uxGroupsGroup.Enabled = !groupsEnabledBefore;
            uxGroupsGroup.Visible = !groupsEnabledBefore;
            if (groupsEnabledBefore) uxSavedHoursGroup.Location = uxGroupsDefaultLocation;
            else uxSavedHoursGroup.Location = uxHoursDefaultLocation;

            groupsCurrentlyEnabled = !groupsEnabledBefore;
        }//end uxToggleGroupsBtn Click event handler
    }//end class
}//end namespace