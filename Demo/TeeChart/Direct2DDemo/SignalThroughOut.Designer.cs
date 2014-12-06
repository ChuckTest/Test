namespace Direct2DDemo
{
    partial class SignalThroughOut
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cbAntiAliased = new System.Windows.Forms.CheckBox();
            this.rbGDIplus = new System.Windows.Forms.RadioButton();
            this.rbDirect2D = new System.Windows.Forms.RadioButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tChart = new Steema.TeeChart.TChart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.checkBox1);
            this.panel1.Controls.Add(this.cbAntiAliased);
            this.panel1.Controls.Add(this.rbGDIplus);
            this.panel1.Controls.Add(this.rbDirect2D);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 29);
            this.panel1.TabIndex = 0;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(503, 7);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(108, 16);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.Text = "Scroll or Page";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(403, 7);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 3;
            this.checkBox1.Text = "animated";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // cbAntiAliased
            // 
            this.cbAntiAliased.AutoSize = true;
            this.cbAntiAliased.Location = new System.Drawing.Point(300, 7);
            this.cbAntiAliased.Name = "cbAntiAliased";
            this.cbAntiAliased.Size = new System.Drawing.Size(60, 16);
            this.cbAntiAliased.TabIndex = 2;
            this.cbAntiAliased.Text = "抗锯齿";
            this.cbAntiAliased.UseVisualStyleBackColor = true;
            this.cbAntiAliased.CheckedChanged += new System.EventHandler(this.cbAntiAliased_CheckedChanged);
            // 
            // rbGDIplus
            // 
            this.rbGDIplus.AutoSize = true;
            this.rbGDIplus.Location = new System.Drawing.Point(156, 7);
            this.rbGDIplus.Name = "rbGDIplus";
            this.rbGDIplus.Size = new System.Drawing.Size(89, 16);
            this.rbGDIplus.TabIndex = 1;
            this.rbGDIplus.Text = "GDI+ Canvas";
            this.rbGDIplus.UseVisualStyleBackColor = true;
            // 
            // rbDirect2D
            // 
            this.rbDirect2D.AutoSize = true;
            this.rbDirect2D.Checked = true;
            this.rbDirect2D.Location = new System.Drawing.Point(36, 7);
            this.rbDirect2D.Name = "rbDirect2D";
            this.rbDirect2D.Size = new System.Drawing.Size(113, 16);
            this.rbDirect2D.TabIndex = 0;
            this.rbDirect2D.TabStop = true;
            this.rbDirect2D.Text = "Direct2D Canvas";
            this.rbDirect2D.UseVisualStyleBackColor = true;
            this.rbDirect2D.CheckedChanged += new System.EventHandler(this.rbDirect2D_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.tChart);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 29);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(708, 385);
            this.panel2.TabIndex = 1;
            // 
            // tChart
            // 
            this.tChart.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tChart.Location = new System.Drawing.Point(0, 0);
            this.tChart.Name = "tChart";
            this.tChart.Size = new System.Drawing.Size(708, 385);
            this.tChart.TabIndex = 0;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 10;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // SignalThroughOut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(708, 414);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "SignalThroughOut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbGDIplus;
        private System.Windows.Forms.RadioButton rbDirect2D;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox cbAntiAliased;
        private Steema.TeeChart.TChart tChart;
        private System.Windows.Forms.Timer timer1;
    }
}