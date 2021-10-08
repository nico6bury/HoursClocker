# HoursClocker
Just a little program I decided to put together to keep track of how much time I spend on various things.
A lot of the code for it is pretty messy, but I was mostly focusing on getting the program done instead of worrying about the ease of updates. If I do end up updating it, that'll be a hurdle I'll have to get over, but I'll burn that bridge down when I get to it.
Essentially, the current features are as follows:  
-Keep Track of time you do something and save it. Can also cancel this without saving it anywhere if you change your mind.  
-Add previous time records into the program with following options  
 -Add time with specific starting and ending date and time. Works correctly for times that span across more than one day.  
 -Add time with specific starting and ending time. If time spills across two days, the program will notice and correct input.  
 -Add number of hours and minutes without specifying when you began or ended whatever you were doing.  
-Group Time spent in different activities in different categories  
-Delete specific times or groups from your entered data. If a group is deleted, its times are added to another group  
-Automatically update a configuration file which serializes information about each instance of time and all entered groups, allowing the program to save information across different sessions.  
-Displays the current system time  
-Gives you the option of hiding the box which holds group information in order to make the window smaller  
-No installation needed. Just plop the executable in whatever folder you want the program to run in. Any necessary files will be created as needed.

Notes:
It is recommended that you put the executable in its own folder so it has less noise to cut through when looking for files.
Currently, there's no way to name or differentiate various time instances. This is a likely avenue for further development.
The only way to save your information is to close the program. That's a little inconvenient. Some information like the display of group info is not saved session-to-session.
The font is pretty small. People with bad eyes might have trouble reading stuff. Not sure what the best way to resolve this would be, as I personally rather like the compactness of the window.
It would also be nice to be able to sort different time instances or at least collapse specific groups. It's somewhat inconvenient to have to scroll down each time.
If you really want to, you can add times and groups by editing the config file that generates upon the program being opened and closed. I don't plan on writing any kind of guide for that, but if you have a reference of the output, it probably wouldn't be that hard to figure out the pattern. You could also just check out the code.
