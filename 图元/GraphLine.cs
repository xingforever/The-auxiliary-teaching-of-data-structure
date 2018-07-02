using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    public class GraphLine : Primitive
    {
        /// <summary>
        /// 起点
        /// </summary>
        public Point2d StartPoint { get; set; }
        /// <summary>
        /// 终点
        /// </summary>
        public Point2d EndPoint { get; set; }
        /// <summary>
        /// 临时点
        /// </summary>
        static PointF[] TempPoints = new PointF[2];
        //绘图点
        float x1, y1, x2, y2;

        /// <summary>
        /// 采用指定参数创建一个线段
        /// </summary>
        /// <param name="StartPoint">起点</param>
        /// <param name="EndPoint">终点</param>
        /// <returns>线段对象</returns>
        public GraphLine(Point2d StartPoint, Point2d EndPoint)
        {
            this.StartPoint = StartPoint;
            this.EndPoint = EndPoint;           

        }
        public GraphLine() : this(new Point2d(), new Point2d()) { }

        public override void Draw(Graphics g)
        {
            x1 = (float)StartPoint.X;
            y1 = (float)StartPoint.Y;
            x2 = (float)EndPoint.X;
            y2 = (float)EndPoint.Y;
            g.DrawLine(DrawPen, x1, y1, x2, y2);
        }

        public override void Extent()
        {
            AddExtent(StartPoint.X, StartPoint.Y);
            AddExtent(EndPoint.X, EndPoint.Y);
        }

        public override void FirstPoint(out double x, out double y)
        {
            x = StartPoint.X;
            y = StartPoint.Y;
        }

        public override void PanRotateZoom(Matrix matrix)
        {
            matrix.TransformPoints(TempPoints);
            StartPoint.X = TempPoints[0].X ;
            StartPoint.Y = TempPoints[0].Y ;
            EndPoint.X = TempPoints[1].X ;
            EndPoint.Y = TempPoints[1].Y ;
        }


        //public static bool LineSnap(Point2d StartPoint, Point2d EndPoint)
        //{
        //    if (IsOnLine(StartPoint, EndPoint, ViewPort.MouseSurveyX, ViewPort.MouseSurveyY) == false) return false;
        //    var s = StartPoint.Distance(EndPoint) / 3;
        //    var s1 = StartPoint.Distance(ViewPort.MouseSurveyX, ViewPort.MouseSurveyY);
        //    if (CurrentSnapTypeSet.HasFlag(SnapType.EndPoint))
        //    {
        //        if (s1 < s)
        //        {
        //            SnapResultType = SnapType.EndPoint;
        //            ResultX = StartPoint.X;
        //            ResultY = StartPoint.Y;
        //            return true;
        //        }
        //        else if (s1 > 2 * s)
        //        {
        //            SnapResultType = SnapType.EndPoint;
        //            ResultX = EndPoint.X;
        //            ResultY = EndPoint.Y;
        //            return true;
        //        }
        //    }
        //    if (CurrentSnapTypeSet.HasFlag(SnapType.MidPoint))
        //    {
        //        if (s1 > s && s1 < 2 * s)
        //        {
        //            SnapResultType = SnapType.MidPoint;
        //            ResultX = (StartPoint.X + EndPoint.X) / 2;
        //            ResultY = (StartPoint.Y + EndPoint.Y) / 2;
        //            return true;
        //        }
        //    }
        //    return false;
        //}
        //public override bool Snap()
        //{
        //    return LineSnap(StartPoint, EndPoint);
        //}
    }
}
