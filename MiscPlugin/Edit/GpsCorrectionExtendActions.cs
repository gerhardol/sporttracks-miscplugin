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
using System.Collections.Generic;

using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Data.GPS;
using ZoneFiveSoftware.Common.Visuals;
using ZoneFiveSoftware.Common.Visuals.Fitness;

namespace MiscPlugin.Edit
{
    class ExtendAction :
#if ST_2_1
    IExtendActivityEditActions
#else
     IExtendDailyActivityViewActions, IExtendActivityReportsViewActions
#endif
    {

#if ST_2_1
        #region IExtendActivityEditActions Members
        public IList<IAction> GetActions(IList<IActivity> activities)
        {
            IList<IActivity> activities2 = new List<IActivity>();
            if (!GpsCorrectionPlugin.Plugin.CorrectGpsFromDistanceEditMenu) return null;

            foreach (IActivity activity in activities)
            {
                if (!GpsCorrection.isEnabled(activity)) continue;
                activities2.Add(activity);
            }
            if (activities2.Count == 0) return null;
            return new IAction[] {
                new GpsCorrectionAction(activities2)
            };
        }

        public IList<IAction> GetActions(IActivity activity)
        {
            if (!GpsCorrectionPlugin.Plugin.CorrectGpsFromDistanceEditMenu) return null;
            //if (!GpsCorrection.isEnabled(activity)) return null;
                
            IList<IActivity> activities2 = new List<IActivity>();
            activities2.Add(activity);
            return new IAction[] { new GpsCorrectionAction(activities2) };
        }
        #endregion
#else
        #region IExtendDailyActivityViewActions Members
        public IList<IAction> GetActions(IDailyActivityView view,
                                                 ExtendViewActions.Location location)
        {
            if (!Plugin.CorrectGpsFromDistanceEditMenu) return new IAction[0];
            if (location == ExtendViewActions.Location.EditMenu)
            {
                return new IAction[] { new GpsCorrectionAction(view) };
            }
            else return new IAction[0];
        }
        public IList<IAction> GetActions(IActivityReportsView view,
                                         ExtendViewActions.Location location)
        {
            if (!Plugin.CorrectGpsFromDistanceEditMenu) return new IAction[0];
            if (location == ExtendViewActions.Location.EditMenu)
            {
                return new IAction[] { new GpsCorrectionAction(view) };
            }
            else return new IAction[0];
        }
        #endregion
#endif

    }
}
