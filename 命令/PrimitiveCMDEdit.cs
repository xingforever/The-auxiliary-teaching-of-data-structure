using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using 图元;

namespace 命令
{
    public class PrimitiveCMDEdit : CMDBase
    {


       public  PrimitiveCMDEdit()
        {
            cMDType = CMDType.PriEditCommand;
        }
        /// <summary>
        /// 矩阵
        /// </summary>
        public static Matrix matrix { get; set; } = new Matrix();


        public  static bool Select()
        {
            if (Primitive.CurrentSelectionPrimitive != null)
            {
                var pri = Primitive.CurrentSelectionPrimitive;
                bool isContains = Primitive.CurrentSelectedPrimitives.Contains(pri);
                if (isContains)
                {
                    Primitive.CurrentSelectedPrimitives.Remove(pri);
                }
                else
                {
                    Primitive.CurrentSelectedPrimitives.Add(pri);
                }
                Primitive.CurrentSelectionPrimitive = null;
            }
            if (Primitive.CurrentSelectedPrimitives.Count > 0)
                return true;
            else
                return false;
        }
        public static void Move(float dx, float dy)
        {
            matrix.Reset();
            matrix.Translate(dx, dy, MatrixOrder.Append);
            foreach (var pri in Primitive.CurrentSelectedPrimitives)
            {
                pri.PanRotateZoom(matrix);
            }  
        }


        //public virtual   void Draw(Graphics g)
        //{
        //    //if (CurrentSelectionPrimitive != null)
        //    //{
        //    //    CurrentSelectionPrimitive.Effective = false;
        //    //    if (IsSelected == false)
        //    //    {
        //    //        Primitive.DrawPen = SelectPen;
        //    //        Primitive.DrawBrush = SelectBrush;
        //    //        CurrentSelectionPrimitive.Draw(g);
        //    //        Primitive.DrawPen = Primitive.NormalPen;
        //    //        Primitive.DrawBrush = Primitive.NormalBrush;
        //    //    }
        //    //    else
        //    //    {
        //    //        Primitive.DrawPen = SelectedPen;
        //    //        Primitive.DrawBrush = SelectedBrush;
        //    //        CurrentSelectionPrimitive.Draw(g);
        //    //        Primitive.DrawPen = Primitive.NormalPen;
        //    //        Primitive.DrawBrush = Primitive.NormalBrush ;
        //    //    }
        //    //}
        //}
        //public static bool Select()
        //{
        //    CurrentSelectionPrimitive = null;
        //    foreach (Primitive pr in Primitive.CurrentGraphics)
        //    {
        //        if (pr.Select())
        //        {
        //            CurrentSelectionPrimitive = pr;
        //            return true;
        //        }
        //    }
        //    return false;
        //}







    }
}
