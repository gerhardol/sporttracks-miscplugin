/*
Copyright (C) 2009, 2010 Gerhard Olsson 

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
using System.Collections;

using ZoneFiveSoftware.Common.Data;
using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Data.GPS;
using ZoneFiveSoftware.Common.Visuals;
using ZoneFiveSoftware.Common.Visuals.Fitness;

namespace MiscPlugin.Edit
{
    class UseEnteredData
    {
        private IActivity activity = null;
        public UseEnteredData(IActivity activity)
        {
            this.activity = activity;
        }
        public static bool isEnabled(IActivity activity)
        {
            if (activity != null)
            {
                return true;
            }
            return false;
        }


        public int Run()
        {
            if (!isEnabled(activity))
            {
                return 1;
            }
            ActivityInfo info = ActivityInfoCache.Instance.GetInfo(activity);

            if (0 == activity.AverageCadencePerMinuteEntered)
            {
                activity.AverageCadencePerMinuteEntered = info.AverageCadence;
            }
            if (0 == activity.AverageHeartRatePerMinuteEntered)
            {
                activity.AverageHeartRatePerMinuteEntered = info.AverageHeartRate;
            }
            if (0 == activity.AveragePowerWattsEntered)
            {
                activity.AveragePowerWattsEntered = info.AveragePower;
            }
            if (0 == activity.MaximumCadencePerMinuteEntered)
            {
                activity.MaximumCadencePerMinuteEntered = info.MaximumCadence;
            }
            if (0 == activity.MaximumHeartRatePerMinuteEntered)
            {
                activity.MaximumHeartRatePerMinuteEntered = info.MaximumHeartRate;
            }
            if (0 == activity.MaximumPowerWattsEntered)
            {
                activity.MaximumPowerWattsEntered = info.MaximumPower;
            }
            if (info.HasElevationTrackData)
            {
                if (0 == activity.TotalAscendMetersEntered)
                {
                    activity.TotalAscendMetersEntered = (float)(info.TotalAscendingMeters(Plugin.GetApplication().DisplayOptions.SelectedClimbZone));
                }
                if (0 == activity.TotalDescendMetersEntered)
                {
                    activity.TotalDescendMetersEntered = (float)(info.TotalDescendingMeters(Plugin.GetApplication().DisplayOptions.SelectedClimbZone));
                }
            }
            if (0 == activity.TotalDistanceMetersEntered)
            {
                activity.TotalDistanceMetersEntered = (float)info.DistanceMetersNonPaused;
            }
            if (0 == activity.TotalTimeEntered.TotalSeconds)
            {
                activity.TotalTimeEntered = info.ActualTrackTime;
            }
            activity.UseEnteredData = true;
            ActivityInfoCache.Instance.ClearInfo(activity);

            return 0;
        }
    }
}
