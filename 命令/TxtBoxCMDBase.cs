using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 命令
{
    public abstract class TxtBoxCMDBase : CMDBase
    {
        public  static  bool Visable { get; set; }
        /// 文字的位置
        public  static  Point Location { get; set; }
        //文字结果
        public static  string ResultText { get; set; }
        /// <summary>
        /// 开启文字编辑
        /// </summary>
        public virtual void WStart() { }
        /// <summary>
        /// 关闭文字编辑
        /// </summary>
        public virtual void WStop() { }

        /// <summary>
        /// 文字编辑框可见性改变
        /// </summary>
        /// <returns></returns>
        public virtual bool VisibleChanged()
        {
            return false;
        }
        /// <summary>
        /// 文本改变
        /// </summary>
        /// <returns></returns>
        public virtual bool TextChanged()
        {
            return false;
        }
        /// <summary>
        /// 按键完成
        /// </summary>
        /// <returns></returns>
        public virtual bool PreviewKeyDown() {
            return false;
        }


    }
}
