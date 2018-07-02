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
   public  class GridSSetting
    {
        /// <summary>
        /// 栅格总高度
        /// </summary>
        public static double TotalHeight { get; set; }
        /// <summary>
        /// 栅格总宽度
        /// </summary>
        public static double  TotalWidth { get; set; }
        /// <summary>
        /// 左上角点
        /// </summary>
        public static  PointF LeftTopPoint { get; set; }
        /// <summary>
        /// 左下角点
        /// </summary>
        public static PointF LeftBottomPoint { get; set; }
        /// <summary>
        /// 右上角点
        /// </summary>
        public static PointF RightTopPoint { get; set; }
        /// <summary>
        /// 右下角点
        /// </summary>
        public static PointF RightBottomPoint { get; set; }

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
        /// <summary>
        /// 栅格总行数
        /// </summary>
        public static  int RowNum { get; set; }
        /// <summary>
        /// 栅格总列数
        /// </summary>
        public static int ColumnNum { get; set; }

      public  GridSSetting(int height,int width)
        {
            TotalHeight = height;
            TotalWidth = width;
            Enable = true;
            DisPlay = false;           
            GridHight = 10;
            GridWidth = 10;
            LeftTopPoint = new PointF(0.0f, 0.0f);
            LeftBottomPoint = new PointF(0.0f, -height);
            RightTopPoint = new PointF(width, 0.0f);
            RightBottomPoint = new PointF(width, -height);
            RowNum = height / 10;
            ColumnNum = width / 10;

        }
      
        GridSSetting(PointF leftTopP,PointF leftBottomP,PointF rightTopP,PointF rightBottomP)
        {
            LeftTopPoint = leftTopP;
            LeftBottomPoint = leftBottomP;
            RightTopPoint = rightTopP;
            RightBottomPoint = RightBottomPoint;
            Enable = true;
            DisPlay = false;
            TopMargin = LeftMargin = RightMargin = BottomMargin = 0;
            GridHight = 10;
            GridWidth = 20;

        }




    }
}
