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
    public abstract  class Primitive:PrimitiveAffine
    {
        /// <summary>
        /// 所有图元集合
        /// </summary>
        public static  List<Primitive> CurrentGraphics { get; set; } = new List<Primitive>();

        /// <summary>
        /// 绘图笔
        /// </summary>
        public static  Pen DrawPen { get; set; }
        /// <summary>
        /// 填充
        /// </summary>
        public static Brush DrawBrush { get; set; }
        public static Pen NormalPen = Pens.Black;
        public static Brush NormalBrush = Brushes.Black;

        public   Primitive()
        {
            DrawPen = NormalPen;
            DrawBrush = NormalBrush;
           

        }


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
            var w = Primitive.DrawPen.Width;
            Xmin -= w;
            Xmax += w;
            Ymin -= w;
            Ymax += w;
        }

       
    }
}
