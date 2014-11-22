using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace ThreadDemo
{
    public partial class ThreaDemo : Form
    {
        Thread thread;

        public ThreaDemo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 在按钮中启动一个独立于ui线程的新线程
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            Thread thread = new Thread(AnotherTask);
            thread.IsBackground = true;
            thread.Start();
        }

        /// <summary>
        /// 此线程用于刷新ui线程
        /// </summary>
        private void DoTask()
        {
            Debug.WriteLine("DoTask线程ID是{0}",Thread.CurrentThread.ManagedThreadId);
            for (int i = 0; i < 100; i++)
            {
                Debug.WriteLine(i);
                this.Invoke((MethodInvoker)delegate()
                {
                    this.Text = i.ToString();
                });
                Thread.Sleep(100);
            }
        }

        /// <summary>
        /// 新线程中启动另外一个新的线程刷新界面
        /// </summary>
        private void AnotherTask()
        {
            Debug.WriteLine("AnotherTask线程ID是{0}", Thread.CurrentThread.ManagedThreadId);
            thread = new Thread(DoTask);
            thread.IsBackground = true;
            thread.Start();
            Thread.Sleep(3000);//此线程休眠3秒不会阻塞ui线程
            Debug.WriteLine("休眠3秒完毕");
        }
    }
}
