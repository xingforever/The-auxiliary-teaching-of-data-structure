using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    /// <summary>
    /// 栅格图元集--选中,捕捉,不可以平移旋转缩放    /// 
    /// </summary>
    public class GraphGridS :Primitive
    {
        /// <summary>
        /// 栅格列总数
        /// </summary>
        public static int ColumnNum { get; set; }
        /// <summary>
        /// 栅格行总数
        /// </summary>
        public static int RowNum { get; set; }

       public  GraphGridS()
        {
            ColumnNum = GridSSetting.ColumnNum;
            RowNum = GridSSetting.RowNum;
            this.Effective = true;
            DrawPen = Pens.Black; 
            DrawBrush= Brushes.Black;
        }



        public override void Draw(Graphics g)
        {
           
            //列
            for (int i = 0; i < GridSSetting.ColumnNum; i++)
            {
                PointF p1 = new PointF(GridSSetting.LeftTopPoint.X , GridSSetting.LeftTopPoint.Y + i * GridSSetting.GridWidth);
                PointF p2 = new PointF(GridSSetting.LeftBottomPoint.X, GridSSetting.LeftBottomPoint.Y +i * GridSSetting.GridWidth);
                g.DrawLine(GridSSetting.BasePen, p1, p2);
            }
            //行
            for (int i = 0; i < GridSSetting.RowNum; i++)
            {
                PointF p1 = new PointF(GridSSetting.LeftBottomPoint.X + i * GridSSetting.GridHight, GridSSetting.LeftBottomPoint.Y);
                PointF p2 = new PointF(GridSSetting.RightBottomPoint.X + i * GridSSetting.GridWidth, GridSSetting.RightBottomPoint.Y);
                g.DrawLine(GridSSetting.BasePen, p1, p2);
            }

        }

        public override void Extent()
        {
            AddExtent(GridSSetting.LeftTopPoint);
            AddExtent(GridSSetting.LeftBottomPoint);
            AddExtent(GridSSetting.RightBottomPoint);
            AddExtent(GridSSetting.RightTopPoint);

        }
        
       

        public override void FirstPoint(out double x, out double y)
        {
            x= GridSSetting.LeftTopPoint.X;
            y = GridSSetting.LeftTopPoint.Y;
        }
      
    }
}
