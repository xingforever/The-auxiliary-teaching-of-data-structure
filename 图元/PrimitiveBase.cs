using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    /// <summary>
    /// 图元基础抽象类
    /// </summary>
   public abstract class PrimitiveBase
    {
       
        /// <summary>
        /// 图元
        /// </summary>
        public static double BasePointX { get; set; }
        /// <summary>
        /// 图元
        /// </summary>
        public static double BasePointY { get; set;  }



        /// <summary>
        /// 图元范围
        /// </summary>
        public abstract void Extent();
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Effective { get; set; }
        /// <summary>
        /// X最小值
        /// </summary>
        public static double Xmin { get; set; }
        /// <summary>
        /// X最大值
        /// </summary>
        public static double Xmax { get; set;  }
        /// <summary>
        /// Y最小值
        /// </summary>
        public static double Ymin { get; set; }
        /// <summary>
        /// Y最大值
        /// </summary>
        public static double Ymax { get; set; }
        /// <summary>
        ///添加范围
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public static void AddExtent(double x, double y)
        {
            if (x < Xmin) Xmin = x;
            if (x > Xmax) Xmax = x;
            if (y < Ymin) Ymin = y;
            if (y > Ymax) Ymax = y;
        }
    }
}
