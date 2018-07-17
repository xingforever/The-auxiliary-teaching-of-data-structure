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
            Primitive.CurrentSelectedPrimitives = new List<Primitive>();
        }
        public override void End()
        {
           
        }
        public override bool MouseUp(MouseEventArgs e)
        {
            if (Primitive.CurrentSelectedPrimitives.Count < 1)
            {
                Select();
            }
            foreach (var pri in Primitive.CurrentSelectedPrimitives)
            {
                Primitive.CurrentGraphics.Remove(pri);
            }
            Primitive.CurrentSelectedPrimitives = new List<Primitive>();
            return true;
        }
        public override void Stop()
        {
            Primitive.CurrentSelectedPrimitives=new List<Primitive> ();
        }

        

    }
}

