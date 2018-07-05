using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 图元;

namespace 数据结构辅助教学
{
    public class SettingBase
    {
        //栅格网设置
       public  static GridSSetting GridSSetting { get; set; }
        //是否开启栅格网
       public  static bool GridsOpen { get; set; }
        /// <summary>
        /// 图框的高度
        /// </summary>
       public  static int PictureBoxHeight { get; set; }
        /// <summary>
        /// 图框宽度
        /// </summary>
       public  static int PictureBoxWidth { get; set; }

        public SettingBase(int height, int width)
        {
            GridSSetting = new GridSSetting(height, width);
            GridsOpen = true;
            PictureBoxHeight = height;
            PictureBoxWidth = width;

        }


    }
}
