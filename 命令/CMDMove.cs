using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 命令
{
  public   class CMDMove:PrimitiveCMDEdit
    {
        //选中图元,右键移动(多选)
        
        static  CMDMove cMDMove { get; set; }
        public static CMDMove Single { get { return cMDMove; } }
        public  CMDMove()
        {
            cMDMove = new CMDMove();
        }

        public override void Start()
        {
            //必须先选择图元
            base.Start();
        }
        public override void Begin()
        {
            //开始命令
            base.Begin();
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
