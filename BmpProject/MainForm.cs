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
    public partial class MainForm : Form
    {
        private SerialPort serialPort;
        public MainForm()
        {
            InitializeComponent();
            serialPort = new SerialPort();
        }

        /// <summary>
        /// 进行串口设置
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspBtnConfig_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm();
            configForm.ShowDialog();
        }

        /// <summary>
        /// 打开串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspOpenPort_Click(object sender, EventArgs e)
        {
            try
            {
                serialPort.PortName = Properties.Settings.Default.serialportName;
                serialPort.BaudRate = int.Parse(Properties.Settings.Default.baudrate);
                serialPort.Parity = (Parity)Enum.Parse(typeof(Parity), Properties.Settings.Default.parity);
                serialPort.DataBits = int.Parse(Properties.Settings.Default.databits);
                serialPort.StopBits = (StopBits)Enum.Parse(typeof(StopBits), Properties.Settings.Default.stopbits);
                serialPort.Open();
                this.tspOpenPort.Enabled = false;
                this.tspClosePort.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 关闭串口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tspClosePort_Click(object sender, EventArgs e)
        {
            try
            {
                if (serialPort.IsOpen)
                {
                    serialPort.Close();
                    this.tspOpenPort.Enabled = true;
                    this.tspClosePort.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnChooseBmp_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = System.Environment.CurrentDirectory;
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = open.FileName;
                Bitmap bmPic = new Bitmap(open.FileName);
                Point ptLoction = new Point(bmPic.Size);
                if (ptLoction.X > pictureBox1.Size.Width || ptLoction.Y > pictureBox1.Size.Height)
                {
                    //圖像框的停靠方式   
                    //pcbPic.Dock = DockStyle.Fill;   
                    //圖像充滿圖像框，並且圖像維持比例   
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    //圖像在圖像框置中   
                    pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                pictureBox1.Image = Image.FromFile(open.FileName);

            }
        }

    }
    
}
