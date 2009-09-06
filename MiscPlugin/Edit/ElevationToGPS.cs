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
class ElevationToGPS
{
        private IActivity activity = null;
        public ElevationToGPS(IActivity activity)
        {
            this.activity = activity;
        }
        public static bool isEnabled(IActivity activity)
        {
            if (activity != null
                && activity.GPSRoute != null && activity.GPSRoute.Count > 1
                && activity.ElevationMetersTrack != null && activity.ElevationMetersTrack.Count > 1
                && 0 <= activity.GPSRoute.StartTime.CompareTo(activity.ElevationMetersTrack.StartTime)
                && 0 >= activity.GPSRoute.EntryDateTime(activity.GPSRoute[activity.GPSRoute.Count-1]).CompareTo(
                  activity.ElevationMetersTrack.EntryDateTime(activity.ElevationMetersTrack[activity.ElevationMetersTrack.Count - 1])))
            {
                return true;
            }
            return false;
        }

                
        public int Run()
        {
            if (MiscPlugin.Plugin.Verbose > 0)
            {
               activity.Notes += "Applying Elevation Track to GPS elevation"+Environment.NewLine;
            }

            IGPSRoute newRoute = new GPSRoute();
            int g;
            for (g = 0; g < activity.GPSRoute.Count; g++)
            {
               IGPSPoint gpsPt = new GPSPoint(
                        activity.GPSRoute[g].Value.LatitudeDegrees, 
                        activity.GPSRoute[g].Value.LongitudeDegrees,
                        activity.ElevationMetersTrack.GetInterpolatedValue(activity.GPSRoute.EntryDateTime(activity.GPSRoute[g])).Value);
                newRoute.Add(activity.GPSRoute.EntryDateTime(activity.GPSRoute[g]), gpsPt);
                if (MiscPlugin.Plugin.Verbose > 99)
                {
                    activity.Notes += "Adding GPS point: [" + g + "]" +
                        activity.GPSRoute.EntryDateTime(activity.GPSRoute[g]) + Environment.NewLine;
                }

            }
            activity.GPSRoute = newRoute;
            return 0;
        }
    }
}
