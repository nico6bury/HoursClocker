using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
        /// <summary>
        /// the start time for this object
        /// </summary>
        public DateTime Start;
        /// <summary>
        /// the end time for this object
        /// </summary>
        public DateTime End;

        public TimeSpan TimeSpan
        {
            get
            {
                return End.Subtract(Start);
            }//end getter
        }//end TimeSpan

        /// <summary>
        /// whether or not we should worry about the exact beginning
        /// and end when printing stuff out.
        /// </summary>
        public bool handleSpecificBeginEnd;

        /// <summary>
        /// whether or not the ToString will include the date
        /// </summary>
        public bool printDate = true;

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
            if (fileComponents.Length > 4) throw new ArgumentException("You seem to have too many semi-colons.");

            //get handleSpecificBeginEnd
            string value = fileComponents[0];
            //gets substring after the first ','
            value = value.Substring(value.IndexOf(',') + 1);
            handleSpecificBeginEnd = Convert.ToBoolean(value);

            //get printDate
            value = fileComponents[1];
            value = value.Substring(value.IndexOf(',') + 1);
            printDate = Convert.ToBoolean(value);

            //get start
            value = fileComponents[2];
            value = value.Substring(value.IndexOf(',') + 1);
            Start = DateTime.Parse(value);

            //get end
            value = fileComponents[3];
            value = value.Substring(value.IndexOf(',') + 1);
            End = DateTime.Parse(value);

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