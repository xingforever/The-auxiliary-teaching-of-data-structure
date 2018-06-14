using System;
using System.Collections.Generic;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    /// <summary>
    /// 平移旋转缩放
    /// </summary>
   public abstract   class PrimitiveAffine:PrimitiveSnap
    {
        /// <summary>
        ///平移旋转缩放
        /// </summary>
        /// <param name="matrix"></param>
        public abstract void PanRotateZoom(Matrix matrix);
    }
}
