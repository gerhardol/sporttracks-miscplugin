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
using System.Xml;
using System.IO;

using ZoneFiveSoftware.Common.Data;
using ZoneFiveSoftware.Common.Data.Fitness;
using ZoneFiveSoftware.Common.Data.GPS;
using ZoneFiveSoftware.Common.Data.Measurement;
using ZoneFiveSoftware.Common.Visuals;

using MiscPlugin.Edit;

namespace MiscPlugin.UI.Settings
{
    /// <summary>
    /// Settings page for ExtendGPS
    /// </summary>
    public partial class MiscPluginPageControl : UserControl
    {
        /// creator
        public MiscPluginPageControl()
        {
            InitializeComponent();
            RefreshPage();
        }
        #region Public methods
        /// <summary>
        /// Refresh the Settings page
        /// </summary>
        public void RefreshPage()
        {
            txtAdjustPausesToDeviceAtImport.Checked = MiscPlugin.Plugin.AdjustPausesToDeviceAtImport;
            txtAdjustPausesToDeviceEditMenu.Checked = MiscPlugin.Plugin.AdjustPausesToDeviceEditMenu;
            txtCorrectGpsFromDistanceAtImport.Checked = MiscPlugin.Plugin.CorrectGpsFromDistanceAtImport;
            txtCorrectGpsFromDistanceEditMenu.Checked = MiscPlugin.Plugin.CorrectGpsFromDistanceEditMenu;
            txtDetectRestLapsAtImport.Checked = MiscPlugin.Plugin.DetectRestLapsAtImport;
            txtDetectRestLapsEditMenu.Checked = MiscPlugin.Plugin.DetectRestLapsEditMenu;
            txtElevationToGPSAtImport.Checked = MiscPlugin.Plugin.ElevationToGPSAtImport;
            txtElevationToGPSEditMenu.Checked = MiscPlugin.Plugin.ElevationToGPSEditMenu;
            txtExtendGPSAtImport.Checked = MiscPlugin.Plugin.ExtendGPSAtImport;
            txtExtendGPSEditMenu.Checked = MiscPlugin.Plugin.ExtendGPSEditMenu;
            txtFixHRAtImport.Checked = MiscPlugin.Plugin.FixHRAtImport;
            txtFixHREditMenu.Checked = MiscPlugin.Plugin.FixHREditMenu;
            txtInsertPausesAtImport.Checked = MiscPlugin.Plugin.InsertPausesAtImport;
            txtInsertPausesEditMenu.Checked = MiscPlugin.Plugin.InsertPausesEditMenu;
            numericInsertPausesMinSeconds.Value = MiscPlugin.Plugin.InsertPausesWhenGPSdifferMinSeconds;
            txtPrepareForActivitiesViewerAtImport.Checked = MiscPlugin.Plugin.PrepareForActivitiesViewerAtImport;
            txtPrepareForActivitiesViewerEditMenu.Checked = MiscPlugin.Plugin.PrepareForActivitiesViewerEditMenu;
            txtRemoveIdenticalGPSAtImport.Checked = MiscPlugin.Plugin.RemoveIdenticalGPSAtImport;
            txtRemoveIdenticalGPSEditMenu.Checked = MiscPlugin.Plugin.RemoveIdenticalGPSEditMenu;
            txtSetTimeGPSAtImport.Checked = MiscPlugin.Plugin.SetTimeGPSAtImport;
            txtSetTimeGPSEditMenu.Checked = MiscPlugin.Plugin.SetTimeGPSEditMenu;
            txtUseEnteredDataAtImport.Checked = MiscPlugin.Plugin.UseEnteredDataAtImport;
            txtUseEnteredDataEditMenu.Checked = MiscPlugin.Plugin.UseEnteredDataEditMenu;
        }

        ///
        /// Theme changed 
        public void ThemeChanged(ITheme visualTheme)
        {
            labelExtendGPS.ForeColor = visualTheme.ControlText;
            labelInsertPauses.ForeColor = visualTheme.ControlText;
            //txtActivateAtImport.ThemeChanged(visualTheme);
        }
        /// <summary>
        /// UI culture changed
        /// </summary>
        /// <param name="culture"></param>
        public void UICultureChanged(CultureInfo culture)
        {
            labelActivateAtImport.Text = Properties.Resources.UI_Settings_PageControl_labelActivateAtImport_Text;
            labelEditMenuItem.Text = Properties.Resources.UI_Settings_PageControl_labelEditMenuItem_Text;

            labelAdjustPausesToDevice.Text = Properties.Resources.UI_Settings_PageControl_labelAdjustPausesToDevice_Text;
            labelAdjustPausesToDeviceInformative.Text = Properties.Resources.UI_Settings_PageControl_labelAdjustPausesToDeviceInformative_Text;
            labelCorrectGpsFromDistance.Text = Properties.Resources.Edit_CorrectGPSFromDistance_Text;
            labelCorrectGpsFromDistanceInformative.Text = Properties.Resources.UI_Settings_PageControl_labelCorrectGPSFromDistanceInformative_Text;
            labelDetectRestLaps.Text = Properties.Resources.UI_Settings_PageControl_labelDetectRestLaps_Text;
            labelDetectRestLapsInformative.Text = Properties.Resources.UI_Settings_PageControl_labelDetectRestLapsInformative_Text;
            labelDetectRestLaps.Text = Properties.Resources.UI_Settings_PageControl_labelDetectRestLaps_Text;
            labelDetectRestLapsInformative.Text = Properties.Resources.UI_Settings_PageControl_labelDetectRestLapsInformative_Text;
            labelElevationToGPS.Text = Properties.Resources.UI_Settings_PageControl_labelElevationToGPS_Text;
            labelElevationToGPSInformative.Text = Properties.Resources.UI_Settings_PageControl_labelElevationToGPSInformative_Text;
            labelExtendGPS.Text = Properties.Resources.UI_Settings_PageControl_labelExtendGPS_Text;
            labelExtendGPSInformative.Text = Properties.Resources.UI_Settings_PageControl_labelExtendGPSInformative_Text;
            labelFixHR.Text = Properties.Resources.UI_Settings_PageControl_labelFixHR_Text;
            labelFixHRInformative.Text = Properties.Resources.UI_Settings_PageControl_labelFixHRInformative_Text;
            labelInsertPauses.Text = Properties.Resources.UI_Settings_PageControl_labelInsertPauses_Text;
            labelInsertPausesWhenGPSdifferMinSeconds.Text = Properties.Resources.UI_Settings_PageControl_labelInsertPausesWhenGPSdifferMinSeconds_Text;
            labelInsertPausesInformative.Text = Properties.Resources.UI_Settings_PageControl_labelInsertPausesInformative_Text;
            labelPrepareForActivitiesViewer.Text = Properties.Resources.UI_Settings_PageControl_labelPrepareForActivitiesViewer_Text;
            labelPrepareForActivitiesViewerInformative.Text = Properties.Resources.UI_Settings_PageControl_labelPrepareForActivitiesViewerInformative_Text;
            labelRemoveIdenticalGPS.Text = Properties.Resources.UI_Settings_PageControl_labelRemoveIdenticalGPS_Text;
            labelRemoveIdenticalGPSInformative.Text = Properties.Resources.UI_Settings_PageControl_labelRemoveIdenticalGPSInformative_Text;
            labelSetTimeGPS.Text = Properties.Resources.UI_Settings_PageControl_labelSetTimeGPS_Text;
            labelSetTimeGPSInformative.Text = Properties.Resources.UI_Settings_PageControl_labelSetTimeGPSInformative_Text;
            labelUseEnteredData.Text = Properties.Resources.UI_Settings_PageControl_labelUseEnteredData_Text;
            labelUseEnteredDataInformative.Text = Properties.Resources.UI_Settings_PageControl_labelUseEnteredDataInformative_Text;

            linkInformativeUrl.Text = Properties.Resources.UI_Settings_PageControl_linkInformativeUrl_Text;
            // Data contains localized text also, refresh.
            RefreshPage();
        }
        #endregion

        private void txtExtendGPSAtImport_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.ExtendGPSAtImport = txtExtendGPSAtImport.Checked;
        }
        private void txtExtendGPSEditMenu_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.ExtendGPSEditMenu = txtExtendGPSEditMenu.Checked;
        }

        private void txtInsertPausesAtImport_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.InsertPausesAtImport = txtInsertPausesAtImport.Checked;
        }
        private void txtInsertPausesEditMenu_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.InsertPausesEditMenu = txtInsertPausesEditMenu.Checked;
        }
        private void numericInsertPauses_ValueChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.InsertPausesWhenGPSdifferMinSeconds = (int)numericInsertPausesMinSeconds.Value;
        }

        private void txtAdjustPausesToDeviceAtImport_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.AdjustPausesToDeviceAtImport = txtAdjustPausesToDeviceAtImport.Checked;
        }
        private void txtAdjustPausesToDeviceEditMenu_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.AdjustPausesToDeviceEditMenu = txtAdjustPausesToDeviceEditMenu.Checked;
        }
        private void txtSetTimeGPSAtImport_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.SetTimeGPSAtImport = txtSetTimeGPSAtImport.Checked;
        }
        private void txtSetTimeGPSEditMenu_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.SetTimeGPSEditMenu = txtSetTimeGPSEditMenu.Checked;
        }
        private void txtDetectRestLapsAtImport_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.DetectRestLapsAtImport = txtDetectRestLapsAtImport.Checked;
        }
        private void txtDetectRestLapsEditMenu_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.DetectRestLapsEditMenu = txtDetectRestLapsEditMenu.Checked;
        }
        private void txtElevationToGPSAtImport_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.ElevationToGPSAtImport = txtElevationToGPSAtImport.Checked;
        }
        private void txtElevationToGPSEditMenu_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.ElevationToGPSEditMenu = txtElevationToGPSEditMenu.Checked;
        }

        private void txtRemoveIdenticalGPSAtImport_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.RemoveIdenticalGPSAtImport = txtRemoveIdenticalGPSAtImport.Checked;
        }
        private void txtRemoveIdenticalGPSEditMenu_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.RemoveIdenticalGPSEditMenu = txtRemoveIdenticalGPSEditMenu.Checked;
        }

        private void linkInformativeUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(Properties.Resources.UI_Settings_PageControl_linkInformativeUrl_Url);
            linkInformativeUrl.LinkVisited = true;
        }

        private void txtFixHRAtImport_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.FixHRAtImport = this.txtFixHRAtImport.Checked;
        }

        private void txtxFixHREditMenu_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.FixHREditMenu = this.txtFixHREditMenu.Checked;
        }

        private void txtPrepareForActivitiesViewerAtImport_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.PrepareForActivitiesViewerAtImport = this.txtPrepareForActivitiesViewerAtImport.Checked;
        }

        private void txtPrepareForActivitiesViewerEditMenu_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.PrepareForActivitiesViewerEditMenu = this.txtPrepareForActivitiesViewerEditMenu.Checked;
        }

        private void txtUseEnteredDataAtImport_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.UseEnteredDataAtImport = this.txtUseEnteredDataAtImport.Checked;
        }

        private void txtUseEnteredDataEditMenu_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.UseEnteredDataEditMenu = this.txtUseEnteredDataEditMenu.Checked;
        }

        private void txtCorrectGpsFromDistanceAtImport_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.CorrectGpsFromDistanceAtImport = this.txtCorrectGpsFromDistanceAtImport.Checked;
        }

        private void txtCorrectGpsFromDistanceEditMenu_CheckedChanged(object sender, EventArgs e)
        {
            MiscPlugin.Plugin.CorrectGpsFromDistanceEditMenu = this.txtCorrectGpsFromDistanceEditMenu.Checked;
        }
     }
}
