/*
Copyright (C) 2007, 2009 Gerhard Olsson 

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
    class ExtendGPS
    {
        public ExtendGPS(IActivity activity)
        {
            this.activity = activity;
        }
        public static bool isEnabled(IActivity activity)
        {
            //Alternatve version is to use ActualTrackStart etc - a little slower to open Edit, avoid!
            //ActivityInfo info = ActivityInfoCache.Instance.GetInfo(activity);

            //Need at least 2 points to extend route
            if (activity != null
                && activity.GPSRoute != null && activity.GPSRoute.Count > 1)
            {
                DateTime gpsStart = activity.GPSRoute.StartTime;
                DateTime gpsEnd = activity.GPSRoute.EntryDateTime(activity.GPSRoute[activity.GPSRoute.Count - 1]);

                if (MiscPlugin.Plugin.Verbose > 99)
                {
                    DateTime startTime = activity.StartTime;
                    DateTime endTime = activity.StartTime.Add(activity.TotalTimeEntered).AddMilliseconds(-activity.TotalTimeEntered.Milliseconds);
                    activity.Notes += "ExtendGPS Edit GPS: " + gpsStart + " " + gpsEnd
                         + " " + activity.UseEnteredData + " " + activity.HasStartTime + Environment.NewLine;
                    activity.Notes += "ExtendGPS Edit Manual: "
                        + " " + startTime + " " + DateTime.Compare(startTime, gpsStart)
                        + " " + endTime + " " + DateTime.Compare(endTime, gpsEnd)
                        + " " + activity.StartTime.Add(activity.TotalTimeEntered) + " " + DateTime.Compare(activity.StartTime.Add(activity.TotalTimeEntered), gpsEnd)
                        + Environment.NewLine;
                    if (activity.HeartRatePerMinuteTrack != null && activity.HeartRatePerMinuteTrack.Count > 1)
                    {
                        startTime = activity.HeartRatePerMinuteTrack.EntryDateTime(activity.HeartRatePerMinuteTrack[0]);
                        endTime = activity.HeartRatePerMinuteTrack.EntryDateTime(activity.HeartRatePerMinuteTrack[activity.HeartRatePerMinuteTrack.Count - 1]);
                        activity.Notes += "ExtendGPS Edit HR: "
                        + " " + startTime + " " + DateTime.Compare(startTime, gpsStart)
                        + " " + endTime + " " + DateTime.Compare(endTime, gpsEnd)
                        + Environment.NewLine;
                    }
                    if (activity.Laps != null && activity.Laps.Count > 1)
                    {
                        startTime = activity.Laps[0].StartTime;
                        endTime = activity.Laps[activity.Laps.Count - 1].StartTime.Add(new TimeSpan(activity.Laps[activity.Laps.Count - 1].TotalTime.Seconds));
                        activity.Notes += "ExtendGPS Edit Laps: "
                            + " " + startTime + " " + DateTime.Compare(startTime, gpsStart)
                            + " " + endTime + " " + DateTime.Compare(endTime, gpsEnd)
                            + Environment.NewLine;
                    }
                }

                if (activity.UseEnteredData && activity.HasStartTime &&
                    (0 > DateTime.Compare(activity.StartTime, gpsStart) ||
                    //TimerPauses not added here - must be calculated
                    //Must adjust activity.TotalTimeEntered to closest second
                     0 < DateTime.Compare(activity.StartTime.Add(activity.TotalTimeEntered).AddMilliseconds(-activity.TotalTimeEntered.Milliseconds), gpsEnd)))
                {
                    return true;
                }
                if (activity.HeartRatePerMinuteTrack != null && activity.HeartRatePerMinuteTrack.Count > 1 &&
                    (0 > DateTime.Compare(activity.HeartRatePerMinuteTrack.EntryDateTime(activity.HeartRatePerMinuteTrack[0]), gpsStart) || 
                     0 < DateTime.Compare(activity.HeartRatePerMinuteTrack.EntryDateTime(activity.HeartRatePerMinuteTrack[activity.HeartRatePerMinuteTrack.Count - 1]), gpsEnd)))
                {
                    return true;
                }
                if (activity.Laps != null && activity.Laps.Count > 0 &&
                   (0 > DateTime.Compare(activity.Laps[0].StartTime, gpsStart)
                   || 0 < DateTime.Compare(activity.Laps[activity.Laps.Count - 1].StartTime.Add(new TimeSpan(activity.Laps[activity.Laps.Count - 1].TotalTime.Seconds)), gpsEnd)))
                {
                    return true;
                }
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
            DateTime currTime = info.ActualTrackStart;
            DateTime manualTime = activity.StartTime;
            if (activity.UseEnteredData && 0 < DateTime.Compare(currTime, manualTime))
            {
                currTime = manualTime;
            }
            if (activity.Laps != null && activity.Laps.Count > 0)
            {
                //Laps are not part of the "track" information, must be checked separately
                DateTime lapTime = activity.Laps[0].StartTime;
                if (0 < DateTime.Compare(currTime, lapTime))
                {
                    currTime = lapTime;
                }
            }
            
            //When extending, use (0,ExtPoints) to set direction
            int ExtPoints = 3;
            if (ExtPoints > activity.GPSRoute.Count-1)
            {
                ExtPoints = activity.GPSRoute.Count-1;
            }
            int i0 = 0;
            int i1 = i0 + ExtPoints;
            DateTime endTime = activity.GPSRoute.EntryDateTime(activity.GPSRoute[i0]);

            IGPSRoute newRoute = new GPSRoute();
            TimeSpan gpsTspan = activity.GPSRoute.EntryDateTime(activity.GPSRoute[i1]).Subtract(endTime);
            if (gpsTspan.TotalSeconds <= 0) {
                //No time set on GPS - use average speed
                gpsTspan = TimeSpan.FromSeconds(info.Time.TotalSeconds / info.DistanceMeters
                    * activity.GPSRoute[i0].Value.DistanceMetersToPoint(activity.GPSRoute[i1].Value));
            }
            if (MiscPlugin.Plugin.Verbose > 0)
            {
                activity.Notes += "ExtendGPS Start: " + currTime + " " + endTime + " " + gpsTspan + Environment.NewLine;
            }
            if (currTime < endTime)
            {
               IGPSPoint gpsPt = new GPSPoint(
                   extrapollate(endTime.Subtract(currTime), gpsTspan, activity.GPSRoute[i0].Value.LatitudeDegrees, activity.GPSRoute[i1].Value.LatitudeDegrees),
                   extrapollate(endTime.Subtract(currTime), gpsTspan, activity.GPSRoute[i0].Value.LongitudeDegrees, activity.GPSRoute[i1].Value.LongitudeDegrees),
                   activity.GPSRoute[i0].Value.ElevationMeters);
               newRoute.Add(currTime, gpsPt);
               if (activity.UseEnteredData)
               {
                   activity.StartTime = currTime;
               }
 
            }

            for (; i0 < activity.GPSRoute.Count; i0++)
            {
                newRoute.Add(activity.GPSRoute.EntryDateTime(activity.GPSRoute[i0]), activity.GPSRoute[i0].Value);
            }

            endTime = info.ActualTrackEnd;
            manualTime = activity.StartTime.Add(activity.TotalTimeEntered);
            if (0 > DateTime.Compare(endTime, manualTime) && activity.UseEnteredData)
            {
                endTime = manualTime;
            }
            if (activity.Laps != null && activity.Laps.Count > 0)
            {
                if (activity.Laps != null && activity.Laps.Count > 0)
                {
                    TimeSpan ltspan = new TimeSpan(activity.Laps[activity.Laps.Count - 1].TotalTime.Seconds);
                    DateTime lapTime = activity.Laps[activity.Laps.Count - 1].StartTime.Add(ltspan);
                    if (0 > DateTime.Compare(endTime, lapTime))
                    {
                        endTime = lapTime;
                    }
                }
            }

            currTime = activity.GPSRoute.EntryDateTime(activity.GPSRoute[activity.GPSRoute.Count - 1]);
            i1 = activity.GPSRoute.Count - 1;
            i0 = i1 - ExtPoints;
            gpsTspan = currTime.Subtract(activity.GPSRoute.EntryDateTime(activity.GPSRoute[i0]));
            if (gpsTspan.TotalSeconds <= 0)
            {
                //No time set on GPS - use average speed
                gpsTspan = TimeSpan.FromSeconds(info.Time.TotalSeconds / info.DistanceMeters 
                    * activity.GPSRoute[i0].Value.DistanceMetersToPoint(activity.GPSRoute[i1].Value));
            }

            if (MiscPlugin.Plugin.Verbose > 0)
            {
                activity.Notes += "ExtendGPS End: " + currTime + " " + endTime + " " + gpsTspan + Environment.NewLine;
            }
            if (currTime < endTime)
            {
               IGPSPoint gpsPt = new GPSPoint(
                        extrapollate(endTime.Subtract(currTime), gpsTspan, activity.GPSRoute[i1].Value.LatitudeDegrees, activity.GPSRoute[i0].Value.LatitudeDegrees),
                        extrapollate(endTime.Subtract(currTime), gpsTspan, activity.GPSRoute[i1].Value.LongitudeDegrees, activity.GPSRoute[i0].Value.LongitudeDegrees),
                        activity.GPSRoute[i1].Value.ElevationMeters);
               newRoute.Add(endTime, gpsPt);
            }
                
            // Copy it to the selected route
            activity.GPSRoute = newRoute;
            return 0;
        }

        //Extend lineary - not OK for long distance, but unlikely the assumption works there anyway
        //A better solution is to use the distance/time for maybe 1km and use that to get a distance
        //and the position from there
        private float extrapollate(TimeSpan hrmTime, TimeSpan gpxTime, float pt1, float pt2)
        {
            return pt1 + (float)((pt1 - pt2) * hrmTime.TotalMilliseconds / gpxTime.TotalMilliseconds);
        }

        private IActivity activity = null;
    }
}
