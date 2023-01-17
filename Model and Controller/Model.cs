using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    public interface IModel
    {
        IGrParams GrParams { get; }
        IGrController GrController { get; }
        IFactory Factory { get; }
    }
    public class Model : IModel
    {
        private Factory factory;
        private GrParamsController grParams;
        private Scene scene;

        public Model(DrawSystem DS)
        {
            Store store = new Store();
            factory = new Factory(store);
            grParams = new GrParamsController(factory);
            scene = new Scene(store, DS);
        }
        IGrParams IModel.GrParams { get { return grParams; } }
        IGrController IModel.GrController { get { return scene; } }
        IFactory IModel.Factory { get { return factory; } }
    }
}
