using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 图元;

namespace 命令
{
   public   class CMDText:PrimitiveCMDBase
    {
        static CMDText cMDText = new CMDText();
        public static CMDText Single { get { return cMDText; } }

        static GraphText Temp;
        CMDText() { }

        public override void Start()
        {
            base.Start();
        }
        public override void Begin()
        {
            TempPrims.Clear();
            Temp = new GraphText();
            TempPrims.Add(Temp);
            Step = 0;

        }
        public override void End()
        {
            Temp.Effective = false;
            Primitive.CurrentGraphics.Add(Temp);
            Begin();
        }
        public override bool MouseUp(MouseEventArgs e)
        {
            SetPrimitiveData(Primitive.ResultX, Primitive.ResultY);
            return true;
        }

        private void SetPrimitiveData(double resultX, double resultY)
        {
            throw new NotImplementedException();
        }
    }
}
