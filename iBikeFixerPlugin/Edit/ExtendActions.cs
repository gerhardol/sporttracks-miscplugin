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
using System.Collections.Generic;

using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Data.GPS;
using ZoneFiveSoftware.Common.Visuals;
using ZoneFiveSoftware.Common.Visuals.Fitness;

namespace IBikeFixerPlugin.Edit
{
    class ExtendAction : IExtendActivityEditActions
    {
        #region IExtendActivityEditActions Members

        IList<IAction> IExtendActivityEditActions.GetActions(IList<IActivity> activities)
        {
            IList<IActivity> activities2 = new List<IActivity>();

            foreach (IActivity activity in activities)
            {
                if (!Action.isEnabled(activity)) continue;
                activities2.Add(activity);
            }
            if (activities2.Count == 0) return null;
            return new IAction[] {
                new Action(activities2)
            };
        }

        IList<IAction> IExtendActivityEditActions.GetActions(IActivity activity)
        {
            if (!Action.isEnabled(activity)) return null;
                
            return new IAction[] {
                new Action(activity)
            };
        }
        #endregion

    }
}
