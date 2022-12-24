using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Painter
{
    public class DrawSystem
    {
        Graphics g;
        public DrawSystem(Graphics g)
        {
            this.g = g;
            g.Clear(Color.White);
        }
        public void DrawRect(int x1, int y1, int x2, int y2)
        {
            int width = Math.Abs(x1 - x2);
            int height = Math.Abs(y1 - y2);
            x1 = new List<int>() { x1, x2 }.Min();
            y1 = new List<int>() { y1, y2 }.Min();
            g.FillRectangle(brush, x1, y1, width, height);
            g.DrawRectangle(pen, x1, y1, width, height);
            
        }
        private Pen pen = new Pen(Color.Black, 1F);
        private SolidBrush brush = new SolidBrush(Color.Transparent);
        public Color penColor { set => pen.Color = value; }
        public float penThick { set => pen.Width = value; }
        public Color brushColor { set => brush.Color = value; }
        public void DrawLine(int x1, int y1, int x2, int y2)
        {
            g.DrawLine(pen, x1, y1, x2, y2);
        }
    }
}
