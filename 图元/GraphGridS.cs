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

       // GridSSetting gridSSetting =new GridSSetting (10,12);
        

        public override void Draw(Graphics g)
        {
            //列
            for (int i = 0; i < GridSSetting.ColumnNum; i++)
            {
                PointF p1 = new PointF(GridSSetting.LeftTopPoint.X + i * GridSSetting.GridWidth, GridSSetting.LeftTopPoint.Y);
                PointF p2 = new PointF(GridSSetting.LeftBottomPoint.X + i * GridSSetting.GridWidth, GridSSetting.LeftTopPoint.Y);
                g.DrawLine(GridSSetting.BasePen, p1, p2);
            }
            //行
            for (int i = 0; i < GridSSetting.RowNum; i++)
            {
                PointF p1 = new PointF(GridSSetting.LeftTopPoint.X , GridSSetting.LeftTopPoint.Y+i*GridSSetting.GridHight);
                PointF p2 = new PointF(GridSSetting.LeftBottomPoint.X + i * GridSSetting.GridWidth, GridSSetting.LeftTopPoint.Y+i * GridSSetting.GridHight);
                g.DrawLine(GridSSetting.BasePen, p1, p2);
            }
            
        }

        public override void Extent()
        {
            //栅格范围不添加
        }
        
       

        public override void FirstPoint(out double x, out double y)
        {
            throw new NotImplementedException();
        }
      
    }
}
