using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 图元;

namespace 命令
{
   public   class CMDLine:PrimitiveCMDBase
    {
        static CMDLine cMDLine = new CMDLine();
        public static CMDLine Single { get { return cMDLine; } }

        static GraphLine Temp;

        CMDLine() { }

        public override void Start()
        {
            if (IsContinue == false) {
                IsContinue = true;
               
            }
            Begin();
        }
        public override void Stop()
        {
            IsContinue = false;
         }
        public override void Begin()
        {
            if (IsContinue == true)
            {
                TempPrims.Clear();
                Temp = new GraphLine();
                TempPrims.Add(Temp);
                Step = 0;

            }
            
        }


        public override void End()
        {
            var p = Temp.EndPoint;
            Temp.Effective = true;
            Primitive.CurrentGraphics.Add(Temp);
            TempPrims.Clear();
            Temp = new GraphLine();
            TempPrims.Add(Temp);
            Temp.StartPoint.X = p.X;
            Temp.StartPoint.Y = p.Y;
            Step = 1;
        }
        public override bool MouseUp(MouseEventArgs e)
        {
            
            SetPrimitiveData(Primitive.ResultX, Primitive.ResultY);
            return true;
        }
        /// <summary>
        /// 设置图元数据
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void SetPrimitiveData(double x, double y)
        {
            if (Step == 0)
            {
                Temp.EndPoint.X = Temp.StartPoint.X = x;
                Temp.EndPoint.Y = Temp.StartPoint.Y = y;
                Step++;
            }
            else
            {
                Temp.EndPoint.X = x;
                Temp.EndPoint.Y = y;
                End();
            }
        }
       
        public override bool MouseMove(MouseEventArgs e)
        {
            if (Step == 1)
            {
                Temp.EndPoint.X = Primitive.ResultX;
                Temp.EndPoint.Y = Primitive.ResultY;
                return true;
            }
            return false;
        }
        public override bool pictureBoxKeyDown(PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Space)
            {
                Start();
                return true;
            }
            else if(e.KeyCode == Keys.Escape)
            {
               
                return false;
            }
            return false;
        }
        
    }
}
