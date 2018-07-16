using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 图元;

namespace 命令
{
   public  class CMDData:PrimitiveCMDBase
    {

        static CMDData cMDData = new CMDData();
        public static CMDData Single { get { return cMDData; } }

        /// <summary>
        /// 绘制节点  不需要 分步骤移动的 走,
        /// 当鼠标移动  一个虚幻的节点 绘制在界面
        /// 节点分 一种带一个箭头尾巴 ,一种不带 也可以带节点 不绘制
        /// </summary>


        static GraphData Temp;

        CMDData() { }


        public override void Start()
        {
            if (IsContinue == false)
            {
                IsContinue = true;
            }
            Begin();
        }

        public override void Begin()
        {
            if (!IsContinue) return;
            TempPrims.Clear();
            Temp = new GraphData();
            TempPrims.Add(Temp);
            GraphText.BaseTxt = Temp.DataText.Text;
            Step = 0;
        }

        public override void End()
        {
          
            Temp.Effective = true;
            Primitive.CurrentGraphics.Add(Temp);
            TempPrims.Clear();
            Temp = new GraphData();
            TempPrims.Add(Temp);
            Step = 1;
        }
        public override void Stop()
        {
            IsContinue = false;
        }
        public override void Init()
        {
            Temp.DataText.Text = GraphText.BaseTxt;
            Temp.DataText.TXTPosition = new Point2d(Primitive.ResultX, Primitive.ResultY);
            Temp.DataText.TxtSize = 10.0;
            End();
        }

        public override bool MouseMove(MouseEventArgs e)
        {
            var p = new Point2d(Primitive.ResultX, Primitive.ResultY);          
            Temp.DataRectangle.Reset(p);
            var size = Temp.DataRectangle.getSize();
            Temp.DataText.TXTPosition = new Point2d((p.X ), (p.Y+(size.Height/2) ));
            return true;
        }
        public override bool pictureBoxKeyDown(PreviewKeyDownEventArgs e)
        {
            
            //if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Space)
            //{
            //    Start();
            //    return true;
            //}
            //else if (e.KeyCode == Keys.Escape)
            //{

            //    return false;
            //}
            return false;
        }
    }
}
