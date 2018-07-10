using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
   public  class GraphRectangle:Primitive
    {
        /// <summary>
        /// 开会绘制起点
        /// </summary>
        public  Point2d StartPoint { get; set; }
        /// <summary>
        /// 起点的对角点
        /// </summary>
        public Point2d EndPoint { get; set; }

        Rectangle rec = new Rectangle();

       public  GraphRectangle(Point2d p1,Point2d p2) {
            this.StartPoint = p1;
            this.EndPoint = p2;
            Init();
        }
        public GraphRectangle() : this(new Point2d(), new Point2d()) { }

        public void Init()
        {
            Point p = new Point();
            Point2d p1 = this.StartPoint;
            Point2d p2 = this.EndPoint;
            if (p1.X < p2.X && p1.Y < p2.Y)
            {
                p = new Point((int)p2.X, (int)p1.Y);
            }
            if (p1.X < p2.X && p1.Y > p2.Y)
            {
                p = new Point((int)p2.X, (int)p2.Y);
            }
            if (p1.X > p2.X && p1.Y > p2.Y)
            {
                p = new Point((int)p1.X, (int)p2.Y);
            }
            if (p1.X > p2.X && p1.Y < p2.Y)
            {
                p = new Point((int)p1.X, (int)p1.Y);
            }
            rec = new Rectangle(p, getSize(p1, p2));
        }

        public Size getSize(Point2d p1, Point2d p2)
        {
            int iWidth =(int)Math.Abs(p1.X - p2.X);
            int iHeight = (int)Math.Abs(p1.Y - p2.Y);
            return new Size(iWidth, iHeight);
        }
        public override void Draw(Graphics g)
        {
            g.DrawRectangle(DrawPen, rec);
        }

        public override void Extent()
        {
            AddExtent(StartPoint);
            AddExtent(EndPoint);
            AddExtent(StartPoint.X, EndPoint.Y);
            AddExtent(EndPoint.X, StartPoint.Y);

        }

        public override void FirstPoint(out double x, out double y)
        {
            x = y = 0;
            x = StartPoint.X;
            y = StartPoint.Y;
        }
    }
}
