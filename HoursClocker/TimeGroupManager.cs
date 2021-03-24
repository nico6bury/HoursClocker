using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/*
 * Author: Nicholas Sixbury
 * File: TimeGroupManager.cs
 * Purpose: To provide a somewhat consolidate interface for
 * managing various groups of timedInstances
 */

namespace HoursClocker
{
    /// <summary>
    /// this basically serves as an interface for a bunch of TimedInstance objects
    /// </summary>
    class TimeGroupManager
    {
        /// <summary>
        /// all the groups of times for this object
        /// </summary>
        public List<TimeGrouping> Groups { get; set; }

        /// <summary>
        /// Initializes list of groups
        /// </summary>
        public TimeGroupManager()
        {
            Groups = new List<TimeGrouping>();
        }//end no-arg constructor

        /// <summary>
        /// adds the specified time to a group with the specified name.
        /// If the group doesn't exist, it will be created.
        /// </summary>
        /// <param name="time">the time to add</param>
        /// <param name="groupName">the name of the group</param>
        /// <returns>Returns true if a new group was created, or
        /// false if the time was put into an old group</returns>
        public bool AddTime(TimedInstance time, string groupName)
        {
            bool foundExistingGroup = false;
            int foundGroupIndex = -1;

            for(int i = 0; i < Groups.Count; i++)
            {
                if(groupName == Groups[i].GroupName)
                {
                    foundExistingGroup = true;
                    foundGroupIndex = i;
                    break;
                }//end if we found an existing group
            }//end looping over all the groups

            if (foundExistingGroup)
            {
                Groups[foundGroupIndex].Times.Add(time);
            }//end if we found an existing group to add to
            else
            {
                foundGroupIndex = Groups.Count;
                Groups.Add(new TimeGrouping(groupName));
                Groups[foundGroupIndex].Times.Add(time);
            }//end else we need to make a new one

            return foundExistingGroup;
        }//end AddTime(time, groupName)

        /// <summary>
        /// Generates a list of file data for this object
        /// </summary>
        /// <returns>a list of strings to be written to a file</returns>
        public List<string> GenerateFileData()
        {
            //this will hold the lines from all the groups
            List<string> finalOutput = new List<string>();

            foreach(TimeGrouping group in Groups)
            {
                List<string> groupOutput = group.FormatForFile();
                foreach(string line in groupOutput)
                {
                    finalOutput.Add(line);
                }//end adding each line for this group
            }//end generating output for each group

            return finalOutput;
        }//end GenerateFileData()

        /// <summary>
        /// Has a very long parser that formats the supplied lines into different lists
        /// based on groups. Will try to fix incorrect formatting as best as it can, but
        /// it can only do so much if stuff is ultra-broken. Will also tell you if *something*
        /// went wrong, but not what exactly it was that did go wrong. Shouldn't throw any errors
        /// </summary>
        /// <param name="lines">all the lines from the file you're reading from, with no
        /// black lines or anything else in between group start and end flags</param>
        /// <returns>returns true if nothing went wrong, and false if something did go wrong, but
        /// we were able to salvage the sitation without throwing any errors. If errors are thrown,
        /// that means something is *really* wrong with whatever your input is.</returns>
        public bool ReadFileData(List<string> lines)
        {
            //make out list of output lists
            List<List<string>> groupOutputs = new List<List<string>>();

            //define our variable to keep track of our index of the first dimension in above list
            int firstDimesionIndex = -1;

            //help us keep track of if we just began a group
            bool justBeganGroup = false;

            //help us track state so we know if something went wrong
            bool currentlyParsingGroup = false;
            bool finishedHeaderForCurrentGroup = false;

            //let us know for sure if something did go wrong
            bool noProblems = true;

            //start looping through the lines to build our list
            for (int i = 0; i < lines.Count; i++)
            {
                if (justBeganGroup)
                {
                    //just double check state isn't fucked
                    if(lines[i] == "$ENDGROUP")
                    {
                        //add a header so we can rest somewhat easier when we parse
                        groupOutputs[firstDimesionIndex].Add("Unordered Group");

                        //go ahead and update stuff and pretend this didn't happen
                        justBeganGroup = false;
                        finishedHeaderForCurrentGroup = true;

                        //let everyone know there's something wrong
                        noProblems = false;
                    }//end if this group has no header. Jeez
                    else
                    {
                        //update this for next iteration
                        justBeganGroup = false;
                        finishedHeaderForCurrentGroup = true;

                        //add the group name to where it's supposed to go
                        groupOutputs[firstDimesionIndex].Add(lines[i]);
                    }//end else the state looks fine for now
                }//end if we just began a new group
                else if(lines[i] == "$BEGINGROUP$")
                {
                    //just double check that the previous group ended right
                    if (currentlyParsingGroup)
                    {
                        //who knows what happened to the last group, but let's try to fix it

                        //let everyone know something happened
                        noProblems = false;

                        //first, let's make sure they had a header
                        if(lines[i - 1] == "$BEGINEND$")
                        {
                            //add that header
                            groupOutputs[firstDimesionIndex].Add("Unordered Group");
                        }//end if they don't even have group header

                        //add the ending flag
                        groupOutputs[firstDimesionIndex].Add("$ENDGROUP$");

                        //we'll have to try and preceded as normal here
                    }//end if the last group didn't end right

                    //get list set up to accept a new group
                    firstDimesionIndex++;
                    groupOutputs.Add(new List<string>());

                    //add the appropriate line to the appropriate place
                    groupOutputs[firstDimesionIndex].Add(lines[i]);

                    //let the next iteration know we just began a group
                    justBeganGroup = true;
                    currentlyParsingGroup = true;
                    finishedHeaderForCurrentGroup = false;
                }//end else if we're beginning a new group
                else if(lines[i] == "$ENDGROUP$")
                {
                    //nothing all too special here, but we know the situation very well
                    groupOutputs[firstDimesionIndex].Add(lines[i]);

                    //update boolean
                    currentlyParsingGroup = false;
                }//end else if we're ending a group
                else
                {
                    //make sure the header is there
                    if (!finishedHeaderForCurrentGroup)
                    {
                        //go ahead and add the default header
                        groupOutputs[firstDimesionIndex].Add("Unordered Group");

                        //let everyone know something happened
                        noProblems = false;

                        //we'll have to try to precede as normal here
                    }//end if we don't have a group header

                    //we evidently have a normal input line here
                    groupOutputs[firstDimesionIndex].Add(lines[i]);
                }//end else we have normal input
            }//end looping to build a new 2-d list

            //initialize the list we'll use
            List<TimeGrouping> groups = new List<TimeGrouping>();

            //start reading the information from the file
            foreach(List<string> groupOutput in groupOutputs)
            {
                TimeGrouping group = new TimeGrouping();
                try
                {
                    //try to read the lines for this group
                    group.ReadFromLines(groupOutput);

                    //we must have been able to read those, so I guess we're good to add this one
                    groups.Add(group);
                }//end trying to parse the lines we got
                catch
                {
                    //I guess that group wasn't formatted correcly ¯\_(ツ)_/¯

                    //we'll let everyone know that something happened
                    noProblems = false;
                }//end catching any parsing errors that get thrown at us
            }//end looping over each list of group output

            //we got to the end, so evidently we must have a good list of groups to use
            this.Groups = groups;

            //we can go ahead and return now
            return noProblems;
        }//end ReadFileData(lines)

        /// <summary>
        /// attempts to merge any groups with the same name
        /// </summary>
        public void MergeEqualGroups()
        {
            //initialize list of groups that can be merged
            List<TimeGrouping> equalGroups = new List<TimeGrouping>();

            //figure out what groups are equal to something
            for(int i = 0; i < Groups.Count; i++)
            {
                for(int j = i + 1; j < Groups.Count; j++)
                {
                    if (Groups[i].Equals(Groups[j]))
                    {
                        //add reference to group
                        equalGroups.Add(Groups[i]);

                        //break out of inner loop
                        j = Groups.Count;
                    }//end if we found a match
                }//end looping over all groups to look for group1
            }//end looping over each group in Groups of this object

            //initialze list of groups that don't need to be merged
            List<TimeGrouping> unequalGroups = new List<TimeGrouping>();

            //build the groups that are already fine
            foreach (TimeGrouping group in Groups)
            {
                if (!equalGroups.Contains(group))
                {
                    unequalGroups.Add(group);
                }//end if group is unequal
            }//end building out unequal list

            //at this point, we should start building our 2d list

            //initialize working list of groups we'll want to merge together
            List<List<TimeGrouping>> groupsToMerge = new List<List<TimeGrouping>>();
            groupsToMerge.Add(new List<TimeGrouping>());

            //actually build the 2d list
            for(int i = 0; i < equalGroups.Count; i++)
            {
                for(int j = 0; j < groupsToMerge.Count; j++)
                {
                    /// <summary>
                    /// we want to search each of the groups in
                    /// groupsToMerge. If we reach the last index
                    /// in groupsToMerge and haven't found a
                    /// containing list, then we want to make
                    /// a new one and add it
                    /// </summary>
                    if (groupsToMerge[j].Contains(equalGroups[i]))
                    {
                        groupsToMerge[j].Add(equalGroups[i]);

                        //exit out of inner loop
                        j = groupsToMerge.Count;
                    }//end if we've found a match
                    else if(j == groupsToMerge.Count - 1)
                    {
                        //add a new slot in the list
                        groupsToMerge.Add(new List<TimeGrouping>());

                        //add our group to that slot
                        groupsToMerge[j + 1].Add(equalGroups[i]);

                        //exit out of this loop
                        j = groupsToMerge.Count;
                    }//end else we need to make a new slot in our list
                }//end looping over all the group lists
            }//end looping over equalGroups

            //at this point, our 2d list should be done. fingers crossed

            //initialize the list that will hold our final list of merged lists
            List<TimeGrouping> mergedGroups = new List<TimeGrouping>();

            //start iterating through groupsToMerge
            for(int i = 0; i < groupsToMerge.Count; i++)
            {
                for(int j = 0; j < groupsToMerge[i].Count; j++)
                {
                    //ok, so we need to merge all the groups in groupsToMerge[i] into one group
                    //initialize temp group to hold time data with shared group name
                    TimeGrouping tempGrouping = new TimeGrouping(groupsToMerge[i][0].GroupName);
                    for(int k = 0; k < groupsToMerge[i][j].Times.Count; k++)
                    {
                        tempGrouping.Times.Add(groupsToMerge[i][j].Times[k]);
                    }//end looping over the individual times in groupsToMerge[i][j]
                }//end looping over each group in this list
            }//end looping over each list of groups to merge

            //we should have our lists all made and ready, so let's put that data in this object
            Groups.Clear();
            foreach(TimeGrouping group in unequalGroups)
            {
                Groups.Add(group);
            }//end adding the non-duplicate groups from before
            foreach(TimeGrouping group in mergedGroups)
            {
                Groups.Add(group);
            }//end adding the merged duplicate groups

            //whoo! We finished
        }//end MergeEqualGroups
    }//end class
}//end namespace