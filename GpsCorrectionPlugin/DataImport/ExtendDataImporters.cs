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
using System.Collections;
using System.Collections.Generic;
using System.Text;

using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Visuals.Fitness;
using GpsCorrectionPlugin.Edit;

namespace GpsCorrectionPlugin.DataImport
{
    class ExtendDataImporters : IExtendDataImporters
    {
        //The actions that visibly affect time/distance and does not have to run at
        //updates runs prior to import
        //Other actions can run post import, both when added as new and when updated
        private void PostImport(IActivity activity)
        {
            if (GpsCorrectionPlugin.Plugin.DistanceDiffToPowerEditMenu)
            {
                if (DistanceDiffToPower.isEnabled(activity))
                {
                    DistanceDiffToPower tmp = new DistanceDiffToPower(activity);
                    tmp.Run();
                }
            }
        }
        #region IExtendDataImporters Members

        public IList<IFileImporter> FileImporters
        {
            get
            {
                return null;
            }
        }

        public void BeforeImport(IList items)
        {
            foreach (object item in items)
            {
                if (item is IActivity)
                {
                    IActivity activity = (IActivity)item;

                    if (GpsCorrectionPlugin.Plugin.CorrectGpsFromDistanceAtImport)
                    {
                        if (GpsCorrection.isEnabled(activity))
                        {
                            GpsCorrection tmp = new GpsCorrection(activity);
                            activity.GPSRoute = tmp.GetGpsRoute();
                        }
                    }
               }
            }
        }

        public void AfterImport(IList added, IList updated)
        {
            foreach (object item in added)
            {
                if (item is IActivity)
                {
                    IActivity activity = (IActivity)item;

                    PostImport(activity);
                }
            }
            foreach (object item in updated)
            {
                if (item is IActivity)
                {
                    IActivity activity = (IActivity)item;

                    PostImport(activity);
                }
            }
        }

        #endregion
    }
}
