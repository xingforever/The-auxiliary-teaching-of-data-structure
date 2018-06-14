using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;

namespace 图元
{
    /// <summary>
    /// 栅格设置
    /// </summary>
   public  class GridSystemSetting
    {
        /// <summary>
        /// 栅格总高度
        /// </summary>
        public static int TotalHeight { get; set; }
        /// <summary>
        /// 栅格总宽度
        /// </summary>
        public static int TotalWidth { get; set; }
        /// <summary>
        /// 是否启用
        /// </summary>
        public static bool Enable { get; set; }
        /// <summary>
        /// 是否显示栅格
        /// </summary>
        public static bool DisPlay { get; set; }
        /// <summary>
        /// 栅格距上边框距离
        /// </summary>
        public static  int TopMargin { get; set; }
        /// <summary>
        /// 栅格距左边框距离
        /// </summary>
        public static int LeftMargin { get; set; }
        /// <summary>
        /// 栅格距右边框距离
        /// </summary>
        public static  int RightMargin { get; set; }
        /// <summary>
        /// 栅格距下边框距离
        /// </summary>
        public static  int BottomMargin { get; set; }
        /// <summary>
        /// 单元格高度
        /// </summary>
        public static int GridHight { get; set; }
        /// <summary>
        /// 单元格宽度
        /// </summary>
        public static  int GridWidth { get; set; }
        /// <summary>
        /// 栅格列总数
        /// </summary>
        public static int ColumnNum { get; set; }
        /// <summary>
        /// 栅格行总数
        /// </summary>
        public static int RowNum { get; set; }
      
        /// <summary>
        /// 画笔
        /// </summary>
        public static Pen BasePen { get; set; } = Pens.Black;
        /// <summary>
        /// 颜色
        /// </summary>
        public static Color BaseColor { get; set; } = Color.Black;
        /// <summary>
        /// 笔宽
        /// </summary>
        public static float BasePenWidth { get; set; } = (float)1.0;

        GridSystemSetting(int height,int width)
        {
            TotalHeight = height;
            TotalWidth = width;
            Enable = true;
            DisPlay = false;
            TopMargin = LeftMargin = RightMargin = BottomMargin = 0;
            GridHight = 10;
            GridWidth = 20;
            RowNum = TotalWidth / GridWidth;
            ColumnNum = TotalHeight / GridHight;
        }
      

       

    }
}
