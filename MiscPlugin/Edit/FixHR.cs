/*
Copyright (C) 2009, 2010 Gerhard Olsson 

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
    class FixHR
    {
        private IActivity activity = null;
        public FixHR(IActivity activity)
        {
            this.activity = activity;
        }

        public static bool isEnabled(IActivity activity)
        {
            if (activity != null
                && activity.HeartRatePerMinuteTrack != null && activity.HeartRatePerMinuteTrack.Count > 1)
            {
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
            ActivityInfo info = ActivityInfoCache.Instance.GetInfo(activity);
            bool changeStart = false;
            bool changeEnd = false;

            INumericTimeDataSeries ntrack = new NumericTimeDataSeries();
            INumericTimeDataSeries otrack = activity.HeartRatePerMinuteTrack;
            int FixHRCheckSeconds = MiscPlugin.Plugin.FixHRCheckSeconds;
            if (DateTime.Compare(info.ActualTrackStart, DateTime.MinValue) > 0
                && DateTime.Compare(info.ActualTrackStart, otrack.StartTime) < 0)
            {
                if (MiscPlugin.Plugin.Verbose > 0)
                {
                    activity.Notes += "Inserting HR at start: " + info.ActualTrackStart + " "
                        + otrack.StartTime + Environment.NewLine;
                }
                changeStart = true;
                ntrack.Add(info.ActualTrackStart, MiscPlugin.Plugin.FixHRStartHR);
                FixHRCheckSeconds -= (int)otrack.StartTime.Subtract(info.ActualTrackStart).TotalSeconds;
            }
            if (DateTime.Compare(info.ActualTrackStart, DateTime.MinValue) > 0
                && DateTime.Compare(info.ActualTrackStart, otrack.StartTime) < 0)
            {
                if (MiscPlugin.Plugin.Verbose > 0)
                {
                    activity.Notes += "Inserting HR at end: " + info.ActualTrackStart + " "
                        + otrack.StartTime + Environment.NewLine;
                }
                changeEnd = true;
                ntrack.Add(info.ActualTrackStart, MiscPlugin.Plugin.FixHRStartHR);
                FixHRCheckSeconds -= (int)otrack.StartTime.Subtract(info.ActualTrackStart).TotalSeconds;
            }
            int i;
            int n = 0;
            int m = 0;
            for (i = 0; i < otrack.Count; i++)
            {
                if ((otrack[i].Value <= Plugin.GetApplication().Logbook.Athlete.InfoEntries.LastEntryAsOfDate(activity.StartTime).MaximumHeartRatePerMinute
                    && otrack[i].Value >= Plugin.GetApplication().Logbook.Athlete.InfoEntries.LastEntryAsOfDate(activity.StartTime).RestingHeartRatePerMinute)
                    &&
                    (otrack[i].ElapsedSeconds > FixHRCheckSeconds
                    || otrack[i].Value < MiscPlugin.Plugin.FixHRTruncateHR))
                {
                    ntrack.Add(otrack.EntryDateTime(otrack[i]), otrack[i].Value);
                }
                else
                {
                    //Special handling if dropping first/last point
                    if (!changeStart && i == 0 && otrack[i].ElapsedSeconds == 0)
                    {
                        ntrack.Add(info.ActualTrackStart, MiscPlugin.Plugin.FixHRStartHR);
                    }
                    else if (!changeEnd && i == otrack.Count - 1 /*&& otrack[i].ElapsedSeconds == info.Time.TotalSeconds*/)
                    {
                        ntrack.Add(info.ActualTrackEnd, info.AverageHeartRate);
                    }
                    
                 //For verbose, track which of the conditions occurred
                    if (otrack[i].ElapsedSeconds <= FixHRCheckSeconds
                      && otrack[i].Value >= MiscPlugin.Plugin.FixHRTruncateHR)
                    {
                        n++;
                    }else{
                        m++;
                    }
                }
                
           }
            if (n > 0 && MiscPlugin.Plugin.Verbose > 0)
            {
                activity.Notes += "Removed HR: " + n + " over " + MiscPlugin.Plugin.FixHRTruncateHR + Environment.NewLine;
            }
            if (m > 0 && MiscPlugin.Plugin.Verbose > 0)
            {
                activity.Notes += "Removed HR: " + m + " outside rest/max "
                    + Plugin.GetApplication().Logbook.Athlete.InfoEntries.LastEntryAsOfDate(activity.StartTime).RestingHeartRatePerMinute + "/"
                    + Plugin.GetApplication().Logbook.Athlete.InfoEntries.LastEntryAsOfDate(activity.StartTime).MaximumHeartRatePerMinute 
                    + Environment.NewLine;
            }
            if (changeStart || changeEnd || m > 0)
            {
                activity.HeartRatePerMinuteTrack = ntrack;
                ActivityInfoCache.Instance.ClearInfo(activity);
            }
            return 0;
        }
    }
}

