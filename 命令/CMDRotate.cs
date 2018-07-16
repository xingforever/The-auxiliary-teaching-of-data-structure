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
    public class CMDRotate:PrimitiveCMDEdit
    {
        static CMDRotate cMDRotate { get; set; }
        public static CMDRotate Single { get { return cMDRotate; } }
        public CMDRotate()
        {
            cMDRotate = new CMDRotate(); 
        }

        public override void Start()
        {
           if(PrimitiveCMDEdit.CurrentSelectedPrimitives.Count > 0)
            {
                Begin();
            }
        }
       
        
        public override void Stop()
        {
            base.Stop();
        }
      
        static double baseX, baseY, angle = 0;
        public override void Begin()
        {

            Step = 0;
            angle = 0;
        }
        public override void End()
        {
            Primitive.CurrentGraphics.Add(Primitive.CurrentSelectionPrimitive);
            Primitive.CurrentSelectionPrimitive = null;
            Begin();
        }
        public override bool MouseUp(MouseEventArgs e)
        {
            SetPrimitiveData(Primitive.ResultX, Primitive.ResultY);
            return true;
        }

        private void SetPrimitiveData(double x, double y)
        {
            if (Step == 0)
            {
                if (Primitive.CurrentSelectionPrimitive != null)
                {

                    Step++;
                    Primitive.CurrentGraphics.Remove(Primitive.CurrentSelectionPrimitive);
                }
            }
            else if (Step == 1)
            {
                baseX = x;
                baseY = y;
                Step++;
            }
            else
            {
                ViewPort.RotateAt((float)baseX, (float)baseY, (float)(-angle));
                if (y == double.MaxValue)
                {
                    angle = x / 180 * Math.PI;
                }
                else
                {
                    var dx = x - baseX;
                    var dy = y - baseY;
                    angle = Azimuth.Create(dx, dy);
                }
                ViewPort.RotateAt((float)baseX, (float)baseY, (float)angle);
                End();
            }
        }

        public override bool MouseMove(MouseEventArgs e)
        {
            if (Step == 0)
            {
                base.MouseMove(e);
                return true;
            }
            else if (Step == 2)
            {
               ViewPort.RotateAt((float)baseX, (float)baseY, (float)(-angle));
                var dx = Primitive.ResultX - baseX;
                var dy = Primitive.ResultY - baseY;
                angle = Azimuth.Create(dx, dy);
                ViewPort.RotateAt((float)baseX, (float)baseY, (float)angle);
                return true;
            }
            return false;
        }
        public override bool pictureBoxKeyDown(PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Return || e.KeyCode == Keys.Space)
            {
                Begin();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
