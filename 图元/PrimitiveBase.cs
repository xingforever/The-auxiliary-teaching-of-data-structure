using System;
using System.Collections.Generic;
using System.Drawing;
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
        /// 图元X
        /// </summary>
        public static double ResultX { get; set; }
        /// <summary>
        /// 图元Y
        /// </summary>
        public static double ResultY { get; set;  }
      
        /// <summary>
        /// 是否启用绘制
        /// </summary>
        public bool Effective { get; set; }
        /// <summary>
        /// X最小值
        /// </summary>
        public static double Xmin { get; set; } = 0;
        /// <summary>
        /// X最大值
        /// </summary>
        public static double Xmax { get; set; } = 300;
        /// <summary>
        /// Y最小值
        /// </summary>
        public static double Ymin { get; set; } = 0;
        /// <summary>
        /// Y最大值
        /// </summary>
        public static double Ymax { get; set; } = 600;

        /// <summary>
        /// 图元范围
        /// </summary>
        public abstract void Extent();
        /// <summary>
        /// 绘制图元
        /// </summary>
        /// <param name="g"></param>
        public abstract void Draw(Graphics g);
        /// <summary>
        /// 图元转换
        /// </summary>
        public virtual void Trans() { }
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
        public static void AddExtent(PointF p)
        {
            var x=  p.X;
            var y = p.Y;
            if (x < Xmin) Xmin = x;
            if (x > Xmax) Xmax = x;
            if (y < Ymin) Ymin = y;
            if (y > Ymax) Ymax = y;
        }
    }
}
