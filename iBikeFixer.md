# Introduction #

"Fixes" PowerTracks from power meters recorded with a separate device, for instance iBike without Garmin 705 integration

See download tab for latest release.

# Details #

<br>iBike Power meters (and supposedly other power meters like the PowerTap) auto pauses and will not record this somehow in the log. It is therefore difficult to compare the iBike data with other sources. For instance Garmin uses absolute time and notes pauses in the log. This is a fix that fixes the Power track and improves the reading a little:<br>
<br>
<br> Will adjust the StoppedSpeed so the iBike and activity MovingTime matches and insert the pauses to the iBike Power track.<br>
<p>For the record: The Garmin does not need to be in Second recording, smart mode should be better. It is likely better to not use Garmin auto-pauses as well (not confirmed).<br>
<br>
<br>This is not an iBike importer.<br>
<br>
<p>Localization: English, svenska, français, español and Nederlands<br>
(Some printouts in English only.)<br>
<br>
<p>Status: A fix for racerfern<br>
<br>
<p>Future: It could be possible to make a better match of the pauses by using Garmin/iBike Distance track too. The algorithm will be very complicated for this, not sure if the precision will be improved.<br>
It likely not worth it trying to merge individual tracks without time data, use Edge 705 as the recorder instead.<br>
<br>
<h2>Acknowledgements</h2>
French translation by Meven<br>
<br>Spanish translation by mazoaguirre<br>
<br>Dutch translation by sdessein<br>
<br>
<h2>Change Log</h2>
Most info about releases is in the SVN log. Old history: <a href='http://hem.bredband.net/gerhardnospam/index_ibikefixer.htm'>http://hem.bredband.net/gerhardnospam/index_ibikefixer.htm</a>