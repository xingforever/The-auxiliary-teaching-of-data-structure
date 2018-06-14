using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    /// <summary>
    /// 捕捉图元
    /// </summary>
  public  abstract  class PrimitiveSnap: PrimitiveSelect
    {
        /// <summary>
        /// 是否启用捕捉
        /// </summary>
        /// <returns></returns>
        public abstract bool Snap();
        /// <summary>
        /// 当前捕捉类型
        /// </summary>
        public static SnapType CurrentSnapTypeSet { get; set; }
        /// <summary>
        /// 是否捕捉成功
        /// </summary>
        public static bool SnapOn { get; set; }
        /// <summary>
        /// 捕捉的结果类型
        /// </summary>
        public static SnapType SnapResultType { get; set; }
        /// <summary>
        /// 捕捉画笔
        /// </summary>
        public static Pen SnapPen { get; set; }

        static PrimitiveSnap()
        {
            SnapPen = new Pen(Brushes.Blue, 2);
            CurrentSnapTypeSet = SnapType.MidPoint | SnapType.CenterPoint | SnapType.EndPoint;
            SnapOn = true;
            SnapResultType = SnapType.NULL;
        }
        //affine 

    }
}
