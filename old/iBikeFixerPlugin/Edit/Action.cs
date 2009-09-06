/*
Copyright (C) 2007 Gerhard Olsson 

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

namespace IBikeFixerPlugin.Edit
{
    class Action : IAction
    {
        public Action(IList<IActivity> activities)
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
        public Action(IActivity activity)
        {
            if (this.activities == null)
            {
                this.activities = new List<IActivity>();
            }
             this.activities.Add(activity);
        }

        public static bool isEnabled(IActivity activity)
        {
            if (activity != null
                && activity.GPSRoute != null && activity.GPSRoute.Count > 0
                && activity.PowerWattsTrack != null && activity.PowerWattsTrack.Count > 0
)//                && 10 < activity.GPSRoute.TotalElapsedSeconds - activity.PowerWattsTrack.TotalElapsedSeconds)
//                &&       activity.HeartRatePerMinuteTrack.EntryDateTime(activity.HeartRatePerMinuteTrack[activity.HeartRatePerMinuteTrack.Count - 1]).
//                Subtract(activity.PowerWattsTrack.EntryDateTime        (activity.PowerWattsTrack        [activity.PowerWattsTrack.Count-1]))
//                > new TimeSpan(0,0,10) )
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
                    if( isEnabled(activity)){
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
            Run();
        }
        public void Run()
        {
            foreach (IActivity activity in activities)
            {
                IBikeFixer tmp = new IBikeFixer(activity);
                activity.PowerWattsTrack = tmp.GetPower();
            }
        }

        public string Title
        {
            get {
                return Resources.Resources.Edit_Action_Text;
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

        private IList<IActivity> activities = null;
    }
}
