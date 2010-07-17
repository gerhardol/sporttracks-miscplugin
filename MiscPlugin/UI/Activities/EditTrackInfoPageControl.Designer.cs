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

namespace MiscPlugin.UI.Activities
{
    partial class EditTrackInfoPageControl
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
            this.labelNumGPSPoints = new System.Windows.Forms.Label();
            this.txtNumGPSPoints = new ZoneFiveSoftware.Common.Visuals.TextBox();
            this.txtAvgSegmentDist = new ZoneFiveSoftware.Common.Visuals.TextBox();
            this.labelAvgSegmentDist = new System.Windows.Forms.Label();
            this.txtMinSegmentDist = new ZoneFiveSoftware.Common.Visuals.TextBox();
            this.labelMinSegmentDist = new System.Windows.Forms.Label();
            this.txtMaxSegmentDist = new ZoneFiveSoftware.Common.Visuals.TextBox();
            this.labelMaxSegmentDist = new System.Windows.Forms.Label();
            this.txtDistStdDev = new ZoneFiveSoftware.Common.Visuals.TextBox();
            this.labelDistStdDev = new System.Windows.Forms.Label();
            this.txtTimeStdDev = new ZoneFiveSoftware.Common.Visuals.TextBox();
            this.labelTimeStdDev = new System.Windows.Forms.Label();
            this.txtMaxSegmentTime = new ZoneFiveSoftware.Common.Visuals.TextBox();
            this.labelMaxSegmentTime = new System.Windows.Forms.Label();
            this.txtMinSegmentTime = new ZoneFiveSoftware.Common.Visuals.TextBox();
            this.labelMinSegmentTime = new System.Windows.Forms.Label();
            this.txtAvgSegmentTime = new ZoneFiveSoftware.Common.Visuals.TextBox();
            this.labelAvgSegmentTime = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelNumGPSPoints
            // 
            this.labelNumGPSPoints.Location = new System.Drawing.Point(0, 3);
            this.labelNumGPSPoints.Name = "labelNumGPSPoints";
            this.labelNumGPSPoints.Size = new System.Drawing.Size(149, 16);
            this.labelNumGPSPoints.TabIndex = 0;
            this.labelNumGPSPoints.Text = "Number of GPS points:";
            // 
            // txtNumGPSPoints
            // 
            this.txtNumGPSPoints.BackColor = System.Drawing.Color.White;
            this.txtNumGPSPoints.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(114)))), ((int)(((byte)(108)))));
            this.txtNumGPSPoints.ButtonImage = null;
            this.txtNumGPSPoints.Location = new System.Drawing.Point(155, 0);
            this.txtNumGPSPoints.Multiline = false;
            this.txtNumGPSPoints.Name = "txtNumGPSPoints";
            this.txtNumGPSPoints.ReadOnly = true;
            this.txtNumGPSPoints.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.txtNumGPSPoints.ReadOnlyTextColor = System.Drawing.SystemColors.ControlLight;
            this.txtNumGPSPoints.Size = new System.Drawing.Size(82, 19);
            this.txtNumGPSPoints.TabIndex = 1;
            this.txtNumGPSPoints.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // txtAvgSegmentDist
            // 
            this.txtAvgSegmentDist.BackColor = System.Drawing.Color.White;
            this.txtAvgSegmentDist.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(114)))), ((int)(((byte)(108)))));
            this.txtAvgSegmentDist.ButtonImage = null;
            this.txtAvgSegmentDist.Location = new System.Drawing.Point(155, 30);
            this.txtAvgSegmentDist.Multiline = false;
            this.txtAvgSegmentDist.Name = "txtAvgSegmentDist";
            this.txtAvgSegmentDist.ReadOnly = true;
            this.txtAvgSegmentDist.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.txtAvgSegmentDist.ReadOnlyTextColor = System.Drawing.SystemColors.ControlLight;
            this.txtAvgSegmentDist.Size = new System.Drawing.Size(82, 19);
            this.txtAvgSegmentDist.TabIndex = 3;
            this.txtAvgSegmentDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // labelAvgSegmentDist
            // 
            this.labelAvgSegmentDist.Location = new System.Drawing.Point(0, 33);
            this.labelAvgSegmentDist.Name = "labelAvgSegmentDist";
            this.labelAvgSegmentDist.Size = new System.Drawing.Size(149, 16);
            this.labelAvgSegmentDist.TabIndex = 2;
            this.labelAvgSegmentDist.Text = "Average segment distance:";
            // 
            // txtMinSegmentDist
            // 
            this.txtMinSegmentDist.BackColor = System.Drawing.Color.White;
            this.txtMinSegmentDist.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(114)))), ((int)(((byte)(108)))));
            this.txtMinSegmentDist.ButtonImage = null;
            this.txtMinSegmentDist.Location = new System.Drawing.Point(155, 53);
            this.txtMinSegmentDist.Multiline = false;
            this.txtMinSegmentDist.Name = "txtMinSegmentDist";
            this.txtMinSegmentDist.ReadOnly = true;
            this.txtMinSegmentDist.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.txtMinSegmentDist.ReadOnlyTextColor = System.Drawing.SystemColors.ControlLight;
            this.txtMinSegmentDist.Size = new System.Drawing.Size(82, 19);
            this.txtMinSegmentDist.TabIndex = 5;
            this.txtMinSegmentDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // labelMinSegmentDist
            // 
            this.labelMinSegmentDist.Location = new System.Drawing.Point(0, 56);
            this.labelMinSegmentDist.Name = "labelMinSegmentDist";
            this.labelMinSegmentDist.Size = new System.Drawing.Size(149, 16);
            this.labelMinSegmentDist.TabIndex = 4;
            this.labelMinSegmentDist.Text = "Minimum segment distance:";
            // 
            // txtMaxSegmentDist
            // 
            this.txtMaxSegmentDist.BackColor = System.Drawing.Color.White;
            this.txtMaxSegmentDist.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(114)))), ((int)(((byte)(108)))));
            this.txtMaxSegmentDist.ButtonImage = null;
            this.txtMaxSegmentDist.Location = new System.Drawing.Point(155, 76);
            this.txtMaxSegmentDist.Multiline = false;
            this.txtMaxSegmentDist.Name = "txtMaxSegmentDist";
            this.txtMaxSegmentDist.ReadOnly = true;
            this.txtMaxSegmentDist.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.txtMaxSegmentDist.ReadOnlyTextColor = System.Drawing.SystemColors.ControlLight;
            this.txtMaxSegmentDist.Size = new System.Drawing.Size(82, 19);
            this.txtMaxSegmentDist.TabIndex = 7;
            this.txtMaxSegmentDist.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // labelMaxSegmentDist
            // 
            this.labelMaxSegmentDist.Location = new System.Drawing.Point(0, 79);
            this.labelMaxSegmentDist.Name = "labelMaxSegmentDist";
            this.labelMaxSegmentDist.Size = new System.Drawing.Size(149, 16);
            this.labelMaxSegmentDist.TabIndex = 6;
            this.labelMaxSegmentDist.Text = "Maximum segment distance:";
            // 
            // txtDistStdDev
            // 
            this.txtDistStdDev.BackColor = System.Drawing.Color.White;
            this.txtDistStdDev.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(114)))), ((int)(((byte)(108)))));
            this.txtDistStdDev.ButtonImage = null;
            this.txtDistStdDev.Location = new System.Drawing.Point(155, 99);
            this.txtDistStdDev.Multiline = false;
            this.txtDistStdDev.Name = "txtDistStdDev";
            this.txtDistStdDev.ReadOnly = true;
            this.txtDistStdDev.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.txtDistStdDev.ReadOnlyTextColor = System.Drawing.SystemColors.ControlLight;
            this.txtDistStdDev.Size = new System.Drawing.Size(82, 19);
            this.txtDistStdDev.TabIndex = 9;
            this.txtDistStdDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // labelDistStdDev
            // 
            this.labelDistStdDev.Location = new System.Drawing.Point(0, 102);
            this.labelDistStdDev.Name = "labelDistStdDev";
            this.labelDistStdDev.Size = new System.Drawing.Size(149, 16);
            this.labelDistStdDev.TabIndex = 8;
            this.labelDistStdDev.Text = "Std. dev. segment distance:";
            // 
            // txtTimeStdDev
            // 
            this.txtTimeStdDev.BackColor = System.Drawing.Color.White;
            this.txtTimeStdDev.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(114)))), ((int)(((byte)(108)))));
            this.txtTimeStdDev.ButtonImage = null;
            this.txtTimeStdDev.Location = new System.Drawing.Point(155, 201);
            this.txtTimeStdDev.Multiline = false;
            this.txtTimeStdDev.Name = "txtTimeStdDev";
            this.txtTimeStdDev.ReadOnly = true;
            this.txtTimeStdDev.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.txtTimeStdDev.ReadOnlyTextColor = System.Drawing.SystemColors.ControlLight;
            this.txtTimeStdDev.Size = new System.Drawing.Size(82, 19);
            this.txtTimeStdDev.TabIndex = 17;
            this.txtTimeStdDev.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // labelTimeStdDev
            // 
            this.labelTimeStdDev.Location = new System.Drawing.Point(0, 204);
            this.labelTimeStdDev.Name = "labelTimeStdDev";
            this.labelTimeStdDev.Size = new System.Drawing.Size(149, 16);
            this.labelTimeStdDev.TabIndex = 16;
            this.labelTimeStdDev.Text = "Std. dev. segment time:";
            // 
            // txtMaxSegmentTime
            // 
            this.txtMaxSegmentTime.BackColor = System.Drawing.Color.White;
            this.txtMaxSegmentTime.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(114)))), ((int)(((byte)(108)))));
            this.txtMaxSegmentTime.ButtonImage = null;
            this.txtMaxSegmentTime.Location = new System.Drawing.Point(155, 178);
            this.txtMaxSegmentTime.Multiline = false;
            this.txtMaxSegmentTime.Name = "txtMaxSegmentTime";
            this.txtMaxSegmentTime.ReadOnly = true;
            this.txtMaxSegmentTime.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.txtMaxSegmentTime.ReadOnlyTextColor = System.Drawing.SystemColors.ControlLight;
            this.txtMaxSegmentTime.Size = new System.Drawing.Size(82, 19);
            this.txtMaxSegmentTime.TabIndex = 15;
            this.txtMaxSegmentTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // labelMaxSegmentTime
            // 
            this.labelMaxSegmentTime.Location = new System.Drawing.Point(0, 181);
            this.labelMaxSegmentTime.Name = "labelMaxSegmentTime";
            this.labelMaxSegmentTime.Size = new System.Drawing.Size(149, 16);
            this.labelMaxSegmentTime.TabIndex = 14;
            this.labelMaxSegmentTime.Text = "Maximum segment time:";
            // 
            // txtMinSegmentTime
            // 
            this.txtMinSegmentTime.BackColor = System.Drawing.Color.White;
            this.txtMinSegmentTime.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(114)))), ((int)(((byte)(108)))));
            this.txtMinSegmentTime.ButtonImage = null;
            this.txtMinSegmentTime.Location = new System.Drawing.Point(155, 155);
            this.txtMinSegmentTime.Multiline = false;
            this.txtMinSegmentTime.Name = "txtMinSegmentTime";
            this.txtMinSegmentTime.ReadOnly = true;
            this.txtMinSegmentTime.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.txtMinSegmentTime.ReadOnlyTextColor = System.Drawing.SystemColors.ControlLight;
            this.txtMinSegmentTime.Size = new System.Drawing.Size(82, 19);
            this.txtMinSegmentTime.TabIndex = 13;
            this.txtMinSegmentTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // labelMinSegmentTime
            // 
            this.labelMinSegmentTime.Location = new System.Drawing.Point(0, 158);
            this.labelMinSegmentTime.Name = "labelMinSegmentTime";
            this.labelMinSegmentTime.Size = new System.Drawing.Size(149, 16);
            this.labelMinSegmentTime.TabIndex = 12;
            this.labelMinSegmentTime.Text = "Minimum segment time:";
            // 
            // txtAvgSegmentTime
            // 
            this.txtAvgSegmentTime.BackColor = System.Drawing.Color.White;
            this.txtAvgSegmentTime.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(114)))), ((int)(((byte)(108)))));
            this.txtAvgSegmentTime.ButtonImage = null;
            this.txtAvgSegmentTime.Location = new System.Drawing.Point(155, 132);
            this.txtAvgSegmentTime.Multiline = false;
            this.txtAvgSegmentTime.Name = "txtAvgSegmentTime";
            this.txtAvgSegmentTime.ReadOnly = true;
            this.txtAvgSegmentTime.ReadOnlyColor = System.Drawing.SystemColors.Control;
            this.txtAvgSegmentTime.ReadOnlyTextColor = System.Drawing.SystemColors.ControlLight;
            this.txtAvgSegmentTime.Size = new System.Drawing.Size(82, 19);
            this.txtAvgSegmentTime.TabIndex = 11;
            this.txtAvgSegmentTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            // 
            // labelAvgSegmentTime
            // 
            this.labelAvgSegmentTime.Location = new System.Drawing.Point(0, 135);
            this.labelAvgSegmentTime.Name = "labelAvgSegmentTime";
            this.labelAvgSegmentTime.Size = new System.Drawing.Size(149, 16);
            this.labelAvgSegmentTime.TabIndex = 10;
            this.labelAvgSegmentTime.Text = "Average segment time:";
            // 
            // ActivityGPSInfoPageControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txtTimeStdDev);
            this.Controls.Add(this.labelTimeStdDev);
            this.Controls.Add(this.txtMaxSegmentTime);
            this.Controls.Add(this.labelMaxSegmentTime);
            this.Controls.Add(this.txtMinSegmentTime);
            this.Controls.Add(this.labelMinSegmentTime);
            this.Controls.Add(this.txtAvgSegmentTime);
            this.Controls.Add(this.labelAvgSegmentTime);
            this.Controls.Add(this.txtDistStdDev);
            this.Controls.Add(this.labelDistStdDev);
            this.Controls.Add(this.txtMaxSegmentDist);
            this.Controls.Add(this.labelMaxSegmentDist);
            this.Controls.Add(this.txtMinSegmentDist);
            this.Controls.Add(this.labelMinSegmentDist);
            this.Controls.Add(this.txtAvgSegmentDist);
            this.Controls.Add(this.labelAvgSegmentDist);
            this.Controls.Add(this.txtNumGPSPoints);
            this.Controls.Add(this.labelNumGPSPoints);
            this.MinimumSize = new System.Drawing.Size(240, 230);
            this.Name = "ActivityGPSInfoPageControl";
            this.Size = new System.Drawing.Size(240, 230);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelNumGPSPoints;
        private ZoneFiveSoftware.Common.Visuals.TextBox txtNumGPSPoints;
        private ZoneFiveSoftware.Common.Visuals.TextBox txtAvgSegmentDist;
        private System.Windows.Forms.Label labelAvgSegmentDist;
        private ZoneFiveSoftware.Common.Visuals.TextBox txtMinSegmentDist;
        private System.Windows.Forms.Label labelMinSegmentDist;
        private ZoneFiveSoftware.Common.Visuals.TextBox txtMaxSegmentDist;
        private System.Windows.Forms.Label labelMaxSegmentDist;
        private ZoneFiveSoftware.Common.Visuals.TextBox txtDistStdDev;
        private System.Windows.Forms.Label labelDistStdDev;
        private ZoneFiveSoftware.Common.Visuals.TextBox txtTimeStdDev;
        private System.Windows.Forms.Label labelTimeStdDev;
        private ZoneFiveSoftware.Common.Visuals.TextBox txtMaxSegmentTime;
        private System.Windows.Forms.Label labelMaxSegmentTime;
        private ZoneFiveSoftware.Common.Visuals.TextBox txtMinSegmentTime;
        private System.Windows.Forms.Label labelMinSegmentTime;
        private ZoneFiveSoftware.Common.Visuals.TextBox txtAvgSegmentTime;
        private System.Windows.Forms.Label labelAvgSegmentTime;
    }
}
