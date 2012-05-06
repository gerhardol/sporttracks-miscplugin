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

using System.Windows.Forms;

namespace MiscPlugin.UI.Settings
{
    partial class MiscPluginPageControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MiscPluginPageControl));
            this.labelExtendGPS = new System.Windows.Forms.Label();
            this.txtExtendGPSAtImport = new System.Windows.Forms.CheckBox();
            this.linkInformativeUrl = new System.Windows.Forms.LinkLabel();
            this.labelExtendGPSInformative = new System.Windows.Forms.Label();
            this.txtInsertPausesAtImport = new System.Windows.Forms.CheckBox();
            this.labelInsertPauses = new System.Windows.Forms.Label();
            this.labelInsertPausesInformative = new System.Windows.Forms.Label();
            this.numericInsertPausesMinSeconds = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelCorrectGpsFromDistanceInformative = new System.Windows.Forms.Label();
            this.labelUseEnteredDataInformative = new System.Windows.Forms.Label();
            this.labelPrepareForActivitiesViewerInformative = new System.Windows.Forms.Label();
            this.txtPrepareForActivitiesViewerEditMenu = new System.Windows.Forms.CheckBox();
            this.txtPrepareForActivitiesViewerAtImport = new System.Windows.Forms.CheckBox();
            this.labelPrepareForActivitiesViewer = new System.Windows.Forms.Label();
            this.labelFixHRInformative = new System.Windows.Forms.Label();
            this.labelActivateAtImport = new System.Windows.Forms.Label();
            this.labelEditMenuItem = new System.Windows.Forms.Label();
            this.txtExtendGPSEditMenu = new System.Windows.Forms.CheckBox();
            this.txtInsertPausesEditMenu = new System.Windows.Forms.CheckBox();
            this.labelSetTimeGPS = new System.Windows.Forms.Label();
            this.txtSetTimeGPSEditMenu = new System.Windows.Forms.CheckBox();
            this.labelSetTimeGPSInformative = new System.Windows.Forms.Label();
            this.labelInsertPausesWhenGPSdifferMinSeconds = new System.Windows.Forms.Label();
            this.txtSetTimeGPSAtImport = new System.Windows.Forms.CheckBox();
            this.labelRemoveIdenticalGPS = new System.Windows.Forms.Label();
            this.txtRemoveIdenticalGPSAtImport = new System.Windows.Forms.CheckBox();
            this.txtRemoveIdenticalGPSEditMenu = new System.Windows.Forms.CheckBox();
            this.labelDetectRestLaps = new System.Windows.Forms.Label();
            this.labelAdjustPausesToDevice = new System.Windows.Forms.Label();
            this.txtDetectRestLapsAtImport = new System.Windows.Forms.CheckBox();
            this.txtDetectRestLapsEditMenu = new System.Windows.Forms.CheckBox();
            this.labelDetectRestLapsInformative = new System.Windows.Forms.Label();
            this.labelAdjustPausesToDeviceInformative = new System.Windows.Forms.Label();
            this.txtAdjustPausesToDeviceAtImport = new System.Windows.Forms.CheckBox();
            this.txtAdjustPausesToDeviceEditMenu = new System.Windows.Forms.CheckBox();
            this.labelRemoveIdenticalGPSInformative = new System.Windows.Forms.Label();
            this.labelElevationToGPS = new System.Windows.Forms.Label();
            this.txtElevationToGPSAtImport = new System.Windows.Forms.CheckBox();
            this.txtElevationToGPSEditMenu = new System.Windows.Forms.CheckBox();
            this.labelElevationToGPSInformative = new System.Windows.Forms.Label();
            this.labelFixHR = new System.Windows.Forms.Label();
            this.txtFixHRAtImport = new System.Windows.Forms.CheckBox();
            this.txtFixHREditMenu = new System.Windows.Forms.CheckBox();
            this.txtUseEnteredDataEditMenu = new System.Windows.Forms.CheckBox();
            this.txtUseEnteredDataAtImport = new System.Windows.Forms.CheckBox();
            this.labelUseEnteredData = new System.Windows.Forms.Label();
            this.txtCorrectGpsFromDistanceEditMenu = new System.Windows.Forms.CheckBox();
            this.txtCorrectGpsFromDistanceAtImport = new System.Windows.Forms.CheckBox();
            this.labelCorrectGpsFromDistance = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericInsertPausesMinSeconds)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelExtendGPS
            // 
            resources.ApplyResources(this.labelExtendGPS, "labelExtendGPS");
            this.labelExtendGPS.Name = "labelExtendGPS";
            // 
            // txtExtendGPSAtImport
            // 
            resources.ApplyResources(this.txtExtendGPSAtImport, "txtExtendGPSAtImport");
            this.txtExtendGPSAtImport.Name = "txtExtendGPSAtImport";
            this.txtExtendGPSAtImport.UseVisualStyleBackColor = false;
            this.txtExtendGPSAtImport.CheckedChanged += new System.EventHandler(this.txtExtendGPSAtImport_CheckedChanged);
            // 
            // linkInformativeUrl
            // 
            resources.ApplyResources(this.linkInformativeUrl, "linkInformativeUrl");
            this.tableLayoutPanel1.SetColumnSpan(this.linkInformativeUrl, 3);
            this.linkInformativeUrl.Name = "linkInformativeUrl";
            this.linkInformativeUrl.TabStop = true;
            this.linkInformativeUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkInformativeUrl_LinkClicked);
            // 
            // labelExtendGPSInformative
            // 
            resources.ApplyResources(this.labelExtendGPSInformative, "labelExtendGPSInformative");
            this.labelExtendGPSInformative.Name = "labelExtendGPSInformative";
            // 
            // txtInsertPausesAtImport
            // 
            resources.ApplyResources(this.txtInsertPausesAtImport, "txtInsertPausesAtImport");
            this.txtInsertPausesAtImport.Name = "txtInsertPausesAtImport";
            this.txtInsertPausesAtImport.UseVisualStyleBackColor = false;
            this.txtInsertPausesAtImport.CheckedChanged += new System.EventHandler(this.txtInsertPausesAtImport_CheckedChanged);
            // 
            // labelInsertPauses
            // 
            resources.ApplyResources(this.labelInsertPauses, "labelInsertPauses");
            this.labelInsertPauses.Name = "labelInsertPauses";
            // 
            // labelInsertPausesInformative
            // 
            resources.ApplyResources(this.labelInsertPausesInformative, "labelInsertPausesInformative");
            this.labelInsertPausesInformative.Name = "labelInsertPausesInformative";
            // 
            // numericInsertPausesMinSeconds
            // 
            resources.ApplyResources(this.numericInsertPausesMinSeconds, "numericInsertPausesMinSeconds");
            this.numericInsertPausesMinSeconds.Maximum = new decimal(new int[] {
            72000,
            0,
            0,
            0});
            this.numericInsertPausesMinSeconds.Name = "numericInsertPausesMinSeconds";
            this.numericInsertPausesMinSeconds.Tag = "Min GPS gap";
            this.numericInsertPausesMinSeconds.ValueChanged += new System.EventHandler(this.numericInsertPauses_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AllowDrop = true;
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
            this.tableLayoutPanel1.Controls.Add(this.labelCorrectGpsFromDistanceInformative, 3, 12);
            this.tableLayoutPanel1.Controls.Add(this.linkInformativeUrl, 0, 13);
            this.tableLayoutPanel1.Controls.Add(this.labelUseEnteredDataInformative, 3, 11);
            this.tableLayoutPanel1.Controls.Add(this.labelPrepareForActivitiesViewerInformative, 3, 10);
            this.tableLayoutPanel1.Controls.Add(this.txtPrepareForActivitiesViewerEditMenu, 2, 10);
            this.tableLayoutPanel1.Controls.Add(this.txtPrepareForActivitiesViewerAtImport, 1, 10);
            this.tableLayoutPanel1.Controls.Add(this.labelPrepareForActivitiesViewer, 0, 10);
            this.tableLayoutPanel1.Controls.Add(this.labelFixHRInformative, 3, 9);
            this.tableLayoutPanel1.Controls.Add(this.labelExtendGPSInformative, 3, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtExtendGPSAtImport, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtInsertPausesAtImport, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelActivateAtImport, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelEditMenuItem, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.labelInsertPauses, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelExtendGPS, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtExtendGPSEditMenu, 2, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtInsertPausesEditMenu, 2, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelSetTimeGPS, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtSetTimeGPSEditMenu, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelSetTimeGPSInformative, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelInsertPausesWhenGPSdifferMinSeconds, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericInsertPausesMinSeconds, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtSetTimeGPSAtImport, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.labelInsertPausesInformative, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelRemoveIdenticalGPS, 0, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtRemoveIdenticalGPSAtImport, 1, 8);
            this.tableLayoutPanel1.Controls.Add(this.txtRemoveIdenticalGPSEditMenu, 2, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelDetectRestLaps, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelAdjustPausesToDevice, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtDetectRestLapsAtImport, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtDetectRestLapsEditMenu, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelDetectRestLapsInformative, 3, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelAdjustPausesToDeviceInformative, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtAdjustPausesToDeviceAtImport, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtAdjustPausesToDeviceEditMenu, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelRemoveIdenticalGPSInformative, 3, 8);
            this.tableLayoutPanel1.Controls.Add(this.labelElevationToGPS, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtElevationToGPSAtImport, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtElevationToGPSEditMenu, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelElevationToGPSInformative, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelFixHR, 0, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtFixHRAtImport, 1, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtFixHREditMenu, 2, 9);
            this.tableLayoutPanel1.Controls.Add(this.txtUseEnteredDataEditMenu, 2, 11);
            this.tableLayoutPanel1.Controls.Add(this.txtUseEnteredDataAtImport, 1, 11);
            this.tableLayoutPanel1.Controls.Add(this.labelUseEnteredData, 0, 11);
            this.tableLayoutPanel1.Controls.Add(this.txtCorrectGpsFromDistanceEditMenu, 2, 12);
            this.tableLayoutPanel1.Controls.Add(this.txtCorrectGpsFromDistanceAtImport, 1, 12);
            this.tableLayoutPanel1.Controls.Add(this.labelCorrectGpsFromDistance, 0, 12);
            this.tableLayoutPanel1.MinimumSize = new System.Drawing.Size(560, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            // 
            // labelCorrectGpsFromDistanceInformative
            // 
            resources.ApplyResources(this.labelCorrectGpsFromDistanceInformative, "labelCorrectGpsFromDistanceInformative");
            this.labelCorrectGpsFromDistanceInformative.Name = "labelCorrectGpsFromDistanceInformative";
            // 
            // labelUseEnteredDataInformative
            // 
            resources.ApplyResources(this.labelUseEnteredDataInformative, "labelUseEnteredDataInformative");
            this.labelUseEnteredDataInformative.Name = "labelUseEnteredDataInformative";
            // 
            // labelPrepareForActivitiesViewerInformative
            // 
            resources.ApplyResources(this.labelPrepareForActivitiesViewerInformative, "labelPrepareForActivitiesViewerInformative");
            this.labelPrepareForActivitiesViewerInformative.Name = "labelPrepareForActivitiesViewerInformative";
            // 
            // txtPrepareForActivitiesViewerEditMenu
            // 
            resources.ApplyResources(this.txtPrepareForActivitiesViewerEditMenu, "txtPrepareForActivitiesViewerEditMenu");
            this.txtPrepareForActivitiesViewerEditMenu.Name = "txtPrepareForActivitiesViewerEditMenu";
            this.txtPrepareForActivitiesViewerEditMenu.UseVisualStyleBackColor = false;
            this.txtPrepareForActivitiesViewerEditMenu.CheckedChanged += new System.EventHandler(this.txtPrepareForActivitiesViewerEditMenu_CheckedChanged);
            // 
            // txtPrepareForActivitiesViewerAtImport
            // 
            resources.ApplyResources(this.txtPrepareForActivitiesViewerAtImport, "txtPrepareForActivitiesViewerAtImport");
            this.txtPrepareForActivitiesViewerAtImport.Name = "txtPrepareForActivitiesViewerAtImport";
            this.txtPrepareForActivitiesViewerAtImport.UseVisualStyleBackColor = false;
            this.txtPrepareForActivitiesViewerAtImport.CheckedChanged += new System.EventHandler(this.txtPrepareForActivitiesViewerAtImport_CheckedChanged);
            // 
            // labelPrepareForActivitiesViewer
            // 
            resources.ApplyResources(this.labelPrepareForActivitiesViewer, "labelPrepareForActivitiesViewer");
            this.labelPrepareForActivitiesViewer.Name = "labelPrepareForActivitiesViewer";
            // 
            // labelFixHRInformative
            // 
            resources.ApplyResources(this.labelFixHRInformative, "labelFixHRInformative");
            this.labelFixHRInformative.Name = "labelFixHRInformative";
            // 
            // labelActivateAtImport
            // 
            resources.ApplyResources(this.labelActivateAtImport, "labelActivateAtImport");
            this.labelActivateAtImport.Name = "labelActivateAtImport";
            // 
            // labelEditMenuItem
            // 
            resources.ApplyResources(this.labelEditMenuItem, "labelEditMenuItem");
            this.labelEditMenuItem.Name = "labelEditMenuItem";
            // 
            // txtExtendGPSEditMenu
            // 
            resources.ApplyResources(this.txtExtendGPSEditMenu, "txtExtendGPSEditMenu");
            this.txtExtendGPSEditMenu.Name = "txtExtendGPSEditMenu";
            this.txtExtendGPSEditMenu.UseVisualStyleBackColor = false;
            this.txtExtendGPSEditMenu.CheckedChanged += new System.EventHandler(this.txtExtendGPSEditMenu_CheckedChanged);
            // 
            // txtInsertPausesEditMenu
            // 
            resources.ApplyResources(this.txtInsertPausesEditMenu, "txtInsertPausesEditMenu");
            this.txtInsertPausesEditMenu.Name = "txtInsertPausesEditMenu";
            this.txtInsertPausesEditMenu.UseVisualStyleBackColor = false;
            this.txtInsertPausesEditMenu.CheckedChanged += new System.EventHandler(this.txtInsertPausesEditMenu_CheckedChanged);
            // 
            // labelSetTimeGPS
            // 
            resources.ApplyResources(this.labelSetTimeGPS, "labelSetTimeGPS");
            this.labelSetTimeGPS.Name = "labelSetTimeGPS";
            // 
            // txtSetTimeGPSEditMenu
            // 
            resources.ApplyResources(this.txtSetTimeGPSEditMenu, "txtSetTimeGPSEditMenu");
            this.txtSetTimeGPSEditMenu.Name = "txtSetTimeGPSEditMenu";
            this.txtSetTimeGPSEditMenu.UseVisualStyleBackColor = false;
            this.txtSetTimeGPSEditMenu.CheckedChanged += new System.EventHandler(this.txtSetTimeGPSEditMenu_CheckedChanged);
            // 
            // labelSetTimeGPSInformative
            // 
            resources.ApplyResources(this.labelSetTimeGPSInformative, "labelSetTimeGPSInformative");
            this.labelSetTimeGPSInformative.Name = "labelSetTimeGPSInformative";
            // 
            // labelInsertPausesWhenGPSdifferMinSeconds
            // 
            resources.ApplyResources(this.labelInsertPausesWhenGPSdifferMinSeconds, "labelInsertPausesWhenGPSdifferMinSeconds");
            this.labelInsertPausesWhenGPSdifferMinSeconds.Name = "labelInsertPausesWhenGPSdifferMinSeconds";
            // 
            // txtSetTimeGPSAtImport
            // 
            resources.ApplyResources(this.txtSetTimeGPSAtImport, "txtSetTimeGPSAtImport");
            this.txtSetTimeGPSAtImport.Name = "txtSetTimeGPSAtImport";
            this.txtSetTimeGPSAtImport.UseVisualStyleBackColor = true;
            this.txtSetTimeGPSAtImport.CheckedChanged += new System.EventHandler(this.txtSetTimeGPSAtImport_CheckedChanged);
            // 
            // labelRemoveIdenticalGPS
            // 
            resources.ApplyResources(this.labelRemoveIdenticalGPS, "labelRemoveIdenticalGPS");
            this.labelRemoveIdenticalGPS.Name = "labelRemoveIdenticalGPS";
            // 
            // txtRemoveIdenticalGPSAtImport
            // 
            resources.ApplyResources(this.txtRemoveIdenticalGPSAtImport, "txtRemoveIdenticalGPSAtImport");
            this.txtRemoveIdenticalGPSAtImport.Name = "txtRemoveIdenticalGPSAtImport";
            this.txtRemoveIdenticalGPSAtImport.UseVisualStyleBackColor = false;
            this.txtRemoveIdenticalGPSAtImport.CheckedChanged += new System.EventHandler(this.txtRemoveIdenticalGPSAtImport_CheckedChanged);
            // 
            // txtRemoveIdenticalGPSEditMenu
            // 
            resources.ApplyResources(this.txtRemoveIdenticalGPSEditMenu, "txtRemoveIdenticalGPSEditMenu");
            this.txtRemoveIdenticalGPSEditMenu.Name = "txtRemoveIdenticalGPSEditMenu";
            this.txtRemoveIdenticalGPSEditMenu.UseVisualStyleBackColor = false;
            this.txtRemoveIdenticalGPSEditMenu.CheckedChanged += new System.EventHandler(this.txtRemoveIdenticalGPSEditMenu_CheckedChanged);
            // 
            // labelDetectRestLaps
            // 
            resources.ApplyResources(this.labelDetectRestLaps, "labelDetectRestLaps");
            this.labelDetectRestLaps.Name = "labelDetectRestLaps";
            // 
            // labelAdjustPausesToDevice
            // 
            resources.ApplyResources(this.labelAdjustPausesToDevice, "labelAdjustPausesToDevice");
            this.labelAdjustPausesToDevice.Name = "labelAdjustPausesToDevice";
            // 
            // txtDetectRestLapsAtImport
            // 
            resources.ApplyResources(this.txtDetectRestLapsAtImport, "txtDetectRestLapsAtImport");
            this.txtDetectRestLapsAtImport.Name = "txtDetectRestLapsAtImport";
            this.txtDetectRestLapsAtImport.UseVisualStyleBackColor = false;
            this.txtDetectRestLapsAtImport.CheckedChanged += new System.EventHandler(this.txtDetectRestLapsAtImport_CheckedChanged);
            // 
            // txtDetectRestLapsEditMenu
            // 
            resources.ApplyResources(this.txtDetectRestLapsEditMenu, "txtDetectRestLapsEditMenu");
            this.txtDetectRestLapsEditMenu.Name = "txtDetectRestLapsEditMenu";
            this.txtDetectRestLapsEditMenu.UseVisualStyleBackColor = true;
            this.txtDetectRestLapsEditMenu.CheckedChanged += new System.EventHandler(this.txtDetectRestLapsEditMenu_CheckedChanged);
            // 
            // labelDetectRestLapsInformative
            // 
            resources.ApplyResources(this.labelDetectRestLapsInformative, "labelDetectRestLapsInformative");
            this.labelDetectRestLapsInformative.Name = "labelDetectRestLapsInformative";
            // 
            // labelAdjustPausesToDeviceInformative
            // 
            resources.ApplyResources(this.labelAdjustPausesToDeviceInformative, "labelAdjustPausesToDeviceInformative");
            this.labelAdjustPausesToDeviceInformative.Name = "labelAdjustPausesToDeviceInformative";
            // 
            // txtAdjustPausesToDeviceAtImport
            // 
            resources.ApplyResources(this.txtAdjustPausesToDeviceAtImport, "txtAdjustPausesToDeviceAtImport");
            this.txtAdjustPausesToDeviceAtImport.Name = "txtAdjustPausesToDeviceAtImport";
            this.txtAdjustPausesToDeviceAtImport.UseVisualStyleBackColor = false;
            this.txtAdjustPausesToDeviceAtImport.CheckedChanged += new System.EventHandler(this.txtAdjustPausesToDeviceAtImport_CheckedChanged);
            // 
            // txtAdjustPausesToDeviceEditMenu
            // 
            resources.ApplyResources(this.txtAdjustPausesToDeviceEditMenu, "txtAdjustPausesToDeviceEditMenu");
            this.txtAdjustPausesToDeviceEditMenu.Name = "txtAdjustPausesToDeviceEditMenu";
            this.txtAdjustPausesToDeviceEditMenu.UseVisualStyleBackColor = false;
            this.txtAdjustPausesToDeviceEditMenu.CheckedChanged += new System.EventHandler(this.txtAdjustPausesToDeviceEditMenu_CheckedChanged);
            // 
            // labelRemoveIdenticalGPSInformative
            // 
            resources.ApplyResources(this.labelRemoveIdenticalGPSInformative, "labelRemoveIdenticalGPSInformative");
            this.labelRemoveIdenticalGPSInformative.Name = "labelRemoveIdenticalGPSInformative";
            // 
            // labelElevationToGPS
            // 
            resources.ApplyResources(this.labelElevationToGPS, "labelElevationToGPS");
            this.labelElevationToGPS.Name = "labelElevationToGPS";
            // 
            // txtElevationToGPSAtImport
            // 
            resources.ApplyResources(this.txtElevationToGPSAtImport, "txtElevationToGPSAtImport");
            this.txtElevationToGPSAtImport.Name = "txtElevationToGPSAtImport";
            this.txtElevationToGPSAtImport.UseVisualStyleBackColor = true;
            this.txtElevationToGPSAtImport.CheckedChanged += new System.EventHandler(this.txtElevationToGPSAtImport_CheckedChanged);
            // 
            // txtElevationToGPSEditMenu
            // 
            resources.ApplyResources(this.txtElevationToGPSEditMenu, "txtElevationToGPSEditMenu");
            this.txtElevationToGPSEditMenu.Name = "txtElevationToGPSEditMenu";
            this.txtElevationToGPSEditMenu.UseVisualStyleBackColor = true;
            this.txtElevationToGPSEditMenu.CheckedChanged += new System.EventHandler(this.txtElevationToGPSEditMenu_CheckedChanged);
            // 
            // labelElevationToGPSInformative
            // 
            resources.ApplyResources(this.labelElevationToGPSInformative, "labelElevationToGPSInformative");
            this.labelElevationToGPSInformative.Name = "labelElevationToGPSInformative";
            // 
            // labelFixHR
            // 
            resources.ApplyResources(this.labelFixHR, "labelFixHR");
            this.labelFixHR.Name = "labelFixHR";
            // 
            // txtFixHRAtImport
            // 
            resources.ApplyResources(this.txtFixHRAtImport, "txtFixHRAtImport");
            this.txtFixHRAtImport.Name = "txtFixHRAtImport";
            this.txtFixHRAtImport.UseVisualStyleBackColor = false;
            this.txtFixHRAtImport.CheckedChanged += new System.EventHandler(this.txtFixHRAtImport_CheckedChanged);
            // 
            // txtFixHREditMenu
            // 
            resources.ApplyResources(this.txtFixHREditMenu, "txtFixHREditMenu");
            this.txtFixHREditMenu.Name = "txtFixHREditMenu";
            this.txtFixHREditMenu.UseVisualStyleBackColor = false;
            this.txtFixHREditMenu.CheckedChanged += new System.EventHandler(this.txtxFixHREditMenu_CheckedChanged);
            // 
            // txtUseEnteredDataEditMenu
            // 
            resources.ApplyResources(this.txtUseEnteredDataEditMenu, "txtUseEnteredDataEditMenu");
            this.txtUseEnteredDataEditMenu.Name = "txtUseEnteredDataEditMenu";
            this.txtUseEnteredDataEditMenu.UseVisualStyleBackColor = false;
            this.txtUseEnteredDataEditMenu.CheckedChanged += new System.EventHandler(this.txtUseEnteredDataEditMenu_CheckedChanged);
            // 
            // txtUseEnteredDataAtImport
            // 
            resources.ApplyResources(this.txtUseEnteredDataAtImport, "txtUseEnteredDataAtImport");
            this.txtUseEnteredDataAtImport.Name = "txtUseEnteredDataAtImport";
            this.txtUseEnteredDataAtImport.UseVisualStyleBackColor = false;
            this.txtUseEnteredDataAtImport.CheckedChanged += new System.EventHandler(this.txtUseEnteredDataAtImport_CheckedChanged);
            // 
            // labelUseEnteredData
            // 
            resources.ApplyResources(this.labelUseEnteredData, "labelUseEnteredData");
            this.labelUseEnteredData.Name = "labelUseEnteredData";
            // 
            // txtCorrectGpsFromDistanceEditMenu
            // 
            resources.ApplyResources(this.txtCorrectGpsFromDistanceEditMenu, "txtCorrectGpsFromDistanceEditMenu");
            this.txtCorrectGpsFromDistanceEditMenu.Name = "txtCorrectGpsFromDistanceEditMenu";
            this.txtCorrectGpsFromDistanceEditMenu.UseVisualStyleBackColor = false;
            // 
            // txtCorrectGpsFromDistanceAtImport
            // 
            resources.ApplyResources(this.txtCorrectGpsFromDistanceAtImport, "txtCorrectGpsFromDistanceAtImport");
            this.txtCorrectGpsFromDistanceAtImport.Name = "txtCorrectGpsFromDistanceAtImport";
            this.txtCorrectGpsFromDistanceAtImport.UseVisualStyleBackColor = false;
            this.txtCorrectGpsFromDistanceAtImport.CheckedChanged += new System.EventHandler(this.txtCorrectGpsFromDistanceAtImport_CheckedChanged);
            // 
            // labelCorrectGpsFromDistance
            // 
            resources.ApplyResources(this.labelCorrectGpsFromDistance, "labelCorrectGpsFromDistance");
            this.labelCorrectGpsFromDistance.Name = "labelCorrectGpsFromDistance";
            // 
            // MiscPluginPageControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.MinimumSize = new System.Drawing.Size(0, 230);
            this.Name = "MiscPluginPageControl";
            ((System.ComponentModel.ISupportInitialize)(this.numericInsertPausesMinSeconds)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelExtendGPS;
        private CheckBox txtExtendGPSAtImport;
        private LinkLabel linkInformativeUrl;
        private Label labelExtendGPSInformative;
        private CheckBox txtInsertPausesAtImport;
        private Label labelInsertPauses;
        private Label labelInsertPausesInformative;
        private NumericUpDown numericInsertPausesMinSeconds;
        private TableLayoutPanel tableLayoutPanel1;
        private Label labelActivateAtImport;
        private Label labelEditMenuItem;
        private CheckBox txtExtendGPSEditMenu;
        private CheckBox txtInsertPausesEditMenu;
        private Label labelSetTimeGPS;
        private CheckBox txtSetTimeGPSEditMenu;
        private Label labelSetTimeGPSInformative;
        private CheckBox txtRemoveIdenticalGPSAtImport;
        private Label labelRemoveIdenticalGPS;
        private Label labelRemoveIdenticalGPSInformative;
        private CheckBox txtRemoveIdenticalGPSEditMenu;
        private Label labelDetectRestLaps;
        private CheckBox txtDetectRestLapsAtImport;
        private Label labelDetectRestLapsInformative;
        private Label labelElevationToGPS;
        private CheckBox txtElevationToGPSAtImport;
        private CheckBox txtElevationToGPSEditMenu;
        private Label labelElevationToGPSInformative;
        private Label labelInsertPausesWhenGPSdifferMinSeconds;
        private CheckBox txtSetTimeGPSAtImport;
        private CheckBox txtDetectRestLapsEditMenu;
        private Label labelAdjustPausesToDevice;
        private Label labelAdjustPausesToDeviceInformative;
        private CheckBox txtAdjustPausesToDeviceAtImport;
        private CheckBox txtAdjustPausesToDeviceEditMenu;
        private Label labelCorrectGpsFromDistanceInformative;
        private Label labelUseEnteredDataInformative;
        private Label labelPrepareForActivitiesViewerInformative;
        private CheckBox txtPrepareForActivitiesViewerEditMenu;
        private CheckBox txtPrepareForActivitiesViewerAtImport;
        private Label labelPrepareForActivitiesViewer;
        private Label labelFixHRInformative;
        private Label labelFixHR;
        private CheckBox txtFixHRAtImport;
        private CheckBox txtFixHREditMenu;
        private CheckBox txtUseEnteredDataEditMenu;
        private CheckBox txtUseEnteredDataAtImport;
        private Label labelUseEnteredData;
        private CheckBox txtCorrectGpsFromDistanceEditMenu;
        private CheckBox txtCorrectGpsFromDistanceAtImport;
        private Label labelCorrectGpsFromDistance;
    }
}
