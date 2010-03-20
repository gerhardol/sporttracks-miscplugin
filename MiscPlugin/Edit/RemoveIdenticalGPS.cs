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

You should have received a copy of the GNU Lesser General Public License
along with this library.  If not, see <http://www.gnu.org/licenses/>.

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
    class RemoveIdenticalGPS
    {
        private IActivity activity = null;
        public RemoveIdenticalGPS(IActivity activity)
        {
            this.activity = activity;
        }

        public static bool isEnabled(IActivity activity)
        {
            //Need at least 2 points in GPS route to extend route
            if (activity != null
                && activity.GPSRoute != null && activity.GPSRoute.Count > 1
                && activity.DistanceMetersTrack != null && activity.DistanceMetersTrack.Count > 1)
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
            IGPSRoute newRoute = new GPSRoute();
            int g;
            if (MiscPlugin.Plugin.Verbose > 0)
            {
                activity.Notes += "Removing duplicate GPS points" + Environment.NewLine;
            }
            newRoute.Add(activity.GPSRoute.StartTime, activity.GPSRoute[0].Value);
            for (g = 1; g < activity.GPSRoute.Count; g++)
            {
                if (!(activity.GPSRoute[g].Value.Equals(activity.GPSRoute[g - 1].Value)
                    && 1 == (activity.GPSRoute[g].ElapsedSeconds - activity.GPSRoute[g - 1].ElapsedSeconds)
                    && (activity.DistanceMetersTrack.GetInterpolatedValue(activity.GPSRoute.EntryDateTime(activity.GPSRoute[g])).Value
                    > activity.DistanceMetersTrack.GetInterpolatedValue(activity.GPSRoute.EntryDateTime(activity.GPSRoute[g - 1])).Value)))
                {
                    newRoute.Add(activity.GPSRoute.EntryDateTime(activity.GPSRoute[g]), activity.GPSRoute[g].Value);
                }
                else if (MiscPlugin.Plugin.Verbose > 0)
                {
                    activity.Notes += "Removing GPS point: [" + g +"]" +
                        activity.GPSRoute.EntryDateTime(activity.GPSRoute[g]) + Environment.NewLine;
                }

            }
            activity.GPSRoute = newRoute;

            return 0;
        }
    }
}
