using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    /// <summary>
    /// 图元命令
    /// </summary>
    public abstract class PrimitiveCMD:PrimitiveAffine
    {
        /// <summary>
        /// 命令转换
        /// </summary>
        /// <param name="strs"></param>
        public abstract void Parse(string[] strs);
    }
}
