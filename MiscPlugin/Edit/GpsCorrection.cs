/*
Copyright (C) 2007, 2009, 2010 Gerhard Olsson 

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

//using ICSharpCode.SharpZipLib.GZip;

using ZoneFiveSoftware.Common.Data;
using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Data.GPS;
using ZoneFiveSoftware.Common.Visuals;
using ZoneFiveSoftware.Common.Visuals.Fitness;

using MiscPlugin;

namespace MiscPlugin.Edit
{
    class GpsCorrection
    {
        public GpsCorrection(IActivity activity)
        {
            this.activity = activity;
        }

        public static bool isEnabled(IActivity activity)
        {
            if (activity != null
                && activity.GPSRoute != null && activity.GPSRoute.Count > 0
                && activity.DistanceMetersTrack != null && activity.DistanceMetersTrack.Count > 0)
            {
                return true;
            }
            return false;
        }

        public IGPSRoute GetGpsRoute(IActivity activity) 
        {
            IDistanceDataTrack distTrack = activity.DistanceMetersTrack;
            IGPSRoute route = activity.GPSRoute;
            const int algorithm = 0; //More algorithms could be implemented...
            int d = 0;

            while (++d < distTrack.Count)
            {
                //If previous point has larger distance, then remove previous points until distance increases
                if (algorithm == 0)
                {
                    int p = d;
                    while (p > 0 && (distTrack[--p].Value > distTrack[d].Value))
                    {
                        DateTime time = distTrack.EntryDateTime(distTrack[p]);
                        if (time >= route.EntryDateTime(route[0]) && time <= route.EntryDateTime(route[route.Count - 1]))
                        {
                            int g = route.IndexOf(route.GetInterpolatedValue(time));
                            if (g > 0 && route.EntryDateTime(route[g]) == time)
                            {
                                route.RemoveAt(g);
                                if (Plugin.Verbose > 0)
                                {
                                    float tmp = distTrack[p].Value - distTrack[d].Value;
                                    activity.Notes += "Remove: " + g + " " + p + " " + d + " " + time + " " + tmp + System.Environment.NewLine;
                                }
                            }
                        }
                    }
                }
            }
            //Other algorithms(?): Remove GPS points where the distance differs too much between the
            //Distance and GPS-distance (Remove first or last?)
             return route;
        }
        public void Run()
        {
            if (isEnabled(this.activity))
            {
                activity.GPSRoute = GetGpsRoute(this.activity);
            }
        }
        private IActivity activity = null;
    }
}
