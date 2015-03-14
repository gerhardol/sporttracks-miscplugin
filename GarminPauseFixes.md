# Introduction #

How to fix the problem with pauses for newer Garmin devices with ANT-agent and USB mass storage, like Edge 705 and Garmin Forerunner 405/310

# Details #

More information about the actions on the MiscPlugin User's Guide

A quick instruction:
  * Make sure you have backups. I do not expect crash&burn, but maybe you not want the data manipulation after all.
  * Check "Include Stopped" (Include Pauses does not make a difference). The plugin will ignore these settings while processing, but ST will make further handling of the data after the plugin and the result will no longer match.
  * Enable the actions in Settings->Plugins->MiscPlugin. You probably want to activate the actions edit actions first, add the option at import when you are comfortable with the changes
    * Insert Pauses at GPS Gaps
      * Min GPS gap depends on your settings
        * Per second recording: Set to 1 sec
        * Smart recording: Probably at least 10 seconds
    * Adjust Pauses to Device Time
    * Remove Identical GPS points (see below)
  * If you want to use this by default, select AtImport and it runs automatically.

Note: If you have the "one second recording issue" discussed here:
http://www.zonefivesoftware.com/SportTracks/Forums/viewtopic.php?t=6142
you want to insert pauses before removing the bad points. As RemoveDuplicates is easiest to use at import, then insert pauses should be done at import (so it runs first).