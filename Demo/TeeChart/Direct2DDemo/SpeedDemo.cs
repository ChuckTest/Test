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
    public partial class SpeedDemo : Form
    {
        
        public SpeedDemo()
        {
            InitializeComponent();
            Graphics3DDirect2D D2D = new Graphics3DDirect2D(tChart.Chart);
            tChart.Graphics3D = D2D;
            InitializeCharts();
        }

        /// <summary>
        /// 加载界面的时候
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Enabled = checkBox1.Checked;
            this.TickFired += Form1_TickFired;
        }

        void Form1_TickFired(object sender, SpeedDemo.TickFiredEventArgs e)
        {
            this.Text = e.Text;
        }

        /// <summary>
        /// 初始化图表的属性
        /// </summary>
        protected virtual void InitializeCharts()
        {
            tChart.Aspect.View3D = false;

            tChart.Walls.Visible = false;
            tChart.Legend.Visible = false;
            tChart.Header.Visible = false;

            tChart.Panel.Pen.UseStyling = false;
            tChart.Panel.Bevel.Inner = BevelStyles.None;
            tChart.Panel.Bevel.Outer = BevelStyles.None;

            Utils.CalcFramesPerSecond = true;//Gets or sets whether the FramesPerSecond is calculated or not (>= .NET 2.0).
            tChart.Panel.Gradient.Visible = false;//panel的渐变不可见
            tChart.Panel.Color = Color.Black;//panle的背景色设置为黑色

            tChart.Series.Add(fastLine = new FastLine());

            tChart.Axes.Left.SetMinMax(0, 600);

            tChart.Axes.Left.AxisPen.UseStyling = false;
            tChart.Axes.Bottom.AxisPen.UseStyling = false;

            tChart.Axes.Left.Grid.UseStyling = false;
            tChart.Axes.Bottom.Grid.UseStyling = false;

            fastLine.Color = Color.Lime;
            fastLine.LinePen.UseStyling = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DoTimerTick();
        }

        /// <summary>
        /// 计算平均值并转换为16进制
        /// </summary>
        /// <returns></returns>
        private string GetAverage()
        {
            return frames.Average().ToString("F2");
        }

        /// <summary>
        /// 定时刷新
        /// </summary>
        protected  void DoTimerTick()
        {
            tChart.AutoRepaint = false;//Enables/Disables Repainting of Chart when points are added.

            for (int i = 0; i < 500; i++)//一次刷新500个点
            {
                fastLine.Add(count, rnd.Next(100, 500));
                ++count;
            }

            tChart.Axes.Bottom.SetMinMax(fastLine.XValues.Maximum - 10000, fastLine.XValues.Maximum);//设置横轴的最小值和最大值

            if (fastLine.Count >= 20000)//点数超出2万
            {
                fastLine.Delete(0, 10000);//删除前1万条数据
            }

            tChart.AutoRepaint = true;//Enables/Disables Repainting of Chart when points are added.

            tChart.Invalidate();

            PointsPerFrame = (int)Math.Round(fastLine.XValues.Maximum - tChart.Axes.Bottom.Minimum);

            baseDoTimerTick();
        }

        /// <summary>
        /// 刷新窗体的标题
        /// </summary>
        protected  void baseDoTimerTick()
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

            OnTickFired(new TickFiredEventArgs() { Text = name });
        }

        public class TickFiredEventArgs : EventArgs
        {
            public string Text { get; set; }
        }

        public delegate void TickFiredEventHandler(object sender, TickFiredEventArgs e);
        public event TickFiredEventHandler TickFired;
       
        protected void OnTickFired(TickFiredEventArgs e)
        {
            if (TickFired != null)
            {
                TickFired(this, e);
            }
        }

        protected void OnChangeParam()
        {
            frames.Clear();
            ticks = DateTime.Now.Ticks;
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            OnChangeParam();
            timer1.Enabled = checkBox1.Checked;
        }

        private void cbAntiAliased_CheckedChanged(object sender, EventArgs e)
        {
            rbDirect2D_CheckedChanged(sender, e);
        }

        FastLine fastLine;
        Random rnd = new Random(400);
        int count;

        private Graphics3DDirect2D D2D = null;//继承自Graphics3D, IDirect2D
        private Graphics3DGdiPlus GDI = null;//继承自Graphics3D

        protected long ticks;
        protected List<float> frames = new List<float>();
        public int PointsPerFrame { get; set; }

        protected TestData ff = new TestData();
    }
}
