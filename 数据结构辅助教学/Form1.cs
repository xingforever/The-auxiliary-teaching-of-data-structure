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
        //命令
        CMDBase command { get; set; }

        public CMDBase Command
        {
            get { return command; }
            set
            {
                command = value;
                if (command != null)
                    command.Start();
            }

        }

        //图元命令
        PrimitiveCMDBase  primitive_Command;    
        //基础设置
        SettingBase SettingBase;      
        ///是否启用文字编辑        
        public static  bool StartWriting { get; set; } = false;       
        ///正在编辑       
        public  static  bool IsWriting { get; set; } = false;
        //文字结果    
        public string TxtResult { get; set; } = "";
        // 鼠标最后确定屏幕坐标      
        public Point ScreenLastPoint { get; set; } = new Point();   
       
        

       


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
            //基础设置
           SettingBase = new SettingBase(this.pictureBox1.Height,this.pictureBox1.Width);
            //绘图设置
            Primitive.SelectEnable = true;
            Primitive.SnapEnable = true;
            //控件设计
            txtWords.Visible = false;
            txtWords.Font = new Font("宋体", 14);
            txtWords.BorderStyle = BorderStyle.FixedSingle;
            txtWords.Width = 30;
            txtWords.Enabled = false;
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
          
            Primitive.SelectedDraw(g);
            Primitive.SelectDraw(g);
            Primitive.SnapSymbolDraw(g);

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
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
          if(e.Button == MouseButtons.Right)
            {
                if(Primitive.CurrentSelectedPrimitives.Count > 0)
                {
                    cmsPic.Enabled = false;
                    cmsSelectPri.Enabled = true;
                    this.pictureBox1.ContextMenuStrip = cmsSelectPri;
                }
                else
                {
                    cmsSelectPri.Enabled = false;
                    cmsPic.Enabled = true;
                    this.pictureBox1.ContextMenuStrip = cmsPic;
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //重点 事件: 
            //第一步 判断是否有命令
            //第二步 判断是否编辑
            //第三步 执行命令

            //设置图元选择距离
            Primitive.SelectDistance = ViewPort.SurveyLengthOfOneScreenMillimeter() * 2;           
            if (IsWriting) { return; }            
            if (Command != null)
            {              
                if (Command.cMDType == CMDType.PriCommand)
                {
                    Primitive.SelectEnable = false;
                    Primitive.SnapEnable = true;
                    if (StartWriting)
                    {
                        TextFunction(e.Location.X, e.Location.Y);
                    }

                } else if (Command.cMDType==CMDType.PriEditCommand)
                {
                    Primitive.SelectEnable = true ;
                    Primitive.SnapEnable = false;

                }
                else if(Command.cMDType==CMDType.PicCommand)
                {
                    ;
                }
                ViewPort.InvTransformPoint(e.Location.X, e.Location.Y);
                Command.MouseMove(e);
            }
            else
            {
                ViewPort.InvTransformPoint(e.Location.X, e.Location.Y);
            }
            //鼠标位置
            this.StatusLabelXY.Text = ViewPort.MouseSurveyX.ToString("F3") + "," + ViewPort.MouseSurveyY.ToString("F3");
            pictureBox1.Invalidate();           
           
        }


        private void pictureBox1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                Primitive.SelectEnable = true;
                Primitive.SnapEnable = false;
                pictureBox1.Invalidate();
                Command = null;
                StartWriting = false;
                IsWriting = false;
                return;
            }
           else  if (Command != null && Command.pictureBoxKeyDown(e))
            {
                Primitive.SelectEnable = true;
                pictureBox1.Invalidate();

            }
          
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Focus();
        }
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            
            if (IsWriting) { return; }
            ViewPort.InvTransformPoint(e.Location.X, e.Location.Y);
            ScreenLastPoint = new Point(e.Location.X, e.Location.Y);
            
                if(e.Button== MouseButtons.Left)
                {
                if (Command != null)
                {
                    //图元绘制
                    if (Command.cMDType == CMDType.PriCommand)
                    {
                        if (StartWriting)
                        {
                            IsWriting = true;
                            TextFunction(e.Location.X, e.Location.Y);
                        }

                    }
                    //图元编辑
                    else if (Command.cMDType == CMDType.PriEditCommand)
                    {

                    }
                    //图形操作
                    else if (Command.cMDType == CMDType.PicCommand)
                    {

                    }
                    Command.MouseUp(e);
                }
                else
                {
                    
                    if (Primitive.CurrentSelectionPrimitive != null)
                    {
                        var pri = Primitive.CurrentSelectionPrimitive;
                       bool isContains =Primitive.CurrentSelectedPrimitives.Contains(pri);
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
                }
              }
            pictureBox1.Invalidate();
            

        }

        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            StartWriting = false;
        }
        private void toolMoveALL_Click(object sender, EventArgs e)
        {

            Command = CMDMoveALL.Single;
            cmsPic.Items[0].Visible = true;
        }
        private void toolRotateALL_Click(object sender, EventArgs e)
        {
            Command = CMDRotateALL.Single;
            cmsPic.Items[0].Visible = true;
        }


        private void toolSelectAll_Click(object sender, EventArgs e)
        {
            
            Command = CMDSelectALL.Single;
            cmsPic.Items[0].Visible = true;
            pictureBox1.Invalidate();
        }
        private void toolPriALL_Click(object sender, EventArgs e)
        {
            ViewPort.All(pictureBox1.Height,pictureBox1.Width);
            pictureBox1.Invalidate();
            Command = null;
            Primitive.SelectEnable = true;
            Primitive.SnapEnable = false;
        }

        private void toolCancelCommand_Click(object sender, EventArgs e)
        {
            Command = null;
            cmsPic.Items[0].Visible = false;
            Primitive.SelectEnable = true;
            Primitive.SnapEnable = false;
        }

        private void toolDelete_Click(object sender, EventArgs e)
        {
            Command = CMDDelete.Single;
        }

        private void toolMove_Click(object sender, EventArgs e)
        {
            Command = CMDMove.Single;
        }

        private void toolCopy_Click(object sender, EventArgs e)
        {
            Command = CMDCopy.Single;
        }

        private void toolRotate_Click(object sender, EventArgs e)
        {
            Command = CMDRotate.Single;
        }

        private void toolCancelSelect_Click(object sender, EventArgs e)
        {
            Primitive.CurrentGraphics.AddRange(Primitive.CurrentSelectedPrimitives);
            Primitive.CurrentSelectedPrimitives = new List<Primitive>();
            Primitive.CurrentSelectionPrimitive = null;
            pictureBox1.Invalidate();
            Command = null;
            cmsPic.Items[0].Visible = false;
            Primitive.SelectEnable = true;
            Primitive.SnapEnable = false;

        }

        private void toolRectangle_Click(object sender, EventArgs e)
        {
            Command = CMDRectangle.Single;
        }
        
        private void toolLine_Click(object sender, EventArgs e)
        {
            Command = CMDLine.Single;
        }

        private void tooltext_Click(object sender, EventArgs e)
        {
            //在单击处添加一个textbox和label 

            Command = CMDText.Single;
            StartWriting = true;
          

        }
                   
         private void toolNode_Click(object sender, EventArgs e)
        {
            Command = CMDNode.Single;
            StartWriting = true;
        }

        private void toolData_Click(object sender, EventArgs e)
        {
            Command = CMDData.Single;
            StartWriting = true;
        }    

        private void toolArrow_Click(object sender, EventArgs e)
        {
            Command = CMDArrow.Single;
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
                txtWords.Enabled = false;
                //this.pictureBox1.Enabled = true;
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
                    PCommand.Init();
                    pictureBox1.Invalidate();
                    lblWords.Text = "";
                    txtWords.Text = "";
                    txtWords.Width = 60;
                    IsWriting = false;

                }
                else if (e.KeyCode == Keys.Escape)
                {
                    StartWriting = false;
                    IsWriting = false;
                    txtWords.Visible = false;
                    txtWords.Enabled = false;
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

       
        public void TextFunction(int x, int y)
        {
            //textbox的位置对应的是整个界面的,
            //而picturebox的是部分 y+50左右
            txtWords.Visible = true;
            if (IsWriting)
            {
                txtWords.Location = new Point(ScreenLastPoint.X - 5, ScreenLastPoint.Y + 50);
                txtWords.ReadOnly = false;
                txtWords.Text = GraphText.BaseTxt;
                txtWords.Focus();
                txtWords.Select(txtWords.TextLength, 0);
            }
            else
            {
                // pictureBox1.Focus();
                txtWords.Location = new Point(x + 10, y + 50);
                txtWords.ReadOnly = true;
            }

        }

        private void cmsPic_Click(object sender, EventArgs e)
        {
            //这里写父容器的集合 --可自动判断。这里我采用手写。提高效率
            foreach (ToolStripMenuItem item in cmsPic.Items)
            {
                //不是当前项的取消选择
                if (item.Name == cmsPic.Name)
                {
                    item.Checked = true; //设选中状态为true
                }
                else
                {
                    item.Checked = false; //设选中状态为false
                }
            }
        }

       
    }
}
