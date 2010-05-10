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
#if ST_2_1
    class LiveUpdateExtendActions : IExtendRouteEditActions
#else
    class LiveUpdateExtendActions : IExtendRouteViewActions
#endif
    {

#if ST_2_1
        #region IExtendRouteEditActions Members
        IList<IAction> IExtendRouteEditActions.GetActions(IList<IRoute> routes)
        {
            return null;
        }

        IList<IAction> IExtendRouteEditActions.GetActions(IRoute route)
        {
            if (!LiveUpdateAction.isEnabled(route)) return null;

            return new IAction[] {
                new LiveUpdateAction(route)
            };
        }
        #endregion
#else
        #region IExtendRouteViewActions Members
        public IList<IAction> GetActions(IRouteView view,
                                                 ExtendViewActions.Location location)
        {
            if (location == ExtendViewActions.Location.EditMenu)
            {
                return new IAction[] { new LiveUpdateAction(view) };
            }
            else return new IAction[0];
        }
        #endregion
#endif

    }
}
