using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    /// <summary>
    /// 捕捉图元
    /// </summary>
  public  abstract  class PrimitiveSnap: PrimitiveSelect
    {
        /// <summary>
        /// 是否捕捉
        /// </summary>
        /// <returns></returns>
        public virtual bool Snap ()
        {
            return false;
        }
        /// <summary>
        /// 当前捕捉类型
        /// </summary>
        public static SnapType CurrentSnapTypeSet { get; set; }
        /// <summary>
        /// 是否捕捉成功
        /// </summary>
        public static bool SnapOn { get; set; }
        /// <summary>
        /// 捕捉的结果类型
        /// </summary>
        public static SnapType SnapResultType { get; set; }
        /// <summary>
        /// 捕捉画笔
        /// </summary>
        public static Pen SnapPen { get; set; } = Pens.Black;



        public  PrimitiveSnap()
        {
           
            CurrentSnapTypeSet = SnapType.MidPoint | SnapType.CenterPoint | SnapType.EndPoint;
            SnapOn = true;
            SnapResultType = SnapType.NULL;
        }
        public static bool DoSnap()
        {
            SnapResultType = SnapType.NULL;
            foreach (var pr in Primitive.CurrentGraphics)
            {
                if (pr.Snap()) return true;
            }
            //if (CMDEditBase.CurrentSelectionPrimitive != null)
            //{
            //    if (CMDEditBase.CurrentSelectionPrimitive.Snap()) return true;
            //}
            return false;
        }
        //public static void SnapSymbolDraw(Graphics g)
        //{
        //    if (SnapResultType == SnapType.NULL) return;
        //    var s = (float)ViewPort.SurveyLengthOfOneScreenMillimeter() * 2;
        //    var x = (float)(ResultX );
        //    var y = (float)(ResultY );
        //    SnapPen.Width = ViewPort.InvScale * 2;
        //    switch (SnapResultType)
        //    {
        //        case SnapType.EndPoint:
        //            g.DrawLine(SnapPen, x - s, y - s, x + s, y - s);
        //            g.DrawLine(SnapPen, x + s, y - s, x + s, y + s);
        //            g.DrawLine(SnapPen, x + s, y + s, x - s, y + s);
        //            g.DrawLine(SnapPen, x - s, y + s, x - s, y - s);
        //            break;
        //        case SnapType.MidPoint:
        //            g.DrawLine(SnapPen, x - s, y - s, x - s, y + s);
        //            g.DrawLine(SnapPen, x - s, y + s, x + s, y - s);
        //            g.DrawLine(SnapPen, x + s, y - s, x + s, y + s);
        //            g.DrawLine(SnapPen, x + s, y + s, x - s, y - s);
        //            break;
        //        case SnapType.CenterPoint:
        //            g.DrawEllipse(SnapPen, x - s, y - s, 2 * s, 2 * s);
        //            break;
        //        default:
        //            break;
        //    }
        //}
        public static bool IsOnLine(Point2d p1, Point2d p2, double x, double y)
        {
            return IsOnLine(p1, p2, x, y, SelectDistance);
        }
        public static bool IsOnLine(Point2d p1, Point2d p2, double x, double y, double w)
        {
            var s1 = p1.Distance(x, y);
            var s2 = p2.Distance(x, y);
            var s3 = p1.Distance(p2);
            var d = (s3 * s3 + s1 * s1 - s2 * s2) / (2 * s3);
            if (d >= 0 && d <= s3)
            {
                var hh = s1 * s1 - d * d;
                if (hh < w * w)
                {
                    return true;
                }
            }
            return false;
        }


    }
}
