using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 图元;

namespace 命令
{
    /// <summary>
    /// 图元命令
    /// </summary>
    public abstract class PrimitiveCMDBase:CMDBase
    {
       
        /// <summary>
        /// 临时图元集合
        /// </summary>
        public static List<Primitive> TempPrims { get; set; } = new List<Primitive>();
      
        /// <summary>
        /// 继续命令
        /// </summary>
        public static bool IsContinue { get; set; }

       public PrimitiveCMDBase()
        {
            cMDType = CMDType.PriCommand;
        }

        /// <summary>
        /// 命令转换
        /// </summary>
        /// <param name="strs"></param>
        public virtual void Parse(string[] strs) { }
       
        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init() { }

       
        /// <summary>
        /// 命令行
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public virtual bool CMDLineKeyDown(KeyEventArgs e)
        {
            return false;
        }
        
    }
}
