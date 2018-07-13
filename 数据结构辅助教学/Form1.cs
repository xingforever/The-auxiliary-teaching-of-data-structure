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
        public TextBox txtWords = new TextBox();
        public  Label lblWords = new Label();

        //图元命令
        PrimitiveCMDBase  primitive_Command;
    
        //基础设置
        SettingBase SettingBase;
        /// <summary>
        /// 是否启用文字编辑
        /// </summary>
        public static  bool StartWriting { get; set; } = false;
        /// <summary>
        /// 正在编辑
        /// </summary>
         public  static  bool IsWriting { get; set; } = false;
        /// <summary>
        /// 文字结果
        /// </summary>

        public  string TxtResult { get; set; }
        /// <summary>
        /// 鼠标最后确定屏幕坐标
        /// </summary>
        public  Point ScreenLastPoint { get; set; }
        public  Point2d SurveyLastPoint { get; set; }
       
        
       
        PrimitiveCMDBase PCommand
        {
            get
            {
                return primitive_Command;
            }
            set
            {
                primitive_Command = value;
                if (primitive_Command != null)
                    primitive_Command.Start();
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
            //PCommand = CMDGrids.Single;
            //PCommand.Start();
            //PCommand.Begin();
            //PCommand.End();
            //PCommand.Stop();

           
        }
        /// <summary>
        /// 初始化设置
        /// </summary>
        public  void Init()
        {
           SettingBase = new SettingBase(this.pictureBox1.Height,this.pictureBox1.Width);            
          
            txtWords.Visible = false;
            txtWords.Font = new Font("宋体", 14);
            txtWords.BorderStyle = BorderStyle.FixedSingle;
            txtWords.Width = 30;
            lblWords.Visible = false;
            lblWords.Font = new Font("宋体", 14);
            txtWords.Location = new Point(0, 0);
            lblWords.Location = new Point(0, 0);
            this.Controls.Add(txtWords);
            this.Controls.Add(lblWords);
            txtWords.VisibleChanged += txtWords_VisibleChanged;
            txtWords.TextChanged += txtWords_TextChanged;
            txtWords.PreviewKeyDown += txtWords_PreviewKeyDown;
            txtWords.KeyPress += txtWords_KeyPress;


        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            g.PageUnit = GraphicsUnit.Pixel;
            g.Transform = ViewPort.matrix;
            foreach (var pr in PrimitiveCMDBase.TempPrims)
            {
                pr.Draw(g);

            }          
           
            foreach (var pr in Primitive.CurrentGraphics)
            {
                if (pr.Effective == true)
                {
                    pr.Draw(g);
                }
                              
            }

           

        }

        private void pictureBox1_MouseWheel(object sender, MouseEventArgs e)
        {
            if (PCommand != null && PCommand.MouseWheel(e))
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
            if (IsWriting) { return; }
            ViewPort.InvTransformPoint(e.Location.X, e.Location.Y);
             if (PCommand != null && PCommand.MouseMove(e))
            {
                //IsPanViewport = false;
            }
            else if(StartWriting)
            {              
                TextFunction(e.Location.X, e.Location.Y);
            }
            else if (PCommand != null && PCommand.MouseMove(e))
            {
                //IsPanViewport = false;
            }
            //按下鼠标左键
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
            PCommand = CMDRectangle.Single;
        }

        private void toolLine_Click(object sender, EventArgs e)
        {
            PCommand = CMDLine.Single;
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (IsWriting) { return; }
            //MessageBox.Show(PrimitiveCMDBase.TempPrims.Count.ToString());
            ViewPort.InvTransformPoint(e.Location.X, e.Location.Y);           
            ScreenLastPoint = new Point(e.Location.X, e.Location.Y);
            
            if (StartWriting)
            {
                IsWriting = true;
                TextFunction(e.Location.X, e.Location.Y);                
            }
           else  if ( PCommand != null && PCommand.MouseUp(e))
            {
                pictureBox1.Invalidate();
            }
           
        }

        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (PCommand != null && PCommand.pictureBoxKeyDown(e))
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

            PCommand = CMDText.Single;
            StartWriting = true;
          

        }
        /// <summary>
        /// 文字功能启用
        /// </summary>
        public void TextFunction(int x,int y)
        {
            //textbox的位置对应的是整个界面的,
            //而picturebox的是部分 y+50左右
            txtWords.Visible = true;
            if (IsWriting)
            {
                txtWords.Location = new Point (ScreenLastPoint.X-5,ScreenLastPoint.Y+50);
                txtWords.ReadOnly = false;
                txtWords.Text = GraphText.BaseTxt;
                txtWords.Focus();
                txtWords.Select(txtWords.TextLength, 0);
            }
            else
            {
               // pictureBox1.Focus();
                txtWords.Location = new Point(x+10, y+50);               
                txtWords.ReadOnly = true;
            }
          
        }
       

       


        private void txtWords_VisibleChanged(object sender, EventArgs e)
        {
            if (txtWords.Visible == true)
            {
                //this.pictureBox1.Enabled = false;
                txtWords.Enabled = true;
                txtWords.BringToFront();              
                txtWords.Focus();
                
            }
            else
            {
               // txtWords.Enabled = false;
               // this.pictureBox1.Enabled = true;
                txtWords.SendToBack();
                this.pictureBox1.Focus();

            }
        }
       
        private void txtWords_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (StartWriting)
            {
                //回车键
                if (e.KeyCode == Keys.Return)
                {
                    TxtResult = txtWords.Text;                   
                    txtWords.Visible = false;
                    GraphText.BaseTxt = txtWords.Text;
                    PCommand.Init ();
                    pictureBox1.Invalidate();
                    lblWords.Text = "";
                    txtWords.Text = "";
                    txtWords.Width = 60;
                    IsWriting = false;

                }else if (e.KeyCode == Keys.Escape)
                {
                    StartWriting = false;
                    IsWriting = false;
                    txtWords.Visible = false;                   
                    txtWords.Text = "";
                    pictureBox1.Invalidate();
                }
                    
            }
        }

       
        private void txtWords_TextChanged(object sender, EventArgs e)
        {
            lblWords.AutoSize = true;
            lblWords.Text = txtWords.Text;

            if (lblWords.Width > 60)
            {
                txtWords.Width = lblWords.Width + 10;
            }
        }
        private void txtWords_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == System.Convert.ToChar(13))
            {
                e.Handled = true;
            }
        }

        private void toolNode_Click(object sender, EventArgs e)
        {
            PCommand = CMDNode.Single;
            StartWriting = true;
        }

        private void toolStripLabel1_Click(object sender, EventArgs e)
        {
            PCommand = CMDData.Single;
            StartWriting = true;
        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            StartWriting = false;
        }
    }
}
