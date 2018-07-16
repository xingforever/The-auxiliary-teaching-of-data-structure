using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 命令
{
   public abstract class CMDBase
    {
        /// <summary>
        /// 命令类型
        /// </summary>
        public  CMDType cMDType { get; set; }
        /// <summary>
        /// 步骤
        /// </summary>
        public static int Step { get; set; }
        /// <summary>
        /// 命令启动
        /// </summary>
        public virtual void Start() { }
        /// <summary>
        /// 开始执行
        /// </summary>
        public virtual void Begin() { }
        /// <summary>
        /// 命令结束
        /// </summary>
        public virtual void End() { }
        /// <summary>
        /// 命令退出
        /// </summary>
        public virtual void Stop() { }

        /// <summary>
        /// 鼠标按下
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public virtual bool MouseDown(MouseEventArgs e)
        {
            return false;
        }
        /// <summary>
        /// 鼠标移动
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public virtual bool MouseMove(MouseEventArgs e)
        {
            return false;
        }
        /// <summary>
        /// 鼠标弹起
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public virtual bool MouseUp(MouseEventArgs e)
        {
            return false;
        }
        /// <summary>
        /// 键盘在绘图区域按下
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public virtual bool pictureBoxKeyDown(PreviewKeyDownEventArgs e)
        {
            return false;
        }
        /// <summary>
        /// 双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public virtual bool DoubleClick(object sender, EventArgs e)
        {
            return false;
        }


        /// <summary>
        /// 鼠标滚轮移动
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public virtual bool MouseWheel(MouseEventArgs e)
        {
            return false;
        }
       
    }
}
