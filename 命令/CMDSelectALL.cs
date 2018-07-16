using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 图元;

namespace 命令
{
   public  class CMDSelectALL:PictureCMDBase
    {
        static CMDSelectALL cMDSelectALL { get; set; }
        public static CMDSelectALL Single { get { return cMDSelectALL; } }
        public CMDSelectALL()
        {
            cMDSelectALL = new CMDSelectALL();
        }
        public override void Start()
        {
            PrimitiveCMDEdit.CurrentSelectedPrimitives = Primitive.CurrentGraphics;
        }
        public override void End()
        {
            base.End();
        }
        public override void Stop()
        {
            base.Stop();
        }

    }
}
