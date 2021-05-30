using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Author: Nicholas Sixbury
 * File: TimeGrouping.cs
 * Purpose: To serve as a container to hold a bunch of
 * TimedInstance objects that are grouped together
 */

namespace HoursClocker
{
    class TimeGrouping
    {
        private List<TimedInstance> times;
        /// <summary>
        /// the times associated with this group
        /// </summary>
        public List<TimedInstance> Times
        {
            get
            {
                foreach(TimedInstance time in times)
                {
                    time.CurrentGroup = this;
                }//end updating CurrentGroup for everything
                return times;
            }//end getter
            set
            {
                times = value;
            }//end setter
        }//end Times

        public int TimeCount
        {
            get
            {
                return times.Count;
            }//end get
        }//end TimeCount

        public decimal TotalHours
        {
            get
            {
                decimal total = 0;

                foreach(TimedInstance time in times)
                {
                    total += (decimal)time.TimeSpan.TotalHours;
                }//end looping over each timed instance

                return total;
            }//end getter
        }//end TotalTime

        public decimal TotalMinutes
        {
            get
            {
                decimal total = 0;
                foreach(TimedInstance time in times)
                {
                    total += (decimal)time.TimeSpan.TotalMinutes;
                }//end getting minutes from each time
                return total;
            }//end getter
        }//end TotalMinutes

        private string groupName;
        /// <summary>
        /// the name of this group
        /// </summary>
        public string GroupName
        {
            get { return new StringBuilder(groupName).ToString(); }
            set
            {
                if (value == null)
                {
                    groupName = "Ungrouped";
                }//end if value is null
                else if (value == "$ENDGROUP$") groupName = "ENDGROUP";
                else if (value == "$BEGINGROUP$") groupName = "BEGINGROUP";
                else { groupName = new StringBuilder(value).ToString(); }
            }//end setter
        }//end GroupName

        /// <summary>
        /// just an empty group, text is Ungrouped
        /// </summary>
        public static TimeGrouping EmptyGroup
        {
            get { return new TimeGrouping(); }
        }//end EmptyGroup

        /// <summary>
        /// initializes this group as empty
        /// </summary>
        public TimeGrouping()
        {
            Times = new List<TimedInstance>();
            GroupName = "Ungrouped";
        }//end no-arg constructor

        public TimeGrouping(List<TimedInstance> times)
        {
            Times = new List<TimedInstance>();
            foreach(TimedInstance time in times)
            {
                TimedInstance newTime = new TimedInstance(time);
                newTime.CurrentGroup = this;
                Times.Add(newTime);
            }//end copying over times
            GroupName = "Ungrouped";
        }//end 1-arg constructor

        public TimeGrouping(string name)
        {
            Times = new List<TimedInstance>();
            this.GroupName = name;
        }//end 1-arg constructor

        public TimeGrouping(List<TimedInstance> times, string name)
        {
            Times = new List<TimedInstance>();
            foreach (TimedInstance time in times)
            {
                TimedInstance newTime = new TimedInstance(time);
                newTime.CurrentGroup = this;
                Times.Add(newTime);
            }//end copying over times
            GroupName = new StringBuilder(name).ToString();
        }//end 2-arg constructor

        /// <summary>
        /// returns the name of the group
        /// </summary>
        public override string ToString()
        {
            return GroupName;
        }//end ToString()

        /// <summary>
        /// checks if the supplied object is the same as this one. TimedGrouping
        /// objects with the same name are considered equal.
        /// </summary>
        /// <param name="group">the object you wish to compare to this one</param>
        /// <returns>returns true if they're equal and false otherwise</returns>
        public bool Equals(TimeGrouping group)
        {
            return this.groupName.Equals(group.groupName);
        }//end Equals

        public void Remove(TimedInstance time)
        {
            Times.Remove(time);
        }//end Remove(time)

        /// <summary>
        /// Gets eariest TimeOfDay from the group without
        /// taking date into account at all
        /// </summary>
        /// <returns>returns the earliest time</returns>
        public TimedInstance EarliestTime
        {
            get
            {
                TimedInstance earliestTime = new TimedInstance(DateTime.Now, DateTime.Now);
                foreach (TimedInstance time in Times)
                {
                    if (time.Start.TimeOfDay.Ticks < earliestTime.Start.TimeOfDay.Ticks)
                    {
                        earliestTime = time;
                        break;
                    }//end if we found an earlier time
                }//end looping for each time in the group
                return earliestTime;
            }//end getter
        }//end GetEarliestTime(times)

        /// <summary>
        /// Gets earliest starting DateTime from the group, taking time into account
        /// </summary>
        /// <returns>returns the earliest date</returns>
        public TimedInstance EarliestDate
        {
            get
            {
                TimedInstance earliestDate = new TimedInstance(DateTime.Now, DateTime.Now);
                foreach (TimedInstance time in Times)
                {
                    if (time.printDate && time.handleSpecificBeginEnd)
                    {
                        if (time.Start.Ticks < earliestDate.Start.Ticks)
                        {
                            earliestDate = time;
                            break;
                        }//end if we found an earlier time
                    }//end if we have a date on this one
                }//end looping for each time in the group
                return earliestDate;
            }//end getter
        }//end GetEarliestDate(dates)

        /// <summary>
        /// returns a list of string lines formatted to be printed to a file.
        /// The string can be read back into a TimeGrouping via
        /// ReadFromLines(), a method in this class
        /// </summary>
        public List<string> FormatForFile()
        {
            List<string> lines = new List<string>();

            //print that we're starting a group
            lines.Add("$BEGINGROUP$");

            //add the group name
            lines.Add($"{GroupName}");

            //add all the times
            foreach (TimedInstance time in Times)
            {
                lines.Add(time.FormatForFile());
            }//end getting all the lines

            //print that we're ending the group
            lines.Add("$ENDGROUP$");

            return lines;
        }//end FormatForFile()

        /// <summary>
        /// reads in the lines formatted from the FormatForFile() method
        /// into this object, replacing any previous data
        /// </summary>
        /// <param name="Lines">The lines from the </param>
        /// <exception cref="ArgumentException"></exception>
        public void ReadFromLines(List<string> lines)
        {
            List<string> Lines = new List<string>();

            //just make sure our input is good
            try
            {
                foreach(string line in lines)
                {
                    Lines.Add(new StringBuilder(line).ToString());
                }//end copying over all lines so we clear the references

                if (!Lines.Remove("$BEGINGROUP$")) throw new ArgumentException("The provided lines do not start with $BEGINGROUP$. Please provide all lines.");
                if (!Lines.Remove("$ENDGROUP$")) throw new ArgumentException("The provided lines do not start with $ENDGROUP$. Please provide all lines.");
            }//end trying to ensure input is good
            catch(Exception e)
            {
                var except = e.InnerException;
                throw except;
            }//end making sure to throw our exception

            //at this point, BEGIN and END flags should be removed if we've gotten here

            //get name from the file
            this.GroupName = Lines[0];
            //remove that name from the lines
            Lines.RemoveAt(0);

            //get all the times from the lines
            this.Times = new List<TimedInstance>();
            while(Lines.Count > 0)
            {
                //adds the first time to this object, read from string
                Times.Add(new TimedInstance(Lines[0]));
                //remove the first time from Lines
                Lines.RemoveAt(0);
            }//end looping while we have lines to process
            
        }//end ReadFromLines(Lines)
    }//end class
}//end namespace