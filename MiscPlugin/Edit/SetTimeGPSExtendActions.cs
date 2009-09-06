/*
Copyright (C) 2008, 2009 Gerhard Olsson 

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
    class SetTimeGPSExtendAction : IExtendActivityEditActions, IExtendRouteEditActions
    {
        #region IExtendRouteEditActions Members

        IList<IAction> IExtendRouteEditActions.GetActions(IList<IRoute> routes)
        {
            IList<IRoute> routes2 = new List<IRoute>();

            if (!MiscPlugin.Plugin.SetTimeGPSEditMenu) return null;
            foreach (IRoute route in routes)
            {
                routes2.Add(route);
            }
            if (routes2.Count == 0) return null;
            return new IAction[] {
                new SetTimeGPSAction(routes2)
            };
        }

        IList<IAction> IExtendRouteEditActions.GetActions(IRoute route)
        {
            if (!MiscPlugin.Plugin.SetTimeGPSEditMenu) return null;
            if (route == null || route.GPSRoute == null || route.GPSRoute.Count == 0) return null;

            return new IAction[] {
                new SetTimeGPSAction(route)
            };
        }
        #endregion

        #region IExtendActivityEditActions Members
        IList<IAction> IExtendActivityEditActions.GetActions(IList<IActivity> activities)
        {
            IList<IActivity> activities2 = new List<IActivity>();

            if (!MiscPlugin.Plugin.SetTimeGPSEditMenu) return null;
            foreach (IActivity activity in activities)
            {
                activities2.Add(activity);
            }
            if (activities2.Count == 0) return null;
            return new IAction[] {
                new SetTimeGPSAction(activities2)
            };
        }

        IList<IAction> IExtendActivityEditActions.GetActions(IActivity activity)
        {
            if (!MiscPlugin.Plugin.SetTimeGPSEditMenu) return null;
                
            return new IAction[] {
                new SetTimeGPSAction(activity)
            };
        }
        #endregion

    }
}
