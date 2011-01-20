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
            txtExtendGPSAtImport.Checked = MiscPlugin.Plugin.ExtendGPSAtImport;
            txtExtendGPSEditMenu.Checked = MiscPlugin.Plugin.ExtendGPSEditMenu;
            txtInsertPausesAtImport.Checked = MiscPlugin.Plugin.InsertPausesAtImport;
            txtInsertPausesEditMenu.Checked = MiscPlugin.Plugin.InsertPausesEditMenu;
            numericInsertPauses.Value = MiscPlugin.Plugin.InsertPausesWhenGPSdifferMinSeconds;
            txtAdjustPausesToDeviceAtImport.Checked = MiscPlugin.Plugin.AdjustPausesToDeviceAtImport;
            txtAdjustPausesToDeviceEditMenu.Checked = MiscPlugin.Plugin.AdjustPausesToDeviceEditMenu;
            txtSetTimeGPSAtImport.Checked = MiscPlugin.Plugin.SetTimeGPSAtImport;
            txtSetTimeGPSEditMenu.Checked = MiscPlugin.Plugin.SetTimeGPSEditMenu;
            txtDetectRestLapsAtImport.Checked = MiscPlugin.Plugin.DetectRestLapsAtImport;
            txtDetectRestLapsEditMenu.Checked = MiscPlugin.Plugin.DetectRestLapsEditMenu;
            txtElevationToGPSAtImport.Checked = MiscPlugin.Plugin.ElevationToGPSAtImport;
            txtElevationToGPSEditMenu.Checked = MiscPlugin.Plugin.ElevationToGPSEditMenu;
            txtRemoveIdenticalGPSAtImport.Checked = MiscPlugin.Plugin.RemoveIdenticalGPSAtImport;
            txtRemoveIdenticalGPSEditMenu.Checked = MiscPlugin.Plugin.RemoveIdenticalGPSEditMenu;
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

            labelExtendGPS.Text = Properties.Resources.UI_Settings_PageControl_labelExtendGPS_Text;
            labelExtendGPSInformative.Text = Properties.Resources.UI_Settings_PageControl_labelExtendGPSInformative_Text;
            labelInsertPauses.Text = Properties.Resources.UI_Settings_PageControl_labelInsertPauses_Text;
            labelInsertPausesWhenGPSdifferMinSeconds.Text = Properties.Resources.UI_Settings_PageControl_labelInsertPausesWhenGPSdifferMinSeconds_Text;
            labelInsertPausesInformative.Text = Properties.Resources.UI_Settings_PageControl_labelInsertPausesInformative_Text;
            labelAdjustPausesToDevice.Text = Properties.Resources.UI_Settings_PageControl_labelAdjustPausesToDevice_Text;
            labelAdjustPausesToDeviceInformative.Text = Properties.Resources.UI_Settings_PageControl_labelAdjustPausesToDeviceInformative_Text;
            labelSetTimeGPS.Text = Properties.Resources.UI_Settings_PageControl_labelSetTimeGPS_Text;
            labelSetTimeGPSInformative.Text = Properties.Resources.UI_Settings_PageControl_labelSetTimeGPSInformative_Text;
            labelDetectRestLaps.Text = Properties.Resources.UI_Settings_PageControl_labelDetectRestLaps_Text;
            labelDetectRestLapsInformative.Text = Properties.Resources.UI_Settings_PageControl_labelDetectRestLapsInformative_Text;
            labelElevationToGPS.Text = Properties.Resources.UI_Settings_PageControl_labelElevationToGPS_Text;
            labelElevationToGPSInformative.Text = Properties.Resources.UI_Settings_PageControl_labelElevationToGPSInformative_Text;
            labelRemoveIdenticalGPS.Text = Properties.Resources.UI_Settings_PageControl_labelRemoveIdenticalGPS_Text;
            labelRemoveIdenticalGPSInformative.Text = Properties.Resources.UI_Settings_PageControl_labelRemoveIdenticalGPSInformative_Text;
       
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
            MiscPlugin.Plugin.InsertPausesWhenGPSdifferMinSeconds = (int)numericInsertPauses.Value;
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

     }
}
