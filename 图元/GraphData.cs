using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    public class GraphData : Primitive
    {
        /// <summary>
        /// 矩形框
        /// </summary>
        public  GraphRectangle graphRectangle { get; set; } 
        /// <summary>
        /// 文字
        /// </summary>
        public GraphText graphText { get; set; }

        public override void Draw(Graphics g)
        {
            throw new NotImplementedException();
        }

        public override void Extent()
        {
            throw new NotImplementedException();
        }

        public override void FirstPoint(out double x, out double y)
        {
            throw new NotImplementedException();
        }
    }
}
