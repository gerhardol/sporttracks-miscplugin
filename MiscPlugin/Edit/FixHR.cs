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
            ActivityInfo info = ActivityInfoCache.Instance.GetInfo(activity);
            bool change = false;

            INumericTimeDataSeries ntrack = new NumericTimeDataSeries();;
            INumericTimeDataSeries otrack = activity.HeartRatePerMinuteTrack;
            if (DateTime.Compare(info.ActualTrackStart, DateTime.MinValue) > 0
                && DateTime.Compare(info.ActualTrackStart, otrack.StartTime) < 0)
            {
                if (MiscPlugin.Plugin.Verbose > 0)
                {
                    activity.Notes += "Inserting HR at start: " + info.ActualTrackStart + " " 
                        + otrack.StartTime + Environment.NewLine;
                }
                change = true;
                ntrack.Add(info.ActualTrackStart, MiscPlugin.Plugin.FixHRStartHR);
            }
            int i;
            int n = 0;
            for (i = 0; i < otrack.Count; i++){
                if (otrack[i].ElapsedSeconds > MiscPlugin.Plugin.FixHRCheckSeconds 
                    || otrack[i].Value < MiscPlugin.Plugin.FixHRTruncateHR)
                {
                    ntrack.Add(otrack.EntryDateTime(otrack[i]),otrack[i].Value);
                } else {
                    n++;
                }
            }
            if (n > 0 && MiscPlugin.Plugin.Verbose > 0)
            {
                activity.Notes += "Removed HR: " + n + " over " + MiscPlugin.Plugin.FixHRTruncateHR + Environment.NewLine;
            }
            if (change || n > 0)
            {
                activity.HeartRatePerMinuteTrack = ntrack;
                ActivityInfoCache.Instance.ClearInfo(activity);
            }
            return 0;
        }
    }
}

