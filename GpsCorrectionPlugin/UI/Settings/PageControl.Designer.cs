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

using System.Windows.Forms;

namespace GpsCorrectionPlugin.UI.Settings
{
    partial class PageControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PageControl));
            this.labelCorrectGpsFromDistance = new System.Windows.Forms.Label();
            this.txtCorrectGpsFromDistanceEditMenu = new System.Windows.Forms.CheckBox();
            this.linkInformativeUrl = new System.Windows.Forms.LinkLabel();
            this.labelCorrectGpsFromDistanceInformative = new System.Windows.Forms.Label();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelActivateAtImport = new System.Windows.Forms.Label();
            this.labelEditMenuItem = new System.Windows.Forms.Label();
            this.txtCorrectGpsFromDistanceAtImport = new System.Windows.Forms.CheckBox();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelCorrectGpsFromDistance
            // 
            resources.ApplyResources(this.labelCorrectGpsFromDistance, "labelCorrectGpsFromDistance");
            this.labelCorrectGpsFromDistance.Name = "labelCorrectGpsFromDistance";
            // 
            // txtCorrectGpsFromDistanceEditMenu
            // 
            this.txtCorrectGpsFromDistanceEditMenu.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtCorrectGpsFromDistanceEditMenu, "txtCorrectGpsFromDistanceEditMenu");
            this.txtCorrectGpsFromDistanceEditMenu.Name = "txtCorrectGpsFromDistanceEditMenu";
            this.txtCorrectGpsFromDistanceEditMenu.UseVisualStyleBackColor = false;
            this.txtCorrectGpsFromDistanceEditMenu.CheckedChanged += new System.EventHandler(this.txtCorrectGpsFromDistanceEditMenu_CheckedChanged);
            // 
            // linkInformativeUrl
            // 
            resources.ApplyResources(this.linkInformativeUrl, "linkInformativeUrl");
            this.linkInformativeUrl.Name = "linkInformativeUrl";
            this.linkInformativeUrl.TabStop = true;
            this.linkInformativeUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkInformativeUrl_LinkClicked);
            // 
            // labelCorrectGpsFromDistanceInformative
            // 
            resources.ApplyResources(this.labelCorrectGpsFromDistanceInformative, "labelCorrectGpsFromDistanceInformative");
            this.labelCorrectGpsFromDistanceInformative.Name = "labelCorrectGpsFromDistanceInformative";
            // 
            // tableLayoutPanel2
            // 
            resources.ApplyResources(this.tableLayoutPanel2, "tableLayoutPanel2");
            this.tableLayoutPanel2.Controls.Add(this.labelActivateAtImport, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.labelCorrectGpsFromDistanceInformative, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelCorrectGpsFromDistance, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.labelEditMenuItem, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtCorrectGpsFromDistanceAtImport, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtCorrectGpsFromDistanceEditMenu, 2, 1);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
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
            // txtCorrectGpsFromDistanceAtImport
            // 
            this.txtCorrectGpsFromDistanceAtImport.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtCorrectGpsFromDistanceAtImport, "txtCorrectGpsFromDistanceAtImport");
            this.txtCorrectGpsFromDistanceAtImport.Name = "txtCorrectGpsFromDistanceAtImport";
            this.txtCorrectGpsFromDistanceAtImport.UseVisualStyleBackColor = false;
            this.txtCorrectGpsFromDistanceAtImport.CheckedChanged += new System.EventHandler(this.txtCorrectGpsFromDistanceAtImport_CheckedChanged);
            // 
            // PageControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.linkInformativeUrl);
            this.MinimumSize = new System.Drawing.Size(240, 230);
            this.Name = "PageControl";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label labelCorrectGpsFromDistance;
        private CheckBox txtCorrectGpsFromDistanceEditMenu;
        private LinkLabel linkInformativeUrl;

        private Label labelCorrectGpsFromDistanceInformative;
        private TableLayoutPanel tableLayoutPanel2;
        private Label labelActivateAtImport;
        private Label labelEditMenuItem;
        private CheckBox txtCorrectGpsFromDistanceAtImport;
    }
}
