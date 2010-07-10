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
    class LiveUpdateAction : IAction
    {
#if !ST_2_1
        public LiveUpdateAction(IRouteView view)
        {
            this.routeView = view;
        }
#endif
        public LiveUpdateAction(IRoute route)
        {
            this._routes.Add(route);
        }

        public static bool isEnabled(IRoute route)
        {
            //TODO not implemented
            return false;
        }

        #region IAction Members

        public bool Enabled
        {
            get
            {
                Boolean enabled = false;
                //foreach (IActivity route in routes)
                //{
                //    if (RemoveIdenticalGPS.isEnabled(route))
                //    {
                //        enabled = true;
                //        break;
                //    }
                //}
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
        }

        public string Title
        {
            get { return Properties.Resources.Edit_LiveUpdate_Text; }
        }
        public bool Visible
        {
            get
            {
                //if (routes.Count == 1) return true;
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
        private IRouteView routeView = null;
#endif
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
                        return GetAllContainedItems<IRoute>(routeView.SelectionProvider);
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
    }
}
