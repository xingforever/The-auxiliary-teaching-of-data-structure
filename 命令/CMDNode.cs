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
            Begin();
        }

        public override void Begin()
        {
            TempPrims.Clear();
            Temp = new GraphNode();
            TempPrims.Add(Temp);
            Step = 0;
        }

        public override void End()
        {
            var p = Temp.NodeCircle.Center;
            Temp.Effective = true;
            Primitive.CurrentGraphics.Add(Temp);
            TempPrims.Clear();
            Temp = new GraphNode();
            TempPrims.Add(Temp);           
            Step = 1;
        }
        public override void Stop()
        {
            base.Stop();
        }

        public override bool MouseUp(MouseEventArgs e)
        {
            SetPrimitiveData(Primitive.ResultX, Primitive.ResultY);
            if (Step == 1)
            {
                return false;
            }
            return true;
        }
        public override bool MouseMove(MouseEventArgs e)
        {
            var p = new Point2d(Primitive.ResultX, Primitive.ResultY);
            Temp.NodeCircle.Center = p;
            Temp.NodeText.TXTPosition = p;
            return true;
        }
        private void SetPrimitiveData(double resultX, double resultY)
        {
            if (Step == 0)
            {
                Temp.NodeCircle.Center.X = resultX;
                Temp.NodeCircle.Center.Y = resultY;                
                Step++;
            }
            else
            {
               // Begin();
            }
        }
    }
}
