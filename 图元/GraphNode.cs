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
        

        //一个圆 圆中包含文字 含有四个接点
         public GraphCircle NodeCircle { get; set; }
        /// <summary>
        /// 节点文字- 落在圆心
        /// </summary>
        public GraphText NodeText { get; set; }

       

        public GraphNode(GraphCircle circle, GraphText txt)
        {
            this.NodeCircle = circle;
            
            this.NodeText = txt ;
        }
        public GraphNode() : this(
            new GraphCircle(new Point2d(),15.0),            
             new GraphText(new Point2d (),"A",10)) { }

        public void Init()
        {
            var x = (float)NodeCircle.Center.X;
            var y = (float)NodeCircle.Center.Y;
            var r = (float)NodeCircle.Radius;
            NodeText.TXTPosition = NodeCircle.Center;
            
        }

        public override void Draw(Graphics g)
        {
            NodeCircle.Draw(g);//绘制圆
            NodeText.Draw(g);//绘制文字
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
