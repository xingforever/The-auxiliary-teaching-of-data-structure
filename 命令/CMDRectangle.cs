using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 图元;

namespace 命令
{
   public  class CMDRectangle :PrimitiveCMDBase
    {
        static CMDRectangle cMDRectangle = new CMDRectangle();
        public static CMDRectangle Single { get { return cMDRectangle; } }

        static GraphRectangle Temp { get; set; }
        CMDRectangle() { }
        public override void Start()
        {
            if (IsContinue == false)
            {
                IsContinue = true;
                Begin();
            }
        }

        public override void Begin()
        {
            TempPrims.Clear();
            Temp = new GraphRectangle();
            TempPrims.Add(Temp);
            Step = 0;
        }

        public override void End()
        {
            var p = Temp.EndPoint;
            Temp.Effective = true;
            Primitive.CurrentGraphics.Add(Temp);
            TempPrims.Clear();
            Temp = new GraphRectangle();
            TempPrims.Add(Temp);
            Step = 0;
        }
        public override bool MouseUp(MouseEventArgs e)
        {
            SetPrimitiveData(Primitive.ResultX, Primitive.ResultY);
            return true;
        }
        public override bool MouseMove(MouseEventArgs e)
        {
            if (Step == 1)
            {
                Temp.EndPoint.X = Primitive.ResultX;
                Temp.EndPoint.Y = Primitive.ResultY;
                Temp.Init();
                return true;
            }
            return false;
        }

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
    }
}
