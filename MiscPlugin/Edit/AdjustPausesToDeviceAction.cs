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

using ZoneFiveSoftware.Common.Data;
using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Data.GPS;
using ZoneFiveSoftware.Common.Visuals;

namespace MiscPlugin.Edit
{
    class AdjustPausesToDeviceAction : IAction
    {
        public AdjustPausesToDeviceAction(IList<IActivity> activities)
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
        public AdjustPausesToDeviceAction(IActivity activity)
        {
            if (this.activities == null)
            {
                this.activities = new List<IActivity>();
            }
             this.activities.Add(activity);
        }
        #region IAction Members

        public bool Enabled
        {
            get
            {
                Boolean enabled = false;
                foreach (IActivity activity in activities)
                {
                    if (AdjustPausesToDevice.isEnabled(activity))
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

        public void Refresh()
        {
        }

        public void Run(Rectangle rectButton)
        {
            foreach (IActivity activity in activities)
            {
                AdjustPausesToDevice tmp = new AdjustPausesToDevice(activity);
                tmp.Run();
            }

        }

        public string Title
        {
            get { return Properties.Resources.Edit_AdjustPausesToDevice_Text; }
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

        private IList<IActivity> activities = null;
    }
}
