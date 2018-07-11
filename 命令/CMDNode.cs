using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 图元;

namespace 命令
{
   public  class CMDNode:PrimitiveCMDBase
    {
        //开启绘制,单击屏幕点,获取坐标为圆心坐标,半径固定,在该位置弹出textbox 
        //输入文本,文本文字个数需要限制.
        //只显示前几个字符 

        static CMDNode cMDNode = new CMDNode();
        public static CMDNode Single { get { return cMDNode; } }

        /// <summary>
        /// 绘制节点  不需要 分步骤移动的 走,
        /// 当鼠标移动  一个虚幻的节点 绘制在界面
        /// 节点分 一种带一个箭头尾巴 ,一种不带 也可以带节点 不绘制
        /// </summary>

        
        static GraphNode Temp;

        CMDNode() { }

       
        public override void Start()
        {
            base.Start();
        }

        public override void Begin()
        {
            base.Begin();
        }

        public override void End()
        {
            base.End();
        }
        public override void Stop()
        {
            base.Stop();
        }

        public override bool MouseUp(MouseEventArgs e)
        {
            return base.MouseUp(e);
        }

        

    }
}
