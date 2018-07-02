using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
   public static  class GraphGridSystem
    {
        /// <summary>
        /// 栅格系统设置
        /// </summary>
        public static GridSSetting Setting { get; set; }
      
        /// <summary>
        /// 栅格列总数
        /// </summary>
        public static int ColumnNum { get; set; }
        /// <summary>
        /// 栅格行总数
        /// </summary>
        public static int RowNum { get; set; }



        public static void Init(double Xmin,double Xmax,double YMin,double Ymax)
        {

        }


    }
}
