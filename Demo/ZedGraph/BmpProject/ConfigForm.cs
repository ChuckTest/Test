using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO.Ports;

namespace BmpProject
{
    public partial class ConfigForm : Form
    {
        public ConfigForm()
        {
            InitializeComponent();
            SetComboboxItems();
            LoadHistoryConfig();

        }

        /// <summary>
        /// 加载历史数据配置
        /// </summary>
        private void LoadHistoryConfig()
        {
            try
            {
                this.comboBox1.Text = Properties.Settings.Default.serialportName;
                this.comboBox2.Text = Properties.Settings.Default.baudrate;
                this.comboBox3.Text = Properties.Settings.Default.parity;
                this.comboBox4.Text = Properties.Settings.Default.databits;
                this.comboBox5.Text = Properties.Settings.Default.stopbits;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 设置默认的配置
        /// </summary>
        private void SetComboboxItems()
        {
            try
            {
                //动态加载可选的串口
                string[] portNames = SerialPort.GetPortNames();
                foreach (string i in portNames)
                {
                    this.comboBox1.Items.Add(i);
                }
                this.comboBox1.Text = "COM1";//默认串口"COM1"

                this.comboBox2.SelectedIndex = 5;//默认波特率9600

                this.comboBox3.SelectedIndex = 2;//默认校验位None

                this.comboBox4.SelectedIndex = 0; ;//默认数据位8

                this.comboBox5.SelectedIndex = 0;//默认停止位1
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        /// <summary>
        /// 保存配置数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.serialportName = this.comboBox1.Text;
            Properties.Settings.Default.baudrate = this.comboBox2.Text;
            Properties.Settings.Default.parity = this.comboBox3.Text;
            Properties.Settings.Default.databits = this.comboBox4.Text;
            Properties.Settings.Default.stopbits = this.comboBox5.Text;

            Properties.Settings.Default.Save();
            this.Close();
            this.Dispose();
        }
    }
}
