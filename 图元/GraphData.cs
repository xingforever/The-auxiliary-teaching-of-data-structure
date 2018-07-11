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
        public  GraphRectangle graphRectangle { get; set; } 
        /// <summary>
        /// 文字
        /// </summary>
        public  string dataText { get; set; }
        /// <summary>
        /// 文字位置(矩形中心)
        /// 文字高度不大于矩形高度,长度不大于矩形长度
        /// </summary>
        public  Point2d textLocation { get; set; }

        public override void Draw(Graphics g)
        {
            //绘制矩形框,在矩形框内添加文字
            //先获取文字,在生成矩形框  文字大小固定/? 依据屏幕大小或者固定大小
            //graphRectangle.Init();
            graphRectangle.Draw(g);
        }
       

        public override void Extent()
        {
            AddExtent(graphRectangle.StartPoint);
            AddExtent(graphRectangle.EndPoint);
            AddExtent(graphRectangle.StartPoint.X, graphRectangle.EndPoint.Y);
            AddExtent(graphRectangle.EndPoint.X, graphRectangle.StartPoint.Y);
        }

        public override void FirstPoint(out double x, out double y)
        {
            x = graphRectangle.StartPoint.X;
            y = graphRectangle.StartPoint.Y;
        }
    }
}
