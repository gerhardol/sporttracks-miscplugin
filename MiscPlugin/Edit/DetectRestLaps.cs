/*
Copyright (C) 2009 Gerhard Olsson 

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Lesser General Public
License as published by the Free Software Foundation; either
version 3 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public
License along with this library. If not, see <http://www.gnu.org/licenses/>.
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections; 

using ZoneFiveSoftware.Common.Data;
using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Data.GPS;
using ZoneFiveSoftware.Common.Visuals;
using ZoneFiveSoftware.Common.Visuals.Fitness;

namespace MiscPlugin.Edit
{
    class DetectRestLaps
    {
        public DetectRestLaps(IActivity activity)
        {
            this.activity = activity;
        }
        public DetectRestLaps(IActivity activity, int checkType)
        {
            this.checkType = checkType;
            this.activity = activity;
        }
        public static bool isEnabled(IActivity activity)
        {
            if (activity != null && activity.Laps != null && activity.Laps.Count > 1)
            {
                return true;
            }
            return false;
        }

        public int Run() 
        {
            if (checkType == 1 && (activity.Laps[0].Rest == true
               || activity.Laps[activity.Laps.Count - 1].Rest == true))
            {
                //Purge update in certain situations, do not slow down Edit
                //(should be all laps)
                return 1;
            }

            ActivityInfo info = ActivityInfoCache.Instance.GetInfo(activity);
            bool update = false;
            String tmpNotes = "";

            //Two warmup laps
            if ((info.RecordedLapDetailInfo[0].LapDistanceMeters + info.RecordedLapDetailInfo[1].LapDistanceMeters)
            < 2 * MiscPlugin.Plugin.DetectRestLapsLapDistance
                && activity.Laps[0].TotalTime.TotalSeconds > 0
                && activity.Laps[1].TotalTime.TotalSeconds > 0
                && activity.TotalTimeEntered.TotalSeconds > 0
                && MiscPlugin.Plugin.DetectRestLapsSpeedFactor
                * info.RecordedLapDetailInfo[0].LapDistanceMeters / activity.Laps[0].TotalTime.TotalSeconds
                  < activity.TotalDistanceMetersEntered / activity.TotalTimeEntered.TotalSeconds
                && MiscPlugin.Plugin.DetectRestLapsSpeedFactor
                * info.RecordedLapDetailInfo[1].LapDistanceMeters / activity.Laps[1].TotalTime.TotalSeconds
                  < activity.TotalDistanceMetersEntered / activity.TotalTimeEntered.TotalSeconds)
            {
                activity.Laps[0].Rest = true;
                activity.Laps[1].Rest = true;
                update = true;
            }
            //One warmup lap
            else if (info.RecordedLapDetailInfo[0].LapDistanceMeters < MiscPlugin.Plugin.DetectRestLapsLapDistance
                && activity.Laps[0].TotalTime.TotalSeconds > 0
                && activity.TotalTimeEntered.TotalSeconds > 0
                && MiscPlugin.Plugin.DetectRestLapsSpeedFactor
                * info.RecordedLapDetailInfo[0].LapDistanceMeters / activity.Laps[0].TotalTime.TotalSeconds
                  < activity.TotalDistanceMetersEntered / activity.TotalTimeEntered.TotalSeconds)
            {
                activity.Laps[0].Rest = true;
                update = true;
            }
            //One cooldown lap
            if (info.RecordedLapDetailInfo[activity.Laps.Count - 1].LapDistanceMeters < MiscPlugin.Plugin.DetectRestLapsLapDistance
                && activity.Laps[activity.Laps.Count - 1].TotalTime.TotalSeconds > 0
                && activity.TotalTimeEntered.TotalSeconds > 0
                && MiscPlugin.Plugin.DetectRestLapsSpeedFactor
                * info.RecordedLapDetailInfo[activity.Laps.Count - 1].LapDistanceMeters / activity.Laps[activity.Laps.Count - 1].TotalTime.TotalSeconds
                  < activity.TotalDistanceMetersEntered / activity.TotalTimeEntered.TotalSeconds)
            {
                activity.Laps[activity.Laps.Count - 1].Rest = true;
                update = true;
            }
            //Slooow laps
            for (int i = 0; i < activity.Laps.Count; i++)
            {
                if (MiscPlugin.Plugin.Verbose > 999)
                {
                    activity.Notes += i + ": " + MiscPlugin.Plugin.DetectRestLapsSlowSpeedFactor
                  * info.RecordedLapDetailInfo[i].LapDistanceMeters / activity.Laps[i].TotalTime.TotalSeconds + " "
                  + activity.TotalDistanceMetersEntered / activity.TotalTimeEntered.TotalSeconds + Environment.NewLine;
                }

                if (MiscPlugin.Plugin.DetectRestLapsSlowSpeedFactor
                * info.RecordedLapDetailInfo[i].LapDistanceMeters / activity.Laps[i].TotalTime.TotalSeconds
                  < activity.TotalDistanceMetersEntered / activity.TotalTimeEntered.TotalSeconds)
                {
                    activity.Laps[i].Rest = true;
                    tmpNotes += " Slow:" + i;
                    update = true;
                }
            }
            if (update)
            {
                //Need to manually set activity as updated to get ST noticing it
                ActivityInfoCache.Instance.ClearInfo(activity);
                if (MiscPlugin.Plugin.Verbose > 0)
                {
                    activity.Notes += "DetectRestLaps set lap 0/1/last rest to " + activity.Laps[0].Rest + "  " + 
                        activity.Laps[1].Rest + " " + activity.Laps[activity.Laps.Count - 1].Rest
                        + tmpNotes + Environment.NewLine;
                }
            }
            return 0;
        }

        private IActivity activity = null;
        private int checkType = 0;
    }
}
