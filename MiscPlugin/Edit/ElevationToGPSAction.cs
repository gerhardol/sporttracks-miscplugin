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
    class ElevationToGPSAction : IAction
    {
#if !ST_2_1
        public ElevationToGPSAction(IDailyActivityView view)
        {
            this.dailyView = view;
        }
        public ElevationToGPSAction(IActivityReportsView view)
        {
            this.reportView = view;
        }
#endif
        public ElevationToGPSAction(IList<IActivity> activities)
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
                            if (ElevationToGPS.isEnabled(activity))
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
                ElevationToGPS tmp = new ElevationToGPS(activity);
                tmp.Run();
            }
        }
        public string Title
        {
            get { return Properties.Resources.Edit_ElevationToGPS_Text; }
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
