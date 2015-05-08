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
            this.checkBoxMove = new System.Windows.Forms.CheckBox();
            this.checkBoxEnabled = new System.Windows.Forms.CheckBox();
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
            this.panel1.Controls.Add(this.checkBoxMove);
            this.panel1.Controls.Add(this.checkBoxEnabled);
            this.panel1.Controls.Add(this.cbAntiAliased);
            this.panel1.Controls.Add(this.rbGDIplus);
            this.panel1.Controls.Add(this.rbDirect2D);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(708, 29);
            this.panel1.TabIndex = 0;
            // 
            // checkBoxMove
            // 
            this.checkBoxMove.AutoSize = true;
            this.checkBoxMove.Location = new System.Drawing.Point(503, 7);
            this.checkBoxMove.Name = "checkBoxMove";
            this.checkBoxMove.Size = new System.Drawing.Size(108, 16);
            this.checkBoxMove.TabIndex = 4;
            this.checkBoxMove.Text = "Scroll or Page";
            this.checkBoxMove.UseVisualStyleBackColor = true;
            this.checkBoxMove.CheckedChanged += new System.EventHandler(this.checkBoxMove_CheckedChanged);
            // 
            // checkBoxEnabled
            // 
            this.checkBoxEnabled.AutoSize = true;
            this.checkBoxEnabled.Checked = true;
            this.checkBoxEnabled.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxEnabled.Location = new System.Drawing.Point(403, 7);
            this.checkBoxEnabled.Name = "checkBoxEnabled";
            this.checkBoxEnabled.Size = new System.Drawing.Size(66, 16);
            this.checkBoxEnabled.TabIndex = 3;
            this.checkBoxEnabled.Text = "enabled";
            this.checkBoxEnabled.UseVisualStyleBackColor = true;
            this.checkBoxEnabled.CheckedChanged += new System.EventHandler(this.checkBoxEnabled_CheckedChanged);
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
            this.tChart.Axes.Bottom.Labels.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Axes.Bottom.Labels.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Axes.Bottom.Labels.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Axes.Bottom.Labels.Bevel.StringColorTwo = "FF808080";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Axes.Bottom.Title.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Axes.Bottom.Title.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Axes.Bottom.Title.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Axes.Bottom.Title.Bevel.StringColorTwo = "FF808080";
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Axes.Depth.Labels.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Axes.Depth.Labels.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Axes.Depth.Labels.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Axes.Depth.Labels.Bevel.StringColorTwo = "FF808080";
            this.tChart.Axes.Depth.LabelsAsSeriesTitles = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Axes.Depth.Title.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Axes.Depth.Title.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Axes.Depth.Title.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Axes.Depth.Title.Bevel.StringColorTwo = "FF808080";
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Axes.DepthTop.Labels.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Axes.DepthTop.Labels.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Axes.DepthTop.Labels.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Axes.DepthTop.Labels.Bevel.StringColorTwo = "FF808080";
            this.tChart.Axes.DepthTop.LabelsAsSeriesTitles = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Axes.DepthTop.Title.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Axes.DepthTop.Title.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Axes.DepthTop.Title.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Axes.DepthTop.Title.Bevel.StringColorTwo = "FF808080";
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Axes.Left.Labels.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Axes.Left.Labels.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Axes.Left.Labels.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Axes.Left.Labels.Bevel.StringColorTwo = "FF808080";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Axes.Left.Title.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Axes.Left.Title.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Axes.Left.Title.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Axes.Left.Title.Bevel.StringColorTwo = "FF808080";
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Axes.Right.Labels.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Axes.Right.Labels.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Axes.Right.Labels.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Axes.Right.Labels.Bevel.StringColorTwo = "FF808080";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Axes.Right.Title.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Axes.Right.Title.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Axes.Right.Title.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Axes.Right.Title.Bevel.StringColorTwo = "FF808080";
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Axes.Top.Labels.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Axes.Top.Labels.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Axes.Top.Labels.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Axes.Top.Labels.Bevel.StringColorTwo = "FF808080";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Axes.Top.Title.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Axes.Top.Title.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Axes.Top.Title.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Axes.Top.Title.Bevel.StringColorTwo = "FF808080";
            this.tChart.Dock = System.Windows.Forms.DockStyle.Fill;
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Footer.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Footer.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Footer.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Footer.Bevel.StringColorTwo = "FF808080";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Header.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Header.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Header.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Header.Bevel.StringColorTwo = "FF808080";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Legend.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Legend.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Legend.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Legend.Bevel.StringColorTwo = "FF808080";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Legend.Title.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Legend.Title.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Legend.Title.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Legend.Title.Bevel.StringColorTwo = "FF808080";
            this.tChart.Location = new System.Drawing.Point(0, 0);
            this.tChart.Name = "tChart";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Panel.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Panel.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Panel.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Panel.Bevel.StringColorTwo = "FF808080";
            this.tChart.Size = new System.Drawing.Size(708, 385);
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.SubFooter.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.SubFooter.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.SubFooter.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.SubFooter.Bevel.StringColorTwo = "FF808080";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.SubHeader.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.SubHeader.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.SubHeader.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.SubHeader.Bevel.StringColorTwo = "FF808080";
            this.tChart.TabIndex = 0;
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Walls.Back.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Walls.Back.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Walls.Back.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Walls.Back.Bevel.StringColorTwo = "FF808080";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Walls.Bottom.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Walls.Bottom.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Walls.Bottom.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Walls.Bottom.Bevel.StringColorTwo = "FF808080";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Walls.Left.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Walls.Left.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Walls.Left.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Walls.Left.Bevel.StringColorTwo = "FF808080";
            // 
            // 
            // 
            // 
            // 
            // 
            this.tChart.Walls.Right.Bevel.ColorOne = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.tChart.Walls.Right.Bevel.ColorTwo = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.tChart.Walls.Right.Bevel.StringColorOne = "FFFFFFFF";
            this.tChart.Walls.Right.Bevel.StringColorTwo = "FF808080";
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
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
        private System.Windows.Forms.CheckBox checkBoxMove;
        private System.Windows.Forms.CheckBox checkBoxEnabled;
        private System.Windows.Forms.CheckBox cbAntiAliased;
        private Steema.TeeChart.TChart tChart;
        private System.Windows.Forms.Timer timer1;
    }
}