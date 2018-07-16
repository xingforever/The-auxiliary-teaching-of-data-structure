using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 图元
{
    /// <summary>
    /// 捕捉图元
    /// </summary>
    public abstract class PrimitiveSnap : PrimitiveSelect
    {

        /// <summary>
        /// 是否启用捕捉
        /// </summary>
        public static bool  SnapEnable{get ;set;}
        /// <summary>
        /// 是否捕捉
        /// </summary>
        /// <returns></returns>
        public virtual bool Snap ()
        {
            return false;
        }
        /// <summary>
        /// 当前捕捉类型
        /// </summary>
        public static SnapType CurrentSnapTypeSet { get; set; }
        /// <summary>
        /// 是否捕捉成功
        /// </summary>
        public static bool SnapOn { get; set; }
        /// <summary>
        /// 捕捉的结果类型
        /// </summary>
        public static SnapType SnapResultType { get; set; }
        /// <summary>
        /// 捕捉画笔
        /// </summary>
        public static Pen SnapPen { get; set; } 



        public  PrimitiveSnap()
        {
            CurrentSnapTypeSet = SnapType.MidPoint | SnapType.CenterPoint | SnapType.EndPoint;
            SnapOn = true;
            SnapResultType = SnapType.NULL;
            SnapPen = Pens.Red;
        }

        public static void SnapSymbolDraw(Graphics g)
        {
            if (SnapResultType == SnapType.NULL) return;
            var s = (float)ViewPort.SurveyLengthOfOneScreenMillimeter() * 2;
            var x = (float)(ResultX);
            var y = (float)(ResultY);
            SnapPen = new Pen(Color.Black, ViewPort.InvScale * 2);        
            switch (SnapResultType)
            {
                case SnapType.EndPoint:
                    g.DrawLine(SnapPen, x - s, y - s, x + s, y - s);
                    g.DrawLine(SnapPen, x + s, y - s, x + s, y + s);
                    g.DrawLine(SnapPen, x + s, y + s, x - s, y + s);
                    g.DrawLine(SnapPen, x - s, y + s, x - s, y - s);
                    break;
                case SnapType.MidPoint:
                    g.DrawLine(SnapPen, x - s, y - s, x - s, y + s);
                    g.DrawLine(SnapPen, x - s, y + s, x + s, y - s);
                    g.DrawLine(SnapPen, x + s, y - s, x + s, y + s);
                    g.DrawLine(SnapPen, x + s, y + s, x - s, y - s);
                    break;
                case SnapType.CenterPoint:
                    g.DrawEllipse(SnapPen, x - s, y - s, 2 * s, 2 * s);
                    break;
                default:
                    break;
            }
        }


    }
}
