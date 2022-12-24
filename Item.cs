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
        public Item(Frame frame)
        {
            this.frame = frame;
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
        public void Add(Frame f)
        {
            List<int> listX = new List<int> { X1, X2, f.X1, f.X2 };
            List<int> listY = new List<int> { Y1, Y2, f.Y1, f.Y2 };
            int x1 = listX.Min();
            int y1 = listY.Min();
            int y2 = listY.Max();
            int x2 = listX.Max();
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }
        public Frame(int x1, int y1, int x2, int y2)
        {
            this.X1 = x1;
            this.Y1 = y1;
            this.X2 = x2;
            this.Y2 = y2;
        }
        public Primitive DrawFrame(DrawSystem DS)
        {
            return new Rect(new Frame(X1, Y1, X2, Y2), new PropList());

        }
    }
    public class Group : Item
    {
        private List<Item> groupList;
        public Group(List<Item> items) : base(null)
        {
            this.groupList = new List<Item>();
            foreach (Item item in items)
            {
                this.Add(item);
            }
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
            if (this.frame == null)
            {
                this.frame = new Frame(item.frame.X1, item.frame.Y1, item.frame.X2, item.frame.Y2);
                this.groupList.Add(item);
            }
            else
            {
                this.frame.Add(item.frame);
                this.groupList.Add(item);
            }
        }
    }
}
