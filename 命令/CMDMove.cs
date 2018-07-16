using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 图元;

namespace 命令
{
  public   class CMDMove:PrimitiveCMDEdit
    {

        static CMDMove cMDMove { get; set; } = new CMDMove();
        public static CMDMove Single { get { return cMDMove; } }
        public  CMDMove()
        {
            cMDMove = new CMDMove();
        }

        public override void Start()
        {
            if (Primitive.CurrentSelectedPrimitives.Count > 0)
            {
                Begin();
            }
        }
        public override void Begin()
        {
            Step = 0;
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
            if (Step == 0)
            {
                foreach (var pri in Primitive.CurrentSelectedPrimitives)
                {

                }
            }
            else
            {
                ;
            }
            return false;
        }
        public override bool MouseMove(MouseEventArgs e)
        {
            return false;

        }




    }
}
