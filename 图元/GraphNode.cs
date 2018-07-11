using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    public class GraphNode : Primitive
    {
        //绘制Node 应该开启栅格网系统 ? 获取绘图点的栅格位置,
        //整体缩小 放大  在节点移动箭头跟着移动

        //一个圆 圆中包含文字 含有四个接点
         public Circle NodeCircle { get; set; }
        /// <summary>
        /// 节点文字- 落在圆心
        /// </summary>
        public GraphText NodeText { get; set; }

        float x, y, r;

        public GraphNode(Circle circle, GraphText txt)
        {
            this.NodeCircle = circle;
            this.NodeText = txt ;
        }
        public GraphNode() : this(new Circle(), new GraphText()) { }

        public void Init()
        {
            x = (float)NodeCircle.Center.X;
            y = (float)NodeCircle.Center.Y;
            r = (float)NodeCircle.Radius;
            NodeText.Position = NodeCircle.Center;
            
        }

        public override void Draw(Graphics g)
        {
            //转制float 进行 绘制圆
            //文字需要 进行矩形变化进行绘制
            g.DrawEllipse(DrawPen, x - r, y - r, 2 * r, 2 * r);

        }

        public override void Extent()
        {
            var Center = NodeCircle.Center;
            var Radius = NodeCircle.Radius;
            AddExtent(Center.X - Radius, Center.Y - Radius);
            AddExtent(Center.X - Radius, Center.Y + Radius);
            AddExtent(Center.X + Radius, Center.Y - Radius);
            AddExtent(Center.X + Radius, Center.Y + Radius);
         

        }

        public override void FirstPoint(out double x, out double y)
        {
            x = NodeCircle.Center.X;
            y = NodeCircle.Center.Y;
        }
    }
}
