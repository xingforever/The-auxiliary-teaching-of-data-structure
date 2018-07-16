using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 图元;

namespace 命令
{
   public  class CMDMoveALL: PictureCMDBase
    {
        static CMDMoveALL cMDMoveALL { get; set; }
        public static CMDMoveALL Single { get { return cMDMoveALL; } }
        public CMDMoveALL()
        {
            cMDMoveALL = new CMDMoveALL();
        }
        public override void Start()
        {
            base.Start();
        }
        public override void Stop()
        {
            base.Stop();
        }

        public override bool MouseMove(MouseEventArgs e)
        {
            //左键按住 移动 还是直接移动,..
             if (e.Button == MouseButtons.Left)
            {
                var dx = e.Location.X - ViewPort.pointLast.X;
                var dy = e.Location.Y - ViewPort.pointLast.Y;
                ViewPort.Move(dx, dy);
                ViewPort.pointLast = e.Location;
                return true;
            }
            return false;
        }
    }
}
