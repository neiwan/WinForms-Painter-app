using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    public class GrParamsController : IGrParams
    {
        public GrParamsController(Factory factory)
        {
            lineprop = factory.lineProp;
            fillprop = factory.fillProp;
        }
        private LineProps lineprop;
        private FillProps fillprop;
        public ILineProps LineProps { get { return lineprop; } }
        public IFillProps FillProps { get { return fillprop; } }
    }
    public interface IGrParams
    {
        ILineProps LineProps { get; }
        IFillProps FillProps { get; }
    }
    public interface ILineProps
    {
        float Width { get; set; }
        Color Color { get; set; }
    }
    public interface IFillProps
    {
        Color Color { get; set; }
    }
}
