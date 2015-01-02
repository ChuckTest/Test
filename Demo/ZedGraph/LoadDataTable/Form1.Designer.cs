namespace LoadDataTable
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonLoadData = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPressureTest = new System.Windows.Forms.ToolStripButton();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.zedGraphControl1 = new ZedGraph.ZedGraphControl();
            this.timerPressureTest = new System.Windows.Forms.Timer(this.components);
            this.toolStripButtonLoadDataTable = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonLoadData,
            this.toolStripButtonPressureTest,
            this.toolStripButtonLoadDataTable});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(893, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButtonLoadData
            // 
            this.toolStripButtonLoadData.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonLoadData.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoadData.Image")));
            this.toolStripButtonLoadData.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoadData.Name = "toolStripButtonLoadData";
            this.toolStripButtonLoadData.Size = new System.Drawing.Size(93, 22);
            this.toolStripButtonLoadData.Text = "加载100万个点";
            this.toolStripButtonLoadData.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButtonPressureTest
            // 
            this.toolStripButtonPressureTest.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonPressureTest.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPressureTest.Image")));
            this.toolStripButtonPressureTest.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPressureTest.Name = "toolStripButtonPressureTest";
            this.toolStripButtonPressureTest.Size = new System.Drawing.Size(60, 22);
            this.toolStripButtonPressureTest.Text = "压力测试";
            this.toolStripButtonPressureTest.Click += new System.EventHandler(this.toolStripButtonPressureTest_Click);
            // 
            // splitter1
            // 
            this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
            this.splitter1.Location = new System.Drawing.Point(0, 25);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(893, 3);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // zedGraphControl1
            // 
            this.zedGraphControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.zedGraphControl1.Location = new System.Drawing.Point(0, 28);
            this.zedGraphControl1.Name = "zedGraphControl1";
            this.zedGraphControl1.ScrollGrace = 0D;
            this.zedGraphControl1.ScrollMaxX = 0D;
            this.zedGraphControl1.ScrollMaxY = 0D;
            this.zedGraphControl1.ScrollMaxY2 = 0D;
            this.zedGraphControl1.ScrollMinX = 0D;
            this.zedGraphControl1.ScrollMinY = 0D;
            this.zedGraphControl1.ScrollMinY2 = 0D;
            this.zedGraphControl1.Size = new System.Drawing.Size(893, 475);
            this.zedGraphControl1.TabIndex = 3;
            this.zedGraphControl1.UseExtendedPrintDialog = true;
            // 
            // timerPressureTest
            // 
            this.timerPressureTest.Interval = 1000;
            this.timerPressureTest.Tick += new System.EventHandler(this.timerPressureTest_Tick);
            // 
            // toolStripButtonLoadDataTable
            // 
            this.toolStripButtonLoadDataTable.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonLoadDataTable.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonLoadDataTable.Image")));
            this.toolStripButtonLoadDataTable.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonLoadDataTable.Name = "toolStripButtonLoadDataTable";
            this.toolStripButtonLoadDataTable.Size = new System.Drawing.Size(95, 22);
            this.toolStripButtonLoadDataTable.Text = "加载DataTable";
            this.toolStripButtonLoadDataTable.Click += new System.EventHandler(this.toolStripButtonLoadDataTable_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 503);
            this.Controls.Add(this.zedGraphControl1);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.toolStrip1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ZedGraph测试";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadData;
        private System.Windows.Forms.Splitter splitter1;
        private ZedGraph.ZedGraphControl zedGraphControl1;
        private System.Windows.Forms.ToolStripButton toolStripButtonPressureTest;
        private System.Windows.Forms.Timer timerPressureTest;
        private System.Windows.Forms.ToolStripButton toolStripButtonLoadDataTable;

    }
}

