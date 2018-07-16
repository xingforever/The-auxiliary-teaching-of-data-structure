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
        public static bool SelectEnable { get; set; } = true;     
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
        public static List<Primitive> CurrentSelectedPrimitives { get; set; }= new List<Primitive>();
        /// <summary>
        /// 选择时绘笔
        /// </summary>
        public static Pen SelectPen { get; set; } = Pens.Cyan;
        /// <summary>
        /// 选择时填充
        /// </summary>
        public static Brush SelectBrush { get; set; } = Brushes.Cyan;
        /// <summary>
        /// 选中后绘笔
        /// </summary>
        public static Pen SelectedPen { get; set; } = Pens.Red;
        /// <summary>
        /// 选中后填充
        /// </summary>
        public static Brush SelectedBrush { get; set; } = Brushes.Red;
        /// <summary>
        /// 是否被选中
        /// </summary>
        public static bool IsSelected { get; set; } = false;
        /// <summary>
        /// 矩阵
        /// </summary>
        public static Matrix matrix { get; set; } = new Matrix();

        public PrimitiveSelect()
        {
            
        }

        /// <summary>
        /// 判断是否被选择
        /// </summary>
        /// <returns></returns>
        public virtual bool Select()
        {
            return false;
        }
        /// <summary>
        /// 绘制已选图元
        /// </summary>
        public static void SelectedDraw(Graphics g)
        {
            if (CurrentSelectedPrimitives.Count > 0)
            {
                foreach (var pri in CurrentSelectedPrimitives)
                {
                    Primitive.DrawPen = Primitive.SelectedPen;
                    Primitive.DrawBrush = Primitive.SelectedBrush;
                    pri.Draw(g);
                    Primitive.DrawPen = Primitive.NormalPen;
                    Primitive.DrawBrush = Primitive.NormalBrush;
                }
            }

        }
       
        /// <summary>
        /// 选择时绘制
        /// </summary>
        /// <param name="g"></param>
        public static void SelectDraw(Graphics g)
        {
            if (CurrentSelectionPrimitive != null)
            {
                
                if (PrimitiveSnap.SnapOn == true)
                {
                    Primitive.DrawPen = SelectPen;
                    Primitive.DrawBrush = SelectBrush;
                    CurrentSelectionPrimitive.Draw(g);
                    Primitive.DrawPen = Primitive.NormalPen;
                    Primitive.DrawBrush = Primitive.NormalBrush;
                }
                else
                {
                    Primitive.DrawPen = Primitive.NormalPen;
                    Primitive.DrawBrush = Primitive.NormalBrush;
                    CurrentSelectionPrimitive.Draw(g);                    
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

        public static bool IsOnCircle(Point2d p1,GraphCircle graphCircle)
        {
            return IsOnCircle(p1, graphCircle.Center, graphCircle.Radius, SelectDistance);
        }

        public static bool IsOnCircle(Point2d p1,Point2d center,double radius,double w)
        {
            var distance = p1.Distance(center);
            if (distance > (radius + w))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool IsOnRectangle(Point2d p1,GraphRectangle graphRectangle,double w)
        {
            return false;
        }
        public static bool IsOnRectangle(Point2d p1, Point2d leftTop,Point2d rightTop,Point2d leftBottom,Point2d rightBottom)
        {
            //
            return false;
        }

    }
}
