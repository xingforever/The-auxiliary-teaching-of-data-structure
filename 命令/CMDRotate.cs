using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public override void Begin()
        {
            foreach (var item in PrimitiveCMDEdit.CurrentSelectedPrimitives)
            {

            }
        }
        public override void End()
        {
            base.End();
        }
        public override void Stop()
        {
            base.Stop();
        }
        public override bool MouseMove(MouseEventArgs e)
        {
            //鼠标移动, 图形进行旋转
            return base.MouseMove(e);
        }
    }
}
