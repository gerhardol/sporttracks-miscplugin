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
    class PrepareForActivitiesViewer
    {
        private IActivity activity = null;
        public PrepareForActivitiesViewer(IActivity activity)
        {
            this.activity = activity;
        }
        public static bool isEnabled(IActivity activity)
        {
            //Need at least 2 points in GPS route and a pause
            if (activity != null)
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
            try
            {
                foreach (ILapInfo l in activity.Laps)
                {
                    DateTime EndTime = ZoneFiveSoftware.Common.Data.Algorithm.DateTimeRangeSeries.AddTimeAndPauses(l.StartTime, l.TotalTime, activity.TimerPauses);
                    l.TotalDistanceMeters = info.MovingDistanceMetersTrack.GetInterpolatedValue(EndTime).Value -
                        info.MovingDistanceMetersTrack.GetInterpolatedValue(l.StartTime).Value;
                }
            }
            catch
            {
                //More checks should be added. Just ignore for now
            }
            ActivityInfoCache.Instance.ClearInfo(activity);
            return 0;
        }
    }
}
#if false
//TimeNotMovingNonPaused StoppedSpeed 
            INumericTimeDataSeries ntrack = activity.PowerWattsTrack;
            float OriginalStopped = activity.Category.StoppedMetersPerSecond;
            //bool OriginalIncludePause = Plugin.GetApplication().SystemPreferences.
            bool OriginalUseParent = activity.Category.UseParentSettings;
            float MaxStopped = 4.0F;
            float MinStopped = 0.0F;
            float currentStopped = OriginalStopped;
            ActivityInfo info = ActivityInfoCache.Instance.GetInfo(activity);
            //bool OriginalIncludePause = IActivityInfoOptions.

            activity.Category.UseParentSettings = false;
            //Binary search to set better stopped speed
            while (Math.Abs(info.TimeMoving.TotalSeconds-ntrack.TotalElapsedSeconds)> 1 &&
                MaxStopped - MinStopped > 0.001F)
            {
                if (info.TimeMoving.TotalSeconds
                              > ntrack.TotalElapsedSeconds)
                {
                    MinStopped = currentStopped;
                    currentStopped = currentStopped + (MaxStopped - currentStopped) / 2;
                }
                else
                {
                    MaxStopped = currentStopped;
                    currentStopped = currentStopped - (-MinStopped + currentStopped) / 2;
                }
                activity.Category.StoppedMetersPerSecond = currentStopped;
                ActivityInfoCache.Instance.ClearInfo(activity);
                info = ActivityInfoCache.Instance.GetInfo(activity);
            }
            TimeSpan diff = new TimeSpan(0, 0, 0);
            IValueRangeSeries<DateTime> pauses = info.NonMovingTimes;
            activity.Notes += "debug "+OriginalStopped+" " + info.TimeNotMovingNonPaused + " " +
                info.ActualTrackTime.Subtract(info.TimeNotMovingNonPaused).TotalSeconds + " " +
                (info.TimeMoving.TotalSeconds) + " " +
                ntrack.TotalElapsedSeconds + " " +
                System.Environment.NewLine +pauses.Count + " " + currentStopped + " " + MinStopped + " " + MaxStopped + " " + OriginalStopped 
                + System.Environment.NewLine;

            if (pauses.Count > 0)
            {
                INumericTimeDataSeries ntrack2 = new NumericTimeDataSeries();
                activity.Notes += " " + ntrack.Count + " " + pauses.Count;

                int d = 0;
                int i = 0;
                while (d < ntrack.Count)
                {
                    DateTime time = ntrack.EntryDateTime(ntrack[d]).Add(diff);
                    if (i < pauses.Count && time > pauses[i].Lower)
                    {
                        diff += pauses[i].Upper.Subtract(pauses[i].Lower);
                        time += diff;
                        i++;
                    }
                    ntrack2.Add(time, ntrack[d].Value);
                    d++;
                }
                activity.Notes += "Inserted Garmin pauses and Stopped @" + currentStopped +
                   "m/s to PowerTrack, total " + diff + System.Environment.NewLine;
                 ntrack= ntrack2; 
            }
            activity.Category.UseParentSettings = OriginalUseParent;
            if (!activity.Category.UseParentSettings){
                activity.Category.StoppedMetersPerSecond = OriginalStopped;
            }
            return ntrack;
#endif