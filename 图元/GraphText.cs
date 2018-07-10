using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    public class GraphText : Primitive
    {
        /// <summary>
        /// 文字内容
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 大小 正数 -- 测量坐标系
        /// </summary>
        public double Size { get; set; }
        /// <summary>
        /// 旋转角度
        /// </summary>
        public Azimuth RotationAngle { get; set; }
        /// <summary>
        /// 位置坐标
        /// </summary>
        public Point2d Position { get; set; }
        static Point2d p1 = new Point2d();
        static Point2d p2 = new Point2d();
        float x, y;
        static Font font = new Font("宋体", 4, GraphicsUnit.Pixel);//为了使文字大小与dxf中接近
        static StringFormat stringFormat = new StringFormat() { LineAlignment = StringAlignment.Far };
        public GraphText() : this(new Point2d(), "", 4.0) { }
        public GraphText(Point2d position, string text, double size)
        {
            this.Position = position;
            this.Text = text;
            this.Size = size;
            this.RotationAngle = (Azimuth)(Math.PI / 2.0);
        }

        public override void Draw(Graphics g)
        {
            if (font.Size != Size)
            {
                font = new Font("宋体", (float)Size, GraphicsUnit.Pixel);
            }
            var matrix = g.Transform;
            float screenX, screenY;
            ViewPort.TransformPoint(Position.X, Position.Y, out screenX, out screenY);
            matrix.RotateAt((float)(RotationAngle / Math.PI * 180), new PointF(screenX, screenY), MatrixOrder.Append);
            g.Transform = matrix;
            g.DrawString(Text, font, DrawBrush, x, y, stringFormat);
            g.Transform = ViewPort.matrix;
        }

        public override void Extent()
        {
            AddExtent(Position.X, Position.Y);
            var angle = RotationAngle - Math.PI / 2;
            var w = Size * Text.Length;
            if (Text.Length > 2) w /= 2;
            p1.X = Position.X + Size * Math.Cos(angle);
            p1.Y = Position.Y + Size * Math.Sin(angle);
            AddExtent(p1.X, p1.Y);
            p2.X = p1.X + w * Math.Cos(RotationAngle);
            p2.Y = p1.Y + w * Math.Sin(RotationAngle);
            AddExtent(p2.X, p2.Y);
        }

        public override void FirstPoint(out double x, out double y)
        {
            x = Position.X;
            y = Position.Y;
        }
    }
}
