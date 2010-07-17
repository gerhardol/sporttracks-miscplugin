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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

using ZoneFiveSoftware.Common.Data;
using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Data.GPS;
using ZoneFiveSoftware.Common.Data.Measurement;
using ZoneFiveSoftware.Common.Visuals;

namespace MiscPlugin.UI.Activities
{
    public partial class EditTrackInfoPageControl : UserControl
    {
        public EditTrackInfoPageControl()
        {
            InitializeComponent();
            RefreshPage();
        }

        #region Public properties
        public IActivity Activity
        {
            set
            {
                if (activity != value)
                {
                    activity = value;
                    RefreshPage();
                }
            }
        }
        #endregion

        #region Public methods
        public void RefreshPage()
        {
            if (activity == null || activity.GPSRoute == null || activity.GPSRoute.Count == 0)
            {
                txtNumGPSPoints.Text = "0";
                txtAvgSegmentDist.Text = "";
                txtMinSegmentDist.Text = "";
                txtMaxSegmentDist.Text = "";
            }
            else
            {
                // Calculate some statistics
                double totalDistance = 0;
                double minSegmentDistance = float.PositiveInfinity;
                double maxSegmentDistance = float.NegativeInfinity;
                double totalTime = 0;
                double minSegmentTime = float.PositiveInfinity;
                double maxSegmentTime = float.NegativeInfinity;

                ITimeValueEntry<IGPSPoint> entryPrior = null;
                foreach (ITimeValueEntry<IGPSPoint> entry in activity.GPSRoute)
                {
                    if (entryPrior != null)
                    {
                        double segmentDistance = entry.Value.DistanceMetersToPoint(entryPrior.Value);
                        minSegmentDistance = Math.Min(minSegmentDistance, segmentDistance);
                        maxSegmentDistance = Math.Max(maxSegmentDistance, segmentDistance);
                        totalDistance += segmentDistance;

                        double segmentTime = entry.ElapsedSeconds - entryPrior.ElapsedSeconds;
                        minSegmentTime = Math.Min(minSegmentTime, segmentTime);
                        maxSegmentTime = Math.Max(maxSegmentTime, segmentTime);
                        totalTime += segmentTime;
                    }
                    entryPrior = entry;
                }

                double avgSegmentDist = totalDistance / activity.GPSRoute.Count;
                double avgSegmentTime = totalTime / activity.GPSRoute.Count;

                double sumVarianceDist = 0;
                double sumVarianceTime = 0;
                entryPrior = null;
                foreach (ITimeValueEntry<IGPSPoint> entry in activity.GPSRoute)
                {
                    if (entryPrior != null)
                    {
                        double segmentDistance = entry.Value.DistanceMetersToPoint(entryPrior.Value);
                        double segmentVarianceDist = Math.Pow(segmentDistance - avgSegmentDist, 2);
                        sumVarianceDist += segmentVarianceDist;

                        double segmentTime = entry.ElapsedSeconds - entryPrior.ElapsedSeconds;
                        double segmentVarianceTime = Math.Pow(segmentTime - avgSegmentTime, 2);
                        sumVarianceTime += segmentVarianceTime;
                    }
                    entryPrior = entry;
                }

                double stdDevSegmentDist = Math.Sqrt(sumVarianceDist / activity.GPSRoute.Count);
                double stdDevSegmentTime = Math.Sqrt(sumVarianceTime / activity.GPSRoute.Count);

                // Refresh the display.
                Length.Units displayUnits = Plugin.GetApplication().SystemPreferences.DistanceUnits;
                if (displayUnits == Length.Units.Kilometer)
                {
                    displayUnits = Length.Units.Meter;
                }
                else if (displayUnits == Length.Units.Mile)
                {
                    displayUnits = Length.Units.Foot;
                }

                txtNumGPSPoints.Text = activity.GPSRoute.Count.ToString("N0");

                // Convert distances to the preferred length when displaying.
                string distanceFormatString = "N" + Length.DefaultDecimalPrecision(displayUnits) + "U";
                txtAvgSegmentDist.Text = Length.ToString(Length.Convert(avgSegmentDist, Length.Units.Meter, displayUnits), displayUnits, distanceFormatString);
                if (!double.IsPositiveInfinity(minSegmentDistance))
                {
                    txtMinSegmentDist.Text = Length.ToString(Length.Convert(minSegmentDistance, Length.Units.Meter, displayUnits), displayUnits, distanceFormatString);
                }
                else
                {
                    txtMinSegmentDist.Text = "";
                }
                if (!double.IsNegativeInfinity(maxSegmentDistance))
                {
                    txtMaxSegmentDist.Text = Length.ToString(Length.Convert(maxSegmentDistance, Length.Units.Meter, displayUnits), displayUnits, distanceFormatString);
                }
                else
                {
                    txtMaxSegmentDist.Text = "";
                }
                txtDistStdDev.Text = stdDevSegmentDist.ToString("N2");

                // Time
                txtAvgSegmentTime.Text = avgSegmentTime.ToString("N1") + "  " + Properties.Resources.UI_Activities_PageControl_tmp_Text;
                if (!double.IsPositiveInfinity(minSegmentTime))
                {
                    txtMinSegmentTime.Text = minSegmentTime.ToString("N1") + "  " + Properties.Resources.UI_Activities_PageControl_tmp_Text;
                }
                else
                {
                    txtMinSegmentTime.Text = "";
                }
                if (!double.IsNegativeInfinity(maxSegmentTime))
                {
                    txtMaxSegmentTime.Text = maxSegmentTime.ToString("N1") + "  " + Properties.Resources.UI_Activities_PageControl_tmp_Text;
                }
                else
                {
                    txtMaxSegmentTime.Text = "";
                }
                txtTimeStdDev.Text = stdDevSegmentTime.ToString("N2");
            }
        }

        public void ThemeChanged(ITheme visualTheme)
        {
            labelNumGPSPoints.ForeColor = visualTheme.ControlText;
            txtNumGPSPoints.ThemeChanged(visualTheme);
            labelAvgSegmentDist.ForeColor = visualTheme.ControlText;
            txtAvgSegmentDist.ThemeChanged(visualTheme);
            labelMinSegmentDist.ForeColor = visualTheme.ControlText;
            txtMinSegmentDist.ThemeChanged(visualTheme);
            labelMaxSegmentDist.ForeColor = visualTheme.ControlText;
            txtMaxSegmentDist.ThemeChanged(visualTheme);
            labelDistStdDev.ForeColor = visualTheme.ControlText;
            txtDistStdDev.ThemeChanged(visualTheme);
            labelAvgSegmentTime.ForeColor = visualTheme.ControlText;
            txtAvgSegmentTime.ThemeChanged(visualTheme);
            labelMinSegmentTime.ForeColor = visualTheme.ControlText;
            txtMinSegmentTime.ThemeChanged(visualTheme);
            labelMaxSegmentTime.ForeColor = visualTheme.ControlText;
            txtMaxSegmentTime.ThemeChanged(visualTheme);
            labelTimeStdDev.ForeColor = visualTheme.ControlText;
            txtTimeStdDev.ThemeChanged(visualTheme);
        }

        public void UICultureChanged(CultureInfo culture)
        {
            labelNumGPSPoints.Text = Properties.Resources.UI_Activities_PageControl_tmp_Text;
            labelAvgSegmentDist.Text = Properties.Resources.UI_Activities_PageControl_tmp_Text;
            labelMinSegmentDist.Text = Properties.Resources.UI_Activities_PageControl_tmp_Text;
            labelMaxSegmentDist.Text = Properties.Resources.UI_Activities_PageControl_tmp_Text;
            labelDistStdDev.Text = Properties.Resources.UI_Activities_PageControl_tmp_Text;
            labelAvgSegmentTime.Text = Properties.Resources.UI_Activities_PageControl_tmp_Text;
            labelMinSegmentTime.Text = Properties.Resources.UI_Activities_PageControl_tmp_Text;
            labelMaxSegmentTime.Text = Properties.Resources.UI_Activities_PageControl_tmp_Text;
            labelTimeStdDev.Text = Properties.Resources.UI_Activities_PageControl_tmp_Text;

            // Data contains localized text also, refresh.
            RefreshPage();
        }
        #endregion

        #region Private members
        private IActivity activity;
        #endregion

    }
}
