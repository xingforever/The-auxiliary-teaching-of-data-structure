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
       
        static CMDDelete cMDDelete { get; set; } = new CMDDelete();
        public static CMDDelete Single { get { return cMDDelete; } }

        public CMDDelete()
        {
        
        }
        public override void Start()
        {
            if(Primitive.CurrentSelectedPrimitives.Count > 0){
                Begin();
            }
        }
        public override void Begin()
        {
            foreach (var pri in Primitive.CurrentSelectedPrimitives)
            {
                Primitive.CurrentGraphics.Remove(pri);
            }
        }
        public override void End()
        {
           
        }

        public override void Stop()
        {
            Primitive.CurrentSelectedPrimitives=new List<Primitive> ();
        }

        

    }
}

