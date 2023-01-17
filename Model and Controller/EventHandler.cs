using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    public class EventHandler : IEventHandler
    {
        private IModel iModel;
        public IModel Model { get { return iModel; } set { iModel = value; } }
        public EventHandler(IModel iModel)
        {
           this.iModel = iModel;

        }
        public void LeftMouseUp(int x, int y)
        {
            iModel.Factory.CreateItem(x, y);
        }
    }
    public interface IEventHandler
    {
        void LeftMouseUp(int x, int y);
    }

}
