using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Painter
{
    public class Item
    {
        public Frame frame;
        public Item()
        {
            frame = new Frame();
        }
        public virtual void Draw(DrawSystem DS)
        {

        }
    }
    public class Frame
    {
        public int X1 { get; set; }
        public int X2 { get; set; }
        public int Y1 { get; set; }
        public int Y2 { get; set; }
        public int X3 { get; set; }
        public int X4 { get; set; }
        public int Y3 { get; set; }
        public int Y4 { get; set; }
        public void Add(Frame f)
        {
            List<int> listX = new List<int> { X1, X2, X3, X4, f.X1, f.X2, f.X3, f.X4};
            List<int> listY = new List<int> { Y1, Y2, Y3, Y4, f.Y1, f.Y2, f.Y3, f.Y4 };
            int x1 = listX.Min();
            int y1 = listY.Min();
            int y2 = listY.Max();
            int x2 = listX.Max();
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y1;
            this.X3 = x2;
            this.Y3 = y2;
            this.X4 = x1;
            this.Y4 = y2;
        }
        public Primitive DrawFrame(DrawSystem DS)
        {
            if (X1 == X2 && X4 == X3 && Y1 == Y2 && Y4 == Y3)
            {
                Line item2;
                return item2 = new Line(X1, Y1, X3, Y3);
            }
            else
            {
                Rect item2;
                return item2 = new Rect(X1, Y1, X3, Y3);
            }

        }
    }
    public class Group : Item
    {
        private List<Item> groupList;
        public Group(Item item1, Item item2)
        {
            this.groupList = new List<Item>();
            this.Add(item1);
            this.Add(item2);
        }
        public override void Draw(DrawSystem DS)
        {
            foreach (Item item in groupList)
            {
                item.Draw(DS);
            }
        }
        public void Add(Item item)
        {
            this.frame.Add(item.frame);
            this.groupList.Add(item);
        }
    }
}
