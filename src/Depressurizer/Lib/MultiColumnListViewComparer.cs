﻿#region LICENSE

//     This file (MultiColumnListViewComparer.cs) is part of Depressurizer.
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
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Depressurizer
{
    /// <summary>
    ///     Implements the manual sorting of ListView items by columns. Supports sorting string representations of integers
    ///     numerically.
    /// </summary>
    public class MultiColumnListViewComparer : IComparer
    {
        #region Fields

        private readonly HashSet<int> _intCols = new HashSet<int>();

        private readonly HashSet<int> _revCols = new HashSet<int>();

        private bool _asInt;

        private int _col;

        private int _direction;

        private bool _rev;

        #endregion

        #region Constructors and Destructors

        public MultiColumnListViewComparer(int column = 0, int dir = 1)
        {
            _col = column;
            _direction = dir;
            _asInt = _intCols.Contains(_col);
        }

        #endregion

        #region Public Methods and Operators

        public void AddIntCol(int col)
        {
            _intCols.Add(col);
            _asInt = _intCols.Contains(_col);
        }

        public void AddRevCol(int col)
        {
            _revCols.Add(col);
            _rev = _revCols.Contains(_col);
        }

        public int Compare(object x, object y)
        {
            string strA = ((ListViewItem) x).SubItems[_col].Text;
            string strB = ((ListViewItem) y).SubItems[_col].Text;

            int dir = _direction * (_rev ? -1 : 1);
            if (_asInt)
            {
                int a, b;
                if (int.TryParse(strA, out a) && int.TryParse(strB, out b))
                {
                    return dir * (a - b);
                }
            }

            if (string.IsNullOrEmpty(strA))
            {
                if (string.IsNullOrEmpty(strB))
                {
                    return 0;
                }

                return dir;
            }

            if (string.IsNullOrEmpty(strB))
            {
                return -dir;
            }

            return dir * string.Compare(strA, strB);
        }

        public int GetSortCol()
        {
            return _col;
        }

        public int GetSortDir()
        {
            return _direction;
        }

        public void RemoveIntCol(int col)
        {
            _intCols.Remove(col);
            _asInt = _intCols.Contains(_col);
        }

        public void RemoveRevCol(int col)
        {
            _revCols.Remove(col);
            _rev = _revCols.Contains(_col);
        }

        public void SetSortCol(int clickedCol, int forceDir = 0)
        {
            if (forceDir == 0)
            {
                if (clickedCol == _col)
                {
                    _direction = -_direction;
                }
                else
                {
                    _direction = 1;
                }
            }
            else
            {
                _direction = forceDir;
            }

            _col = clickedCol;
            _asInt = _intCols.Contains(_col);
            _rev = _revCols.Contains(_col);
        }

        #endregion
    }

    /// <summary>
    ///     This allows drawing sorting arrows on the columns in the ListView.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public static class ListViewExtensions
    {
        #region Constants

        public const int HDM_FIRST = 0x1200;

        public const int HDM_GETITEM = HDM_FIRST + 11;

        public const int HDM_SETITEM = HDM_FIRST + 12;

        public const int LVM_FIRST = 0x1000;

        public const int LVM_GETHEADER = LVM_FIRST + 31;

        #endregion

        #region Public Methods and Operators

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, IntPtr lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, ref HDITEM lParam);

        public static void SetSortIcon(this ListView listViewControl, int columnIndex, SortOrder order)
        {
            IntPtr columnHeader = SendMessage(listViewControl.Handle, LVM_GETHEADER, IntPtr.Zero, IntPtr.Zero);
            for (int columnNumber = 0; columnNumber <= listViewControl.Columns.Count - 1; columnNumber++)
            {
                IntPtr columnPtr = new IntPtr(columnNumber);
                HDITEM item = new HDITEM
                {
                    mask = HDITEM.Mask.Format
                };

                if (SendMessage(columnHeader, HDM_GETITEM, columnPtr, ref item) == IntPtr.Zero)
                {
                    throw new Win32Exception();
                }

                if (order != SortOrder.None && columnNumber == columnIndex)
                {
                    switch (order)
                    {
                        case SortOrder.Ascending:
                            item.fmt &= ~HDITEM.Format.SortDown;
                            item.fmt |= HDITEM.Format.SortUp;
                            break;
                        case SortOrder.Descending:
                            item.fmt &= ~HDITEM.Format.SortUp;
                            item.fmt |= HDITEM.Format.SortDown;
                            break;
                    }
                }
                else
                {
                    item.fmt &= ~HDITEM.Format.SortDown & ~HDITEM.Format.SortUp;
                }

                if (SendMessage(columnHeader, HDM_SETITEM, columnPtr, ref item) == IntPtr.Zero)
                {
                    throw new Win32Exception();
                }
            }
        }

        #endregion

        [StructLayout(LayoutKind.Sequential)]
        public struct HDITEM
        {
            #region Fields

            public int cchTextMax;

            public int cxy;

            public Format fmt;

            public IntPtr hbm;

            // _WIN32_IE >= 0x0300 
            public int iImage;

            public int iOrder;

            public IntPtr lParam;

            public Mask mask;

            [MarshalAs(UnmanagedType.LPTStr)]
            public string pszText;

            public IntPtr pvFilter;

            // _WIN32_WINNT >= 0x0600
            public uint state;

            // _WIN32_IE >= 0x0500
            public uint type;

            #endregion

            #region Enums

            [Flags]
            public enum Format
            {
                SortDown = 0x200, // HDF_SORTDOWN

                SortUp = 0x400 // HDF_SORTUP
            }

            [Flags]
            public enum Mask
            {
                Format = 0x4 // HDI_FORMAT
            }

            #endregion
        }
    }
}
