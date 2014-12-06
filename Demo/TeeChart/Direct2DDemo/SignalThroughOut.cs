using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using Steema.TeeChart;
using Steema.TeeChart.Drawing;
using Steema.TeeChart.Drawing.Direct2D;
using Steema.TeeChart.Styles;

namespace Direct2DDemo
{
    public partial class SignalThroughOut : Form
    {
        public SignalThroughOut()
        {
            InitializeComponent();
            Graphics3DDirect2D D2D = new Graphics3DDirect2D(tChart.Chart);
            tChart.Graphics3D = D2D;
            tChart.Graphics3D.BufferStyle = BufferStyle.None;
            InitializeCharts();
        }

        protected void InitializeCharts()
        {
            Utils.CalcFramesPerSecond = true;

            tChart.Panel.Color = Color.Black;

            tChart.Axes.Left.SetMinMax(-2.5, 2.5);
            tChart.Axes.Bottom.SetMinMax(0, 1000);

            tChart.Series.Add(fastLine = new FastLine());
            tChart.Series.Add(fastLine2 = new FastLine());
            tChart.Series.Add(fastLine3 = new FastLine());
            tChart.Series.Add(fastLine4 = new FastLine());
            tChart.Series.Add(fastLine5 = new FastLine());
            tChart.Series.Add(fastLine6 = new FastLine());

            fastLine.LinePen.UseStyling = false;
            fastLine2.LinePen.UseStyling = false;
            fastLine3.LinePen.UseStyling = false;
            fastLine4.LinePen.UseStyling = false;
            fastLine5.LinePen.UseStyling = false;
            fastLine6.LinePen.UseStyling = false;

            fastLine.LinePen.Width = 2;
            fastLine2.LinePen.Width = 2;
            fastLine3.LinePen.Width = 2;
            fastLine4.LinePen.Width = 2;
            fastLine5.LinePen.Width = 2;
            fastLine6.LinePen.Width = 2;

            //*********** axes ***********
            tChart.Axes.Bottom.Labels.Font.Color = Color.LightGray;

            tChart.Axes.Left.EndPosition = 100 / (tChart.Series.Count);//设置fastline的y轴的结束位置
            tChart.Axes.Left.Labels.Font.Color = Color.LightGray;
            
            addCustomLeftAxis(fastLine2);
            addCustomLeftAxis(fastLine3);
            addCustomLeftAxis(fastLine4);
            addCustomLeftAxis(fastLine5);
            addCustomLeftAxis(fastLine6);

            tChart.Aspect.View3D = false;

            tChart.Walls.Visible = false;
            tChart.Legend.Visible = false;
            tChart.Header.Visible = false;

            tChart.Panel.Pen.UseStyling = false;
            tChart.Panel.Bevel.Inner = BevelStyles.None;
            tChart.Panel.Bevel.Outer = BevelStyles.None;
        }

        private void addCustomLeftAxis(Series s)
        {
            Axis a = new Axis(false, false, tChart.Chart);

            double axisShare = 100 / (tChart.Series.Count);

            a.StartPosition = axisShare * tChart.Series.IndexOf(s);
            a.EndPosition = (axisShare * tChart.Series.IndexOf(s)) + axisShare;
            a.Labels.Font.Color = Color.LightGray;

            a.SetMinMax(-2.5, 2.5);

            switch (1 + tChart.Series.IndexOf(s))
            {
                case 2: a.SetMinMax(-Max(ff.arr2), Max(ff.arr2)); break;
                case 3: a.SetMinMax(-Max(ff.arr3), Max(ff.arr3)); break;
                case 4: a.SetMinMax(-Max(ff.arr4), Max(ff.arr4)); break;
                case 5: a.SetMinMax(-Max(ff.arr5), Max(ff.arr5)); break;
                case 6: a.SetMinMax(-Max(ff.arr6), Max(ff.arr6)); break;
            }
            tChart.Axes.Custom.Add(a);
            s.CustomVertAxis = a;
        }

        private double Max(double[] array)
        {
            double maxVal = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxVal)
                    maxVal = array[i];
            }
            return maxVal;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                int rr = 0;

                tChart.AutoRepaint = false;

                for (int i = 0; i < 15; i++)
                {
                    if (dataCounter >= ff.arr1.Length)
                        rr = dataCounter % ff.arr1.Length;
                    else
                        rr = dataCounter;

                    if (checkBox2.Checked)
                    {
                        if (tChart.Axes.Bottom.Maximum - fastLine.XValues.Maximum == 50)
                            tChart.Axes.Bottom.SetMinMax(tChart.Axes.Bottom.Minimum + 15, tChart.Axes.Bottom.Maximum + 15);
                    }
                    else
                    {
                        if ((dataCounter > 0) && (rr == 0))
                            tChart.Axes.Bottom.SetMinMax(dataCounter, dataCounter + 1000);
                    }

                    fastLine.Add(dataCounter, ff.arr1[rr]);
                    fastLine2.Add(dataCounter, ff.arr2[rr]);
                    fastLine3.Add(dataCounter, ff.arr3[rr]);
                    fastLine4.Add(dataCounter, ff.arr4[rr]);
                    fastLine5.Add(dataCounter, ff.arr5[rr]);
                    fastLine6.Add(dataCounter, ff.arr6[rr]);

                    dataCounter++;

                }

                if (fastLine.Count > 10000)
                {
                    fastLine.Delete(0, 5000);
                    fastLine2.Delete(0, 5000);
                    fastLine3.Delete(0, 5000);
                    fastLine4.Delete(0, 5000);
                    fastLine5.Delete(0, 5000);
                    fastLine6.Delete(0, 5000);
                }

                tChart.AutoRepaint = true;
                tChart.Invalidate();

                PointsPerFrame = (int)Math.Round((fastLine.XValues.Maximum - tChart.Axes.Bottom.Minimum) * 6);

                baseDoTimerTick();
            }
            catch (Exception ex)
            {
                timer1.Enabled = false;
                MessageBox.Show(ex.Message);
            }
        }

        protected void OnChangeParam()
        {
            frames.Clear();
            ticks = DateTime.Now.Ticks;
        }

        protected void baseDoTimerTick()
        {
            string fps;
            string seconds;
            string name;
            Debug.WriteLineIf(Utils.CalcFramesPerSecond, "Utils.FramesPerSecond计算开启");

            if (Utils.FramesPerSecond > 0)
            {
                frames.Add(Utils.FramesPerSecond);
            }
            if (frames.Count > 0)
            {
                fps = GetAverage();
            }
            else
            {
                fps = "0";
            }

            //DateTime.Ticks
            //A single tick represents one hundred nanoseconds or one ten-millionth of a second. There are 10,000 ticks in a millisecond, or 10 million ticks in a second.
            //The value of this property represents the number of 100-nanosecond intervals that have elapsed since 12:00:00 midnight, January 1, 0001, which represents DateTime.MinValue. It does not include the number of ticks that are attributable to leap seconds.

            //TimeSpan.FromTicks
            //Returns a TimeSpan that represents a specified time, where the specification is in units of ticks.

            //TimeSpan.Ticks   The number of ticks contained in this instance.
            seconds = TimeSpan.FromTicks(DateTime.Now.Ticks - ticks).Seconds.ToString();

            if (tChart.Graphics3D is Graphics3DDirect2D)
            {
                name = "TeeChart.Direct2D.dll";
            }
            else
            {
                name = "TeeChart.dll";
            }
            //我们通常说帧数，简单地说，就是在1秒钟时间里传输的图片的帧数，也可以理解为图形处理器每秒钟能够刷新几次，通常用fps（Frames Per Second）表示。
            //每一帧都是静止的图象，快速连续地显示帧便形成了运动的假象。高的帧率可以得到更流畅、更逼真的动画。每秒钟帧数 (fps) 愈多，所显示的动作就会愈流畅。
            name += " | 帧率: " + fps + " | 点数/帧: " + PointsPerFrame.ToString() + " | 耗时: " + seconds;
            Debug.WriteLine(name);

            this.Invoke((MethodInvoker)delegate() {
                Text = name;
            });
        }

        private string GetAverage()
        {
            return frames.Average().ToString("F2");
        }
        private void rbDirect2D_CheckedChanged(object sender, EventArgs e)
        {
            timer1.Enabled = false;

            if (rbDirect2D.Checked)
            {
                setD2D(tChart);
            }
            else
            {
                setGDIPlus(tChart);
            }

            OnChangeParam();
            timer1.Enabled = checkBox1.Checked;
        }

        private void setD2D(TChart chart)
        {
            if (D2D == null)
            {
                D2D = new Graphics3DDirect2D(chart.Chart);
            }
            if (cbAntiAliased.Checked)//平滑
            {
                D2D.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                D2D.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//抗锯齿
            }
            else
            {
                D2D.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
                D2D.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;//不抗锯齿
            }

            chart.Graphics3D = D2D;
            chart.Graphics3D.BufferStyle = BufferStyle.None;//No double-buffering.
        }

        private void setGDIPlus(TChart chart)
        {
            if (GDI == null)
            {
                GDI = new Graphics3DGdiPlus(chart.Chart);
            }
            if (cbAntiAliased.Checked)//平滑
            {
                GDI.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
                GDI.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;//抗锯齿
            }
            else
            {
                GDI.TextRenderingHint = System.Drawing.Text.TextRenderingHint.SingleBitPerPixel;
                GDI.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;//不抗锯齿
            }

            chart.Graphics3D = GDI;
            chart.Graphics3D.BufferStyle = BufferStyle.OptimizedBuffer;//Manually implemented, fully optimal double-buffering. 
        }

        private void cbAntiAliased_CheckedChanged(object sender, EventArgs e)
        {
            rbDirect2D_CheckedChanged(sender, e);
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            OnChangeParam();
            timer1.Enabled = checkBox1.Checked;
        }

        private Graphics3DDirect2D D2D = null;//继承自Graphics3D, IDirect2D
        private Graphics3DGdiPlus GDI = null;//继承自Graphics3D

        private FastLine fastLine;
        private FastLine fastLine2;
        private FastLine fastLine3;
        private FastLine fastLine4;
        private FastLine fastLine5;
        private FastLine fastLine6;
        protected TestData ff = new TestData();

        protected long ticks;
        protected List<float> frames = new List<float>();
        public int PointsPerFrame { get; set; }

        int dataCounter = 0;

    }
}
