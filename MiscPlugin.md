

# Introduction #

MiscPlugin is a SportTracks plugin with several smaller "actions", most could be included in core ST. Most functionality is done from Activity (or Route) Edit or at import. This is configurable from the plugin settings. If a functionality cannot be applied if conditions not fulfilled (like no separate Elevation track for ElevationToGPS), the option is grayed out in the Edit menu. Generally, the plugin works for several activities.

Note: By default all actions are deactivated and must be manually activated in the settings.

See download tab for latest release.

# Details #

<p>Localization: English, svenska, français, español and Nederlands<br>
<br>If you want to translate the plugin to another language, the instructions are here:<br>
<a href='http://code.google.com/p/gps-running/wiki/Translations'>http://code.google.com/p/gps-running/wiki/Translations</a>
A few of the strings are not used yet...<br>
<br>
<h3>ExtendGPSTrack</h3>
Ever started a run without a GPS-fix? This Plugin inserts GPS points before the fix (and after) and extends the route in the direction. You can then add other GPS points in the ST map editor. (The action extends the route in the direction between the 1 and 4 GPS point with the same elevation as in the first point.)<br>
<br>
The start/end points are determined by using the earliest start time and latest end time from the lap times and all track start/end points. (But availability in the Edit menu item uses only the start/end lap/hr times due to efficiency.)<br>
<br>
The action can also extend GPS where there are no recordings at all, but the handling is trickier. Some combinations of exporting/importing gpx files inserting points is an alternative.<br>
Add a HR point at the start/end where you want to extend the route in Edit Data Tracks, select Data Track. The HR track does not have to cover the activity, to extend the start it is sufficient to have one point data track. The HR track can be removed after editing.<br>
You can insert a GPS point in the end (without manipulating the HR track) by setting Manual calculations, then setting the activity time starting from Start Time to the time of the last GPS point.<br>
<br>
Note regarding Start Time and Activity Time: ST Data tracks (including GPS) is stored relative the Start Time. After inserting points in the start, the Start Time will be incorrect. This cannot be easily changed (the simplest is likely to export a .fitlog edit it and reimport).<br>
<br>
<h3>SetTimeGPS</h3>
When creating a GPS track manually, ST will not set time for the GPS points. This action will set the GPS point time from the activity DistanceTrack if that exists, otherwise from the manually set activity time. If time not manually set (or not possible to set like for routes) the time for the activity is set to one hour.<br>
<br>This can be used to create courses.<br>
<br>Another use for the function is to apply a Distance track (for instance from a foot-pod) on a GPS track, as ST always use GPS track for speed/distance if it exists. Note that it is hard to adjust so the distance in the Distance track and for the GPS matches exactly, so the match will be approximate. See also the ElevationToGPS function below.<br>
<br>
If part of the route is selected on the route when selecting the menu item, the plugin will prompt to smooth the selection, just setting time on the points in the selection, instead of setting the time on the complete activity.<br>
<br>
<p>Possible enhancements:<br>
</p><ul>
<li>Adjust speed for elevation changes (slower uphill than downhill). This should possibly be another plugin and the formula depends on the sport. (old_man_biking did some work for his GPX2Power utility that I have not adapted)(Have not investigated the formula to use for running, any ideas? I believe I have seen such a functionality somewhere, do not know where.)</li>
</ul>
<p>Note that the ApplyRoutes plugin has a similar functionality when downloading courses to devices.<br>
<br>
<h3>Insert Pauses if there is a time-gap for GPS points</h3>
If there are no GPS points for a certain configurable time period, insert pauses.<br>
<br>
<br>This action can for instance be used for the following:<br>
<ul>
<li>You stop but forget to pause on the device. Delete the GPS points at the pause and the plugin will insert a pause.</li>
<li>Edge 705 (see <a href='http://www.zonefivesoftware.com/SportTracks/Forums/viewtopic.php?p=22768#22768'>ST forum</a>) will not include pause markers in a way that ST detects them.</li>
<li>Devices that creates GPX files have no pauses (this is not clearly specified in the GPX format).</li>
</ul>

Note: A Garmin device in smart recording can wait over two minutes between GPS updates when standing still with good accuracy, why the default wait time is set to 180 seconds.<br>
<br>
<br>If a pause already exists just after (3 seconds) the GPS gap start or just before the gap end, those values are used instead. This will utilize the pause start/end markers that devices like Forerunner/Edge 305 includes start/end in the USB communication and the .TCX files (the Edge 705 does not have this info).<br>
<br>
<br>This functionality should be included in a separate plugin that shows paused (and stopped) time in an activity page table (and on the map), and let you manipulate it.<br>
<br>
<h3>Adjust Pauses to Device</h3>
The time ST sees can differ from the time the device sees. To som extent this can be explained with rounding, but especially Edge 705 devices seem to display too loang time even when pauses are inserted.<br>
This action will change the length for pauses so the ST time matches the device time.<br>
<br>
<h3>Detect Rest laps</h3>
If all laps are set to Rest (a problem when importing from some Garmin devices), all laps are set to Active.<br>
<br>
Laps slower than half average activity speed are set as rest laps.<br>
<br>
Detect warmup/cooldown laps in some situations. Rest laps is set in the following situations:<br>
<ul><li>No rest laps exists already</li>
<li>First or last lap is shorter than 1000m</li>
<li>Lap pace/speed is at least 10% slower than the activity average</li>
<li>If both first and second lap is slower than 10% of the activity average, and the total of first and second lap is shorter than 2*1000m</li>
</ul>
The time is not configurable in Settings, but it is possible to edit the ST settings file: Preferences.System.xml<br>
<br>
<h3>Apply Elevation Track to GPS elevation</h3>
ST uses the GPS track if it exists to display elevation. If you import a elevation and GPS track from separate sources, the separate Elevation track will be ignored. One example could be if you have two devices synchronized in time where one records GPS (like a Forerunner) together with a barometric altimeter (for instance some Polar device).<br>
<br>The elevation track must have start/stop time with same or longer time to be active.<br>
<p>Note: In situations where the GPS log is created manually (for instance using an editor or from another ride), it will generally be better to use the elevation correction plugin, as the time at each location will not match the time in the elevation track. The same applies to the speed/pace track. A solution could be to handle Elevation and Pace/Speed tracks from non-GPS devices separately and display that as separate charts in a custom graph.<br>
<p>This can be compared to the SetGPStime function, making ST "prefer" the Elevation track instead of the GPS track.<br>
<br>
<h3>Remove identical GPS locations while moving</h3>
Edge 705 (see <a href='http://www.zonefivesoftware.com/SportTracks/Forums/viewtopic.php?p=32752#32752'>ST forum</a>) had a bug in some firmware, where using one second recording where the GPS position is not updated even if the device is moving. The speed is therefore very uneven. Without smoothing, a bike ride in 30km/h where the device updates the position every fifth second look like four seconds without moving followed by one second in 150km/h (smoothing will even out some of this). However, the device updates the distance track so this plugin can detect and remove these false GPS points.<br>
<br>
<h3>FixHR</h3>
This action fixes initial HR. Garmin HR will occasionally give very high readings the first minutes (probably due to stic from the shirt).<br>
This action will drop HR points over a threshold value for a certain time and over max HR / below rest HR for the complete activity. The action will also insert a HR point at the activity start (to avoid the the HR track is shortened and fix the problem when there were no contact initially).<br>
<br>
<i>This action must be enabled in Settings. Some changes can be done by editing the Preferences.System.xml file.</i>
<br># FixHRCheckSeconds="500"<br>
<br>The activity time for which to run the "initial" check<br>
<br># FixHRTruncateHR="255"<br>
<br>The truncate value (HR over this will be dropped in the initial check)<br>
<br># FixHRStartHR="100"<br>
<br>The HR value inserted (if necessary) at the start of the activity.<br>
<br>
<h3>Prepare for ActivitiesViewer</h3>
ActivitiesViewer is an Android app that shows SportTracks activities in .fitlog and .tcx format on Android devices.<br>
The app will not parse the complete files initially, to speed-up the app.<br>
This action will add certain information to the lap summaries, so the app presents data like Active Pace.<br>
<br>
<h3>Set Manual Calculation on Activities</h3>
Use Device (Manual) activity summaries instead of calculated values.<br>
With this change, ST will report the same summaries as the device reports.<br>
<br>
<h3>Correct GPS</h3>

The Garmin devices have access to information about accuracy. In some situations the device can determine that some points are incorrect and decreases the Distance. Garmin is better at finding stops with no moving. This plugin will use the Distance information to drop bad points.<br>
<br>
<p>This will improve the accuracy when the reception is bad and the pace is low. For instance, a berry picking tour in the woods read 3.85 km in the Garmin, 5.70 km in ST before correction and 4.71 km after correction. The Garmin values seem more reliable from looking at the map, so the distance estimation is likely improved.<br>
<p>This will improve the accuracy when the reception is bad and the pace is low. For instance, a berry picking tour in the woods read 3.85 km in the Garmin, 5.70 km in ST before correction and 4.71 km after correction. The Garmin values seem more reliable from looking at the map, so the distance estimation is likely improved.<br>
<br>A use where the distance could matter is a marathon or so with pauses. The difference will be much smaller in example that matters. In activities without stopped time and decent reception, there is normally no difference.<br>
<br>
You can activate the action to run when importing.<br>
To run the action later, you must import a second time from the ST .fitlog, or Garmin or .tcx, as ST does not read Distance tracks by default. The menu item will not be available when there are no Distance track. It is normally not a good idea to run this if you have manipulated the track somehow.<br>
<br>
<br><b>Note:</b>There is no backup done by the plugin, to undo you need to import the GPS track again. (The ST .fitlog can be used for that purpose.)<br>
<br>
Edit menu Action: Adjust GPS from Device Distance<br>
Drops the points where the device has noted a negative distance.<br>
<br>
This action was previously included in the separate GpsCorrection plugin. The functionality is a fix, just to test, hoping to trigger a discussion of what can be done. This action was written as a simple test what could be done. An enhancement is to possibly drop more points where ST and Garmin has larger differences. A better long term solution is to reorder the GPS route somehow where you have the knowledge of the type of activity. (Some commercial map programs supposedly can do this.)<br>
<br>
To compare the device distance track to the GPS distance track, see <a href='http://code.google.com/p/trails/wiki/Tutorials#GPS_point_to_device_distance_difference'>Trails Plugin</a>.<br>
<br>
<h2>Acknowledgements</h2>
French translation by Meven<br>
Spanish translation by mazoaguirre<br>
Dutch translation by sdessein<br>
<br>
<h2>Change Log</h2>
See Changes<br>
More details about changes in the SVN log.