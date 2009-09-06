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
            this.numericInsertPauses = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelActivateAtImport = new System.Windows.Forms.Label();
            this.labelEditMenuItem = new System.Windows.Forms.Label();
            this.txtExtendGPSEditMenu = new System.Windows.Forms.CheckBox();
            this.txtInsertPausesEditMenu = new System.Windows.Forms.CheckBox();
            this.labelSetTimeGPS = new System.Windows.Forms.Label();
            this.txtSetTimeGPSEditMenu = new System.Windows.Forms.CheckBox();
            this.labelSetTimeGPSInformative = new System.Windows.Forms.Label();
            this.labelRemoveIdenticalGPS = new System.Windows.Forms.Label();
            this.labelDetectRestLaps = new System.Windows.Forms.Label();
            this.txtRemoveIdenticalGPSAtImport = new System.Windows.Forms.CheckBox();
            this.txtRemoveIdenticalGPSEditMenu = new System.Windows.Forms.CheckBox();
            this.labelRemoveIdenticalGPSInformative = new System.Windows.Forms.Label();
            this.txtDetectRestLapsAtImport = new System.Windows.Forms.CheckBox();
            this.labelElevationToGPS = new System.Windows.Forms.Label();
            this.txtElevationToGPSAtImport = new System.Windows.Forms.CheckBox();
            this.txtElevationToGPSEditMenu = new System.Windows.Forms.CheckBox();
            this.labelInsertPausesWhenGPSdifferMinSeconds = new System.Windows.Forms.Label();
            this.txtSetTimeGPSAtImport = new System.Windows.Forms.CheckBox();
            this.txtDetectRestLapsEditMenu = new System.Windows.Forms.CheckBox();
            this.labelDetectRestLapsInformative = new System.Windows.Forms.Label();
            this.labelElevationToGPSInformative = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numericInsertPauses)).BeginInit();
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
            this.txtExtendGPSAtImport.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtExtendGPSAtImport, "txtExtendGPSAtImport");
            this.txtExtendGPSAtImport.Name = "txtExtendGPSAtImport";
            this.txtExtendGPSAtImport.UseVisualStyleBackColor = false;
            this.txtExtendGPSAtImport.CheckedChanged += new System.EventHandler(this.txtExtendGPSAtImport_CheckedChanged);
            // 
            // linkInformativeUrl
            // 
            resources.ApplyResources(this.linkInformativeUrl, "linkInformativeUrl");
            this.linkInformativeUrl.Name = "linkInformativeUrl";
            this.linkInformativeUrl.TabStop = true;
            this.linkInformativeUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkInformativeUrl_LinkClicked);
            // 
            // labelExtendGPSInformative
            // 
            this.labelExtendGPSInformative.AllowDrop = true;
            resources.ApplyResources(this.labelExtendGPSInformative, "labelExtendGPSInformative");
            this.labelExtendGPSInformative.Name = "labelExtendGPSInformative";
            this.labelExtendGPSInformative.UseCompatibleTextRendering = true;
            // 
            // txtInsertPausesAtImport
            // 
            this.txtInsertPausesAtImport.BackColor = System.Drawing.Color.White;
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
            // numericInsertPauses
            // 
            resources.ApplyResources(this.numericInsertPauses, "numericInsertPauses");
            this.numericInsertPauses.Maximum = new decimal(new int[] {
            72000,
            0,
            0,
            0});
            this.numericInsertPauses.Name = "numericInsertPauses";
            this.numericInsertPauses.Tag = "Min GPS gap";
            this.numericInsertPauses.ValueChanged += new System.EventHandler(this.numericInsertPauses_ValueChanged);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AllowDrop = true;
            resources.ApplyResources(this.tableLayoutPanel1, "tableLayoutPanel1");
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
            this.tableLayoutPanel1.Controls.Add(this.labelRemoveIdenticalGPS, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelDetectRestLaps, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtRemoveIdenticalGPSAtImport, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtRemoveIdenticalGPSEditMenu, 2, 7);
            this.tableLayoutPanel1.Controls.Add(this.labelRemoveIdenticalGPSInformative, 3, 7);
            this.tableLayoutPanel1.Controls.Add(this.txtDetectRestLapsAtImport, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelElevationToGPS, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtElevationToGPSAtImport, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.txtElevationToGPSEditMenu, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.labelInsertPausesWhenGPSdifferMinSeconds, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.numericInsertPauses, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtSetTimeGPSAtImport, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtDetectRestLapsEditMenu, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelDetectRestLapsInformative, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.labelInsertPausesInformative, 3, 2);
            this.tableLayoutPanel1.Controls.Add(this.labelElevationToGPSInformative, 3, 6);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
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
            this.txtExtendGPSEditMenu.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtExtendGPSEditMenu, "txtExtendGPSEditMenu");
            this.txtExtendGPSEditMenu.Name = "txtExtendGPSEditMenu";
            this.txtExtendGPSEditMenu.UseVisualStyleBackColor = false;
            // 
            // txtInsertPausesEditMenu
            // 
            this.txtInsertPausesEditMenu.BackColor = System.Drawing.Color.White;
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
            this.txtSetTimeGPSEditMenu.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtSetTimeGPSEditMenu, "txtSetTimeGPSEditMenu");
            this.txtSetTimeGPSEditMenu.Name = "txtSetTimeGPSEditMenu";
            this.txtSetTimeGPSEditMenu.UseVisualStyleBackColor = false;
            this.txtSetTimeGPSEditMenu.CheckedChanged += new System.EventHandler(this.txtSetTimeGPSEditMenu_CheckedChanged);
            // 
            // labelSetTimeGPSInformative
            // 
            this.labelSetTimeGPSInformative.AllowDrop = true;
            resources.ApplyResources(this.labelSetTimeGPSInformative, "labelSetTimeGPSInformative");
            this.labelSetTimeGPSInformative.Name = "labelSetTimeGPSInformative";
            // 
            // labelRemoveIdenticalGPS
            // 
            resources.ApplyResources(this.labelRemoveIdenticalGPS, "labelRemoveIdenticalGPS");
            this.labelRemoveIdenticalGPS.Name = "labelRemoveIdenticalGPS";
            // 
            // labelDetectRestLaps
            // 
            resources.ApplyResources(this.labelDetectRestLaps, "labelDetectRestLaps");
            this.labelDetectRestLaps.Name = "labelDetectRestLaps";
            // 
            // txtRemoveIdenticalGPSAtImport
            // 
            this.txtRemoveIdenticalGPSAtImport.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtRemoveIdenticalGPSAtImport, "txtRemoveIdenticalGPSAtImport");
            this.txtRemoveIdenticalGPSAtImport.Name = "txtRemoveIdenticalGPSAtImport";
            this.txtRemoveIdenticalGPSAtImport.UseVisualStyleBackColor = false;
            this.txtRemoveIdenticalGPSAtImport.CheckedChanged += new System.EventHandler(this.txtRemoveIdenticalGPSAtImport_CheckedChanged);
            // 
            // txtRemoveIdenticalGPSEditMenu
            // 
            this.txtRemoveIdenticalGPSEditMenu.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtRemoveIdenticalGPSEditMenu, "txtRemoveIdenticalGPSEditMenu");
            this.txtRemoveIdenticalGPSEditMenu.Name = "txtRemoveIdenticalGPSEditMenu";
            this.txtRemoveIdenticalGPSEditMenu.UseVisualStyleBackColor = false;
            this.txtRemoveIdenticalGPSEditMenu.CheckedChanged += new System.EventHandler(this.txtRemoveIdenticalGPSEditMenu_CheckedChanged);
            // 
            // labelRemoveIdenticalGPSInformative
            // 
            resources.ApplyResources(this.labelRemoveIdenticalGPSInformative, "labelRemoveIdenticalGPSInformative");
            this.labelRemoveIdenticalGPSInformative.Name = "labelRemoveIdenticalGPSInformative";
            // 
            // txtDetectRestLapsAtImport
            // 
            this.txtDetectRestLapsAtImport.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtDetectRestLapsAtImport, "txtDetectRestLapsAtImport");
            this.txtDetectRestLapsAtImport.Name = "txtDetectRestLapsAtImport";
            this.txtDetectRestLapsAtImport.UseVisualStyleBackColor = false;
            this.txtDetectRestLapsAtImport.CheckedChanged += new System.EventHandler(this.txtDetectRestLapsAtImport_CheckedChanged);
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
            // labelElevationToGPSInformative
            // 
            resources.ApplyResources(this.labelElevationToGPSInformative, "labelElevationToGPSInformative");
            this.labelElevationToGPSInformative.Name = "labelElevationToGPSInformative";
            // 
            // MiscPluginPageControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.linkInformativeUrl);
            this.MinimumSize = new System.Drawing.Size(240, 230);
            this.Name = "MiscPluginPageControl";
            ((System.ComponentModel.ISupportInitialize)(this.numericInsertPauses)).EndInit();
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
        private NumericUpDown numericInsertPauses;
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
    }
}
