using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
   public  class GraphArrow:GraphLine
    {

        /// <summary>
        /// 绘制带箭头的直线 箭头的宽度大小 根据屏幕设置
        /// </summary>
        /// <param name="g"></param>
        public override void Draw(Graphics g)
        {
           var  x1 = (float)StartPoint.X;
            var y1 = (float)StartPoint.Y;
           var  x2 = (float)EndPoint.X;
           var  y2 = (float)EndPoint.Y;
            var arrawPen = new Pen(Color.Black,2.5f);
            arrawPen.StartCap = LineCap.Round;
            arrawPen.EndCap = LineCap.ArrowAnchor;
            g.DrawLine(arrawPen, x1, y1, x2, y2);
        }

    }
}
