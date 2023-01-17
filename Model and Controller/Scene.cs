using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    public interface IGrController
    {
        void SetPort(Graphics g);
        void Repaint();
    }
    public class Scene : IGrController
    {
        public DrawSystem DS { get; set; }
        public Store store { get; set; }
        public Scene(Store store, DrawSystem DS)
        {
            this.store = store;
            this.DS = DS;
        }
        public void Repaint()
        {
            DS.g.Clear(Color.White);

            for (int i = 0; i< store.Count; i++)
            {
                store[i].Draw(DS);
            }
        }

        public void SetPort(Graphics g)
        {
            DS.g = g;
        }
    }
}
