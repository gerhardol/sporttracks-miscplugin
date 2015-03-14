# Introduction #

Note: Depreciated Plugin: Gps Correction functionality is now included in MiscPlugin.

Corrects GPS routes by removing bad points

Note: By default all actions are deactivated and must be manually activated in the settings.

See download tab for latest release.

# Details #

Localization: English, svenska, français, español and Nederlands
If you want to translate the plugin to another language, use the language file http://code.google.com/p/sporttracks-miscplugin/source/browse/trunk/SportTracksPluginResources.xls (I only have OpenOffice, save in Excel 2000 format.) PM me where to get the file or your email address. A few of the strings are not used yet...

The Garmin devices have access to information about accuracy. In some situations the device can determine that some points are incorrect and decreases the Distance. Garmin is better at finding stops with no moving. This plugin will use the Distance information to drop bad points.

<p>This will improve the accuracy when the reception is bad and the pace is low. For instance, a berry picking tour in the woods read 3.85 km in the Garmin, 5.70 km in ST before correction and 4.71 km after correction. The Garmin values seem more reliable from looking at the map, so the distance estimation is likely improved.<br>
<p>This will improve the accuracy when the reception is bad and the pace is low. For instance, a berry picking tour in the woods read 3.85 km in the Garmin, 5.70 km in ST before correction and 4.71 km after correction. The Garmin values seem more reliable from looking at the map, so the distance estimation is likely improved.<br>
<br>A use where the distance could matter is a marathon or so with pauses. The difference will be much smaller in example that matters. In activities without stopped time and decent reception, there is normally no difference.<br>
<br>
You can activate the action to run when importing.<br>
To run the action later, you must import a second time from the ST .fitlog, or Garmin or .tcx, as ST does not read Distance tracks by default. The menu item will not be available when there are no Distance track. It is normally not a good idea to run this if you have manipulated the track somehow.<br>
<br>
<br><b>Note:</b>There is no backup done by the plugin, to undo you need to import the GPS track again. (The ST .fitlog can be used for that purpose.)<br>
<p>Two options in Edit menu:<br>
<br>
<ul><li>DifferenceToPowerTrack<br>
If GPS and a DistanceTrack both exists (and no PowerTrack), it puts the distance difference in the PowerTrack.<br>
Use it to try to find how the black magic in !Garmin devices calculates distances compared to ST postprocessing. Even if the distance is not causing bad points, it shows where the problems likely are located.<br>
</li>
<li>Adjust GPS from Device Distance<br>
Drops the points where the device has noted a negative distance.<br>
</li>
</ul>

<h4>Status</h4> A fix, just to test, hoping to trigger a discussion of what can be done<br>
<br>
<h4>Future</h4> This was written as a simple test what could be done. An enhancement is to possibly drop more points where ST and Garmin has larger differences. A better long term solution is to reorder the GPS route somehow where you have the knowledge of the type of activity. (Some commercial map programs supposedly can do this.)<br>
<br>
<h2>Acknowledgements</h2>
French translation by Meven<br>
<br>Spanish translation by mazoaguirre<br>
<br>Dutch translation by sdessein<br>
<br>
<h2>ChangeLog</h2>

Most info about releases is in the SVN log.<br>
Old history: <a href='http://hem.bredband.net/gerhardnospam/index_gpscorrection.htm'>http://hem.bredband.net/gerhardnospam/index_gpscorrection.htm</a>