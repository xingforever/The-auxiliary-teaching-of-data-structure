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
        public int Width { get; set; }
        public int Height { get; set; }

        Rectangle rec = new Rectangle();

       public GraphRectangle(Point2d p1,int width,int height)
        {
            this.StartPoint = p1;
            this.Width = width;
            this.Height = height;
            this.EndPoint = new Point2d(p1.X + width, p1.Y + height);
            Init();

        }

       public  GraphRectangle(Point2d p1,Point2d p2)
        {
            this.StartPoint = p1;
            this.EndPoint = p2;
            Init();
        }
        public GraphRectangle() : this(new Point2d(), new Point2d()) { }

        public void Reset(Point2d startP)
        {
            this.StartPoint = startP;
            this.EndPoint= new Point2d(startP.X + Width, startP.Y + Height);
            Init();
        }
        public void Init()
        {
            Point p = new Point();
            Point2d p1 = this.StartPoint;
            Point2d p2 = this.EndPoint;
            if (p1.X < p2.X && p1.Y < p2.Y)
            {
                //p = new Point((int)p2.X, (int)p1.Y);
                p = new Point((int)p1.X, (int)p1.Y);
            }
            if (p1.X < p2.X && p1.Y > p2.Y)
            {
                // p = new Point((int)p2.X, (int)p2.Y);
                p = new Point((int)p1.X, (int)p2.Y);
            }
            if (p1.X > p2.X && p1.Y > p2.Y)
            {
                //p = new Point((int)p1.X, (int)p2.Y);
                p = new Point((int)p2.X, (int)p2.Y);
            }
            if (p1.X > p2.X && p1.Y < p2.Y)
            {
                //p = new Point((int)p1.X, (int)p1.Y);
                p = new Point((int)p2.X, (int)p1.Y);
            }
            rec = new Rectangle(p, getSize());
        }

        public Size getSize()
        {
            Point2d p1 = this.StartPoint;
            Point2d p2 = this.EndPoint;           
            this.Width = (int)Math.Abs(p1.X - p2.X);
            this.Height = (int)Math.Abs(p1.Y - p2.Y);
            return new Size(Width,Height);
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

        public override bool Select()
        {
            var p = new Point ((int)(ViewPort.MouseSurveyX), (int)(ViewPort.MouseSurveyY));
            return rec.Contains(p);
        }
        public override bool Snap()
        {
            //鼠标位置是否在 线上
            //if (!Select()) return false;
            //var s = StartPoint.Distance(EndPoint) / 3;
            //var s1 = StartPoint.Distance(ViewPort.MouseSurveyX, ViewPort.MouseSurveyY);
            //if (CurrentSnapTypeSet.HasFlag(SnapType.EndPoint))
            //{
            //    if (s1 < s)
            //    {
            //        SnapResultType = SnapType.EndPoint;
            //        ResultX = StartPoint.X;
            //        ResultY = StartPoint.Y;
            //        return true;
            //    }
            //    else if (s1 > 2 * s)
            //    {
            //        SnapResultType = SnapType.EndPoint;
            //        ResultX = EndPoint.X;
            //        ResultY = EndPoint.Y;
            //        return true;
            //    }
            //}
            //if (CurrentSnapTypeSet.HasFlag(SnapType.MidPoint))
            //{
            //    if (s1 > s && s1 < 2 * s)
            //    {
            //        SnapResultType = SnapType.MidPoint;
            //        ResultX = (StartPoint.X + EndPoint.X) / 2;
            //        ResultY = (StartPoint.Y + EndPoint.Y) / 2;
            //        return true;
            //    }
            //}
            return false;
        }

        public Point2d[] GetMidPoints()
        {
            
            var w = Math.Abs(EndPoint.Y - StartPoint.Y);
            var h = Math.Abs(EndPoint.X - StartPoint.X);
            var s = w / 3;
            var s2 = h / 3;
            Point2d p1 = new Point2d(StartPoint.X, StartPoint.Y + s);
            Point2d p2 = new Point2d(StartPoint.X, StartPoint.Y + 2 * s);
            Point2d p3 = new Point2d(EndPoint.X, EndPoint.Y -s);
            Point2d p4 = new Point2d(EndPoint.X, EndPoint.Y - 2 * s);
            Point2d p5 = new Point2d(StartPoint.X - s2, StartPoint.X);
            Point2d p6 = new Point2d(StartPoint.X - 2*s2, StartPoint.X);
            Point2d p7 = new Point2d(EndPoint.X + s2, EndPoint.Y);
            Point2d p8 = new Point2d(EndPoint.X + 2 * s2, EndPoint.Y );
            Point2d[] point2Ds = new Point2d[] { p1, p2, p3, p4, p5, p6, p7, p8 };
            return point2Ds;

        }
    }
}
