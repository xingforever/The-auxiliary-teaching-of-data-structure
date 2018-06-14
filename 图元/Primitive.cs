using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    /// <summary>
    /// 图元
    /// </summary>
    public abstract  class Primitive:PrimitiveCMD
    {
        /// <summary>
        /// 所有图元集合
        /// </summary>
        public static  List<Primitive> CurrentGraphics { get; set; }
        /// <summary>
        /// 位于栅格系统的行号
        /// </summary>
        public int RowNum { get; set; }
        /// <summary>
        /// 位于栅格系统的列号
        /// </summary>
        public int ColumnNum { get; set; }
        /// <summary>
        /// 绘图笔
        /// </summary>
        public static  Pen pen { get; set; }
        /// <summary>
        /// 填充
        /// </summary>
        public static Brush brush { get; set; }
       
        /// <summary>
        /// 首点
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public abstract void FirstPoint(out double x, out double y);
        /// <summary>
        /// 获取所有图元范围
        /// </summary>
        public static void GetExtent()
        {
            if (CurrentGraphics.Count == 0) return;          
            else
            {
                double x, y;
                CurrentGraphics[0].FirstPoint(out x, out y);
                Xmin = Xmax = x;
                Ymin = Ymax = y;
            }
            foreach (var item in CurrentGraphics)
            {
               //计算每个图元范围
                item.Extent();
            }
            var w = Primitive.pen.Width;
            Xmin -= w;
            Xmax += w;
            Ymin -= w;
            Ymax += w;
        }
    }
}
