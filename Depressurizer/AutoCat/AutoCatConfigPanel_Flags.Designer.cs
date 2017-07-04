﻿/*
    This file is part of Depressurizer.
    Original work Copyright 2011, 2012, 2013 Steve Labbe.
    Modified work Copyright 2017 Martijn Vegter.

    Depressurizer is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, either version 3 of the License, or
    (at your option) any later version.

    Depressurizer is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
    GNU General Public License for more details.

    You should have received a copy of the GNU General Public License
    along with Depressurizer.  If not, see <http://www.gnu.org/licenses/>.
*/

namespace Depressurizer.AutoCat {
    partial class AutoCatConfigPanel_Flags {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose( bool disposing ) {
            if( disposing && ( components != null ) ) {
                components.Dispose();
            }
            base.Dispose( disposing );
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.grpMain = new System.Windows.Forms.GroupBox();
            this.helpPrefix = new System.Windows.Forms.Label();
            this.tblButtons = new System.Windows.Forms.TableLayoutPanel();
            this.cmdCheckAll = new System.Windows.Forms.Button();
            this.cmdUncheckAll = new System.Windows.Forms.Button();
            this.lblInclude = new System.Windows.Forms.Label();
            this.lstIncluded = new System.Windows.Forms.ListView();
            this.txtPrefix = new System.Windows.Forms.TextBox();
            this.lblPrefix = new System.Windows.Forms.Label();
            this.ttHelp = new Depressurizer.Lib.ExtToolTip();
            this.grpMain.SuspendLayout();
            this.tblButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpMain
            // 
            this.grpMain.Controls.Add(this.helpPrefix);
            this.grpMain.Controls.Add(this.tblButtons);
            this.grpMain.Controls.Add(this.lblInclude);
            this.grpMain.Controls.Add(this.lstIncluded);
            this.grpMain.Controls.Add(this.txtPrefix);
            this.grpMain.Controls.Add(this.lblPrefix);
            this.grpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpMain.Location = new System.Drawing.Point(0, 0);
            this.grpMain.Name = "grpMain";
            this.grpMain.Size = new System.Drawing.Size(576, 460);
            this.grpMain.TabIndex = 0;
            this.grpMain.TabStop = false;
            this.grpMain.Text = "Edit Flag Autocat";
            // 
            // helpPrefix
            // 
            this.helpPrefix.AutoSize = true;
            this.helpPrefix.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.helpPrefix.Location = new System.Drawing.Point(238, 22);
            this.helpPrefix.Name = "helpPrefix";
            this.helpPrefix.Size = new System.Drawing.Size(15, 15);
            this.helpPrefix.TabIndex = 2;
            this.helpPrefix.Text = "?";
            // 
            // tblButtons
            // 
            this.tblButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblButtons.ColumnCount = 2;
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tblButtons.Controls.Add(this.cmdCheckAll, 0, 0);
            this.tblButtons.Controls.Add(this.cmdUncheckAll, 1, 0);
            this.tblButtons.Location = new System.Drawing.Point(3, 426);
            this.tblButtons.Name = "tblButtons";
            this.tblButtons.RowCount = 1;
            this.tblButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblButtons.Size = new System.Drawing.Size(570, 30);
            this.tblButtons.TabIndex = 5;
            // 
            // cmdCheckAll
            // 
            this.cmdCheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdCheckAll.Location = new System.Drawing.Point(3, 3);
            this.cmdCheckAll.Name = "cmdCheckAll";
            this.cmdCheckAll.Size = new System.Drawing.Size(279, 23);
            this.cmdCheckAll.TabIndex = 0;
            this.cmdCheckAll.Text = "Check All";
            this.cmdCheckAll.UseVisualStyleBackColor = true;
            this.cmdCheckAll.Click += new System.EventHandler(this.cmdCheckAll_Click);
            // 
            // cmdUncheckAll
            // 
            this.cmdUncheckAll.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmdUncheckAll.Location = new System.Drawing.Point(288, 3);
            this.cmdUncheckAll.Name = "cmdUncheckAll";
            this.cmdUncheckAll.Size = new System.Drawing.Size(279, 23);
            this.cmdUncheckAll.TabIndex = 1;
            this.cmdUncheckAll.Text = "Uncheck All";
            this.cmdUncheckAll.UseVisualStyleBackColor = true;
            this.cmdUncheckAll.Click += new System.EventHandler(this.cmdUncheckAll_Click);
            // 
            // lblInclude
            // 
            this.lblInclude.AutoSize = true;
            this.lblInclude.Location = new System.Drawing.Point(3, 69);
            this.lblInclude.Name = "lblInclude";
            this.lblInclude.Size = new System.Drawing.Size(79, 13);
            this.lblInclude.TabIndex = 3;
            this.lblInclude.Text = "Included Flags:";
            // 
            // lstIncluded
            // 
            this.lstIncluded.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lstIncluded.CheckBoxes = true;
            this.lstIncluded.Location = new System.Drawing.Point(6, 85);
            this.lstIncluded.Name = "lstIncluded";
            this.lstIncluded.Size = new System.Drawing.Size(564, 339);
            this.lstIncluded.TabIndex = 4;
            this.lstIncluded.UseCompatibleStateImageBehavior = false;
            this.lstIncluded.View = System.Windows.Forms.View.List;
            // 
            // txtPrefix
            // 
            this.txtPrefix.Location = new System.Drawing.Point(67, 19);
            this.txtPrefix.Name = "txtPrefix";
            this.txtPrefix.Size = new System.Drawing.Size(165, 20);
            this.txtPrefix.TabIndex = 1;
            // 
            // lblPrefix
            // 
            this.lblPrefix.AutoSize = true;
            this.lblPrefix.Location = new System.Drawing.Point(25, 22);
            this.lblPrefix.Name = "lblPrefix";
            this.lblPrefix.Size = new System.Drawing.Size(36, 13);
            this.lblPrefix.TabIndex = 0;
            this.lblPrefix.Text = "Prefix:";
            // 
            // AutoCatConfigPanel_Flags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpMain);
            this.Name = "AutoCatConfigPanel_Flags";
            this.Size = new System.Drawing.Size(576, 460);
            this.grpMain.ResumeLayout(false);
            this.grpMain.PerformLayout();
            this.tblButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpMain;
        private System.Windows.Forms.Label helpPrefix;
        private System.Windows.Forms.TableLayoutPanel tblButtons;
        private System.Windows.Forms.Button cmdCheckAll;
        private System.Windows.Forms.Button cmdUncheckAll;
        private System.Windows.Forms.Label lblInclude;
        private System.Windows.Forms.ListView lstIncluded;
        private System.Windows.Forms.TextBox txtPrefix;
        private System.Windows.Forms.Label lblPrefix;
        private Lib.ExtToolTip ttHelp;
    }
}
