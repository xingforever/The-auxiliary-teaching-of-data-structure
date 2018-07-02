using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    /// <summary>
    /// 选中图元
    /// </summary>
   public  abstract  class PrimitiveSelect: PrimitiveBase
    {
        /// <summary>
        /// 是否启用选择
        /// </summary>
        public static   bool SelectEnable { get; set; }
        /// <summary>
        /// 选择距离
        /// </summary>
        public static double SelectDistance { get; set; }
        /// <summary>
        /// 判断是否被选择
        /// </summary>
        /// <returns></returns>
        public virtual bool Select()
        {
            return false;
        }
        /// <summary>
        /// 被选中后
        /// </summary>
        public virtual void Selected() { }

    }
}
