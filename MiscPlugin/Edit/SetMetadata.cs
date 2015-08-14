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

            if (string.IsNullOrEmpty(activity.Metadata.Source))
            {
                string[][] data = { };//TBD { new string[] { "[\\d.,]*km med [\\d.,]*m stigning på [\\d.,:]*", "IpBike D6603" } };

                for (int i = 0; i < data.Length; i++)
                {
                    if (!string.IsNullOrEmpty(data[i][0]) && Regex.IsMatch(activity.Notes, data[i][0]))
                    {
                        activity.Metadata.Source = data[i][1];
                        break;
                    }
                }
            }
            return 0;
        }
    }
}

