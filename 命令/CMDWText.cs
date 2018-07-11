using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 图元;

namespace 命令
{
    //只管文字部分--
   public  class CMDWText:TxtBoxCMDBase
    {
        static CMDWText cMDWText = new CMDWText();
       
      
        public static CMDWText Single { get { return cMDWText; } }
       
        public  CMDWText(int  x,int  y)
        {
            Location = new Point(x, y);
        }
        public CMDWText():this (0,0){}

        public override void WStart()
        {
            if (Visable == false)
            {
                Visable = true;
            }
        }

        public override void WStop()
        {
            if (Visable == true)
            {
                Visable = false;
            }
        }

        public override bool TextChanged()
        {
            return base.TextChanged();
        }

        public override bool VisibleChanged()
        {
            if (Visable == true)
            {
                return true;
            }else
            {
                Location = new Point();
                return false;
            }
        }
        public override bool PreviewKeyDown()
        {
            //如果按键为回车键,则文字输入完毕
            return base.PreviewKeyDown();
        }


    }
}
