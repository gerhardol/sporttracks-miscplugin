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

using IBikeFixerPlugin.Edit;

namespace IBikeFixerPlugin.UI.Settings
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
            txtActivateAtImportBool1.Checked = Resources.Plugin.ActivateAtImportBool1;
        }

        public void ThemeChanged(ITheme visualTheme)
        {
            labelActivateAtImportBool1.ForeColor = visualTheme.ControlText;
            //txtActivateAtImport.ThemeChanged(visualTheme);
        }

        public void UICultureChanged(CultureInfo culture)
        {
            labelActivateAtImportBool1.Text = Resources.Resources.UI_Settings_PageControl_labelActivateAtImportBool1_Text;
            labelInformative.Text = Resources.Resources.UI_Settings_PageControl_labelInformative_Text;
            linkInformativeUrl.Text = Resources.Resources.UI_Settings_PageControl_linkInformativeUrl_Text;
            // Data contains localized text also, refresh.
            RefreshPage();
        }
        #endregion

        private void txtActivateAtImportBool1_CheckedChanged(object sender, EventArgs e)
        {
            Resources.Plugin.ActivateAtImportBool1 = txtActivateAtImportBool1.Checked;
            RefreshPage();
        }

        private void linkInformativeUrl_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("IExplore", Resources.Resources.UI_Settings_PageControl_linkInformativeUrl_Url);
            linkInformativeUrl.LinkVisited = true;
        }

    }
}
