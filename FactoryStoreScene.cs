using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    public class Scene
    {
        Store store;
        public Scene(Store store, DrawSystem DS)
        {
            this.store = store;
        }
        public void Repaint()
        {
            store.Repaint();
        }
    }
    public class Store
    {
        private List<Item> list;
        public Store()
        {
            this.list = new List<Item>();
        }
        public void Repaint()
        {
            foreach (Item item in this.list)
            {

            }
        }
        public void Add(Item item)
        {
            this.list.Add(item);
        }
    }
    public class Factory
    {
        Store store;
        public Factory(Store store)
        {
            this.store = store;
        }
        ItemType ItemType { get; set; }
        public void CreateItem(int x, int y)
        {
            
        }
    }
    public enum ItemType {itNone, itLine, itRect}

    public class Model : IModel
    {
        DrawSystem DS;
        GrParamsController grParams;
        Factory factory;
        Store store;
        Scene scene;
        public Model()
        {
            this.store = new Store();
            this.factory = new Factory(store);
            this.grParams = new GrParamsController(factory);
            this.scene = new Scene(store, DS);
        }
        public IGrParams GrParams { get; }
        public ItemType CreatingItemType { get; set; }
        public void CreateItem(int x, int y)
        {
            
        }
        public void Repaint()
        {
            
        }
        public void SetGrPort(Graphics graphics, int Width, int Height)
        {
            
        }
    }
    public class GrParamsController : IGrParams
    {
        Factory factory;
        public GrParamsController(Factory factory)
        {
            this.factory = factory;
        }
        public ILineProps LineProps { get; }
        public IFillProps FileProps { get; }
    }
    public interface IModel
    {
        IGrParams GrParams { get; }
        void SetGrPort(Graphics graphics,int Width,int Height);
        ItemType CreatingItemType { get; set; }
        void CreateItem(int x, int y);
        void Repaint();
    }
    public interface IGrParams
    {
        ILineProps LineProps { get; }
        IFillProps FileProps { get; }
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
    public class Controller : IController
    {
        public IModel IModel { get; set; }
        public EventHandler EventHandler { get; }
        public Controller(IModel iModel)
        {
            this.IModel = iModel;
            this.EventHandler = new EventHandler(this.IModel);
        }
        public void SetItemCreationRegime(ItemType it)
        {
            IModel.CreateItem(1, 2);
        }
    }
    public class EventHandler : IEventHandler
    {
        IModel iModel;
        public EventHandler(IModel iModel)
        {
            this.iModel = iModel;
        }
        public void LeftMouseUp(int x, int y)
        {

        }
    }

     public interface IEventHandler
    {
        void LeftMouseUp(int x, int y);
    }
    public interface IController
    {
        EventHandler EventHandler { get; }
        void SetItemCreationRegime(ItemType itemType);
        IModel IModel { get; set; }
    }
}
