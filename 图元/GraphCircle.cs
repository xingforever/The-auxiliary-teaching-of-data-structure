using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    public class GraphCircle:Primitive
    {
        public Point2d Center { get; set; }
        public  double Radius { get; set; }

        public  GraphCircle(Point2d center,double radius)
        {
            this.Center = center;
            this.Radius = radius;
        }
        public GraphCircle() : this(new Point2d(), 1.0) { }

        
        public  Point2d [] GetCircleSelect()
        {
            Point2d p1 = new Point2d(Center.X, Center.Y + Radius);
            Point2d p2 = new Point2d(Center.X, Center.Y - Radius);
            Point2d p3 = new Point2d(Center.X + Radius, Center.Y);
            Point2d p4 = new Point2d(Center.X - Radius, Center.Y);
            Point2d[] selected = new Point2d[4] { p1, p2, p3, p4 };
            return selected;
        }
        public  bool  IsInCircle(Point2d p)
        {
            var distance = Center.Distance(p);
            if (distance >= Radius){
                return false;
            }
            else {
                return true;
            }
                
            
        }

        public override bool Select()
        {
            var s = Center.Distance(ViewPort.MouseSurveyX, ViewPort.MouseSurveyY);
            if (Math.Abs(s - Radius) < SelectDistance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public override void FirstPoint(out double x, out double y)
        {
           x=Center.X;
           y=Center.Y;
        }

        public override void Extent()
        {   
            AddExtent(Center.X - Radius, Center.Y - Radius);
            AddExtent(Center.X - Radius, Center.Y + Radius);
            AddExtent(Center.X + Radius, Center.Y - Radius);
            AddExtent(Center.X + Radius, Center.Y + Radius);
        }

        public override void Draw(Graphics g)
        {
           var x = (float)Center.X;
            var r =(float) Radius;
            var y =(float) Center.Y;           
            g.DrawEllipse(DrawPen, x - r, y - r, 2 * r, 2 * r);
        }
    }
}
