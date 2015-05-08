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
            D2D = new Graphics3DDirect2D(tChart.Chart);
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
            tChart.Axes.Bottom.Labels.Font.Color = Color.LightGray;//X轴刻度的颜色
            tChart.Axes.Left.Labels.Font.Color = Color.LightGray;//Y轴可读的颜色

             //一共有6条曲线
            //第一条曲线的纵轴 直接对应于Y轴
            tChart.Axes.Left.EndPosition = 100 / (tChart.Series.Count);//设置fastline的左轴的结束位置
            
            //剩下的5条曲线，需要添加自定义的纵轴
            addCustomLeftAxis(fastLine2);
            addCustomLeftAxis(fastLine3);
            addCustomLeftAxis(fastLine4);
            addCustomLeftAxis(fastLine5);
            addCustomLeftAxis(fastLine6);

            tChart.Aspect.View3D = false;//取消3D显示效果

            tChart.Walls.Visible = false;
            tChart.Legend.Visible = false;
            tChart.Header.Visible = false;

            tChart.Panel.Pen.UseStyling = false;
            tChart.Panel.Bevel.Inner = BevelStyles.None;
            tChart.Panel.Bevel.Outer = BevelStyles.None;
        }

        /// <summary>
        /// 给指定的曲线添加自定义的纵轴
        /// </summary>
        /// <param name="curve"></param>
        private void addCustomLeftAxis(Series curve)
        {
            Axis axis = new Axis(false, false, tChart.Chart);//创建一个新的坐标轴，作为自定义的纵轴

            double axisShare = 100 / (tChart.Series.Count);//计算单个坐标轴占据Y轴的百分比

            axis.StartPosition = axisShare * tChart.Series.IndexOf(curve);//设置坐标轴的其实位置
            axis.EndPosition = (axisShare * tChart.Series.IndexOf(curve)) + axisShare;//设置坐标轴的结束位置

            axis.Labels.Font.Color = Color.LightGray;//自定义坐标轴的刻度的颜色

            axis.SetMinMax(-2.5, 2.5);//设置坐标轴的默认的取值范围

            //根据每个曲线对应的数值的取值范围决定坐标轴的范围
            switch (1 + tChart.Series.IndexOf(curve))
            {
                case 2:
                    axis.SetMinMax(Min(testData.arr2), Max(testData.arr2));
                    break;
                case 3:
                    axis.SetMinMax(Min(testData.arr3), Max(testData.arr3)); 
                    break;
                case 4:
                    axis.SetMinMax(Min(testData.arr4), Max(testData.arr4));
                    break;
                case 5:
                    axis.SetMinMax(Min(testData.arr5), Max(testData.arr5)); 
                    break;
                case 6:
                    axis.SetMinMax(Min(testData.arr6), Max(testData.arr6)); 
                    break;
            }

            tChart.Axes.Custom.Add(axis);//将坐标轴添加到图表的自定义坐标轴中

            curve.CustomVertAxis = axis;//将曲线curve和坐标轴axis绑定
        }

        /// <summary>
        /// 从指定的数组中筛选出最大值
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private double Max(double[] array)
        {
            double maxVal = array[0];
            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] > maxVal)
                {
                    maxVal = array[i];
                }
            }
            return maxVal;
        }

        /// <summary>
        /// 从指定的数组中筛选出最小值
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private double Min(double[] array)
        {
            double minVal = array[0];
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] < minVal)
                {
                    minVal=array[i];
                }
            }
            return minVal;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                int rr = 0;

                tChart.AutoRepaint = false;

                //一次添加15个点
                for (int i = 0; i < 15; i++)
                {
                    if (dataCounter >= testData.arr1.Length)
                    {
                        rr = dataCounter % testData.arr1.Length;
                    }
                    else
                    {
                        rr = dataCounter;
                    }

                    if (moveFlag)
                    {
                        //滚动效果

                        //如果底轴的最大值-曲线X值列表的最大值=50  则重新调整底轴的范围
                        if (tChart.Axes.Bottom.Maximum - fastLine.XValues.Maximum == 50)
                        {
                            //底轴的最小值和最大值同时增加15，确保平移的效果
                            tChart.Axes.Bottom.SetMinMax(tChart.Axes.Bottom.Minimum + 15, tChart.Axes.Bottom.Maximum + 15);
                        }
                    }
                    else
                    {
                        //不需要滚动效果
                        if ((dataCounter > 0) && (rr == 0))
                        {
                            tChart.Axes.Bottom.SetMinMax(dataCounter, dataCounter + 1000);
                        }
                    }

                    fastLine.Add(dataCounter, testData.arr1[rr]);
                    fastLine2.Add(dataCounter, testData.arr2[rr]);
                    fastLine3.Add(dataCounter, testData.arr3[rr]);
                    fastLine4.Add(dataCounter, testData.arr4[rr]);
                    fastLine5.Add(dataCounter, testData.arr5[rr]);
                    fastLine6.Add(dataCounter, testData.arr6[rr]);

                    dataCounter++;

                }

                //曲线上的点数超过1万，就删除前面5000个点
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

            //帧数大于0的时候，进行统计
            if (Utils.FramesPerSecond > 0)
            {
                frames.Add(Utils.FramesPerSecond);
            }

            //计算每秒刷新的平均帧数
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
                //使用Direct2D
                setD2D(tChart);
            }
            else
            {
                //使用GDI+
                setGDIPlus(tChart);
            }

            OnChangeParam();
            timer1.Enabled = checkBoxEnabled.Checked;
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

        private void checkBoxEnabled_CheckedChanged(object sender, EventArgs e)
        {
            OnChangeParam();
            timer1.Enabled = checkBoxEnabled.Checked;
        }

        private Graphics3DDirect2D D2D = null;//继承自Graphics3D, IDirect2D 同时使用了SlimDX
        private Graphics3DGdiPlus GDI = null;//继承自Graphics3D

        private FastLine fastLine;
        private FastLine fastLine2;
        private FastLine fastLine3;
        private FastLine fastLine4;
        private FastLine fastLine5;
        private FastLine fastLine6;
        protected TestData testData = new TestData();

        protected long ticks;

        /// <summary>
        /// 每秒的刷新的帧数的集合
        /// </summary>
        protected List<float> frames = new List<float>();

        public int PointsPerFrame { get; set; }

        int dataCounter = 0;

        /// <summary>
        /// 标记是否移动平移曲线
        /// </summary>
        private bool moveFlag;

        private void checkBoxMove_CheckedChanged(object sender, EventArgs e)
        {
            moveFlag = checkBoxMove.Checked;
        }

    }
}
