﻿#region LICENSE

//     This file (AutoCatConfigPanel_VrSupport.cs) is part of Depressurizer.
//     Copyright (C) 2011 Steve Labbe
//     Copyright (C) 2017 Theodoros Dimos
//     Copyright (C) 2017 Martijn Vegter
// 
//     This program is free software: you can redistribute it and/or modify
//     it under the terms of the GNU General Public License as published by
//     the Free Software Foundation, either version 3 of the License, or
//     (at your option) any later version.
// 
//     This program is distributed in the hope that it will be useful,
//     but WITHOUT ANY WARRANTY; without even the implied warranty of
//     MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//     GNU General Public License for more details.
// 
//     You should have received a copy of the GNU General Public License
//     along with this program.  If not, see <http://www.gnu.org/licenses/>.

#endregion

using System;
using System.Windows.Forms;
using Depressurizer.Core.Models;

namespace Depressurizer
{
    public partial class AutoCatConfigPanel_VrSupport : AutoCatConfigPanel
    {
        #region Constructors and Destructors

        public AutoCatConfigPanel_VrSupport()
        {
            InitializeComponent();

            ttHelp.Ext_SetToolTip(helpPrefix, GlobalStrings.DlgAutoCat_Help_Prefix);

            FillVrSupportLists();
        }

        #endregion

        #region Properties

        private static Database Database => Database.Instance;

        #endregion

        #region Public Methods and Operators

        public void FillVrSupportLists()
        {
            lstVrHeadsets.Items.Clear();
            lstVrInput.Items.Clear();
            lstVrPlayArea.Items.Clear();

            VRSupport vrSupport = Database.AllVRSupport;

            foreach (string s in vrSupport.Headsets)
            {
                lstVrHeadsets.Items.Add(s);
            }

            foreach (string s in vrSupport.Input)
            {
                lstVrInput.Items.Add(s);
            }

            foreach (string s in vrSupport.PlayArea)
            {
                lstVrPlayArea.Items.Add(s);
            }
        }

        public override void LoadFromAutoCat(AutoCat autoCat)
        {
            AutoCatVrSupport ac = autoCat as AutoCatVrSupport;
            if (ac == null)
            {
                return;
            }

            txtPrefix.Text = ac.Prefix;

            foreach (ListViewItem item in lstVrHeadsets.Items)
            {
                item.Checked = ac.IncludedVRSupportFlags.Headsets.Contains(item.Text);
            }

            foreach (ListViewItem item in lstVrInput.Items)
            {
                item.Checked = ac.IncludedVRSupportFlags.Input.Contains(item.Text);
            }

            foreach (ListViewItem item in lstVrPlayArea.Items)
            {
                item.Checked = ac.IncludedVRSupportFlags.PlayArea.Contains(item.Text);
            }
        }

        public override void SaveToAutoCat(AutoCat autoCat)
        {
            AutoCatVrSupport ac = autoCat as AutoCatVrSupport;
            if (ac == null)
            {
                return;
            }

            ac.Prefix = txtPrefix.Text;

            ac.IncludedVRSupportFlags.Headsets.Clear();
            ac.IncludedVRSupportFlags.Input.Clear();
            ac.IncludedVRSupportFlags.PlayArea.Clear();

            foreach (ListViewItem i in lstVrHeadsets.Items)
            {
                if (i.Checked)
                {
                    ac.IncludedVRSupportFlags.Headsets.Add(i.Text);
                }
            }

            foreach (ListViewItem i in lstVrInput.Items)
            {
                if (i.Checked)
                {
                    ac.IncludedVRSupportFlags.Input.Add(i.Text);
                }
            }

            foreach (ListViewItem i in lstVrPlayArea.Items)
            {
                if (i.Checked)
                {
                    ac.IncludedVRSupportFlags.PlayArea.Add(i.Text);
                }
            }
        }

        #endregion

        #region Methods

        private void cmdCheckAll_Click(object sender, EventArgs e)
        {
            SetAllListCheckStates(lstVrHeadsets, true);
            SetAllListCheckStates(lstVrInput, true);
            SetAllListCheckStates(lstVrPlayArea, true);
        }

        private void cmdUncheckAll_Click(object sender, EventArgs e)
        {
            SetAllListCheckStates(lstVrHeadsets, false);
            SetAllListCheckStates(lstVrInput, false);
            SetAllListCheckStates(lstVrPlayArea, false);
        }

        private void SetAllListCheckStates(ListView list, bool to)
        {
            foreach (ListViewItem item in list.Items)
            {
                item.Checked = to;
            }
        }

        #endregion
    }
}
