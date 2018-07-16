﻿using System;
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

      
        /// <summary>
        /// 选择时图元
        /// </summary>
        public static Primitive CurrentSelectionPrimitive { get; set; }
        /// <summary>
        /// 被选中图元数组
        /// </summary>
        public static  List<Primitive> CurrentSelectedPrimitives { get; set; }
        /// <summary>
        /// 选择时画笔
        /// </summary>
        public static Pen SelectPen { get; set; }
        /// <summary>
        /// 选择时填充
        /// </summary>
        public static Brush SelectBrush { get; set; }
        /// <summary>
        /// 选择后画笔
        /// </summary>
        public static Pen SelectedPen { get; set; }
        /// <summary>
        /// 选择后填充
        /// </summary>
        public static Brush SelectedBrush { get; set; }
        /// <summary>
        /// 是否被选中
        /// </summary>
        public static bool IsSelected { get; set; }
        /// <summary>
        /// 矩阵
        /// </summary>
        public static Matrix matrix { get; set; }


        public PrimitiveCMDEdit()
        {
            cMDType = CMDType.PriEditCommand;
            IsSelected = false;
            SelectedBrush = Brushes.Red;
            SelectedPen = Pens.Red;
            SelectBrush = Brushes.Cyan;
            SelectPen = Pens.Cyan;
            matrix = new Matrix();
            CurrentSelectedPrimitives = new List<Primitive>();


        }



        public virtual   void Draw(Graphics g)
        {
            //if (CurrentSelectionPrimitive != null)
            //{
            //    CurrentSelectionPrimitive.Effective = false;
            //    if (IsSelected == false)
            //    {
            //        Primitive.DrawPen = SelectPen;
            //        Primitive.DrawBrush = SelectBrush;
            //        CurrentSelectionPrimitive.Draw(g);
            //        Primitive.DrawPen = Primitive.NormalPen;
            //        Primitive.DrawBrush = Primitive.NormalBrush;
            //    }
            //    else
            //    {
            //        Primitive.DrawPen = SelectedPen;
            //        Primitive.DrawBrush = SelectedBrush;
            //        CurrentSelectionPrimitive.Draw(g);
            //        Primitive.DrawPen = Primitive.NormalPen;
            //        Primitive.DrawBrush = Primitive.NormalBrush ;
            //    }
            //}
        }
        public static bool Select()
        {
            CurrentSelectionPrimitive = null;
            foreach (Primitive pr in Primitive.CurrentGraphics)
            {
                if (pr.Select())
                {
                    CurrentSelectionPrimitive = pr;
                    return true;
                }
            }
            return false;
        }
       

       

       

       
    }
}
