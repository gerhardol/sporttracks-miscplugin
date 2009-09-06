/*
Copyright (C) 2007, 2009 Gerhard Olsson 

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

namespace MiscPlugin.Export
{
    class ExportActivityToCompareTracksExtendAction : IExtendActivityExportActions
    {
        #region IExtendActivityExportActions Members

        IList<IAction> IExtendActivityExportActions.GetActions(IList<IActivity> activities)
        {
            IList<IActivity> activities2 = new List<IActivity>();

            foreach (IActivity activity in activities)
            {
                if (!ExportActivityToCompareTracksAction.isEnabled(activity)) continue;
                activities2.Add(activity);
            }
            if (activities2.Count == 0) return null;
            return new IAction[] {
                new ExportActivityToCompareTracksAction(activities2)
            };
        }

        IList<IAction> IExtendActivityExportActions.GetActions(IActivity activity)
        {
            if (!ExportActivityToCompareTracksAction.isEnabled(activity)) return null;

            return new IAction[] {
                new ExportActivityToCompareTracksAction(activity)
            };
        }
 
        #endregion
    }
}
