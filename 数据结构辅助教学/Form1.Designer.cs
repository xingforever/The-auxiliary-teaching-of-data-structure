namespace 数据结构辅助教学
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.开始ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolRectangle = new System.Windows.Forms.ToolStripLabel();
            this.toolLine = new System.Windows.Forms.ToolStripLabel();
            this.tooltext = new System.Windows.Forms.ToolStripLabel();
            this.toolData = new System.Windows.Forms.ToolStripLabel();
            this.toolNode = new System.Windows.Forms.ToolStripLabel();
            this.toolArrow = new System.Windows.Forms.ToolStripLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmsPic = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolCancelCommand = new System.Windows.Forms.ToolStripMenuItem();
            this.toolMoveALL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolRotateALL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSelectALL = new System.Windows.Forms.ToolStripMenuItem();
            this.toolPriALL = new System.Windows.Forms.ToolStripMenuItem();
            this.cmsSelectPri = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolSelectDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSelectMove = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSelectCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.toolSelectRotate = new System.Windows.Forms.ToolStripMenuItem();
            this.toolCancelSelect = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusLabelXY = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolSelectQuitEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.cmsPic.SuspendLayout();
            this.cmsSelectPri.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开始ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 开始ToolStripMenuItem
            // 
            this.开始ToolStripMenuItem.Name = "开始ToolStripMenuItem";
            this.开始ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.开始ToolStripMenuItem.Text = "开始";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolRectangle,
            this.toolLine,
            this.tooltext,
            this.toolData,
            this.toolNode,
            this.toolArrow});
            this.toolStrip1.Location = new System.Drawing.Point(0, 25);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(800, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolRectangle
            // 
            this.toolRectangle.Name = "toolRectangle";
            this.toolRectangle.Size = new System.Drawing.Size(32, 22);
            this.toolRectangle.Text = "矩形";
            this.toolRectangle.Click += new System.EventHandler(this.toolRectangle_Click);
            // 
            // toolLine
            // 
            this.toolLine.Name = "toolLine";
            this.toolLine.Size = new System.Drawing.Size(20, 22);
            this.toolLine.Text = "线";
            this.toolLine.Click += new System.EventHandler(this.toolLine_Click);
            // 
            // tooltext
            // 
            this.tooltext.Name = "tooltext";
            this.tooltext.Size = new System.Drawing.Size(32, 22);
            this.tooltext.Text = "文字";
            this.tooltext.Click += new System.EventHandler(this.tooltext_Click);
            // 
            // toolData
            // 
            this.toolData.Name = "toolData";
            this.toolData.Size = new System.Drawing.Size(32, 22);
            this.toolData.Text = "数据";
            this.toolData.Click += new System.EventHandler(this.toolData_Click);
            // 
            // toolNode
            // 
            this.toolNode.Name = "toolNode";
            this.toolNode.Size = new System.Drawing.Size(32, 22);
            this.toolNode.Text = "节点";
            this.toolNode.Click += new System.EventHandler(this.toolNode_Click);
            // 
            // toolArrow
            // 
            this.toolArrow.Name = "toolArrow";
            this.toolArrow.Size = new System.Drawing.Size(32, 22);
            this.toolArrow.Text = "箭头";
            this.toolArrow.Click += new System.EventHandler(this.toolArrow_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ContextMenuStrip = this.cmsPic;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 378);
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            this.pictureBox1.DoubleClick += new System.EventHandler(this.pictureBox1_DoubleClick);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseEnter += new System.EventHandler(this.pictureBox1_MouseEnter);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            this.pictureBox1.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.pictureBox1_PreviewKeyDown);
            // 
            // cmsPic
            // 
            this.cmsPic.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolCancelCommand,
            this.toolMoveALL,
            this.toolRotateALL,
            this.toolSelectALL,
            this.toolPriALL});
            this.cmsPic.Name = "cmsPic";
            this.cmsPic.Size = new System.Drawing.Size(101, 114);
            this.cmsPic.Click += new System.EventHandler(this.cmsPic_Click);
            // 
            // toolCancelCommand
            // 
            this.toolCancelCommand.CheckOnClick = true;
            this.toolCancelCommand.Name = "toolCancelCommand";
            this.toolCancelCommand.Size = new System.Drawing.Size(100, 22);
            this.toolCancelCommand.Text = "退出";
            this.toolCancelCommand.Visible = false;
            this.toolCancelCommand.Click += new System.EventHandler(this.toolCancelCommand_Click);
            // 
            // toolMoveALL
            // 
            this.toolMoveALL.CheckOnClick = true;
            this.toolMoveALL.Name = "toolMoveALL";
            this.toolMoveALL.Size = new System.Drawing.Size(100, 22);
            this.toolMoveALL.Text = "平移";
            this.toolMoveALL.Click += new System.EventHandler(this.toolMoveALL_Click);
            // 
            // toolRotateALL
            // 
            this.toolRotateALL.CheckOnClick = true;
            this.toolRotateALL.Name = "toolRotateALL";
            this.toolRotateALL.Size = new System.Drawing.Size(100, 22);
            this.toolRotateALL.Text = "旋转";
            this.toolRotateALL.Click += new System.EventHandler(this.toolRotateALL_Click);
            // 
            // toolSelectALL
            // 
            this.toolSelectALL.CheckOnClick = true;
            this.toolSelectALL.Name = "toolSelectALL";
            this.toolSelectALL.Size = new System.Drawing.Size(100, 22);
            this.toolSelectALL.Text = "全选";
            this.toolSelectALL.Click += new System.EventHandler(this.toolSelectAll_Click);
            // 
            // toolPriALL
            // 
            this.toolPriALL.CheckOnClick = true;
            this.toolPriALL.Name = "toolPriALL";
            this.toolPriALL.Size = new System.Drawing.Size(100, 22);
            this.toolPriALL.Text = "全图";
            this.toolPriALL.Click += new System.EventHandler(this.toolPriALL_Click);
            // 
            // cmsSelectPri
            // 
            this.cmsSelectPri.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolSelectQuitEdit,
            this.toolSelectDelete,
            this.toolSelectMove,
            this.toolSelectCopy,
            this.toolSelectRotate,
            this.toolCancelSelect});
            this.cmsSelectPri.Name = "cmsSelectPri";
            this.cmsSelectPri.Size = new System.Drawing.Size(181, 158);
            this.cmsSelectPri.Click += new System.EventHandler(this.cmsSelectPri_Click);
            // 
            // toolSelectDelete
            // 
            this.toolSelectDelete.CheckOnClick = true;
            this.toolSelectDelete.Name = "toolSelectDelete";
            this.toolSelectDelete.Size = new System.Drawing.Size(180, 22);
            this.toolSelectDelete.Text = "删除";
            this.toolSelectDelete.Click += new System.EventHandler(this.toolSelectDelete_Click);
            // 
            // toolSelectMove
            // 
            this.toolSelectMove.CheckOnClick = true;
            this.toolSelectMove.Name = "toolSelectMove";
            this.toolSelectMove.Size = new System.Drawing.Size(180, 22);
            this.toolSelectMove.Text = "移动";
            this.toolSelectMove.Click += new System.EventHandler(this.toolSelectMove_Click);
            // 
            // toolSelectCopy
            // 
            this.toolSelectCopy.CheckOnClick = true;
            this.toolSelectCopy.Name = "toolSelectCopy";
            this.toolSelectCopy.Size = new System.Drawing.Size(180, 22);
            this.toolSelectCopy.Text = "复制";
            this.toolSelectCopy.Click += new System.EventHandler(this.toolSelectCopy_Click);
            // 
            // toolSelectRotate
            // 
            this.toolSelectRotate.CheckOnClick = true;
            this.toolSelectRotate.Name = "toolSelectRotate";
            this.toolSelectRotate.Size = new System.Drawing.Size(180, 22);
            this.toolSelectRotate.Text = "旋转";
            this.toolSelectRotate.Click += new System.EventHandler(this.toolSelectRotate_Click);
            // 
            // toolCancelSelect
            // 
            this.toolCancelSelect.CheckOnClick = true;
            this.toolCancelSelect.Name = "toolCancelSelect";
            this.toolCancelSelect.Size = new System.Drawing.Size(180, 22);
            this.toolCancelSelect.Text = "取消选择";
            this.toolCancelSelect.Click += new System.EventHandler(this.toolCancelSelect_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusLabelXY});
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // StatusLabelXY
            // 
            this.StatusLabelXY.Name = "StatusLabelXY";
            this.StatusLabelXY.Size = new System.Drawing.Size(29, 17);
            this.StatusLabelXY.Text = "X:Y:";
            // 
            // toolSelectQuitEdit
            // 
            this.toolSelectQuitEdit.CheckOnClick = true;
            this.toolSelectQuitEdit.Name = "toolSelectQuitEdit";
            this.toolSelectQuitEdit.Size = new System.Drawing.Size(180, 22);
            this.toolSelectQuitEdit.Text = "退出";
            this.toolSelectQuitEdit.Visible = false;
            this.toolSelectQuitEdit.Click += new System.EventHandler(this.toolSelectQuitEdit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.cmsPic.ResumeLayout(false);
            this.cmsSelectPri.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripMenuItem 开始ToolStripMenuItem;
        private System.Windows.Forms.ToolStripLabel toolRectangle;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusLabelXY;
        private System.Windows.Forms.ToolStripLabel toolLine;
        public System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolStripLabel toolData;
        private System.Windows.Forms.ToolStripLabel tooltext;
        private System.Windows.Forms.ToolStripLabel toolNode;
        private System.Windows.Forms.ToolStripLabel toolArrow;
        private System.Windows.Forms.ContextMenuStrip cmsPic;
        private System.Windows.Forms.ToolStripMenuItem toolMoveALL;
        private System.Windows.Forms.ToolStripMenuItem toolRotateALL;
        private System.Windows.Forms.ToolStripMenuItem toolSelectALL;
        private System.Windows.Forms.ToolStripMenuItem toolCancelCommand;
        private System.Windows.Forms.ContextMenuStrip cmsSelectPri;
        private System.Windows.Forms.ToolStripMenuItem toolSelectDelete;
        private System.Windows.Forms.ToolStripMenuItem toolSelectMove;
        private System.Windows.Forms.ToolStripMenuItem toolSelectCopy;
        private System.Windows.Forms.ToolStripMenuItem toolSelectRotate;
        private System.Windows.Forms.ToolStripMenuItem toolCancelSelect;
        private System.Windows.Forms.ToolStripMenuItem toolPriALL;
        private System.Windows.Forms.ToolStripMenuItem toolSelectQuitEdit;
    }
}

