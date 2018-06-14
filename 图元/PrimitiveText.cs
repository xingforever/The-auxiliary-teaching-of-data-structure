using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
   abstract class PrimitiveText :PrimitiveAffine
    {

         
        /// <summary>
        /// 文字内容
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// 大小 正数 -- 测量坐标系，单位：米；负数-- 图纸坐标系 ，单位：毫米
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

        float x, y;
        static Font font = new Font("宋体", 4, GraphicsUnit.Pixel);//标注文字
        static StringFormat stringFormat = new StringFormat() { LineAlignment = StringAlignment.Far };



    }
}
