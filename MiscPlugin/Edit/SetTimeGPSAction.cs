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
            if (this._activities == null)
            {
                this._activities = activities;
            } else {
                foreach (IActivity activity in activities)
                {
                    this._activities.Add(activity);
                }
            }
        }

        public SetTimeGPSAction(IList<IRoute> routes)
        {
            if (this._routes == null)
            {
                this._routes = routes;
            }
            else
            {
                foreach (IRoute route in routes)
                {
                    this._routes.Add(route);
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
            foreach (IActivity activity in activities)
            {
                SetTimeGPS tmp = new SetTimeGPS(activity);
                activity.GPSRoute = tmp.getGPSRoute();
            }
            if (routes != null)
            foreach (IRoute route in routes)
            {
                SetTimeGPS tmp = new SetTimeGPS(route);
                route.GPSRoute = tmp.getGPSRoute();
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
                        return CollectionUtils.GetItemsOfType<IRoute>(routeView.SelectionProvider.SelectedItems);
                    }
                    else
                    {
                        return new List<IRoute>();
                    }
                }
#endif
                return _routes;
            }
        }
        private IList<IRoute> _routes = null;
    }
}
