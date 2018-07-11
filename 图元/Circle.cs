using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    public class Circle
    {
        public Point2d Center { get; set; }
        public  double Radius { get; set; }

        public  Circle(Point2d center,double radius)
        {
            this.Center = center;
            this.Radius = radius;
        }
        public Circle() : this(new Point2d(), 1.0) { }

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

    }
}
