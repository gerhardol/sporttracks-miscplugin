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

using System.Windows.Forms;

namespace IBikeFixerPlugin.UI.Settings
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
            this.labelActivateAtImportBool1 = new System.Windows.Forms.Label();
            this.txtActivateAtImportBool1 = new System.Windows.Forms.CheckBox();
            this.labelInformative = new System.Windows.Forms.Label();
            this.linkInformativeUrl = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // labelActivateAtImportBool1
            // 
            resources.ApplyResources(this.labelActivateAtImportBool1, "labelActivateAtImportBool1");
            this.labelActivateAtImportBool1.Name = "labelActivateAtImportBool1";
            // 
            // txtActivateAtImportBool1
            // 
            this.txtActivateAtImportBool1.BackColor = System.Drawing.Color.White;
            resources.ApplyResources(this.txtActivateAtImportBool1, "txtActivateAtImportBool1");
            this.txtActivateAtImportBool1.Name = "txtActivateAtImportBool1";
            this.txtActivateAtImportBool1.UseVisualStyleBackColor = false;
            this.txtActivateAtImportBool1.CheckedChanged += new System.EventHandler(this.txtActivateAtImportBool1_CheckedChanged);
            // 
            // labelInformative
            // 
            resources.ApplyResources(this.labelInformative, "labelInformative");
            this.labelInformative.Name = "labelInformative";
            // 
            // linkInformativeUrl
            // 
            resources.ApplyResources(this.linkInformativeUrl, "linkInformativeUrl");
            this.linkInformativeUrl.Name = "linkInformativeUrl";
            this.linkInformativeUrl.TabStop = true;
            this.linkInformativeUrl.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkInformativeUrl_LinkClicked);
            // 
            // PageControl
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.linkInformativeUrl);
            this.Controls.Add(this.labelInformative);
            this.Controls.Add(this.txtActivateAtImportBool1);
            this.Controls.Add(this.labelActivateAtImportBool1);
            this.MinimumSize = new System.Drawing.Size(240, 230);
            this.Name = "PageControl";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelActivateAtImportBool1;
        private CheckBox txtActivateAtImportBool1;
        private Label labelInformative;
        private LinkLabel linkInformativeUrl;
    }
}
