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
            //Alternatve versions: Use ActualTrackStart etc - a little slower
            // or use HRM track start/end
            //ActivityInfo info = ActivityInfoCache.Instance.GetInfo(activity);

            //Need at least 2 points to extend route
            if (activity != null
                && activity.GPSRoute != null && activity.GPSRoute.Count > 1)
            {
                DateTime gpsStart = activity.GPSRoute.StartTime;
                DateTime gpsEnd = activity.GPSRoute.EntryDateTime(activity.GPSRoute[activity.GPSRoute.Count - 1]);

                if (activity.UseEnteredData &&
                    (activity.StartTime < gpsStart || activity.StartTime.Add(activity.TotalTimeEntered) > gpsEnd))
                {
                    return true;
                }
                //No check for UseEnteredData here
                if (activity.HeartRatePerMinuteTrack != null && activity.HeartRatePerMinuteTrack.Count > 1 &&
                    (gpsStart > activity.HeartRatePerMinuteTrack.EntryDateTime(activity.HeartRatePerMinuteTrack[0])
                   || gpsEnd < activity.HeartRatePerMinuteTrack.EntryDateTime(activity.HeartRatePerMinuteTrack[activity.HeartRatePerMinuteTrack.Count - 1])))
                {
                    return true;
                }
                if (activity.Laps != null && activity.Laps.Count > 0 &&
                    (activity.Laps[0].StartTime < gpsStart
                    || gpsEnd < activity.Laps[activity.Laps.Count - 1].StartTime.Add(new TimeSpan(activity.Laps[activity.Laps.Count - 1].TotalTime.Seconds))))
                {
                    return true;
                }
                // Extend end is for some reason not working with compareTo
                //                   || false && (0>activity.GPSRoute.EntryDateTime(activity.GPSRoute[activity.GPSRoute.Count - 1]).CompareTo
                //                 (activity.Laps[activity.Laps.Count-1].StartTime.Add(new TimeSpan(activity.Laps[activity.Laps.Count-1].TotalTime.Seconds))))))

                //                && (activity.Laps[0].StartTime < activity.GPSRoute.EntryDateTime(activity.GPSRoute[0])
                //                 || activity.Laps[activity.Laps.Count-1].StartTime+ activity.Laps[activity.Laps.Count-1].TotalTime > activity.GPSRoute.EntryDateTime(activity.GPSRoute[activity.GPSRoute.Count - 1])))
                //                            && (info.ActualTrackStart < activity.GPSRoute.EntryDateTime(activity.GPSRoute[0])
                //                 || info.ActualTrackEnd > activity.GPSRoute.EntryDateTime(activity.GPSRoute[activity.GPSRoute.Count - 1])))

                //                && activity.HeartRatePerMinuteTrack != null && activity.HeartRatePerMinuteTrack.Count > 0
                //                && (activity.HeartRatePerMinuteTrack.EntryDateTime(activity.HeartRatePerMinuteTrack[0]) 
                //                  < activity.GPSRoute.               EntryDateTime(activity.GPSRoute[0])
                //                 || activity.HeartRatePerMinuteTrack.EntryDateTime(activity.HeartRatePerMinuteTrack[activity.HeartRatePerMinuteTrack.Count - 1])
                //                  > activity.GPSRoute.               EntryDateTime(activity.GPSRoute[activity.GPSRoute.Count - 1])))
            }
            return false;
        }
        public int Run() 
        {
            ActivityInfo info = ActivityInfoCache.Instance.GetInfo(activity);
            DateTime currTime = info.ActualTrackStart;
            DateTime lapTime = activity.Laps[0].StartTime;
            if (0 < DateTime.Compare(currTime, lapTime))
            {
                currTime = lapTime;
            }
            lapTime = activity.StartTime;
            if (activity.UseEnteredData && 0 < DateTime.Compare(currTime, lapTime))
            {
                currTime = lapTime;
            }
            
            int ExtPoints = 3;
            if (ExtPoints > activity.GPSRoute.Count-1)
            {
                ExtPoints = activity.GPSRoute.Count-1;
            }
            int i0 = 0;
            int i1 = i0 + ExtPoints;
            DateTime endTime = activity.GPSRoute.EntryDateTime(activity.GPSRoute[i0]);

            IGPSRoute newRoute = new GPSRoute();
            //Could add more points, but that will only make it difficult to edit
            TimeSpan gpsTspan = activity.GPSRoute.EntryDateTime(activity.GPSRoute[i1]).Subtract(endTime);

            if (currTime  < endTime) {
               IGPSPoint gpsPt = new GPSPoint(
                   extrapollate(endTime.Subtract(currTime), gpsTspan, activity.GPSRoute[i0].Value.LatitudeDegrees, activity.GPSRoute[i1].Value.LatitudeDegrees),
                   extrapollate(endTime.Subtract(currTime), gpsTspan, activity.GPSRoute[i0].Value.LongitudeDegrees, activity.GPSRoute[i1].Value.LongitudeDegrees),
                   activity.GPSRoute[i0].Value.ElevationMeters);
               newRoute.Add(currTime, gpsPt);
            }

            for (; i0 < activity.GPSRoute.Count; i0++)
            {
                newRoute.Add(activity.GPSRoute.EntryDateTime(activity.GPSRoute[i0]), activity.GPSRoute[i0].Value);
            }

            endTime = info.ActualTrackEnd;
            TimeSpan ltspan = new TimeSpan(activity.Laps[activity.Laps.Count - 1].TotalTime.Seconds);
            lapTime = activity.Laps[activity.Laps.Count - 1].StartTime.Add(ltspan);
            if (0 > DateTime.Compare(endTime, lapTime))
            {
                endTime = lapTime;
            }
            lapTime = activity.StartTime.Add(activity.TotalTimeEntered);
            if (0 > DateTime.Compare(endTime, lapTime) && activity.UseEnteredData)
            {
                endTime = lapTime;
            }

            currTime = activity.GPSRoute.EntryDateTime(activity.GPSRoute[activity.GPSRoute.Count - 1]);
            i1 = activity.GPSRoute.Count - 1;
            i0 = i1 - ExtPoints;
            gpsTspan = currTime.Subtract(activity.GPSRoute.EntryDateTime(activity.GPSRoute[i0]));
            
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
