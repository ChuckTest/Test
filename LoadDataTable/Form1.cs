﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZedGraph;
using System.Threading;
using System.Diagnostics;
namespace LoadDataTable
{
    public partial class Form1 : Form
    {
        Thread thread;
        public Form1()
        {
            InitializeComponent();
            InitZedGraph();
        }

        /// <summary>
        /// 数据集
        /// </summary>
        PointPairList list;

        int number ;

        /// <summary>
        /// 1秒加载300个点的面板的数据量上限
        /// </summary>
        int maxNumber;

        /// <summary>
        /// 序号
        /// </summary>
        int count;
        /// <summary>
        /// 初始化变量以及数据集
        /// </summary>
        public void InitZedGraph()
        {
            list = new PointPairList();
            number = 20 * 5 * 10000;
            maxNumber = 3000;
            zedGraphControl1.GraphPane.XAxis.Title.IsOmitMag = false;
            zedGraphControl1.GraphPane.XAxis.Scale.IsUseTenPower = false;
            zedGraphControl1.GraphPane.AddCurve("百万曲线的点", list, Color.Blue, SymbolType.None);
            zedGraphControl1.IsShowHScrollBar = true;//显示水平滑动条
            //zedGraphControl1.GraphPane.XAxis.Scale.IsLog = true;//属性只读的，只有get，没有set
            //zedGraphControl1.GraphPane.XAxis.Scale.Max = number;
            //zedGraphControl1.GraphPane.XAxis.Scale.MinorStep = number / 4 / 5;
            //Console.WriteLine("横坐标轴的Scale类型：{0}",zedGraphControl1.GraphPane.XAxis.Scale.IsLog==true?"LogScale":"非LogScale");
        }
       

        /// <summary>
        /// 加载一百万个点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            zedGraphControl1.GraphPane.XAxis.Type = AxisType.Log;
            this.toolStripButtonLoadData.Enabled = false;
            try
            {
                if (thread != null)
                {
                    thread.Abort();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                thread = null;
            }
            thread = new Thread(LoadCurve);
            thread.IsBackground = true;
            thread.Start();
        }

        private void LoadCurve()
        {
            this.Invoke((MethodInvoker)delegate()
            {
                try
                {
                    list.Clear();
                    Random r = new Random();
                    double[] x = new double[number];
                    double[] y = new double[number];
                    for (double i = 0; i < number; i++)
                    {
                        list.Add(i, r.Next(10));
                        //zedGraphControl1.Invalidate();//重绘整个界面
                        //System.Threading.Thread.Sleep(1000);
                    }
                    Stopwatch stopWatch = new Stopwatch();
                    stopWatch.Start();
                    zedGraphControl1.AxisChange();//重新适应x和y
                    Console.WriteLine("AxisChange耗时{0}毫秒",stopWatch.ElapsedMilliseconds);
                    zedGraphControl1.Invalidate();//重绘整个界面
                    zedGraphControl1.Update();
                    //zedGraphControl1.Refresh();//比上面的刷新慢了100毫秒左右
                    Console.WriteLine("Refresh耗时{0}毫秒", stopWatch.ElapsedMilliseconds);
                    stopWatch.Stop();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                } 
                this.toolStripButtonLoadData.Enabled = true;
            });
        }

        private void toolStripButtonPressureTest_Click(object sender, EventArgs e)
        {
            //zedGraphControl1.GraphPane.XAxis.Scale.Max = maxNumber;
            //zedGraphControl1.GraphPane.XAxis.Type = AxisType.Text;
            zedGraphControl1.GraphPane.XAxis.Type = AxisType.Linear;
            timerPressureTest.Start();//也可以通过将 Enabled 属性设置为 true 来启动计时器。
        }

        /// <summary>
        /// 计时器,每秒刷新300个点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timerPressureTest_Tick(object sender, EventArgs e)
        {
            LoadThreeHundredPerSec();
        }

        /// <summary>
        /// 每秒钟加载300个点
        /// </summary>
        private void LoadThreeHundredPerSec()
        {
            if (list.Count % 300 != 0)
            {
                list.Clear();
            }
            Random r = new Random();
            for (int i = 0; i < 300; i++)
            {
                list.Add(++count, r.Next(10));
            }
            if (list.Count > maxNumber)
            {
                list.RemoveRange(0, list.Count - maxNumber);
            }
            zedGraphControl1.AxisChange();
            zedGraphControl1.Invalidate();
            zedGraphControl1.Update();
        }
    }
}
