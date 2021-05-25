using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Threading.Tasks;

/*
 * Author: Nicholas Sixbury
 * File: TimedInstance.cs
 * Purpose: To store time related information for a single
 * instance of doing something over a period of time
 */

namespace HoursClocker
{
    /// <summary>
    /// this class represents one instance of time over which
    /// something took place
    /// </summary>
    class TimedInstance
    {
        private DateTime start;
        /// <summary>
        /// the start time for this object
        /// </summary>
        public DateTime Start { get => start; set => start = value; }
        private DateTime end;
        /// <summary>
        /// the end time for this object
        /// </summary>
        public DateTime End { get => end; set => end = value; }

        public string DateSpan { get { return $"{Start:g} => {End:g}"; } }
        public string StartDateShort { get { return $"{Start:d}"; }
            set
            {

            }//end setter
        }//end StartDateShort
        public int Hours { get { return TimeSpan.Hours; }
            set
            {
                //figure out the difference between what we have and what we want
                int hoursDifference = value - TimeSpan.Hours;
                //add those hours to the DateTime End thing
                End = End.AddHours(hoursDifference);
            }//end setter
        }//end Hours
        public int Minutes { get { return TimeSpan.Minutes; }
            set
            {
                //figure out the difference between what we have and what we want
                int minutesDifference = value - TimeSpan.Minutes;
                //add those hours to the DateTime End thing
                End = End.AddMinutes(minutesDifference);
            }//end setter
        }//end Minutes

        private string instanceName;
        /// <summary>
        /// The name of this timed instance, likely as set arbitrarily by the user
        /// </summary>
        public string InstanceName
        {
            get
            {
                return instanceName;
            }//end getter
            set
            {
                StringBuilder nameBuilder = new StringBuilder();
                foreach(char character in value)
                {
                    if (character != ';' && character != ',')
                        nameBuilder.Append(character);
                }//end looping foreach character in new value
                instanceName = nameBuilder.ToString();
            }//end setter
        }//end InstanceName

        public TimeSpan TimeSpan
        {
            get
            {
                return End.Subtract(Start);
            }//end getter
        }//end TimeSpan

        /// <summary>
        /// The group which this time currently belongs to
        /// </summary>
        public TimeGrouping CurrentGroup { get; set; }

        /// <summary>
        /// whether or not we should worry about the exact beginning
        /// and end when printing stuff out.
        /// </summary>
        public bool handleSpecificBeginEnd { get; set; }

        /// <summary>
        /// whether or not the ToString will include the date
        /// </summary>
        public bool printDate { get; set; } = true;

        public bool Equals(TimedInstance time)
        {
            return this.printDate == time.printDate && this.handleSpecificBeginEnd == time.handleSpecificBeginEnd &&
                this.Start.Equals(time.Start) && this.End.Equals(time.End) && this.CurrentGroup == time.CurrentGroup;
        }

        /// <summary>
        /// initializes DateTime object with a particular start and end time.
        /// Assumes you are using a specific beginning and end for this object.
        /// </summary>
        /// <param name="start">the starting time</param>
        /// <param name="end">the ending time</param>
        public TimedInstance(DateTime start, DateTime end)
        {
            this.Start = start;
            this.End = end;
            handleSpecificBeginEnd = true;
        }//end 2-arg specific constructor

        /// <summary>
        /// initializes DateTime object with an arbitrary date and time, instead 
        /// specifying the span of hours and minutes. Assumes you don't care about
        /// the specific beginning or ending.
        /// </summary>
        /// <param name="hours">the hours this object spans</param>
        /// <param name="minutes">the minutes in addition to hours that this object
        /// spans</param>
        public TimedInstance(int hours, int minutes)
        {
            Start = DateTime.Now;
            DateTime temp = Start.AddHours(hours);
            End = temp.AddMinutes(minutes);
        }//end 2-arg non-specific constructor

        /// <summary>
        /// creates this object as a copy of the supplied instance
        /// </summary>
        /// <param name="instance">the object you wish to copy</param>
        public TimedInstance(TimedInstance instance)
        {
            this.Start = new DateTime(instance.Start.Ticks);
            this.End = new DateTime(instance.End.Ticks);
            this.handleSpecificBeginEnd = instance.handleSpecificBeginEnd;
            this.printDate = instance.printDate;
        }//end 1-arg copy constructor

        /// <summary>
        /// initializes this object based on information in a file
        /// </summary>
        /// <param name="fileLine">the line from a file with information for
        /// this object</param>
        /// <exception cref="ArgumentException"></exception>
        public TimedInstance(string fileLine)
        {
            char[] splitters = new char[1];
            splitters[0] = ';';

            string[] fileComponents = fileLine.Split(splitters, StringSplitOptions.RemoveEmptyEntries);

            foreach(string component in fileComponents)
            {
                string[] componentComponents = component.Split(',');
                PropertyInfo property = this.GetType().GetProperty(componentComponents[0]);
                if(property.PropertyType == typeof(bool))
                {
                    property.SetValue(this, Convert.ToBoolean(componentComponents[1]));
                }//end if the property is a bool
                else if(property.PropertyType == typeof(DateTime))
                {
                    property.SetValue(this, DateTime.Parse(componentComponents[1]));
                }//end else if property is a DateTime
                else if(property.PropertyType == typeof(string))
                {
                    property.SetValue(this, componentComponents[1]);
                }//end else if property is a string
            }//end looping over each component of the line
        }//end 1-arg constructor for reading data from a file line

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            if (handleSpecificBeginEnd)
            {
                if (printDate)
                {
                    sb.Append($"{Start} to {End}");
                }//end if we should print the date
                else
                {
                    sb.Append($"{Start.ToString("T")} to {End.ToString("T")}");
                }//end if we just want the time
            }//end if handleSpecificBeginEnd
            else
            {
                TimeSpan span = End.Subtract(Start);
                sb.Append($"{span.Hours} hours and {span.Minutes} minutes");
            }//end else we just want the span

            return sb.ToString();
        }//end ToString()

        public string FormatForFile()
        {
            StringBuilder sb = new StringBuilder();

            //add name to string
            sb.Append($"InstanceName,{InstanceName};");

            //add boolean to string
            sb.Append($"handleSpecificBeginEnd,{handleSpecificBeginEnd};");
            sb.Append($"printDate,{printDate};");

            //add dateTime begin to string
            sb.Append($"Start,{Start};");

            //add dateTime end to string
            sb.Append($"End,{End};");

            return sb.ToString();
        }//end FormatForFile()
    }//end class
}//end namespace