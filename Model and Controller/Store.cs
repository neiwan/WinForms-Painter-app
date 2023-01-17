using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    public class Store
    {
        private List<Item> list;
        public Store()
        {
            this.list = new List<Item>();
        }
        public void Add(Item item)
        {
            this.list.Add(item);
        }
        public Item this[int i] { get { return this.list[i]; } }
        public int Count { get { return this.list.Count; } }
    }
}
