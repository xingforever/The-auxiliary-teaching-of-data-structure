using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 数据结构辅助教学
{
    /// <summary>
    /// 视窗
    /// </summary>
    public static class ViewPort
    {
        /// <summary>
        /// 屏幕屏幕一毫米的像素值
        /// </summary>
        public static float MMPixels { get; set; }
        /// <summary>
        /// 最后操作点
        /// </summary>
        public static Point pointLast { get; set; }
        /// <summary>
        /// 矩阵
        /// </summary>
        public static Matrix matrix { get; set; }
        /// <summary>
        /// 逆矩阵
        /// </summary>
        public static Matrix invmatrix { get; set; }
        /// <summary>
        /// 辅助计算点数组
        /// </summary>
        static PointF[] points { get; set; }
        /// <summary>
        /// 鼠标X坐标
        /// </summary>
        public static double MouseSurveyX { get; set; }
        /// <summary>
        /// 鼠标Y坐标
        /// </summary>
        public static double MouseSurveyY { get; set; }
        public static float InvScale
        {
            get
            {
                var Elements = invmatrix.Elements;
                return (float)Math.Sqrt(Elements[0] * Elements[0] + Elements[1] * Elements[1]);
            }
        }
        static ViewPort()
        {
            matrix = new Matrix();
            Init();
            points = new PointF[1];
        }
        /// <summary>
        /// 初始化
        /// </summary>
        public static void Init()
        {
            matrix.Reset();
            matrix.Rotate(-90, MatrixOrder.Append);
            Invert();
        }
        static void Invert()
        {
            invmatrix = matrix.Clone();
            invmatrix.Invert();
        }
        //平移
        public static void Move(float dx, float dy)
        {
            matrix.Translate(dx, dy, MatrixOrder.Append);
            Invert();
        }
        //缩放
        public static void ScaleAt(float x, float y, float s)
        {
            matrix.Scale(s, s, MatrixOrder.Append);
            s = 1 - s;
            Move(x * s, y * s);
        }
        /// <summary>
        /// 在当前屏幕坐标处，旋转一个角度
        /// </summary>
        /// <param name="x">屏幕坐标X</param>
        /// <param name="y">屏幕坐标Y</param>
        /// <param name="angle">单位：弧度</param>
        public static void RotateAt(float x, float y, float angle)
        {
            matrix.RotateAt((float)(angle / Math.PI * 180), new PointF(x, y), MatrixOrder.Append);
            Invert();
        }
        public static void All()
        {
            Init();
            //Primitive.GetExtent();
            //var x1 = (float)(Primitive.Xmin - Primitive.BasePointX);
            //var y1 = (float)(Primitive.Ymin - Primitive.BasePointY);
            //var x2 = (float)(Primitive.Xmax - Primitive.BasePointX);
            //var y2 = (float)(Primitive.Ymax - Primitive.BasePointY);
            //var s1 = Form1.form1.pictureBox1.Height / (x2 - x1);
            //var s2 = Form1.form1.pictureBox1.Width / (y2 - y1);
            //if (s2 < s1) s1 = s2;
            //matrix.Scale(s1, s1, MatrixOrder.Append);
            //points[0].X = x2;
            //points[0].Y = y1;
            //matrix.TransformPoints(points);
            //matrix.Translate(0 - points[0].X, 0 - points[0].Y, MatrixOrder.Append);
            Invert();
        }
        public static void InvTransformPoint(float x, float y)
        {
            points[0].X = x;
            points[0].Y = y;
            invmatrix.TransformPoints(points);
            //MouseSurveyX = points[0].X + Primitive.BasePointX;
            //MouseSurveyY = points[0].Y + Primitive.BasePointY;
            //执行捕捉
            //Primitive.ResultX = MouseSurveyX;
            //Primitive.ResultY = MouseSurveyY;
            //if (GraphSnaps.SnapOn)
            //{
            //    GraphSnaps.DoSnap();
            //}
        }
        /// <summary>
        /// 测量坐标点转屏幕坐标
        /// </summary>
        /// <param name="x">测量坐标点X</param>
        /// <param name="y">测量坐标点Y</param>
        /// <param name="outX">屏幕坐标X</param>
        /// <param name="outY">屏幕坐标Y</param>
        public static void TransformPoint(double x, double y, out float outX, out float outY)
        {
            //points[0].X = (float)(x - Primitive.BasePointX);
            //points[0].Y = (float)(y - Primitive.BasePointY);
            matrix.TransformPoints(points);
            outX = points[0].X;
            outY = points[0].Y;
        }
        public static double SurveyLengthOfOneScreenMillimeter()
        {
            return InvScale * MMPixels;
        }
    }
}
