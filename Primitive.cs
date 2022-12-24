using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Painter
{
    public abstract class Primitive : Item
    {
        protected PropList propList;
        public Primitive(PropList propList, Frame frame) : base(frame)
        {
            this.propList = propList.Clone();
        }
        public override void Draw(DrawSystem DS)
        {
            propList.Apply(DS);
            DrawGeometry(DS);
        }
        public abstract void DrawGeometry(DrawSystem DS);
    }
    public class Line : Primitive
    {
        public Line(Frame frame, PropList propList) : base(propList, frame)
        {

        }
        public override void DrawGeometry(DrawSystem DS)
        {
            DS.DrawLine(this.frame.X1, this.frame.Y1, this.frame.X2, this.frame.Y2);
        }
    }
    public class Rect : Primitive
    {
        public Rect(Frame frame, PropList propList) : base(propList, frame)
        {

        }
        public override void DrawGeometry(DrawSystem DS)
        {
            DS.DrawRect(this.frame.X1, this.frame.Y1, this.frame.X2, this.frame.Y2);
        }
    }
}
