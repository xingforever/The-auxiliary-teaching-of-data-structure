using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 图元;

namespace 数据结构辅助教学
{
   public  class SettingBase
    {
        //栅格格网设置
        GridSSetting gridSSetting;

        public SettingBase(int height,int width)
        {
             gridSSetting=new GridSSetting (height, width);
        }
    }
}
