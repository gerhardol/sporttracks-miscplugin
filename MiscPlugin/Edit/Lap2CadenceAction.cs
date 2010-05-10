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
#if !ST_2_1
using ZoneFiveSoftware.Common.Visuals.Fitness;
using ZoneFiveSoftware.Common.Visuals.Util;
#endif

namespace MiscPlugin.Edit
{
    class Lap2CadenceAction : IAction
    {
#if !ST_2_1
        public Lap2CadenceAction(IDailyActivityView view)
        {
            this.dailyView = view;
        }
        public Lap2CadenceAction(IActivityReportsView view)
        {
            this.reportView = view;
        }
#endif
        public Lap2CadenceAction(IList<IActivity> activities)
        {
            if (this.activities == null)
            {
                this._activities = activities;
            }
            else
            {
                foreach (IActivity activity in activities)
                {
                    this.activities.Add(activity);
                }
            }
        }
        public static bool isEnabled(IActivity activity)
        {
            if (activity != null && activity.GPSRoute != null && activity.GPSRoute.Count > 0)
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

        public IList<string> MenuPath
        {
            get
            {
                return new List<string>();
            }
        }
        public Image Image
        {
            get { return null; }
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
                    IValueRangeSeries<DateTime> pauses = activity.TimerPauses;
                    IActivityLaps laps = activity.Laps;
                    INumericTimeDataSeries ntrack = new NumericTimeDataSeries();
                    int g;

                    if (activity.CadencePerMinuteTrack == null)
                    {
                        activity.CadencePerMinuteTrack = new NumericTimeDataSeries();
                    }

                    for (g = 0; g < pauses.Count; g++)
                    {
                        if (g > 0 && pauses[g - 1].Lower < pauses[g].Lower.Subtract(new TimeSpan(0, 0, 1))
                            || activity.StartTime < pauses[g].Lower.Subtract(new TimeSpan(0, 0, 1)))
                        {
                            activity.CadencePerMinuteTrack.Add(pauses[g].Lower.Subtract(new TimeSpan(0, 0, 1)), 0);
                        }
                        activity.CadencePerMinuteTrack.Add(pauses[g].Lower, 200);
                        if (g < pauses.Count - 1 && pauses[g + 1].Lower > pauses[g].Lower.AddSeconds(1)
                            || activity.GPSRoute != null && activity.GPSRoute.Count >= 0 &&
                            activity.GPSRoute.EntryDateTime(activity.GPSRoute[activity.GPSRoute.Count - 1]) >
                                pauses[g].Lower.AddSeconds(1))
                        {
                            activity.CadencePerMinuteTrack.Add(pauses[g].Lower.AddSeconds(1), 0);
                        }

                        if (g > 0 && pauses[g - 1].Upper < pauses[g].Upper.Subtract(new TimeSpan(0, 0, 1))
                            || activity.StartTime < pauses[g].Upper.Subtract(new TimeSpan(0, 0, 1)))
                        {
                            activity.CadencePerMinuteTrack.Add(pauses[g].Upper.Subtract(new TimeSpan(0, 0, 1)), 0);
                        }
                        activity.CadencePerMinuteTrack.Add(pauses[g].Upper, 200);
                        if (g < pauses.Count - 1 && pauses[g + 1].Upper > pauses[g].Upper.AddSeconds(1)
                            || activity.GPSRoute != null && activity.GPSRoute.Count >= 0 &&
                            activity.GPSRoute.EntryDateTime(activity.GPSRoute[activity.GPSRoute.Count - 1]) >
                                pauses[g].Upper.AddSeconds(1))
                        {
                            activity.CadencePerMinuteTrack.Add(pauses[g].Upper.AddSeconds(1), 0);
                        }
                    }

                    for (g = 0; g < laps.Count; g++)
                    {
                        if (g > 0 && laps[g - 1].StartTime < laps[g].StartTime.Subtract(new TimeSpan(0, 0, 1)))
                        {
                            activity.CadencePerMinuteTrack.Add(laps[g].StartTime.Subtract(new TimeSpan(0, 0, 1)), 0);
                        }
                        activity.CadencePerMinuteTrack.Add(laps[g].StartTime, 254);
                        if (g < laps.Count - 1 && laps[g + 1].StartTime > laps[g].StartTime.AddSeconds(1))
                        {
                            activity.CadencePerMinuteTrack.Add(laps[g].StartTime.AddSeconds(1), 0);
                        }
                    }
                    //Fudge to get ST notice the update
                    for (g = 0; g < activity.CadencePerMinuteTrack.Count; g++)
                    {
                        ntrack.Add(activity.CadencePerMinuteTrack.EntryDateTime(activity.CadencePerMinuteTrack[g]),
                            activity.CadencePerMinuteTrack[g].Value);
                    }
                    activity.CadencePerMinuteTrack = ntrack;
                }
            }
        }

        public string Title
        {
            get { return Properties.Resources.Edit_Lap2Cadence_Text; }
        }
        public bool Visible
        {
            get
            {
                if (!MiscPlugin.Plugin.Laps2CadenceEditMenu) return false;
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
        private IDailyActivityView dailyView    = null;
        private IActivityReportsView reportView = null;
#endif
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
                        return CollectionUtils.GetItemsOfType<IActivity>(dailyView.SelectionProvider.SelectedItems);
                    }
                    else if (reportView != null)
                    {
                        return CollectionUtils.GetItemsOfType<IActivity>(reportView.SelectionProvider.SelectedItems);
                    }
                    else
                    {
                        return new List<IActivity>();
                    }
                }
#endif
                return _activities;
            }
        }
       private IList<IActivity> _activities = null;
       }

}
