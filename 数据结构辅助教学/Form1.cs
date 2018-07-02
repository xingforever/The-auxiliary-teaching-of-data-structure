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
            Command = CMDGrids.Single;
            Command.End();
        }
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
    }
}
