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
        /// 步骤
        /// </summary>
        public static int Step { get; set; }
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
        /// 开启绘制
        /// </summary>
        public virtual void Start() { }
        /// <summary>
        /// 开始绘制单个图元
        /// </summary>
        public virtual void Begin() { }
        /// <summary>
        /// 结束绘制单个图元
        /// </summary>
        public virtual void End() { }
        /// <summary>
        /// 结束绘制
        /// </summary>
        public virtual void Stop() { }    
        /// <summary>
        /// 初始化
        /// </summary>
        public virtual void Init() { }

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
        /// 命令行
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public virtual bool CMDLineKeyDown(KeyEventArgs e)
        {
            return false;
        }
        /// <summary>
        /// 双击
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public virtual bool  DoubleClick(object sender, EventArgs e)
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
