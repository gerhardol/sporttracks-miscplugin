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
    class SetTimeGPSAction : IAction
    {
#if !ST_2_1
        public SetTimeGPSAction(IDailyActivityView view)
        {
            this.dailyView = view;
        }
        public SetTimeGPSAction(IActivityReportsView view)
        {
            this.reportView = view;
        }
        public SetTimeGPSAction(IRouteView view)
        {
            this.routeView = view;
        }
#endif
        public SetTimeGPSAction(IList<IActivity> activities)
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

        public SetTimeGPSAction(IList<IRoute> routes)
        {
            if (this.routes == null)
            {
                this.routes = routes;
            }
            else
            {
                foreach (IRoute route in routes)
                {
                    this.routes.Add(route);
                }
            }
        }

        #region IAction Members

        public bool Enabled
        {
            get
            {
                Boolean enabled = false;
                    if (activities != null)
                    {
                        foreach (IActivity activity in activities)
                        {
                            if (SetTimeGPS.isEnabled(activity))
                            {
                                enabled = true;
                                break;
                            }
                        }
                    }
                    if (routes != null)
                    {
                        foreach (IRoute route in routes)
                        {
                            if (SetTimeGPS.isEnabled(route))
                            {
                                enabled = true;
                                break;
                            }
                        }
                    }
                return enabled; 
            }
        }

        public bool HasMenuArrow
        {
            get { return true; }
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
            if (activities != null)
            {
                bool handled = false;
                if (dailyView != null)
                {
                    IList<IItemTrackSelectionInfo> selectedGPS = TrailsPlugin.Data.TrailsItemTrackSelectionInfo.SetAndAdjustFromSelection(dailyView.RouteSelectionProvider.SelectedItems, activities, true);
                    if (TrailsPlugin.Data.TrailsItemTrackSelectionInfo.ContainsData(selectedGPS))
                    {
                        string message = Properties.Resources.Edit_SetTimeGPS_UseSelection_Text;
                        if (MessageBox.Show(string.Format(message, CommonResources.Text.ActionYes, CommonResources.Text.ActionNo),
                            "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            handled = true;
                            foreach (IItemTrackSelectionInfo sel in selectedGPS)
                            {
                                if (sel is TrailsPlugin.Data.TrailsItemTrackSelectionInfo)
                                {
                                    IGPSRoute route = new GPSRoute();
                                    IActivity activity = (sel as TrailsPlugin.Data.TrailsItemTrackSelectionInfo).Activity;
                                    ActivityInfo info = ActivityInfoCache.Instance.GetInfo(activity);
                                    foreach (IValueRange<DateTime> times in sel.MarkedTimes)
                                    {
                                        IDistanceDataTrack dtrack = info.MovingDistanceMetersTrack;
                                        float startDist = dtrack.GetInterpolatedValue(times.Lower).Value;
                                        float endDist = dtrack.GetInterpolatedValue(times.Upper).Value;
                                        double speed = (endDist - startDist) / (times.Upper - times.Lower).TotalSeconds;
                                        for (int i = 0; i < activity.GPSRoute.Count; i++)
                                        {
                                            ITimeValueEntry<IGPSPoint> g = activity.GPSRoute[i];
                                            DateTime time = activity.GPSRoute.EntryDateTime(g);
                                            if (time > times.Lower && time < times.Upper)
                                            {
                                                float dist = dtrack.GetInterpolatedValue(time).Value - startDist;
                                                time = ZoneFiveSoftware.Common.Data.Algorithm.DateTimeRangeSeries.AddTimeAndPauses(times.Lower, TimeSpan.FromSeconds(dist / speed), info.NonMovingTimes);
                                            }
                                            route.Add(time, g.Value);
                                        }
                                    }
                                    activity.GPSRoute = route;
                                }
                            }
                        }
                    }
                }
                if (!handled)
                {
                    foreach (IActivity activity in activities)
                    {
                        //TODO: Possibly implement selection above
                        SetTimeGPS tmp = new SetTimeGPS(activity);
                        activity.GPSRoute = tmp.getGPSRoute();
                    }
                }
            }
            if (routes != null)
            {
                foreach (IRoute route in routes)
                {
                    SetTimeGPS tmp = new SetTimeGPS(route);
                    route.GPSRoute = tmp.getGPSRoute();
                }
            }
        }
        public string Title
        {
            get { return Properties.Resources.Edit_SetTimeGPS_Text; }
        }
        public bool Visible
        {
            get
            {
                if (activities.Count > 0) return true;
                if (routes.Count > 0) return true;
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
        private IRouteView routeView = null;
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
        private IList<IRoute> _routes = null;
        private IList<IRoute> routes
        {
            get
            {
#if !ST_2_1
                //activities are set either directly or by selection,
                //not by more than one
                if (_routes == null)
                {
                    if (routeView != null)
                    {
                        return CollectionUtils.GetAllContainedItemsOfType<IRoute>(routeView.SelectionProvider.SelectedItems);
                    }
                    else
                    {
                        return new List<IRoute>();
                    }
                }
#endif
                return _routes;
            }
           set
            {
                _routes = value;
            }
        }
    }
}
