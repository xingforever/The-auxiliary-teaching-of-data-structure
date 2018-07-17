using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 图元;

namespace 命令
{
    public class CMDRotateALL:PictureCMDBase 
    {
        static CMDRotateALL cMDRotateALL { get; set; } = new CMDRotateALL();
        public static CMDRotateALL Single { get { return cMDRotateALL; } }
        static double baseX, baseY, angle = 0;

      
        public CMDRotateALL()
        {
           
        }
        public override void Start()
        {
            Step = 0;
            angle = 0;
        }
       
        public override void Stop()
        {
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
                baseX = x;
                baseY = y;
                Step++;
            }
            else
            {
                RotateALL(baseX, baseY, (float)(-angle));
                var dx = x - baseX;
                var dy = y - baseY;
                angle = Azimuth.Create(dx, dy);
                RotateALL(baseX, baseY, (float)angle);
                Stop();
            }
              
            
            
        }
        public override bool MouseMove(MouseEventArgs e)
        {            
            if (Step==1)
            {                
                RotateALL(baseX, baseY, (float)(-angle));
                var dx = Primitive.ResultX - baseX;
                var dy = Primitive.ResultY - baseY;
                angle = Azimuth.Create(dx, dy);
                RotateALL(baseX, baseY, (float)angle);
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
