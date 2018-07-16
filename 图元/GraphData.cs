using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    public class GraphData : Primitive
    {
        /// <summary>
        /// 矩形框
        /// </summary>
        public  GraphRectangle DataRectangle { get; set; } 
        public GraphText DataText { get; set; }
        public GraphData(GraphRectangle rec, GraphText txt)
        {
            this.DataRectangle = rec;
            this.DataText = txt;
        }
        public GraphData() : this(
            new GraphRectangle(new Point2d (),10,20),
             new GraphText(new Point2d(), "A", 10))
        { }
        public void Init()
        {
            var starP = DataRectangle.StartPoint;
            var txtPoint = new Point2d((starP.X+1), (starP.Y + (DataRectangle.Height / 2)));
            DataText.TXTPosition = txtPoint;
        }

        public override void Draw(Graphics g)
        {
            Init();
            DataRectangle.Draw(g);
            DataText.Draw(g);

        }
       

        public override void Extent()
        {
            AddExtent(DataRectangle.StartPoint);
            AddExtent(DataRectangle.EndPoint);
            AddExtent(DataRectangle.StartPoint.X, DataRectangle.EndPoint.Y);
            AddExtent(DataRectangle.EndPoint.X, DataRectangle.StartPoint.Y);
        }

        public override void FirstPoint(out double x, out double y)
        {
            x = DataRectangle.StartPoint.X;
            y = DataRectangle.StartPoint.Y;
        }

        public override Primitive Copy()
        {
            throw new NotImplementedException();
        }
    }
}
