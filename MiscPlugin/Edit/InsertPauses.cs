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
    class InsertPauses
    {
        private IActivity activity = null;
        public InsertPauses(IActivity activity)
        {
            this.activity = activity;
        }
        public static bool isEnabled(IActivity activity)
        {
            //Need at least 2 points in GPS route to extend route
            if (activity != null
                && MiscPlugin.Plugin.InsertPausesWhenGPSdifferMinSeconds > 0
                && activity.GPSRoute != null && activity.GPSRoute.Count > 1)
            {
                //overkill to check here
#if false
		        int minTime = MiscPlugin.Plugin.InsertPauseWhenGPSdifferMinSeconds;
                for (int nEntry = 1; nEntry < activity.GPSRoute.Count; nEntry++)
                {
                    if (minTime < (activity.GPSRoute.EntryDateTime(activity.GPSRoute[nEntry]) -
                                  activity.GPSRoute.EntryDateTime(activity.GPSRoute[nEntry - 1])).Seconds
                    ) { return true; }
                }
            
#endif
                return true;
            }
            return false;
        }

                
        public int Run()
        {
            if (!isEnabled(activity))
            {
                return 1;
            }
            //Do not use stopped time while adjusting
            bool OriginalStoppedUse = activity.Category.UseParentSettings;
            float OriginalStoppedSpeed = activity.Category.StoppedMetersPerSecond;
            activity.Category.UseParentSettings = false;
            activity.Category.StoppedMetersPerSecond = 0;

            if (MiscPlugin.Plugin.Verbose > 0)
            {
                if (activity.TimerPauses == null || activity.TimerPauses.Count == 0)
                {
                    activity.Notes += "No existing pauses" + Environment.NewLine;
                }
                else
                {
                for (int i = 0; i< activity.TimerPauses.Count; i++)
                {
                        activity.Notes += "Existing pause: " + activity.TimerPauses[i].Lower + 
                            " - " + activity.TimerPauses[i].Upper + Environment.NewLine;
                }
                activity.Notes += Environment.NewLine;
                }
            }
            int minTime = MiscPlugin.Plugin.InsertPausesWhenGPSdifferMinSeconds;
            for (int nEntry = 1; nEntry < activity.GPSRoute.Count; nEntry++)
            {
                if (minTime + 2 * MiscPlugin.Plugin.InsertPausesGPSOffsetSeconds
                    < (activity.GPSRoute.EntryDateTime(activity.GPSRoute[nEntry]).Subtract(
                       activity.GPSRoute.EntryDateTime(activity.GPSRoute[nEntry - 1]))).TotalSeconds
                )
                {
                    //Here there should potentially be a check if the new pause is slightly
                    //longer than a existing pause (for other users than Edge 705)
                    //or maybe even align to lap time?
                    DateTime lower = activity.GPSRoute.EntryDateTime(activity.GPSRoute[nEntry - 1]).AddSeconds(MiscPlugin.Plugin.InsertPausesGPSOffsetSeconds);
                    DateTime upper = activity.GPSRoute.EntryDateTime(activity.GPSRoute[nEntry]).AddSeconds(-MiscPlugin.Plugin.InsertPausesGPSOffsetSeconds);
                    if (MiscPlugin.Plugin.Verbose > 0) {
                        activity.Notes += "New potential pause: " + lower + " - " + upper + Environment.NewLine;
                    }
                    if (activity.TimerPauses != null 
                        && MiscPlugin.Plugin.InsertPausesAdjacentCheckSeconds > 0)
                    {
                        int n = 0;
                        DateTime lower2 = lower.AddSeconds(MiscPlugin.Plugin.InsertPausesAdjacentCheckSeconds);

                        while (n < activity.TimerPauses.Count
                            && activity.TimerPauses[n].Lower.CompareTo(lower2) < 0)
                        {
                            n++;
                        }
                        if (n < activity.TimerPauses.Count
                            && activity.TimerPauses[n].Lower.CompareTo(upper) < 0
                            && activity.TimerPauses[n].Lower.CompareTo(lower2) < 0)
                        {
                            if (MiscPlugin.Plugin.Verbose > 0)
                            {
                                activity.Notes += "Adjusting start of pause from " + lower + " to " + activity.TimerPauses[n].Lower + Environment.NewLine;
                            }
                            lower = activity.TimerPauses[n].Lower;
                        }
                        DateTime upper2 = upper.AddSeconds(-MiscPlugin.Plugin.InsertPausesAdjacentCheckSeconds);

                        n = activity.TimerPauses.Count - 1;
                        while (n >= 0
                            && activity.TimerPauses[n].Upper.CompareTo(upper2) > 0)
                        {
                            n--;
                        }
                        if (n >= 0
                            && activity.TimerPauses[n].Upper.CompareTo(lower) > 0
                            && activity.TimerPauses[n].Upper.CompareTo(upper2) > 0)
                        {
                            if (MiscPlugin.Plugin.Verbose > 0)
                            {
                                activity.Notes += "Adjusting end of pause from " + upper + " to " + activity.TimerPauses[n].Upper + Environment.NewLine;
                            }
                            upper = activity.TimerPauses[n].Upper;
                        }
                        
                    }
                    activity.TimerPauses.Add(new ValueRange<DateTime>(lower,upper));

                }
            }
            activity.Category.StoppedMetersPerSecond = OriginalStoppedSpeed;
            activity.Category.UseParentSettings = OriginalStoppedUse;

            ActivityInfoCache.Instance.ClearInfo(activity);
            return 0;
        }
    }
}
