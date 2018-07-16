using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 图元;

namespace 命令
{
   public  class CMDSelectALL:PictureCMDBase
    {
        static CMDSelectALL cMDSelectALL { get; set; } = new CMDSelectALL();
        public static CMDSelectALL Single { get { return cMDSelectALL; } }
        public CMDSelectALL()
        {
           
        }
        public override void Start()
        {
            Primitive.CurrentSelectedPrimitives.AddRange(Primitive.CurrentGraphics);
            Primitive.CurrentGraphics = new List<Primitive>();
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
