// Custom DataGridView
// Copyright (C) 2011 Marvin E. Pineda
//
// This library is free software; you can redistribute it and/or
// modify it under the terms of the GNU Lesser General Public
// License as published by the Free Software Foundation; either
// version 2.1 of the License, or (at your option) any later version.

// This library is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
// Lesser General Public License for more details.

// You should have received a copy of the GNU Lesser General Public
// License along with this library; if not, write to the Free Software
// Foundation, Inc., 51 Franklin St, Fifth Floor, Boston, MA  02110-1301  USA
//

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using System.ComponentModel.Design;
using System.Collections;

namespace MEP.Windows.Controls
{
    public class MEPDataGridView : DataGridView
    {
        #region -> Variables

        private bool vAutoGenerateColumns;
        private bool vFillEmptyArea;
        private bool NeedPaintEmptyArea
        {
            get
            {
                int lastRowDisplayed = Rows.GetLastRow(DataGridViewElementStates.Displayed);
                return lastRowDisplayed > -1 || DesignMode;
            }
        }
        private bool NeedPaintColumnEmptyArea
        {
            get
            {
                int ajust = 2;
                if (this.BorderStyle == BorderStyle.None)
                    ajust = 0;
                if (this.VerticalScrollBar.Visible)
                    ajust += SystemInformation.VerticalScrollBarWidth;

                int columnsWidth = this.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed) + ajust;
                if (this.RowHeadersVisible)
                    columnsWidth += this.RowHeadersWidth;
                else
                    columnsWidth += 1;

                return columnsWidth < this.Width;
            }
        }

        #endregion

        #region -> Constructor

        public MEPDataGridView()
        {
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.DoubleBuffered = true;
            this.vAutoGenerateColumns = true;
        }

        #endregion

        #region -> New Properties

        [DefaultValue(false)]
        public bool FillEmptyArea
        {
            get
            {
                return vFillEmptyArea;
            }
            set
            {
                vFillEmptyArea = value;
                if (this.IsHandleCreated)
                    this.Invalidate(true);
            }
        }

        #endregion

        #region -> Override properties

        [Browsable(true), DefaultValue(true)]
        public new virtual bool AutoGenerateColumns
        {
            get
            {
                return vAutoGenerateColumns;
            }
            set
            {
                vAutoGenerateColumns = value;
                base.AutoGenerateColumns = value;
            }
        }

        #endregion

        #region -> Override methods

        protected override void WndProc(ref Message m)
        {
            switch (m.Msg)
            {
                case NativeMethods.WM_SETFOCUS:
                    WmSetFocus(ref m);
                    break;
            }
            base.WndProc(ref m);
        }
        protected override void OnCellPainting(DataGridViewCellPaintingEventArgs e)
        {
            base.OnCellPainting(e);
            if (e.RowIndex == -1 && e.ColumnIndex == -1)
            {
                // Pinta el encabezado de la columna indicador.
                this.PaintIndicatorHeader(e);
            }
            else if (e.RowIndex == -1 && e.ColumnIndex > -1)
            {
                // Pinta los encabezados de las columnas
                this.PaintColumnHeader(new PaintingEventArgs(e.Graphics, e.CellBounds, e.RowIndex, e.ColumnIndex));
                e.PaintContent(e.ClipBounds);
                e.Handled = true;
            }
            else if (e.ColumnIndex == -1)
            {
                // Pinta la columna indicador.
                this.PaintRowIndicator(new PaintingEventArgs(e.Graphics, e.CellBounds, e.RowIndex, e.ColumnIndex));
                e.PaintContent(e.ClipBounds);
                e.Handled = true;
            }
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if (FillEmptyArea)
                PaintEmptyArea(e);
        }

        #endregion

        #region -> Auxiliary methods

        private void WmSetFocus(ref Message m)
        {
            if (NeedPaintEmptyArea && FillEmptyArea)
                Invalidate(true);
        }
        private void PaintColumnHeader(PaintingEventArgs e)
        {
            #region -> Draw background

            using (LinearGradientBrush brush = new LinearGradientBrush(e.CellBounds, SystemColors.Window, SystemColors.Control, LinearGradientMode.Vertical))
            {
                Blend blend = new Blend();
                blend.Factors = new float[] { 0.0f, 0.1f, 0.6f, 0.0f, 1.0f };
                blend.Positions = new float[] { 0.0f, 0.25f, 0.1f, 3.0f, 1.0f };
                brush.Blend = blend;
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }

            #endregion

            #region -> Draw external border

            ControlPaint.DrawBorder
                (
                    e.Graphics, e.CellBounds,
                    SystemColors.ControlDark, 1, ButtonBorderStyle.None,    // Left
                    SystemColors.ControlDark, 1, ButtonBorderStyle.Solid,   // Top
                    SystemColors.ControlDark, 1, ButtonBorderStyle.None,    // Right
                    SystemColors.ControlDark, 1, ButtonBorderStyle.Solid    // Bottom
                );

            #endregion

            #region -> Draw internal border

            Rectangle intCellBounds = e.CellBounds;
            intCellBounds.Height -= 2;
            using (Pen pen = new Pen(Color.FromArgb(50, SystemColors.ControlDark)))
            {
                ControlPaint.DrawBorder
                    (
                        e.Graphics, intCellBounds,
                        pen.Color, 1, ButtonBorderStyle.None,  // Left
                        pen.Color, 1, ButtonBorderStyle.None,   // Top
                        pen.Color, 1, ButtonBorderStyle.Solid,  // Right
                        pen.Color, 1, ButtonBorderStyle.Solid   // Bottom
                    );
            }

            #endregion
        }
        private void PaintIndicatorHeader(DataGridViewCellPaintingEventArgs e)
        {
            e.Handled = true;
            using (LinearGradientBrush brush = new LinearGradientBrush(e.CellBounds, SystemColors.Window, SystemColors.Control, LinearGradientMode.Vertical))
            {
                e.Graphics.FillRectangle(brush, e.CellBounds);
            }
            ControlPaint.DrawBorder
                (
                    e.Graphics, e.CellBounds,
                    SystemColors.ControlDark, 1, ButtonBorderStyle.Solid,
                    SystemColors.ControlDark, 1, ButtonBorderStyle.Solid,
                    SystemColors.ControlDark, 1, ButtonBorderStyle.Solid,
                    SystemColors.ControlDark, 1, ButtonBorderStyle.Solid
                );
        }
        private void PaintRowIndicator(PaintingEventArgs e)
        {
            int x = 1, w = 0;
            if (this.BorderStyle == BorderStyle.None)
            {
                x = 0; w = 1;
            }

            #region -> Draw Background

            Rectangle fillBackColor = new Rectangle(x, e.CellBounds.Y, e.CellBounds.Width, e.CellBounds.Height);
            using (LinearGradientBrush brush = new LinearGradientBrush(fillBackColor, SystemColors.Window, SystemColors.Control, LinearGradientMode.Horizontal))
            {
                Blend blend = new Blend();
                blend.Factors = new float[] { 0.0f, 0.1f, 0.6f, 0.0f, 1.0f };
                blend.Positions = new float[] { 0.0f, 0.23f, 0.1f, 3.0f, 1.0f };
                brush.Blend = blend;
                e.Graphics.FillRectangle(brush, fillBackColor);
            }

            #endregion

            #region -> Draw external border

            Rectangle rct0 = new Rectangle(x, e.CellBounds.Y - 1, e.CellBounds.Width, e.CellBounds.Height);
            // left border
            e.Graphics.DrawLine(SystemPens.ControlDark, rct0.X, rct0.Y, rct0.X, rct0.Bottom);
            if (e.RowIndex == 0)
                // top border
                e.Graphics.DrawLine(SystemPens.ControlDark, rct0.X, rct0.Y, rct0.Width, rct0.Y);
            // right border
            e.Graphics.DrawLine(SystemPens.ControlDark, rct0.Width - w, rct0.Y, rct0.Width - w, rct0.Bottom);

            #endregion

            #region -> Draw internal border

            Rectangle rct1 = new Rectangle(x + 1, e.CellBounds.Y, e.CellBounds.Width - 2, e.CellBounds.Height);
            using (Pen pen = new Pen(Color.FromArgb(213, 213, 213)))
            {
                // bottom border
                e.Graphics.DrawLine(pen, rct1.X, rct1.Bottom - 1, rct1.Width, rct1.Bottom - 1);
                // right border
                e.Graphics.DrawLine(pen, rct1.Width - w, rct1.Y, rct1.Width - w, rct1.Bottom);
            }

            #endregion
        }
        private void PaintCell(PaintingEventArgs e)
        {
            e.Graphics.FillRectangle(SystemBrushes.Window, e.CellBounds);
            ControlPaint.DrawBorder
                (
                    e.Graphics, e.CellBounds,
                    this.GridColor, 1, ButtonBorderStyle.None,
                    this.GridColor, 1, ButtonBorderStyle.None,
                    this.GridColor, 1, ButtonBorderStyle.Solid,
                    this.GridColor, 1, ButtonBorderStyle.Solid
                );
        }
        private void PaintEmptyArea(PaintEventArgs e)
        {
            if (this.FillEmptyArea)
            {

                NativeMethods.RECT RECT = new NativeMethods.RECT();
                NativeMethods.GetWindowRect(this.Handle, ref RECT);

                if (this.NeedPaintEmptyArea)
                {
                    #region -> Paint row empty area

                    // excluye borde inferior
                    e.Graphics.ExcludeClip(new Rectangle(0, RECT.Height - 1, RECT.Width, 1));
                    // excluye borde derecho
                    e.Graphics.ExcludeClip(new Rectangle(RECT.Width - 1, 0, 1, RECT.Height));

                    // obtiene indice de la ultima fila mostrada.
                    int lastRowVisible = Rows.GetLastRow(DataGridViewElementStates.Displayed);
                    // rectangulo predeterminado de la ultima fila mostrada, sobre todo
                    // si no hay datos.
                    Rectangle lastRowBounds = new Rectangle(0, ColumnHeadersHeight - RowTemplate.Height + 1, RECT.Width, RowTemplate.Height);
                    if (lastRowVisible > -1)
                        // si hay filas mostradas, obtenemos el rectangulo de la ultima.
                        lastRowBounds = GetRowDisplayRectangle(lastRowVisible, false);

                    // Alto de las filas.
                    int rowHeight = this.RowTemplate.Height; // lastRowBounds.Height;
                    // Alto del control.
                    int height = RECT.Height;
                    // Calcula la cantidad de filas necesario para llegar el area vacia.
                    int fillRows = ((height - lastRowBounds.Bottom) / rowHeight) + 1;
                    // Ciclo para pintar las filas.
                    for (int fillRow = 0; fillRow < fillRows; fillRow++)
                    {
                        int y = lastRowBounds.Bottom + (fillRow * rowHeight);

                        #region -> Paint row indicator

                        if (this.RowHeadersVisible)
                        {
                            Rectangle rctRowIndicatorBounds = new Rectangle(0, y, RowHeadersWidth, rowHeight);
                            PaintRowIndicator(new PaintingEventArgs(e.Graphics, rctRowIndicatorBounds, -1, -1));
                        }

                        #endregion

                        #region -> Paint columns to fill empty area

                        foreach (DataGridViewColumn col in Columns)
                        {
                            Rectangle colBounds = GetColumnDisplayRectangle(col.Index, true);
                            Rectangle cellBounds = new Rectangle(colBounds.X, y, colBounds.Width, rowHeight);

                            if (this.Columns.GetLastColumn(DataGridViewElementStates.Displayed, DataGridViewElementStates.None) == col)
                                cellBounds.Width = col.Width;

                            PaintCell(new PaintingEventArgs(e.Graphics, cellBounds, -1, -1));
                        }

                        #endregion
                    }

                    #endregion
                }
                if (this.NeedPaintColumnEmptyArea)
                {
                    #region -> Paint column empty area

                    int borderWidth = 1;
                    if (this.BorderStyle == BorderStyle.None)
                        borderWidth = 0;

                    // Obtiene al ancho de todas las filas mostradas.
                    int x = this.Columns.GetColumnsWidth(DataGridViewElementStates.Displayed) + (this.RowHeadersVisible ? this.RowHeadersWidth : 1) + borderWidth;
                    int y = borderWidth;

                    // Obtiene rectangulo para pintar encabezado
                    Rectangle rctColumn = new Rectangle(x, y, RECT.Width - x - borderWidth, this.ColumnHeadersHeight);
                    // Pinta encabezado
                    this.PaintColumnHeader(new PaintingEventArgs(e.Graphics, rctColumn, -1, -1));

                    // Obtiene el indice de la primera fila mostrada.
                    int firstRowDisplayed = this.Rows.GetFirstRow(DataGridViewElementStates.Displayed);

                    // Calcula la cantidad de filas a pintar.
                    int rowsToPaint = (int)Math.Ceiling(((double)RECT.Height - (double)this.ColumnHeadersHeight) / (double)this.RowTemplate.Height);

                    // Obtiene rectangulo para pintar filas.
                    Rectangle rct1 = Rectangle.Empty;
                    if (firstRowDisplayed > -1)
                        rct1 = this.GetRowDisplayRectangle(firstRowDisplayed, true);
                    else
                        rct1 = new Rectangle(x, this.ColumnHeadersHeight + borderWidth, RECT.Width - x, this.RowTemplate.Height);

                    Rectangle rowBounds = new Rectangle(x, rct1.Y, RECT.Width - x - borderWidth, rct1.Height);
                    for (int r = 0; r < rowsToPaint; r++)
                    {
                        //Trace.WriteLine(string.Format("{0} - {1}", firstRowDisplayed, rowBounds));
                        this.PaintCell(new PaintingEventArgs(e.Graphics, rowBounds, -1, -1));

                        int rowHeight = rowBounds.Height;
                        int nextRowHeight = this.RowTemplate.Height;
                        if (firstRowDisplayed > -1)
                        {
                            firstRowDisplayed++;
                            if (firstRowDisplayed < this.Rows.Count || firstRowDisplayed == this.NewRowIndex)
                                nextRowHeight = this.GetRowDisplayRectangle(firstRowDisplayed, true).Height;
                        }

                        rowBounds.Y += rowHeight;
                        rowBounds.Height = nextRowHeight;
                    }

                    #endregion
                }
            }
        }

        #endregion
    }

    internal class PaintingEventArgs : EventArgs
    {
        public Graphics Graphics { get; private set; }
        public Rectangle CellBounds { get; private set; }
        public int RowIndex { get; private set; }
        public int ColumnIndex { get; private set; }

        internal PaintingEventArgs(Graphics g, Rectangle cellBounds, int rowIndex, int colIndex)
        {
            this.Graphics = g;
            this.CellBounds = cellBounds;
            this.RowIndex = rowIndex;
            this.ColumnIndex = colIndex;
        }
    }
}
