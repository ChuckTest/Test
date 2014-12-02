namespace Direct2DDemo
{
    partial class SpeedDemo
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.cbAntiAliased = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.rbGDIplus = new System.Windows.Forms.RadioButton();
            this.rbDirect2D = new System.Windows.Forms.RadioButton();
            this.workPanel = new System.Windows.Forms.Panel();
            this.tChart = new Steema.TeeChart.TChart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.buttonPanel.SuspendLayout();
            this.workPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonPanel
            // 
            this.buttonPanel.Controls.Add(this.cbAntiAliased);
            this.buttonPanel.Controls.Add(this.checkBox1);
            this.buttonPanel.Controls.Add(this.rbGDIplus);
            this.buttonPanel.Controls.Add(this.rbDirect2D);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.buttonPanel.Location = new System.Drawing.Point(0, 0);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(708, 29);
            this.buttonPanel.TabIndex = 0;
            // 
            // cbAntiAliased
            // 
            this.cbAntiAliased.AutoSize = true;
            this.cbAntiAliased.Location = new System.Drawing.Point(398, 7);
            this.cbAntiAliased.Name = "cbAntiAliased";
            this.cbAntiAliased.Size = new System.Drawing.Size(60, 16);
            this.cbAntiAliased.TabIndex = 3;
            this.cbAntiAliased.Text = "抗锯齿";
            this.cbAntiAliased.UseVisualStyleBackColor = true;
            this.cbAntiAliased.CheckedChanged += new System.EventHandler(this.cbAntiAliased_CheckedChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(500, 7);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "animated";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // rbGDIplus
            // 
            this.rbGDIplus.AutoSize = true;
            this.rbGDIplus.Location = new System.Drawing.Point(190, 7);
            this.rbGDIplus.Name = "rbGDIplus";
            this.rbGDIplus.Size = new System.Drawing.Size(89, 16);
            this.rbGDIplus.TabIndex = 1;
            this.rbGDIplus.TabStop = true;
            this.rbGDIplus.Text = "GDI+ Canvas";
            this.rbGDIplus.UseVisualStyleBackColor = true;
            // 
            // rbDirect2D
            // 
            this.rbDirect2D.AutoSize = true;
            this.rbDirect2D.Checked = true;
            this.rbDirect2D.Location = new System.Drawing.Point(54, 7);
            this.rbDirect2D.Name = "rbDirect2D";
            this.rbDirect2D.Size = new System.Drawing.Size(113, 16);
            this.rbDirect2D.TabIndex = 0;
            this.rbDirect2D.TabStop = true;
            this.rbDirect2D.Text = "Direct2D Canvas";
            this.rbDirect2D.UseVisualStyleBackColor = true;
            this.rbDirect2D.CheckedChanged += new System.EventHandler(this.rbDirect2D_CheckedChanged);
            // 
            // workPanel
            // 
            this.workPanel.Controls.Add(this.tChart);
            this.workPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.workPanel.Location = new System.Drawing.Point(0, 29);
            this.workPanel.Name = "workPanel";
            this.workPanel.Size = new System.Drawing.Size(708, 385);
            this.workPanel.TabIndex = 1;
            // 
            // tChart
            // 
            // 
            // 
            // 
            this.tChart.Aspect.View3D = false;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Axes.Bottom.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Axes.Left.Labels.Font.Brush.Color = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.tChart.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            this.tChart.Header.Visible = false;
            this.tChart.Location = new System.Drawing.Point(0, 0);
            this.tChart.Name = "tChart";
            this.tChart.Size = new System.Drawing.Size(708, 385);
            this.tChart.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SpeedDemo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 414);
            this.Controls.Add(this.workPanel);
            this.Controls.Add(this.buttonPanel);
            this.Name = "SpeedDemo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.buttonPanel.ResumeLayout(false);
            this.buttonPanel.PerformLayout();
            this.workPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Panel workPanel;
        private System.Windows.Forms.RadioButton rbGDIplus;
        private System.Windows.Forms.RadioButton rbDirect2D;
        private Steema.TeeChart.TChart tChart;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.CheckBox cbAntiAliased;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}