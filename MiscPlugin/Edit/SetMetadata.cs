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
using System.Text.RegularExpressions;

using ZoneFiveSoftware.Common.Data;
using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Data.GPS;
using ZoneFiveSoftware.Common.Visuals;
using ZoneFiveSoftware.Common.Visuals.Fitness;

namespace MiscPlugin.Edit
{
    class SetMetadata
    {
        private IActivity activity = null;
        public SetMetadata(IActivity activity)
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

        //From UniqueRoutes
        private static IActivityCategory parseCategory(string p)
        {
            if (p == null || p.Equals("")) return null;
            string[] ps = p.Split('|');
            IActivityCategory cat = getCategory(ps, 0, Plugin.GetApplication().Logbook.ActivityCategories);
            return cat;
        }
        public static IActivityCategory getCategory(string[] ps, int p, IEnumerable<IActivityCategory> iList)
        {
            if (iList == null) return null;
            foreach (IActivityCategory category in iList)
            {
                if (category.Name.Equals(ps[p]))
                {
                    if (p == ps.Length - 1)
                    {
                        return category;
                    }
                    return getCategory(ps, p + 1, category.SubCategories);
                }
            }
            return null;
        }

        public int Run()
        {
            if (!isEnabled(activity))
            {
                return 1;
            }

            //Specific fixes, use separate GUID to run before ElevationCorrection
#if !OLD_GUID

            //Temp fix for Globalsat
            //int c = 0;
            //if (activity.HeartRatePerMinuteTrack != null && activity.HeartRatePerMinuteTrack.Count == 2)
            //{
            //    if (activity.HeartRatePerMinuteTrack[0].Value == 0 && activity.HeartRatePerMinuteTrack[1].Value == 0)
            //    {
            //        activity.HeartRatePerMinuteTrack = null;
            //        c++;
            //    }
            //}

            //Notes, name matching, possibly Cadence
            if (string.IsNullOrEmpty(activity.Metadata.Source))
            {
                //enum cCheck  {Ignore, Yes, No };
                string[][] data = {
                    new string[] { "IpBike D6603", "", "[\\d.,]*km (med|with) [\\d.,]*m (stigning på|climb in) [\\d.,:]*", null },
                    //Assume Strava is recorded with the App, giving Cadence
                    new string[] { "Strava D6603", "Yes", "^(Morning|Lunch|Afternoon|Night) (Run|Ride)", null },
                    //GPX likely, empty Note
                    //Assume GPX Strava name matching is runnerup
                    new string[] { "Runnerup(Strava) D6603", "", "^$", "(Morning|Lunch|Afternoon|Night) (Run|Ride)" },
                    new string[] { "ViewRanger D6603", "", "^$", "Track \\w\\w\\w \\d{1,2}, \\d{4}" },
                    new string[] { "Runkeeper D6603", "", "^$", "Running \\d{1,2}/\\d{1,2}/\\d{1,2} \\d{1,2}:\\d{1,2} \\w\\w" },
                    new string[] { "Jogg D6603", "", "^$", "\\d{4}-\\d{2}-\\d{2}T\\d{2}:\\d{1,2}:\\d{1,2}Z$" },
                    new string[] { "Oruxmaps D6603", "", "^$", "\\d{4}-\\d{2}-\\d{2} \\d{2}:\\d{1,2}$" },
                    //Note that Trails run before, if it sets a name it is no longer empty
                    new string[] { "Endomondo D6603", "", "^$", "^$" },
                    //??Funbeat, OSMand

                };

                for (int i = 0; i < data.Length; i++)
                {
                    if ((data[i][2] == null || Regex.IsMatch(activity.Notes, data[i][2])) &&
                        (data[i][3] == null || Regex.IsMatch(activity.Name, data[i][3])))
                    {
                        if (data[i][1] == "Yes")
                        {
                            if (activity.CadencePerMinuteTrack != null && activity.CadencePerMinuteTrack.Count > 0)
                            {
                                activity.Metadata.Source = data[i][0];
                            }
                        }
                        else if (data[i][1] == "No")
                        {
                            if (activity.CadencePerMinuteTrack == null || activity.CadencePerMinuteTrack.Count == 0)
                            {
                                activity.Metadata.Source = data[i][0];
                            }
                        }
                        else
                        {
                            activity.Metadata.Source = data[i][0];
                        }
                        if (!string.IsNullOrEmpty(activity.Metadata.Source))
                        {
                            break;
                        }
                    }
                }
            }
            //
            if (string.IsNullOrEmpty(activity.Metadata.Source))
            {
                string data = "Ghostracer D6603";// "Garmin 920XT";
                
                if (activity.CadencePerMinuteTrack != null && activity.CadencePerMinuteTrack.Count > 0)
                {
                    activity.Metadata.Source = data;
                }
            }
            if (string.IsNullOrEmpty(activity.Metadata.Source))
            {
                activity.Metadata.Source = "Unknown D6603";
            }

            if (string.IsNullOrEmpty(activity.Metadata.Source))
            {
                string[][] data = {
                new string[] { "Garmin 920XT", "My Friends Activities|Garmin" },
                new string[] { "Garmin 920XT", "Mina vänners aktiviteter|Garmin"
                }
            };
                for (int i = 0; i < data.Length; i++)
                {
                    if (!string.IsNullOrEmpty(data[i][1]) && parseCategory(data[i][1]) != null)
                    {
                        activity.Metadata.Source = data[i][0];
                        break;
                    }
                }
            }
#endif
            return 0;
        }
    }
}

