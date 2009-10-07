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
using MiscPlugin.Edit;

namespace MiscPlugin.DataImport
{
    class ExtendDataImporters : IExtendDataImporters
    {
        //The actions that visibly affect time/distance and does not have to run at
        //updates runs prior to import
        //Other actions can run post import, both when added as new and when updated
        private void PostImport(IActivity activity)
        {
            if (MiscPlugin.Plugin.DetectRestLapsAtImport)
            {
                if (DetectRestLaps.isEnabled(activity))
                {
                    DetectRestLaps tmp = new DetectRestLaps(activity);
                    tmp.Run();
                }
            }
            if (MiscPlugin.Plugin.RemoveIdenticalGPSAtImport)
            {
                if (RemoveIdenticalGPS.isEnabled(activity))
                {
                    RemoveIdenticalGPS tmp = new RemoveIdenticalGPS(activity);
                    tmp.Run();
                }
            }
            if (MiscPlugin.Plugin.ElevationToGPSAtImport)
            {
                if (ElevationToGPS.isEnabled(activity))
                {
                    ElevationToGPS tmp = new ElevationToGPS(activity);
                    tmp.Run();
                }
            }
            if (MiscPlugin.Plugin.SetTimeGPSAtImport)
            {
                if (SetTimeGPS.isEnabled(activity)
                    && activity.GPSRoute[activity.GPSRoute.Count - 1].ElapsedSeconds == 0)
                {
                    SetTimeGPS tmp = new SetTimeGPS(activity);
                    activity.GPSRoute = tmp.getGPSRoute();
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

                    if (MiscPlugin.Plugin.InsertPausesAtImport)
                    {
                        if (InsertPauses.isEnabled(activity))
                        {
                            InsertPauses tmp = new InsertPauses(activity);
                            tmp.Run();
                        }
                    }
                    if (MiscPlugin.Plugin.AdjustPausesToDeviceAtImport)
                    {
                        if (AdjustPausesToDevice.isEnabled(activity))
                        {
                            AdjustPausesToDevice tmp = new AdjustPausesToDevice(activity);
                            tmp.Run();
                        }
                    }
                    if (MiscPlugin.Plugin.ExtendGPSAtImport)
                    {
                        if (ExtendGPS.isEnabled(activity))
                        {
                            ExtendGPS tmp = new ExtendGPS(activity);
                            tmp.Run();
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
                    if (MiscPlugin.Plugin.FixHRAtImport)
                    {
                        if (FixHR.isEnabled(activity))
                        {
                            FixHR tmp = new FixHR(activity);
                            tmp.Run();
                        }
                    }
                    activity.UseEnteredData = MiscPlugin.Plugin.SetUseEnteredDataAtImport;
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
