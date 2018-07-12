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
            if (IsContinue == false)
            {
                IsContinue = true;
               
            }
            //需要显示textbox 加载文字功能. 
            //但是这不部分在form 中,
            //Begin();
        }
        public override void Begin()
        {
            Temp = new GraphText();
            Init();
            Temp.Effective = true;
            Primitive.CurrentGraphics.Add(Temp);


        }

        public override void Stop()
        {
            IsContinue = false;
        }
        public override bool MouseUp(MouseEventArgs e)
        {
            //SetPrimitiveData(Primitive.ResultX, Primitive.ResultY);
            return true;
        }

        private void SetPrimitiveData(double resultX, double resultY)
        {

           
        }

        public static  void Init()
        {
            Temp.Text = GraphText.BaseTxt;
            Temp.TXTPosition = new Point2d(Primitive.ResultX, Primitive.ResultY);
            Temp.TxtSize = 10.0;
        }

       
    }
}
