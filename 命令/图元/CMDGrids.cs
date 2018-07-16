using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 图元;

namespace 命令
{
   public class CMDGrids:PrimitiveCMDBase
    {
        static CMDGrids cMDGrids = new CMDGrids();
        public static CMDGrids Single { get { return cMDGrids; } }
        static GraphGridS Temp;

        CMDGrids() { }

        public override void Start()
        {
            if (IsContinue == false)
            {
                IsContinue = true;
            }
        }
        public override void Stop()
        {
            IsContinue = false;
        }
        public override void Begin()
        {
            TempPrims.Clear();
            Temp = new GraphGridS();
            TempPrims.Add(Temp);
           
        }


        public override void End()
        {
          
            Primitive.CurrentGraphics.Add(Temp);
            TempPrims.Clear();
            
        }

        
    }
}
