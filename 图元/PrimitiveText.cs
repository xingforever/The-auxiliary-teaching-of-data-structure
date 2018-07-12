using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
  public  abstract class PrimitiveText :Primitive
    {
        /// <summary>
        /// 静态存储文字
        /// </summary>
        public static string BaseTxt { get; set; } = "";
        /// <summary>
        /// 文字内容
        /// </summary>
        public   string Text { get; set; }
        /// <summary>
        /// 大小 正数 -- 测量坐标系，单位：米；负数-- 图纸坐标系 ，单位：毫米
        /// </summary>
        public  double TXTSize { get; set; }
        /// <summary>
        /// 旋转角度
        /// </summary>
        public  Azimuth TXTRotationAngle { get; set; }
        /// <summary>
        /// 位置坐标
        /// </summary>
        public Point2d TXTPosition { get; set; }

        public  float x, y;
        public  static Font font = new Font("宋体", 4, GraphicsUnit.Pixel);//标注文字
         public static StringFormat stringFormat = new StringFormat() { LineAlignment = StringAlignment.Far };



    }
}
