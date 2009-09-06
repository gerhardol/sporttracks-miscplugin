/*
Copyright (C) 2007 Gerhard Olsson

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Lesser General Public
License as published by the Free Software Foundation; either
version 2.1 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public
License along with this library; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
 */

using System;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Collections;

//using ICSharpCode.SharpZipLib.GZip;

using ZoneFiveSoftware.Common.Data;
using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Data.GPS;
using ZoneFiveSoftware.Common.Visuals;
using ZoneFiveSoftware.Common.Visuals.Fitness;

using IBikeFixerPlugin.Resources;

namespace IBikeFixerPlugin.Edit
{
    class IBikeFixer
    {
        public IBikeFixer(IActivity activity)
        {
            this.activity = activity;
        }

 //       private float 
   //     activity.Category.StoppedMetersPerSecond
     //       if (!activity.Category.UseParentSettings){
       //         activity.Category.StoppedMetersPerSecond = OriginalStopped;
         //   }

        public INumericTimeDataSeries GetPower()
        {
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
        }



        public INumericTimeDataSeries GetPowerOld() 
        {
            INumericTimeDataSeries ntrack = activity.PowerWattsTrack;
            TimeSpan diff = new TimeSpan(0, 0, 0);
            IValueRangeSeries<DateTime> pauses = activity.TimerPauses;

            if (pauses.Count>0)
            {
                INumericTimeDataSeries PTrack = ntrack;
                ntrack = new NumericTimeDataSeries();
                int d = -1;
                int i = 0;
                while (++d < PTrack.Count)
                {
                    DateTime time = PTrack.EntryDateTime(PTrack[d]).Add(diff);
                    if (i < pauses.Count && time > pauses[i].Lower)
                    {
                        diff += pauses[i].Upper.Subtract(pauses[i].Lower);
                        time += diff;
                        i++;
                    }
                    ntrack.Add(time, PTrack[d].Value);
                }
                activity.Notes += "Inserted Garmin pauses to PowerTrack, total " + diff + System.Environment.NewLine;
            }
            //If End time differs "too much", then adjust points
            //Use ms precision to not loose too much rounding instead of ST direct function
            TimeSpan pTime = ntrack.EntryDateTime(ntrack[ntrack.Count - 1]).Subtract(ntrack.EntryDateTime(ntrack[0]));
            //TimeSpan hTime = activity.HeartRatePerMinuteTrack.EntryDateTime(activity.HeartRatePerMinuteTrack[activity.HeartRatePerMinuteTrack.Count - 1]).Subtract(activity.HeartRatePerMinuteTrack.EntryDateTime(activity.HeartRatePerMinuteTrack[0]));
            TimeSpan hTime = activity.GPSRoute.EntryDateTime(activity.GPSRoute[activity.GPSRoute.Count - 1]).Subtract(activity.GPSRoute.EntryDateTime(activity.GPSRoute[0]));
            double aDiff = hTime.TotalMilliseconds / pTime.TotalMilliseconds;
            double pDiff = (hTime.TotalMilliseconds - pTime.TotalMilliseconds) / 1000;
            //int pTime = ntrack.TotalElapsedSeconds;
            //int hTime = activity.HeartRatePerMinuteTrack.TotalElapsedSeconds;
            //double pDiff = hTime - pTime;
            //double aDiff = hTime / pTime;

            if (3 < Math.Abs(pDiff))
            {
                INumericTimeDataSeries PTrack = ntrack;
                ntrack = new NumericTimeDataSeries();
                double tmp2 = (aDiff - 1);
                activity.Notes += "Stretched the length of PowerTrack " + pDiff + " sec (" + tmp2.ToString("#0.####%") + ")" + System.Environment.NewLine;
                int d = -1;
                while (++d < PTrack.Count)
                {
                    TimeSpan tspan = new TimeSpan(0, 0, 0, 0, (int)(PTrack.EntryDateTime(PTrack[d]).Subtract(PTrack.EntryDateTime(PTrack[0])).TotalMilliseconds * aDiff));
                    DateTime time = PTrack.EntryDateTime(PTrack[0]).Add(tspan);
                    ntrack.Add(time, PTrack[d].Value);
                }
            }
           return ntrack;
        }

        private IActivity activity = null;
    }
}

