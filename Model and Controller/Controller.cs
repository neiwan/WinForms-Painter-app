using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    public class Controller : IController
    {
        public IModel IModel { get; set; }
        public IEventHandler IEventHandler { get; }
        public Controller(IModel Model)
        {
            this.IModel = Model;
            this.IEventHandler = new EventHandler(this.IModel);
        }
    }
    public interface IController
    {
        IEventHandler IEventHandler { get; }
        IModel IModel { get; set; }
    }
}
