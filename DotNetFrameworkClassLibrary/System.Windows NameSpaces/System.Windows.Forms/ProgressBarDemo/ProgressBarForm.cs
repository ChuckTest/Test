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

namespace ProgressBarDemo
{
    public partial class ProgressBarForm : Form
    {
        public ProgressBarForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Debug.WriteLine("Form1_Load线程ID是{0}", Thread.CurrentThread.ManagedThreadId);
                backgroundWorker1.WorkerReportsProgress = true;
                backgroundWorker1.RunWorkerAsync();
                progressBar1.Minimum = 0;
                progressBar1.Maximum = 99;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for (int i = 0; i < 100; i++)
                {
                    Debug.WriteLine("backgroundWorker1_DoWork线程ID是{0}", Thread.CurrentThread.ManagedThreadId);
                    Thread.Sleep(100);
                    backgroundWorker1.ReportProgress(i);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            try
            {
                Debug.WriteLine("backgroundWorker1_ProgressChanged线程ID是{0}", Thread.CurrentThread.ManagedThreadId);
                progressBar1.Value = e.ProgressPercentage;
                this.Text = e.ProgressPercentage.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
