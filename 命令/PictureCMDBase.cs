using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 图元;

namespace 命令
{
    public class PictureCMDBase:CMDBase 
    {
        public static Matrix matrix = new Matrix();
        public PictureCMDBase()
        {
            cMDType = CMDType.PicCommand;
        }
        public static void Pan(float dx, float dy)
        {
            matrix.Reset();
            matrix.Translate(dx, dy, MatrixOrder.Append);
            Primitive.CurrentSelectionPrimitive.PanRotateZoom(matrix);
        }
        public static void ZoomAt(double x, double y, float scale)
        {
            matrix.Reset();
            var x1 = (float)(x);
            var y1 = (float)(y);
            matrix.Translate(0 - x1, 0 - y1, MatrixOrder.Append);//平移到坐标原点
            matrix.Scale(scale, scale, MatrixOrder.Append);
            matrix.Translate(x1, y1, MatrixOrder.Append);
            Primitive.CurrentSelectionPrimitive.PanRotateZoom(matrix);
        }
        
        public static void RotateALL(double x, double y, double angle)
        {
            matrix.Reset();
            var x1 = (float)(x);
            var y1 = (float)(y);
            matrix.RotateAt((float)(angle * 180 / Math.PI), new PointF(x1, y1), MatrixOrder.Append);
            foreach (var pri in Primitive.CurrentGraphics)
            {
                pri.PanRotateZoom(matrix);
            }

        }
    }
}
