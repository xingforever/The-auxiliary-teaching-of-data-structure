using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 图元;

namespace 命令
{
    public class CMDMoveALL : PictureCMDBase
    {
        static CMDMoveALL cMDMoveALL { get; set; } = new CMDMoveALL();
        public static CMDMoveALL Single { get { return cMDMoveALL; } }
        private bool Move { get; set; }
        public CMDMoveALL()
        {
           
        }
        public override void Start()
        {
            Move = true;
        }
        public override void Stop()
        {
            Move = false;
            
        }

        public override bool MouseMove(MouseEventArgs e)
        {
            if (e.Button==MouseButtons.Left)
            {
                var dx = e.Location.X - ViewPort.pointLast.X;
                var dy = e.Location.Y - ViewPort.pointLast.Y;
                ViewPort.Move(dx, dy);
                ViewPort.pointLast = e.Location;
            }
           
            return true;           
        }
        public override bool MouseUp(MouseEventArgs e)
        {
            //ViewPort.pointLast = e.Location;
            return true;
        }
        public override bool MouseDown(MouseEventArgs e)
        {
           if(e.Button==MouseButtons.Left)
            {
                ViewPort.pointLast = e.Location;
            }
            return true;
        }
    }
}
