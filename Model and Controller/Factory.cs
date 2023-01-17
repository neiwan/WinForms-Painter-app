using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    public enum ItemType { None, Line, Rect }
    public class Factory : IFactory
    {
        public ItemType ItemType { get; set; }
        public Store store { get; set; }
        public LineProps lineProp { get; set; }
        public FillProps fillProp { get; set; }
        public Factory(Store store)
        {
            this.store = store;
            ItemType = ItemType.Line;
            lineProp = new LineProps(System.Drawing.Color.Black, 3f);
            fillProp = new FillProps(System.Drawing.Color.Transparent);
        }
        public Item CreateItem(int x, int y)
        {
            PropList property = new PropList();
            LineProps tmpConProp = new LineProps(lineProp.Color, lineProp.Width);
            if (ItemType == ItemType.Line)
            {
                property.Add(tmpConProp);
                Line line = new Line(new Frame(x, y, x + 100, y + 100), property);
                store.Add(line);
                return line;
            }
            else
            {
                FillProps tmpFillProp = new FillProps(fillProp.Color);
                property.Add(tmpConProp);
                property.Add(tmpFillProp);
                Rect rect = new Rect(new Frame(x, y, x+100, y+100), property);
                store.Add(rect);
                return rect;
            }
        }
    }
    public interface IFactory
    {
        ItemType ItemType { get; set; }
        Item CreateItem(int x, int y);
    }
}
