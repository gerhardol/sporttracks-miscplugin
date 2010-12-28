/*
Copyright (C) 2008, 2009, 2010 Gerhard Olsson 

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
class SetTimeGPS
{
    public int GpsBabel(String common, String filter, String input, String output, IGPSRoute ing, IGPSRoute outg)
    {
        return 1;
    }
    public static bool isEnabled(IGPSRoute gpsRoute)
    {
        if (gpsRoute != null && gpsRoute.Count > 0)
        {
            return true;
        }
        return false;
    }
    public static bool isEnabled(IActivity activity)
    {
        if (activity != null
            && isEnabled(activity.GPSRoute)
            && activity.TotalTimeEntered != null)
        {
            return true;
        }
        return false;
    }
    public static bool isEnabled(IRoute route)
    {
        if (route != null
            && isEnabled(route.GPSRoute))
        //Note: not gui modifyable right now
        //&& route.TotalTime)
        {
            return true;
        }
        return false;
    }

    private IDistanceDataTrack getSimpleDistanceTrack(IGPSRoute gpsRoute, TimeSpan totalTime, DateTime startTime)
    {
        if (totalTime == null || totalTime.TotalSeconds < 1)
        {
            //TODO: Configurable? - Global pace or popup?
            //this.totalTime = new TimeSpan((long)(gpsRoute.TotalDistanceMeters * (5 * 60 / 1000 * 10000000)));
            totalTime = new TimeSpan(1, 0, 0);
        }
        if (startTime == null || startTime == DateTime.MinValue)
        {
            //TODO: Configurable? - Probably not
            startTime = new DateTime(2007, 09, 10, 12, 30, 0);
        }
        IDistanceDataTrack DistanceTrack = new DistanceDataTrack();
        DateTime endTime = startTime.Add(totalTime);
        DistanceTrack.Add(startTime, 0);
        DistanceTrack.Add(endTime, gpsRoute.TotalDistanceMeters);

        return DistanceTrack;
    }
    public SetTimeGPS(IRoute route)
        {
            this.gpsRoute = route.GPSRoute;
            IDistanceDataTrack DistanceTrack = getSimpleDistanceTrack(route.GPSRoute, route.TotalTime, new DateTime());
            this.SpeedDistTrack = this.continuousDistance(DistanceTrack, null);
    }
    public SetTimeGPS(IActivity activity)
    {
        IDistanceDataTrack DistanceTrack = activity.DistanceMetersTrack;
        if (DistanceTrack == null || DistanceTrack.Count < 2 || activity.UseEnteredData)
        {
            DistanceTrack = getSimpleDistanceTrack(activity.GPSRoute, activity.TotalTimeEntered, activity.StartTime);
            //activity.Notes += activity.StartTime.ToString()+DistanceTrack.EntryDateTime(DistanceTrack[0]).ToString() + DistanceTrack.EntryDateTime(DistanceTrack[1]).ToString();
        }

        this.gpsRoute = activity.GPSRoute;
        this.SpeedDistTrack = DistanceTrack;
        //            this.SpeedDistTrack = this.continuousDistance(DistanceTrack, activity);
        this.activity = activity;
    }

    private IDistanceDataTrack continuousDistance(IDistanceDataTrack inTrack, IActivity activity)
        {
            IDistanceDataTrack newTrack = new DistanceDataTrack();
            int i;
            if (activity != null)
            {
                IDistanceDataTrack DistanceTrack2 = new DistanceDataTrack();
                //Fix start time for track - may be for another activity
                i = 0;
                TimeSpan tDiff = inTrack.StartTime.Subtract(activity.StartTime);
                for (i = 0; i < inTrack.Count; i++)
                {
                    DistanceTrack2.Add(inTrack.EntryDateTime(inTrack[i]).Subtract(tDiff), inTrack[i].Value);
                }
                inTrack = DistanceTrack2;
            }

            //Is track starting from 0? Lineary extend otherwise instead of raising error
            if (inTrack[0].Value > 0)
            {
                TimeSpan duration = inTrack.EntryDateTime(inTrack[inTrack.Count - 1]).Subtract(
                    inTrack.EntryDateTime(inTrack[0]));
                TimeSpan diff = new TimeSpan(duration.Ticks * 
                    (long)(inTrack[0].Value / inTrack[inTrack.Count - 1].Value));
                DateTime time = inTrack.EntryDateTime(inTrack[0]).Subtract(diff);
                    
                 newTrack.Add(time, 0);
            }
            //Check continously increasing
            for (i = 0; i < inTrack.Count; i++)
            {
                //If distance decreasing, remove previous distance
                //Assume Garmin behaviour where this can occur
                while (newTrack.Count > 0 && inTrack[i].Value < newTrack[newTrack.Count - 1].Value)
                {
                    newTrack.RemoveAt(newTrack.Count - 1);
                }
                newTrack.Add(inTrack.EntryDateTime(inTrack[i]), inTrack[i].Value);
            }
            //Extend track if too short
            if (newTrack[newTrack.Count - 1].Value < 
                gpsRoute[gpsRoute.Count - 1].Value.DistanceMetersToPoint(gpsRoute[gpsRoute.Count - 1].Value))
            {
                TimeSpan duration = newTrack.EntryDateTime(newTrack[newTrack.Count - 1]).Subtract(
                    newTrack.EntryDateTime(newTrack[0]));
                TimeSpan diff = new TimeSpan(duration.Ticks * 
                    (long)(gpsRoute[gpsRoute.Count - 1].Value.DistanceMetersToPoint(gpsRoute[gpsRoute.Count - 1].Value)
                    / newTrack[newTrack.Count - 1].Value));
                DateTime time = inTrack.EntryDateTime(newTrack[newTrack.Count - 1]).Add(diff);

                newTrack.Add(time, gpsRoute[gpsRoute.Count - 1].Value.DistanceMetersToPoint(gpsRoute[gpsRoute.Count - 1].Value));
            }
            return newTrack;
        }

    public IGPSRoute getGPSRoute()
        {
            if (!isEnabled(gpsRoute))
            {
                return gpsRoute;
            }
            if (activity != null)
            {
                ActivityInfo info = ActivityInfoCache.Instance.GetInfo(activity);
                if (MiscPlugin.Plugin.Verbose > 9)
                {
                    activity.Notes += "Setting time on GPS points: ";

                    activity.Notes += info.ActualTrackStart.ToString() + " " + info.ActualTrackEnd.ToString() + Environment.NewLine;
                    //if (activity.DistanceMetersTrack != null && activity.DistanceMetersTrack.Count>0)
                }
            }

            IGPSRoute newRoute = new GPSRoute();
            int g;
            IDistanceDataTrack GpsDistanceTrack = gpsRoute.GetDistanceMetersTrack();
            double dist = 0;
            newRoute.Add(SpeedDistTrack.EntryDateTime(SpeedDistTrack[0]), gpsRoute[0].Value);
            for (g = 1; g < gpsRoute.Count; g++)
            {
                //dist += gpsRoute[g - 1].Value.DistanceMetersToPoint(gpsRoute[g].Value);
                dist = GpsDistanceTrack[g].Value;
                DateTime time = SpeedDistTrack.GetTimeAtDistanceMeters(dist);
                newRoute.Add(time,
                            gpsRoute[g].Value);
                if (MiscPlugin.Plugin.Verbose > 999 && activity != null)
                {
                    activity.Notes += time +
                        " " + gpsRoute[0].Value.DistanceMetersToPoint(gpsRoute[g].Value) + Environment.NewLine;
                }
            }

            return newRoute;
        }
    public IGPSRoute getGPSRouteOld()
        {
            if (MiscPlugin.Plugin.Verbose > 99 && activity != null)
            {
                ActivityInfo info = ActivityInfoCache.Instance.GetInfo(activity);
                activity.Notes += info.ActualTrackStart.ToString() + " " + info.ActualTrackEnd.ToString();
                //if (activity.DistanceMetersTrack != null && activity.DistanceMetersTrack.Count>0)
            }

            IGPSRoute newRoute = new GPSRoute();
            IDistanceDataTrack GpsDistanceTrack = gpsRoute.GetDistanceMetersTrack();
            DateTime startTime = SpeedDistTrack.EntryDateTime(SpeedDistTrack[0]);
            int g = 0;
            int s = 1;
            //The previous index for the NewRoute where Speed was changed
            //The time for GPS points are added from here, to minimize rounding errors
            int gLast = 0;
            int gpsPrev = 0;
            int newLast = 0;
            int newPrev = 0;
            //The previous index for the SpeedDistTrack where Speed was changed
            //the point from the speedtrack to use
            int sPrev = 0;
            int sLast = 0;
            newRoute.Add(SpeedDistTrack.EntryDateTime(SpeedDistTrack[0]), gpsRoute[0].Value);

            for (g = 1; g < gpsRoute.Count; g++)
            {
                bool isChange = false;
                //Update if point is next intervall (if track too short, use last speed)
                while ((GpsDistanceTrack[g].Value > SpeedDistTrack[s].Value && s < SpeedDistTrack.Count - 1)
                    || SpeedDistTrack.EntryDateTime(SpeedDistTrack[s]).Subtract(SpeedDistTrack.EntryDateTime(SpeedDistTrack[sPrev])).TotalSeconds < 1
                    || SpeedDistTrack[s].Value <= SpeedDistTrack[sPrev].Value)
                {
                    s++;
                    //First point or not moving
                    if (SpeedDistTrack[s].Value <= SpeedDistTrack[sPrev].Value)
                    {
                        newRoute.Add(SpeedDistTrack.EntryDateTime(SpeedDistTrack[s]), gpsRoute[g].Value);
                        sLast = s;
                        gLast = g;
                        newLast = newRoute.Count - 1;
                    }
                    isChange = true;
                }
                if (isChange)
                {
                    sPrev = sLast;
                    //Minimize rounding error by saving where the current "speed" starts from
                    gpsPrev = gLast;
                    newPrev = newLast;
                }
                //TODO: Adjust speed to elevation change
                if ((SpeedDistTrack[s].Value - SpeedDistTrack[sPrev].Value) > 0 &&
                    SpeedDistTrack.EntryDateTime(SpeedDistTrack[s]).Subtract(SpeedDistTrack.EntryDateTime(SpeedDistTrack[sPrev])).TotalSeconds >= 1)
                {
                    //Moving point
                    double speed = (SpeedDistTrack[s].Value - SpeedDistTrack[sPrev].Value) * 1000 /
                    (SpeedDistTrack.EntryDateTime(SpeedDistTrack[s]).Subtract(SpeedDistTrack.EntryDateTime(SpeedDistTrack[sPrev])).TotalMilliseconds);
                    DateTime gpsTime = newRoute.EntryDateTime(newRoute[newPrev]).Add(new TimeSpan(0, 0,
                        (int)((GpsDistanceTrack[g].Value - GpsDistanceTrack[gpsPrev].Value)
                          / speed)));
                    if (gpsTime.Subtract(newRoute.EntryDateTime(newRoute[newRoute.Count - 1])).TotalSeconds >= 1)
                    {
                        newRoute.Add(gpsTime, gpsRoute[g].Value);

#if false
		                        if (activity != null && false)
                        {
                            activity.Notes += sPrev + " " + s + " " + g + " " + gpsPrev + " " + gLast + " " + SpeedDistTrack.EntryDateTime(SpeedDistTrack[s]).ToString() + "  " + SpeedDistTrack[s].Value + "  " +
                                GpsDistanceTrack[g].Value + "  " + GpsDistanceTrack[gpsPrev].Value + " " + speed +
                                " " + ((GpsDistanceTrack[g].Value - GpsDistanceTrack[gpsPrev].Value)
                                  / speed) + " " + " yyy; ";
                        }
  
#endif
                        sLast = s;
                        gLast = g;
                        newLast = newRoute.Count - 1;
                    }
                }
                else if (g == GpsDistanceTrack.Count - 1)
                {
                    //Take care to add endpoint, even if time not updated
                    //newRoute.RemoveAt[newRoute.Count - 1];
                    newRoute.Add(newRoute.EntryDateTime(newRoute[newRoute.Count - 1]), gpsRoute[g].Value);
                }
                //Note: This may add several points in the same second - let the exporter handle this
            }

            return newRoute;
        }

        private IGPSRoute gpsRoute = null;
        private IDistanceDataTrack SpeedDistTrack = null;
        private IActivity activity = null; //used for debug
    }
}
