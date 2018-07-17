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
        static CMDRotate cMDRotate { get; set; } = new CMDRotate();
        public static CMDRotate Single { get { return cMDRotate; } }
        public CMDRotate()
        {
            
        }
        static double baseX, baseY, angle = 0;
        public override void Start()
        {
            Step = 0;
            angle = 0;
            if (Primitive.CurrentSelectedPrimitives.Count > 0)
            {
                Begin();
            }
           
        }
        public override void Begin()
        {
            baseX = Primitive.ResultX;
            baseY = Primitive.ResultY;
            Step = 1;
        }

        public override void Stop()
        {
            Primitive.CurrentGraphics.AddRange(Primitive.CurrentSelectedPrimitives);
            Primitive.CurrentSelectedPrimitives = new List<Primitive>();
            Start();
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
                if (Primitive.CurrentSelectedPrimitives.Count < 1)
                {
                    if (Select())
                        Step++;
                }
                baseX = Primitive.ResultX;
                baseY = Primitive.ResultY;

            }            
            else
            {
                RotateAt(baseX, baseY, (float)(-angle));
                var dx = x - baseX;
                var dy = y - baseY;
                angle = Azimuth.Create(dx, dy);
                RotateAt(baseX, baseY, (float)angle);
                Stop();
            }



        }
        public override bool MouseMove(MouseEventArgs e)
        {
            if (Step == 1)
            {
                RotateAt(baseX, baseY, (float)(-angle));
                var dx = Primitive.ResultX - baseX;
                var dy = Primitive.ResultY - baseY;
                angle = Azimuth.Create(dx, dy);
                RotateAt(baseX, baseY, (float)angle);
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
            else
            {
                return false;
            }
        }
       
    }
}
