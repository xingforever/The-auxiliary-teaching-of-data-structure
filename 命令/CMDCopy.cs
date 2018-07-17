using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 图元;

namespace 命令
{
    public class CMDCopy : PrimitiveCMDEdit
    {
    
        static CMDCopy cMDCopy { get; set; } = new CMDCopy();
        public static CMDCopy Single { get { return cMDCopy; } }
        public CMDCopy()
        {
      
        }
        public override void Start()
        {
            if (Primitive.CurrentSelectedPrimitives.Count > 0)
            {
                Begin();
            }


        }
        public override void Begin()
        {
            //深拷贝到临时图元,----每个图元需要写深拷贝函数
            foreach (var pri in Primitive.CurrentSelectedPrimitives)
            {
                var newPri = pri.Copy();
                PrimitiveCMDBase.TempPrims.Add(newPri);

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
            //鼠标移动 ,复制的图元跟着移动
            foreach (var item in PrimitiveCMDBase.TempPrims)
            {
                //每个图元根据  firstPoint 进行重置 


            }
            return true;
        }
    }
}
