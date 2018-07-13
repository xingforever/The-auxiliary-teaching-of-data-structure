using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    /// <summary>
    /// 选中图元
    /// </summary>
   public  abstract  class PrimitiveSelect: PrimitiveBase
    {
        /// <summary>
        /// 是否启用选择
        /// </summary>
        public static   bool SelectEnable { get; set; }
        /// <summary>
        /// 选择距离
        /// </summary>
        public static double SelectDistance { get; set; }
        /// <summary>
        /// 判断是否被选择
        /// </summary>
        /// <returns></returns>
        public virtual bool Select()
        {
            return false;
        }
        /// <summary>
        /// 被选中后
        /// </summary>
        public virtual void Selected() { }

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
