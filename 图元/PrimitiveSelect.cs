using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
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
        public static  bool SelectEnable { get; set; }
        /// <summary>
        /// 是否多选
        /// </summary>
        public static  bool MultiPleSelect { get; set; }
        /// <summary>
        /// 选择距离
        /// </summary>
        public static double SelectDistance { get; set; }
        /// <summary>
        /// 当前图形
        /// </summary>
        public static Primitive CurrentSelectionPrimitive { get; set; }
        /// <summary>
        /// 当前已选图形
        /// </summary>
        public static List<Primitive> CurrentSelectedPrimitives { get; set; }
        /// <summary>
        /// 选择时绘笔
        /// </summary>
        public static Pen SelectPen = Pens.Cyan;
        /// <summary>
        /// 选择时填充
        /// </summary>
        public static Brush SelectBrush = Brushes.Cyan;
        /// <summary>
        /// 选中后绘笔
        /// </summary>
        public static Pen SelectedPen = Pens.Red;
        /// <summary>
        /// 选中后填充
        /// </summary>
        public static Brush SelectedBrush = Brushes.Red;
        /// <summary>
        /// 是否被选中
        /// </summary>
        public static bool IsSelected = false;
        /// <summary>
        /// 矩阵
        /// </summary>
        public static Matrix matrix = new Matrix();
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
        public virtual void Selected() {

            ;

        }

        public static void UnSelectDraw(Graphics g)
        {
            if (CurrentSelectionPrimitive != null)
            {

                if (IsSelected == false)
                {
                    Primitive.DrawPen = NormalPen;
                    Primitive.DrawBrush = NormalBrush;
                    CurrentSelectionPrimitive.Draw(g);
                }  
                
               
            }
        }
        public static void SelectDraw(Graphics g)
        {
            if (CurrentSelectionPrimitive != null)
            {
                
                if (IsSelected == false)
                {
                    Primitive.DrawPen = SelectPen;
                    Primitive.DrawBrush = SelectBrush;
                    CurrentSelectionPrimitive.Draw(g);
                    Primitive.DrawPen = Primitive.NormalPen;
                    Primitive.DrawBrush = Primitive.NormalBrush;
                }
                else
                {
                    Primitive.DrawPen = SelectedPen;
                    Primitive.DrawBrush = SelectedBrush;
                    CurrentSelectionPrimitive.Draw(g);
                    Primitive.DrawPen = Primitive.NormalPen;
                    Primitive.DrawBrush = Primitive.NormalBrush;
                }
            }
        }


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
