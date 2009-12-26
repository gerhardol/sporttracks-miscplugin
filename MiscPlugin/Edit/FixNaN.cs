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
    class FixNaN
    {
        private IActivity activity = null;
        public FixNaN(IActivity activity)
        {
            this.activity = activity;
        }

        public static bool isEnabled(IActivity activity)
        {
            if (activity != null)
            {
                //No special check - an activity should have at least one track
                return true;
            }
            return false;
        }

                
        public int Run()
        {
            //Some Copy&Paste programming - this should be fixed soon anyway in the core program
            //The problem occurs after Edit->Data Tracks but is fixed at next startup

            String tmpNotes = "";
            String tType = "";
            int n = 0;

            // All NumericTimeDataSeries: HR, Cadence, Elevation, Power
            if (activity.HeartRatePerMinuteTrack != null && activity.HeartRatePerMinuteTrack.Count > 1)
            {
                INumericTimeDataSeries ntrack = new NumericTimeDataSeries();
                INumericTimeDataSeries otrack = activity.HeartRatePerMinuteTrack;
                tmpNotes = "";
                tType = "HR";
                n = 0;
                for (int i = 0; i < otrack.Count; i++)
                {
                    if (float.IsNaN(otrack[i].Value))
                    {
                        n++;
                        if (MiscPlugin.Plugin.Verbose > 99)
                        {
                            tmpNotes += "Found NaN: " + i + " " + otrack.EntryDateTime(otrack[i]) + " " + otrack[i].Value
                                 + Environment.NewLine;
                        }
                    }
                    else
                    {
                        ntrack.Add(otrack.EntryDateTime(otrack[i]), otrack[i].Value);
                    }

                }
                if (n > 0)
                {
                    if (MiscPlugin.Plugin.Verbose > 9)
                    {
                        activity.Notes += tType + " NaN Total " + n + " " + Environment.NewLine;
                        activity.Notes += tmpNotes;
                    }
                    activity.HeartRatePerMinuteTrack = ntrack;
                }
            }

            ////////////
            if (activity.CadencePerMinuteTrack != null && activity.CadencePerMinuteTrack.Count > 1)
            {
                INumericTimeDataSeries ntrack = new NumericTimeDataSeries();
                INumericTimeDataSeries otrack = activity.CadencePerMinuteTrack;
                tmpNotes = "";
                tType = "Cadence";
                n = 0;
                for (int i = 0; i < otrack.Count; i++)
                {
                    if (float.IsNaN(otrack[i].Value))
                    {
                        n++;
                        if (MiscPlugin.Plugin.Verbose > 99)
                        {
                            tmpNotes += "Found NaN: " + i + " " + otrack.EntryDateTime(otrack[i]) + " " + otrack[i].Value
                                 + Environment.NewLine;
                        }
                    }
                    else
                    {
                        ntrack.Add(otrack.EntryDateTime(otrack[i]), otrack[i].Value);
                    }

                }
                if (n > 0)
                {
                    if (MiscPlugin.Plugin.Verbose > 9)
                    {
                        activity.Notes += tType + " NaN Total " + n + " " + Environment.NewLine;
                        activity.Notes += tmpNotes;
                    }
                    activity.CadencePerMinuteTrack = ntrack;
                }
            }

            ////////////
            if (activity.ElevationMetersTrack != null && activity.ElevationMetersTrack.Count > 1)
            {
                INumericTimeDataSeries ntrack = new NumericTimeDataSeries();
                INumericTimeDataSeries otrack = activity.ElevationMetersTrack;
                tmpNotes = "";
                tType = "Elevation";
                n = 0;
                for (int i = 0; i < otrack.Count; i++)
                {
                    if (float.IsNaN(otrack[i].Value))
                    {
                        n++;
                        if (MiscPlugin.Plugin.Verbose > 99)
                        {
                            tmpNotes += "Found NaN: " + i + " " + otrack.EntryDateTime(otrack[i]) + " " + otrack[i].Value
                                 + Environment.NewLine;
                        }
                    }
                    else
                    {
                        ntrack.Add(otrack.EntryDateTime(otrack[i]), otrack[i].Value);
                    }

                }
                if (n > 0)
                {
                    if (MiscPlugin.Plugin.Verbose > 9)
                    {
                        activity.Notes += tType + " NaN Total " + n + " " + Environment.NewLine;
                        activity.Notes += tmpNotes;
                    }
                    activity.ElevationMetersTrack = ntrack;
                }
            }

            ////////////
            if (activity.PowerWattsTrack != null && activity.PowerWattsTrack.Count > 1)
            {
                INumericTimeDataSeries ntrack = new NumericTimeDataSeries();
                INumericTimeDataSeries otrack = activity.PowerWattsTrack;
                tmpNotes = "";
                tType = "Power";
                n = 0;
                for (int i = 0; i < otrack.Count; i++)
                {
                    if (float.IsNaN(otrack[i].Value))
                    {
                        n++;
                        if (MiscPlugin.Plugin.Verbose > 99)
                        {
                            tmpNotes += "Found NaN: " + i + " " + otrack.EntryDateTime(otrack[i]) + " " + otrack[i].Value
                                 + Environment.NewLine;
                        }
                    }
                    else
                    {
                        ntrack.Add(otrack.EntryDateTime(otrack[i]), otrack[i].Value);
                    }

                }
                if (n > 0)
                {
                    if (MiscPlugin.Plugin.Verbose > 9)
                    {
                        activity.Notes += tType + " NaN Total " + n + " " + Environment.NewLine;
                        activity.Notes += tmpNotes;
                    }
                    activity.PowerWattsTrack = ntrack;
                }
            }

            ////////////
            if (activity.DistanceMetersTrack != null && activity.DistanceMetersTrack.Count > 1)
            {
                IDistanceDataTrack ntrack = new DistanceDataTrack();
                IDistanceDataTrack otrack = activity.DistanceMetersTrack;
                tmpNotes = "";
                tType = "Distance";
                n = 0;
                for (int i = 0; i < otrack.Count; i++)
                {
                    if (float.IsNaN(otrack[i].Value))
                    {
                        n++;
                        if (MiscPlugin.Plugin.Verbose > 99)
                        {
                            tmpNotes += "Found NaN: " + i + " " + otrack.EntryDateTime(otrack[i]) + " " + otrack[i].Value
                                 + Environment.NewLine;
                        }
                    }
                    else
                    {
                        ntrack.Add(otrack.EntryDateTime(otrack[i]), otrack[i].Value);
                    }

                }
                if (n > 0)
                {
                    if (MiscPlugin.Plugin.Verbose > 9)
                    {
                        activity.Notes += tType + " NaN Total " + n + " " + Environment.NewLine;
                        activity.Notes += tmpNotes;
                    }
                    activity.DistanceMetersTrack = ntrack;
                }
            }
            //////////// GPS
            if (activity.GPSRoute != null && activity.GPSRoute.Count > 1)
            {
                IGPSRoute ntrack = new GPSRoute();
                IGPSRoute otrack = activity.GPSRoute;
                tmpNotes = "";
                tType = "GPS";
                n = 0;
                for (int i = 0; i < otrack.Count; i++)
                {
                    if (float.IsNaN(otrack[i].Value.LatitudeDegrees) || otrack[i].Value.LatitudeDegrees < -90 || otrack[i].Value.LatitudeDegrees > 90
                        || float.IsNaN(otrack[i].Value.LongitudeDegrees) || otrack[i].Value.LongitudeDegrees < -180 || otrack[i].Value.LongitudeDegrees > 180)
                    {
                        n++;
                        if (MiscPlugin.Plugin.Verbose > 99)
                        {
                            tmpNotes += "Found NaN: " + i + " " + otrack.EntryDateTime(otrack[i]) + " " + otrack[i].Value
                                 + Environment.NewLine;
                        }
                    }
                    else
                    {
                        ntrack.Add(otrack.EntryDateTime(otrack[i]), otrack[i].Value);
                    }

                }
                if (n > 0)
                {
                    if (MiscPlugin.Plugin.Verbose > 9)
                    {
                        activity.Notes += tType + " NaN Total " + n + " " + Environment.NewLine;
                        activity.Notes += tmpNotes;
                    }
                    activity.GPSRoute = ntrack;
                }
            }

            return 0;
        }
    }
}

