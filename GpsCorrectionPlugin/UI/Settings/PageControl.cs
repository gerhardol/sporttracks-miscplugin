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

using GpsCorrectionPlugin.Edit;

namespace GpsCorrectionPlugin.UI.Settings
{
    public partial class PageControl : UserControl
    {
        public PageControl()
        {
            InitializeComponent();
            RefreshPage();
        }
        #region Public methods
        public void RefreshPage()
        {
            txtCorrectGpsFromDistanceAtImport.Checked = GpsCorrectionPlugin.Plugin.CorrectGpsFromDistanceAtImport;
            txtCorrectGpsFromDistanceEditMenu.Checked = GpsCorrectionPlugin.Plugin.CorrectGpsFromDistanceEditMenu;
        }

        public void ThemeChanged(ITheme visualTheme)
        {
            labelCorrectGpsFromDistance.ForeColor = visualTheme.ControlText;
            //txtActivateAtImport.ThemeChanged(visualTheme);
        }

        public void UICultureChanged(CultureInfo culture)
        {
            labelActivateAtImport.Text = Properties.Resources.UI_Settings_PageControl_labelActivateAtImport_Text;
            labelEditMenuItem.Text = Properties.Resources.UI_Settings_PageControl_labelEditMenuItem_Text;
            
            labelCorrectGpsFromDistance.Text = Properties.Resources.UI_Settings_PageControl_labelCorrectGPSFromDistance_Text;
            labelCorrectGpsFromDistanceInformative.Text = Properties.Resources.UI_Settings_PageControl_labelCorrectGPSFromDistanceInformative_Text;
            
            linkInformativeUrl.Text = Properties.Resources.UI_Settings_PageControl_linkInformativeUrl_Text;
            // Data contains localized text also, refresh.
            RefreshPage();
        }
        #endregion

        private void txtCorrectGpsFromDistanceAtImport_CheckedChanged(object sender, EventArgs e)
        {
            GpsCorrectionPlugin.Plugin.CorrectGpsFromDistanceAtImport = txtCorrectGpsFromDistanceAtImport.Checked;
        }

        private void linkInformativeUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore", Properties.Resources.UI_Settings_PageControl_linkInformativeUrl_Url);
            linkInformativeUrl.LinkVisited = true;
        }

        private void txtCorrectGpsFromDistanceEditMenu_CheckedChanged(object sender, EventArgs e)
        {
            GpsCorrectionPlugin.Plugin.CorrectGpsFromDistanceEditMenu = txtCorrectGpsFromDistanceEditMenu.Checked;
        }

    }
}
