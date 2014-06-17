namespace BmpProject
{
    partial class MainForm
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tspMenu = new System.Windows.Forms.ToolStrip();
            this.tspOpenPort = new System.Windows.Forms.ToolStripButton();
            this.tspClosePort = new System.Windows.Forms.ToolStripButton();
            this.tspBtnConfig = new System.Windows.Forms.ToolStripButton();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnChooseBmp = new System.Windows.Forms.Button();
            this.lalFilePath = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCoordinate = new System.Windows.Forms.Label();
            this.lblPicSize = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnLoadNewCurve = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.tspMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tspMenu
            // 
            this.tspMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tspOpenPort,
            this.tspClosePort,
            this.tspBtnConfig});
            this.tspMenu.Location = new System.Drawing.Point(0, 0);
            this.tspMenu.Name = "tspMenu";
            this.tspMenu.Size = new System.Drawing.Size(1035, 25);
            this.tspMenu.TabIndex = 0;
            this.tspMenu.Text = "toolStrip1";
            // 
            // tspOpenPort
            // 
            this.tspOpenPort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tspOpenPort.Image = ((System.Drawing.Image)(resources.GetObject("tspOpenPort.Image")));
            this.tspOpenPort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspOpenPort.Name = "tspOpenPort";
            this.tspOpenPort.Size = new System.Drawing.Size(60, 22);
            this.tspOpenPort.Text = "打开串口";
            this.tspOpenPort.Click += new System.EventHandler(this.tspOpenPort_Click);
            // 
            // tspClosePort
            // 
            this.tspClosePort.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tspClosePort.Enabled = false;
            this.tspClosePort.Image = ((System.Drawing.Image)(resources.GetObject("tspClosePort.Image")));
            this.tspClosePort.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspClosePort.Name = "tspClosePort";
            this.tspClosePort.Size = new System.Drawing.Size(60, 22);
            this.tspClosePort.Text = "关闭串口";
            this.tspClosePort.Click += new System.EventHandler(this.tspClosePort_Click);
            // 
            // tspBtnConfig
            // 
            this.tspBtnConfig.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.tspBtnConfig.Image = ((System.Drawing.Image)(resources.GetObject("tspBtnConfig.Image")));
            this.tspBtnConfig.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tspBtnConfig.Name = "tspBtnConfig";
            this.tspBtnConfig.Size = new System.Drawing.Size(60, 22);
            this.tspBtnConfig.Text = "串口设置";
            this.tspBtnConfig.Click += new System.EventHandler(this.tspBtnConfig_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(71, 28);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(181, 21);
            this.txtFilePath.TabIndex = 1;
            // 
            // btnChooseBmp
            // 
            this.btnChooseBmp.Location = new System.Drawing.Point(258, 26);
            this.btnChooseBmp.Name = "btnChooseBmp";
            this.btnChooseBmp.Size = new System.Drawing.Size(75, 23);
            this.btnChooseBmp.TabIndex = 2;
            this.btnChooseBmp.Text = "浏览";
            this.btnChooseBmp.UseVisualStyleBackColor = true;
            this.btnChooseBmp.Click += new System.EventHandler(this.btnChooseBmp_Click);
            // 
            // lalFilePath
            // 
            this.lalFilePath.AutoSize = true;
            this.lalFilePath.Location = new System.Drawing.Point(12, 35);
            this.lalFilePath.Name = "lalFilePath";
            this.lalFilePath.Size = new System.Drawing.Size(53, 12);
            this.lalFilePath.TabIndex = 3;
            this.lalFilePath.Text = "图片路径";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pictureBox1.Location = new System.Drawing.Point(6, 42);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(344, 424);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lblCoordinate);
            this.groupBox1.Controls.Add(this.lblPicSize);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Location = new System.Drawing.Point(0, 55);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(360, 480);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "图片展示区";
            // 
            // lblCoordinate
            // 
            this.lblCoordinate.AutoSize = true;
            this.lblCoordinate.Location = new System.Drawing.Point(184, 24);
            this.lblCoordinate.Name = "lblCoordinate";
            this.lblCoordinate.Size = new System.Drawing.Size(71, 12);
            this.lblCoordinate.TabIndex = 6;
            this.lblCoordinate.Text = "坐标(行,列)";
            // 
            // lblPicSize
            // 
            this.lblPicSize.AutoSize = true;
            this.lblPicSize.Location = new System.Drawing.Point(12, 24);
            this.lblPicSize.Name = "lblPicSize";
            this.lblPicSize.Size = new System.Drawing.Size(53, 12);
            this.lblPicSize.TabIndex = 5;
            this.lblPicSize.Text = "图片大小";
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(381, 97);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(642, 438);
            this.tabControl1.TabIndex = 6;
            // 
            // tabPage1
            // 
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(634, 412);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "曲线展示区";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.btnSend);
            this.groupBox2.Controls.Add(this.btnLoadNewCurve);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.textBox1);
            this.groupBox2.Location = new System.Drawing.Point(385, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(634, 79);
            this.groupBox2.TabIndex = 7;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "曲线设置";
            // 
            // btnSend
            // 
            this.btnSend.Enabled = false;
            this.btnSend.Location = new System.Drawing.Point(282, 23);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnLoadNewCurve
            // 
            this.btnLoadNewCurve.Location = new System.Drawing.Point(187, 23);
            this.btnLoadNewCurve.Name = "btnLoadNewCurve";
            this.btnLoadNewCurve.Size = new System.Drawing.Size(75, 23);
            this.btnLoadNewCurve.TabIndex = 4;
            this.btnLoadNewCurve.Text = "载入";
            this.btnLoadNewCurve.UseVisualStyleBackColor = true;
            this.btnLoadNewCurve.Click += new System.EventHandler(this.btnLoadNewCurve_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(153, 46);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(17, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "行";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(153, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "行";
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(46, 43);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(46, 14);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1035, 550);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lalFilePath);
            this.Controls.Add(this.btnChooseBmp);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.tspMenu);
            this.Name = "MainForm";
            this.Text = "BMP图片查看器";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.tspMenu.ResumeLayout(false);
            this.tspMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspMenu;
        private System.Windows.Forms.ToolStripButton tspBtnConfig;
        private System.Windows.Forms.ToolStripButton tspOpenPort;
        private System.Windows.Forms.ToolStripButton tspClosePort;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnChooseBmp;
        private System.Windows.Forms.Label lalFilePath;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnLoadNewCurve;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Label lblPicSize;
        private System.Windows.Forms.Label lblCoordinate;
    }
}

