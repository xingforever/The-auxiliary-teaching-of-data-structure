using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 图元;

namespace 命令
{
   public  class CMDDelete:PrimitiveCMDEdit
    {
       
        static CMDDelete cMDDelete { get; set; }
        public static CMDDelete Single { get { return cMDDelete; } }

        public CMDDelete()
        {
            cMDDelete = new CMDDelete();
        }
        public override void Start()
        {
            if(CurrentSelectedPrimitives.Count > 0){
                Begin();
            }
        }
        public override void Begin()
        {
            foreach (var pri in CurrentSelectedPrimitives)
            {
                Primitive.CurrentGraphics.Remove(pri);
            }
        }
        public override void End()
        {
           
        }

        public override void Stop()
        {
            CurrentSelectedPrimitives=new List<Primitive> ();
        }

        

    }
}

