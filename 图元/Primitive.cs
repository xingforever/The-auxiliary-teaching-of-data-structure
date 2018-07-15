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
       

        public   Primitive()
        {
            DrawPen = NormalPen;
            DrawPen.StartCap = System.Drawing.Drawing2D.LineCap.Round;
            DrawBrush = NormalBrush;          

        }

        /// <summary>
        /// 是否被选中
        /// </summary>
        /// <returns></returns>
        public static  bool DoSelect()
        {
            foreach (var pr in CurrentGraphics)
            {
                if (pr.Select())
                {
                    Primitive.CurrentSelectionPrimitive = pr;
                    return true;
                }
                   
            }
            return false;
        }
        /// <summary>
        /// 是否捕捉成功
        /// </summary>
        /// <returns></returns>
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
