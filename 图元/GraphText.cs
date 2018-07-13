using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    public class GraphText :Primitive
    {
        
        static Point2d p1 = new Point2d();
        static Point2d p2 = new Point2d();
        /// <summary>
        /// 静态存储文字
        /// </summary>
        public static string BaseTxt { get; set; } = "";
        /// <summary>
        /// 文字内容
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 大小 正数 -- 测量坐标系，单位：米；负数-- 图纸坐标系 ，单位：毫米
        /// </summary>
        public double TxtSize { get; set; }
        /// <summary>
        /// 旋转角度
        /// </summary>
        public Azimuth TxtRotationAngle { get; set; }
        /// <summary>
        /// 位置坐标
        /// </summary>
        public Point2d TXTPosition { get; set; }

       
        public static Font font = new Font("宋体", 4, GraphicsUnit.Pixel);//标注文字
        public static StringFormat stringFormat = new StringFormat() { LineAlignment = StringAlignment.Far };

        public GraphText() : this(new Point2d(), "", 4.0) { }
      
        public GraphText(Point2d position, string text, double size)
        {
            DrawPen = Pens.Red;
            this.TXTPosition =position;
            Text = text;
            TxtSize = size;
            TxtRotationAngle = (Azimuth)(Math.PI / 2.0);
        }

        public override void Draw(Graphics g)
        {
            if (font.Size != TxtSize)
            {
                font = new Font("宋体", (float)TxtSize, GraphicsUnit.Pixel);
            }
            var matrix = g.Transform;
            float screenX, screenY;
            ViewPort.TransformPoint(TXTPosition.X, TXTPosition.Y, out screenX, out screenY);
            matrix.RotateAt((float)(TxtRotationAngle / Math.PI * 180), new PointF(screenX, screenY), MatrixOrder.Append);
            g.Transform = matrix;           
            g.DrawString(Text, font, DrawBrush, (float)(TXTPosition.X-TxtSize/2), (float)(TXTPosition.Y+TxtSize / 2), stringFormat);
            g.Transform = ViewPort.matrix;
        }

        public override bool Select()
        {
            var angle = TxtRotationAngle - Math.PI / 2;
            var w = TxtSize * Text.Length;
            if (Text.Length > 2) w /= 2;
            p1.X = TXTPosition.X + TxtSize * Math.Cos(angle) / 2;
            p1.Y = TXTPosition.Y + TxtSize * Math.Sin(angle) / 2;
            p2.X = p1.X + w * Math.Cos(TxtRotationAngle);
            p2.Y = p1.Y + w * Math.Sin(TxtRotationAngle);
            return IsOnLine(p1, p2, ViewPort.MouseSurveyX, ViewPort.MouseSurveyY, SelectDistance);
        }
        public override void Extent()
        {
            AddExtent(TXTPosition.X, TXTPosition.Y);
            var angle = TxtRotationAngle - Math.PI / 2;
            var w = TxtSize * Text.Length;
            if (Text.Length > 2) w /= 2;
            p1.X = TXTPosition.X + TxtSize * Math.Cos(angle);
            p1.Y = TXTPosition.Y + TxtSize * Math.Sin(angle);
            AddExtent(p1.X, p1.Y);
            p2.X = p1.X + w * Math.Cos(TxtRotationAngle);
            p2.Y = p1.Y + w * Math.Sin(TxtRotationAngle);
            AddExtent(p2.X, p2.Y);
        }

        public override void FirstPoint(out double x, out double y)
        {
            x = TXTPosition.X;
            y = TXTPosition.Y;
        }
    }
}
