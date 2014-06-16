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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tspMenu = new System.Windows.Forms.ToolStrip();
            this.tspBtnConfig = new System.Windows.Forms.ToolStripButton();
            this.tspOpenPort = new System.Windows.Forms.ToolStripButton();
            this.tspClosePort = new System.Windows.Forms.ToolStripButton();
            this.tspMenu.SuspendLayout();
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
            this.tspMenu.Size = new System.Drawing.Size(1002, 25);
            this.tspMenu.TabIndex = 0;
            this.tspMenu.Text = "toolStrip1";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 546);
            this.Controls.Add(this.tspMenu);
            this.Name = "MainForm";
            this.Text = "BMP图片查看器";
            this.tspMenu.ResumeLayout(false);
            this.tspMenu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip tspMenu;
        private System.Windows.Forms.ToolStripButton tspBtnConfig;
        private System.Windows.Forms.ToolStripButton tspOpenPort;
        private System.Windows.Forms.ToolStripButton tspClosePort;
    }
}

