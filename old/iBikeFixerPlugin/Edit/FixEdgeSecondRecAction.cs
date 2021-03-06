/*
Copyright (C) 2007, 2010 Gerhard Olsson 

This library is free software; you can redistribute it and/or
modify it under the terms of the GNU Lesser General Public
License as published by the Free Software Foundation; either
version 2.1 of the License, or (at your option) any later version.

This library is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
Lesser General Public License for more details.

You should have received a copy of the GNU Lesser General Public
License along with this library; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
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
#if !ST_2_1
using ZoneFiveSoftware.Common.Visuals.Fitness;
using ZoneFiveSoftware.Common.Visuals.Util;
#endif

namespace IBikeFixerPlugin.Edit
{
    class FixEdgeSecondRecAction : IAction
    {
#if !ST_2_1
        public FixEdgeSecondRecAction(IDailyActivityView view)
        {
            this.dailyView = view;
        }
        public FixEdgeSecondRecAction(IActivityReportsView view)
        {
            this.reportView = view;
        }
#endif
        public FixEdgeSecondRecAction(IList<IActivity> activities)
        {
            if (this.activities == null)
            {
                this.activities = activities;
            } else {
                foreach (IActivity activity in activities)
                {
                    this.activities.Add(activity);
                }
            }
       }
        public static bool isEnabled(IActivity activity)
        {
            if (activity != null
                && activity.GPSRoute != null && activity.GPSRoute.Count > 0)
            {
                return true;
            }
            return false;
        }

        #region IAction Members

        public bool Enabled
        {
            get
            {
                Boolean enabled = true;
                foreach (IActivity activity in activities)
                {
                    if (isEnabled(activity))
                    {
                        enabled = true;
                        break;
                    }
                }
                return enabled;
            }
        }

        public bool HasMenuArrow
        {
            get { return false; }
        }

        public Image Image
        {
            get { return null; }
        }

        public IList<string> MenuPath
        {
            get
            {
                return new List<string>();
            }
        }
        public void Refresh()
        {
        }

        public void Run(Rectangle rectButton)
        {
            foreach (IActivity activity in activities)
            {
                if (isEnabled(activity))
                {
                    int g;

                    for (g = 1; g < activity.GPSRoute.Count - 1; g++)
                    {
                        if (Math.Abs(activity.GPSRoute[g - 1].Value.ElevationMeters - activity.GPSRoute[g + 1].Value.ElevationMeters) < 0.1
                            && Math.Abs(activity.GPSRoute[g - 1].Value.ElevationMeters - activity.GPSRoute[g].Value.ElevationMeters) <= 1
                            && (activity.GPSRoute[g + 1].ElapsedSeconds - activity.GPSRoute[g - 1].ElapsedSeconds) < 2.1)
                        {
                            //activity.GPSRoute[g].Value.ElevationMeters = activity.GPSRoute[g-1].Value.ElevationMeters;
                            IGPSPoint p = new GPSPoint(activity.GPSRoute[g].Value.LatitudeDegrees,
                                activity.GPSRoute[g].Value.LongitudeDegrees,
                                activity.GPSRoute[g - 1].Value.ElevationMeters);
                            activity.GPSRoute.SetValueAt(g, p);
                        }
                    }
                    activity.Notes += "Edge Elevation fixed";
                }
            }
        }

        public string Title
        {
            get { return "FixEdgeSecondRecording"; }
//            get { return Resources.Resources.Edit_PowerDistanceDiffToCadenceTrackAction_Text; }
        }
        public bool Visible
        {
            get
            {
                if (activities.Count > 0) return true;
                return false;
            }
        }

        #endregion

        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion


        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

#if !ST_2_1
        private IDailyActivityView dailyView = null;
        private IActivityReportsView reportView = null;
#endif
        private IList<IActivity> _activities = null;
        private IList<IActivity> activities
        {
            get
            {
#if !ST_2_1
                //activities are set either directly or by selection,
                //not by more than one
                if (_activities == null)
                {
                    if (dailyView != null)
                    {
                        return CollectionUtils.GetAllContainedItemsOfType<IActivity>(dailyView.SelectionProvider.SelectedItems);
                    }
                    else if (reportView != null)
                    {
                        return CollectionUtils.GetAllContainedItemsOfType<IActivity>(reportView.SelectionProvider.SelectedItems);
                    }
                    else
                    {
                        return new List<IActivity>();
                    }
                }
#endif
                return _activities;
            }
            set
            {
                _activities = value;
            }
        }
    }
}
