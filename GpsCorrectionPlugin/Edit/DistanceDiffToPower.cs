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

using ZoneFiveSoftware.Common.Data;
using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Data.GPS;
using ZoneFiveSoftware.Common.Visuals;

namespace GpsCorrectionPlugin.Edit
{
    class DistanceDiffToPower
    {
        public DistanceDiffToPower(IActivity activity)
        {
            this.activity = activity;
        }

        public static bool isEnabled(IActivity activity)
        {
            if (activity != null
                && (activity.PowerWattsTrack == null /*|| activity.PowerWattsTrack.Count == 0*/) 
                && activity.DistanceMetersTrack != null && activity.DistanceMetersTrack.Count > 0
                && activity.GPSRoute != null && activity.GPSRoute.Count > 0)
            {
                return true;
            }
            return false;
        }

        public void Run()
        {
            if (isEnabled(this.activity))
            {
                IDistanceDataTrack gpsDist = activity.GPSRoute.GetDistanceMetersTrack();
                IDistanceDataTrack devDist = activity.DistanceMetersTrack;
                INumericTimeDataSeries ptrack = new NumericTimeDataSeries();
                int g = 0;

                for (g = 0; g < gpsDist.Count; g++)
                {
                    if (gpsDist.EntryDateTime(gpsDist[g]) < devDist.EntryDateTime(devDist[devDist.Count - 1]) &&
                        gpsDist.EntryDateTime(gpsDist[g]) > devDist.EntryDateTime(devDist[0]))
                    {
                        ptrack.Add(gpsDist.EntryDateTime(gpsDist[g]),
                          devDist.GetInterpolatedValue(gpsDist.EntryDateTime(gpsDist[g])).Value - gpsDist[g].Value);
                    }
                }
                // Copy it to the selected PowerTrack
                activity.PowerWattsTrack = ptrack;
            }
        }

        private IActivity activity = null;
    }
}
