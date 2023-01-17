using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Painter
{
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
        public PropList Clone()
        {
            PropList clone = new PropList();
            for (int i = 0; i < list.Count; i++)
            {
                clone.Add(list[i].Clone());
            }
            return clone;
        }
        public int Count { get { return this.list.Count; } }
        public Props this[int i] { get { return this.list[i]; } }
    }
    public abstract class Props
    {
        abstract public void Apply(DrawSystem DS);
        abstract public Props Clone();
    }
    public class FillProps : Props, IFillProps
    {
        public Color Color { get => fill; set => fill = value; }
        private Color fill = Color.Transparent;
        public FillProps(Color fill)
        {
            this.fill = fill;
        }
        public override void Apply(DrawSystem DS)
        {
            DS.brushColor = fill;
        }
        public override Props Clone()
        {
            return new FillProps(fill);
        }
    }
    public class LineProps : Props, ILineProps
    {
        public Color Color { get => color; set => color = value; }
        public float Width { get => width; set => width = value; }
        private Color color = Color.Black;
        private float width = 1F;
        public LineProps(Color color, float width)
        {
            this.color = color;
            this.width = width;
        }
        public override void Apply(DrawSystem DS)
        {
            DS.penColor = color;
            DS.penThick = width;
        }
        public override Props Clone()
        {
            return new LineProps(color, width);
        }
    }
}
