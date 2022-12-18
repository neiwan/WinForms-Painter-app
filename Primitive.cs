using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Painter
{
    public abstract class Primitive : Item
    {
        protected PropList propList;
        public Primitive()
        {
            this.propList = new PropList();
        }
        public override void Draw(DrawSystem DS)
        {
            propList.Apply(DS);
            DrawGeometry(DS);
        }
        public virtual void AddProps(Props prop)
        {
            propList.Add(prop);
        }
        public abstract void DrawGeometry(DrawSystem DS);
    }
    public class Line : Primitive
    {
        public Line(int x1, int y1, int x2, int y2)
        {
            this.frame.X1 = x1;
            this.frame.X2 = x1;
            this.frame.X3 = x2;
            this.frame.X4 = x2;
            this.frame.Y1 = y1;
            this.frame.Y2 = y1;
            this.frame.Y3 = y2;
            this.frame.Y4 = y2;
        }
        public override void DrawGeometry(DrawSystem DS)
        {
            DS.DrawLine(this.frame.X1, this.frame.Y1, this.frame.X3, this.frame.Y3);
        }
        public override void AddProps(Props prop)
        {
            propList.Add(prop);
        }
    }
    public class Rect : Primitive
    {
        public Rect(int x1, int y1, int width, int height)
        {
            this.frame.X1 = x1;
            this.frame.Y1 = y1;
            this.frame.X2 = x1 + width;
            this.frame.Y2 = y1;
            this.frame.X3 = x1 + width;
            this.frame.Y3 = y1 + height;
            this.frame.X4 = x1;
            this.frame.Y4 = y1 + height;
        }
        public override void DrawGeometry(DrawSystem DS)
        {
            DS.DrawRect(this.frame.X1, this.frame.Y1, this.frame.X3, this.frame.Y3);
        }
        public override void AddProps(Props prop)
        {
            propList.Add(prop);
        }
    }
    public class PropList
    {
        private List<Props> list;
        public PropList()
        {
            this.list = new List<Props>();
        }
        public void Add(Props prop)
        {
            this.list.Add(prop);
        }
        public void Apply(DrawSystem DS)
        {
            foreach (Props prop in this.list)
            {
                prop.Apply(DS);
            }
        }
    }
    public abstract class Props
    {
        abstract public void Apply(DrawSystem DS); 
    }
    public class FillProps : Props
    {
        private Color fill = Color.Transparent;
        public FillProps(Color fill)
        {
            this.fill = fill;
        }
        public override void Apply(DrawSystem DS)
        {
            DS.brushColor = fill;
        }
    }
    public class LineProps : Props
    {
        private Color color = Color.Black;
        private float width = 1F;
        public LineProps(Color color, float width)
        {
            this.color = color;
            this.width = width;
        }
        public LineProps(Color color)
        {
            this.color = color;
        }
        public LineProps(float width)
        {
            this.width = width;
        }
        public override void Apply(DrawSystem DS)
        {
            DS.penColor = color;
            DS.penThick = width;
        }
    }
}
