using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;

namespace MEP.Windows.Controls
{
    public class NativeMethods
    {
        [DllImport("user32.dll")]
        internal static extern bool GetWindowRect(IntPtr hWnd, ref RECT rect);

        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            public int Left, Top, Right, Bottom;
            public RECT(Rectangle bounds)
            {
                this.Left = bounds.Left;
                this.Top = bounds.Top;
                this.Right = bounds.Right;
                this.Bottom = bounds.Bottom;
            }
            public void Inflate(int x, int y)
            {
                this.Left -= x;
                this.Top -= y;
                this.Right += x;
                this.Bottom += y;
            }
            public Rectangle ToRectangle()
            {
                return Rectangle.FromLTRB(Left, Top, Right, Bottom);
            }
            public int Height
            {
                get { return this.Bottom - this.Top; }
            }
            public int Width
            {
                get { return this.Right - this.Left; }
            }
        }

        internal const int WM_SETFOCUS = 0x0007;
    }
}
