using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using 命令;
using 图元;

namespace 数据结构辅助教学
{
    public partial class Form1 : Form
    {
        public static Form1 form1;
        PrimitiveCMDBase  private_Command;
        SettingBase SettingBase;
        PrimitiveCMDBase Command
        {
            get
            {
                return private_Command;
            }
            set
            {
                private_Command = value;
                if (private_Command != null)
                    private_Command.Begin();
            }
        }
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Init();
            pictureBox1.MouseWheel += pictureBox1_MouseWheel;
            form1 = this;
            ViewPort.All(this.pictureBox1.Height, this.pictureBox1.Width);
            var g = pictureBox1.CreateGraphics();
            ViewPort.MMPixels = g.DpiX / 20.4f;
            g.Dispose();
            Command = CMDGrids.Single;
            Command.Start();
            Command.Begin();
            Command.End();
            Command.Stop();

           
        }
        /// <summary>
        /// 初始化设置
        /// </summary>
        public  void Init()
        {
           SettingBase = new SettingBase(this.pictureBox1.Height,this.pictureBox1.Width);
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            if (Primitive.CurrentGraphics.Count == 0)
            {
                return ;
            }
            var g = e.Graphics;
            g.PageUnit = GraphicsUnit.Pixel;//为了使文字大小与dxf中接近
            g.Transform = ViewPort.matrix;
            foreach (var pr in Primitive.CurrentGraphics)
            {
                pr.Draw(g);               
            }
           
        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (Command != null && Command.MouseWheel(e))
            {
                pictureBox1.Invalidate();
            }
            else
            {
                float s = 1.2f;
                if (e.Delta < 0) s = 0.8f;
                ViewPort.ScaleAt(e.Location.X, e.Location.Y, s);
                pictureBox1.Invalidate();
            }
          
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //设置图元选择距离
            Primitive.SelectDistance = ViewPort.SurveyLengthOfOneScreenMillimeter() * 2;
            //点坐标转换
            ViewPort.InvTransformPoint(e.Location.X, e.Location.Y);
            //if (Command != null && Command.MouseMove(e))
            //{
            //     //IsPanViewport = false;
            //}
            ////按下鼠标左键
            //else if (e.Button == MouseButtons.Left)
            //{
            //    var dx = e.Location.X - ViewPort.pointLast.X;
            //    var dy = e.Location.Y - ViewPort.pointLast.Y;
            //    ViewPort.Move(dx, dy);
            //    ViewPort.pointLast = e.Location;
            //   // IsPanViewport = true;
            //}
            //鼠标位置
            this.StatusLabelXY.Text = ViewPort.MouseSurveyX.ToString("F3") + "," + ViewPort.MouseSurveyY.ToString("F3");
           // pictureBox1.Invalidate();

        }
    }
}
