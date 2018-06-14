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
    /// 栅格图元
    /// </summary>
    public class GraphGrid : Primitive
    {
        /// <summary>
        /// 左上角点
        /// </summary>
        public PointF LeftTop { get; set; }
        /// <summary>
        /// 左下角点
        /// </summary>
        public PointF LeftBottom { get; set; }
        /// <summary>
        /// 右上角点
        /// </summary>
        public  PointF RigtTop { get; set; }
        /// <summary>
        /// 右下角点
        /// </summary>
        public PointF RightBottom { get; set; }
        /// <summary>
        /// 栅格高度
        /// </summary>
        public static  double Height { get; set; }
        /// <summary>
        /// 栅格宽度
        /// </summary>
        public static  double Width { get; set; }




        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }

        public override void Extent()
        {
            throw new NotImplementedException();
        }

        public override void FirstPoint(out double x, out double y)
        {
            throw new NotImplementedException();
        }

        public override void PanRotateZoom(Matrix matrix)
        {
            throw new NotImplementedException();
        }

        public override void Parse(string[] strs)
        {
            throw new NotImplementedException();
        }

        public override bool Select()
        {
            throw new NotImplementedException();
        }

        public override void Selected()
        {
            throw new NotImplementedException();
        }

        public override bool Snap()
        {
            throw new NotImplementedException();
        }
    }
}
