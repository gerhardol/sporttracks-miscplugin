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
    class PowerDistanceDiffToCadenceTrackAction : IAction
    {
#if !ST_2_1
        public PowerDistanceDiffToCadenceTrackAction(IDailyActivityView view)
        {
            this.dailyView = view;
        }
        public PowerDistanceDiffToCadenceTrackAction(IActivityReportsView view)
        {
            this.reportView = view;
        }
#endif
        public PowerDistanceDiffToCadenceTrackAction(IList<IActivity> activities)
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
                && activity.PowerWattsTrack != null && activity.PowerWattsTrack.Count > 0
                && activity.DistanceMetersTrack != null && activity.DistanceMetersTrack.Count > 0)
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
                    INumericTimeDataSeries gpsDist = activity.PowerWattsTrack;
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
                    activity.CadencePerMinuteTrack = ptrack;
                }
            }
        }

        public string Title
        {
            get { return "PowerDistanceDiffToCadenceTrack"; }
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
        IList<ItemType> GetAllContainedItems<ItemType>(ISelectionProvider selectionProvider)
        {
            List<ItemType> items = new List<ItemType>();
            foreach (ItemType item in CollectionUtils.GetItemsOfType<ItemType>(selectionProvider.SelectedItems))
            {
                if (!items.Contains(item)) items.Add(item);
            }
            AddGroupItems<ItemType>(CollectionUtils.GetItemsOfType<IGroupedItem<ItemType>>(
                                    selectionProvider.SelectedItems), items);
            return items;
        }

        void AddGroupItems<ItemType>(IList<IGroupedItem<ItemType>> groups, IList<ItemType> allItems)
        {
            foreach (IGroupedItem<ItemType> group in groups)
            {
                foreach (ItemType item in group.Items)
                {
                    if (!allItems.Contains(item)) allItems.Add(item);
                }
                AddGroupItems(group.SubGroups, allItems);
            }
        }
#endif
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
                        return GetAllContainedItems<IActivity>(dailyView.SelectionProvider);
                    }
                    else if (reportView != null)
                    {
                        return GetAllContainedItems<IActivity>(reportView.SelectionProvider);
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
