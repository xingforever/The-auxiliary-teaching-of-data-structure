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
        static double baseX, baseY;
        public  CMDMove()
        {
            
        }

        public override void Start()
        {
            Step = 0;
            if (Primitive.CurrentSelectedPrimitives.Count > 0)
            {               
                Begin();
            }
        }
        public override void Begin()
        {
            
            baseX = Primitive.ResultX;
            baseY = Primitive.ResultY;
            Step ++;
        }
        public override void End()
        {
            Primitive.CurrentSelectedPrimitives = new List<Primitive>();
            Step = 0;
        }
        public override void Stop()
        {
            base.Stop();
        }
      


        public override bool MouseUp(MouseEventArgs e)
        {
            SetPrimitiveData(Primitive.ResultX, Primitive.ResultY);
            return true;
        }
        private void SetPrimitiveData(double x, double y)
        {

            if (Step==0)
            {
                if (Select())
                    Start();
            }           
            else
            {
                var dx = (float)(x - baseX);
                var dy = (float)(y - baseY);
                MoveAt(dx, dy);
                End();
            }
            
           
            
              
            
        }
        public override bool MouseMove(MouseEventArgs e)
        {
            if (Step == 0)
            {
                return true;
            }
            else
            {
                var dx = (float)(Primitive.ResultX - baseX);
                var dy = (float)(Primitive.ResultY - baseY);
                MoveAt(dx, dy);
                baseX = Primitive.ResultX;
                baseY = Primitive.ResultY;
                return true;
            }
               
          
           
        }




    }
}
