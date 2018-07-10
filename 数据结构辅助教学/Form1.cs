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
        /// <summary>
        /// 文本框
        /// </summary>
        public TextBox textBox = new TextBox();
        public Label textLabel = new Label();
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
                    private_Command.Start();
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
                if (pr.Effective == true)
                {
                    pr.Draw(g);
                }
                              
            }
            foreach (var pr in PrimitiveCMDBase.TempPrims)
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
            if (Command != null && Command.MouseMove(e))
            {
                //IsPanViewport = false;
            }
            ////按下鼠标左键
            else if (e.Button == MouseButtons.Left)
            {
                var dx = e.Location.X - ViewPort.pointLast.X;
                var dy = e.Location.Y - ViewPort.pointLast.Y;
               // ViewPort.Move(dx, dy);
                //ViewPort.pointLast = e.Location;
                // IsPanViewport = true;
            }
            //鼠标位置
            this.StatusLabelXY.Text = ViewPort.MouseSurveyX.ToString("F3") + "," + ViewPort.MouseSurveyY.ToString("F3");
            pictureBox1.Invalidate();

        }

        private void Rectangle_Click(object sender, EventArgs e)
        {
            Command = CMDRectangle.Single;
        }

        private void toolLine_Click(object sender, EventArgs e)
        {
            Command = CMDLine.Single;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            ViewPort.InvTransformPoint(e.Location.X, e.Location.Y);
            if ( Command != null && Command.MouseUp(e))
            {
                pictureBox1.Invalidate();
            }
           // IsPanViewport = false;
        }

        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (Command != null && Command.pictureBoxKeyDown(e))
            {
                pictureBox1.Invalidate();
            }
            if (e.KeyCode == Keys.ControlKey)
            {
               // IsRPress = true;
            }
            else
            {
                //IsRPress = false;
            }
        }

        private void tooltext_Click(object sender, EventArgs e)
        {
            //在单击处添加一个textbox和label 

            Command = CMDText.Single;
            TextFunctionInstall();//文字功能添加





        }
        /// <summary>
        /// 文字功能控件加载
        /// </summary>
        public void TextFunctionInstall()
        {
            textBox.Location = new Point(0, 0);
            textLabel.Location = new Point(0, 0);
            textBox.Width = 60;
            textLabel.Width = textBox.Width;
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = new Font("宋体", 14);
            textLabel.Font = new Font("宋体", 14);            
            textLabel.Visible = false;
            textBox.Visible = false;            
            this.Controls.Add(textBox);
            this.Controls.Add(textLabel);
            //textBox.Enabled = true;
            //textBox.BringToFront();
            //textBox.Focus();
            
            textBox.TextChanged += TextBox_TextChanged;
        }
        public void TextFunctionUnstall()
        {
            if(this.Controls.Contains(textBox))
            this.Controls.Remove(textBox);
            if (this.Controls.Contains(textLabel))
            this.Controls.Remove(textLabel);
        }

        public  void TextBox_TextChanged(object sender, EventArgs e)
        {
           
            textLabel.AutoSize = true;
            textLabel.Text= textBox.Text;
            textBox1.Text= textBox1.Width.ToString();
            label1.Text = textLabel.Text;
            if (textLabel.Width > 60)
            {
                textBox.Width = textLabel.Width+10;
            }
           
        }
        //s设置属性 查看是否 开启文字功能 , 在 picturebox 鼠标按下 进行判断 如果功能开启 那么 则textbox 显示
        // 否则 关闭 
        //是否将 textbox  和label 添加winform还是单独 动态加载?
        // 模仿 picturebox  进行 类似架构?
        //
    }
}
