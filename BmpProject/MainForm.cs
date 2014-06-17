using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.IO.Ports;
using ZedGraph;
namespace BmpProject
{
    public partial class MainForm : Form
    {
        private SerialPort serialPort;
        private ZedGraphControl zedGraphcontrol;
        private PointPairList list1;
        private PointPairList list2;
        private string sBmpFilePath;
        private byte[] buffer;

        public MainForm()
        {
            InitializeComponent();
            InitVariable();
            LoadCurve();
        }

        /// <summary>
        /// 初始化全局的私有变量
        /// </summary>
        private void InitVariable()
        {
            serialPort = new SerialPort();
            zedGraphcontrol = new ZedGraphControl();
            zedGraphcontrol.IsShowPointValues = true;//显示曲线上存在点的坐标
            SetAnchor(zedGraphcontrol);
            list1 = new PointPairList();
            list2 = new PointPairList();
        }

        /// <summary>
        /// 鼠标移动时,动态显示zedGraphcontrol上的当前鼠标位置的坐标点
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        private bool zedGraphcontrol_MouseMoveEvent(object sender, MouseEventArgs e)
        {
            PointF mousePt = new PointF(e.X, e.Y);
            string tooltip = string.Empty;
            GraphPane pane = ((ZedGraphControl)sender).MasterPane.FindChartRect(mousePt);
            if (pane != null)
            {
                double x, y;
                // Convert the mouse location to X, and Y scale values
                pane.ReverseTransform(mousePt, out x, out y);
                // 获取横纵坐标信息
                tooltip = "(" + Convert.ToInt32(x).ToString() +", " + y.ToString("f2") + ")";
            }
            toolTip1.SetToolTip(zedGraphcontrol, tooltip);
            return false;
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
                this.btnSend.Enabled = true;
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
                    this.btnSend.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("错误", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// 选择bmp文件,并展示
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnChooseBmp_Click(object sender, EventArgs e)
        {
            bool openFlag = false;
            OpenFileDialog open = new OpenFileDialog();
            open.InitialDirectory = System.Environment.CurrentDirectory+@"..\..\";
            if (open.ShowDialog() == DialogResult.OK)
            {
                txtFilePath.Text = open.FileName;
                Bitmap bmPic = new Bitmap(open.FileName);
                Point ptLoction = new Point(bmPic.Size);
                if (ptLoction.X > pictureBox1.Size.Width || ptLoction.Y > pictureBox1.Size.Height)
                {
                    //图像充满图像框,并且图像维持比例
                    pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    //图像在图像框置中
                    pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                pictureBox1.Image = Image.FromFile(open.FileName);
                openFlag = true;
            }
            if (openFlag == true)//将十六进制的图片数据读出
            {
                sBmpFilePath = open.FileName;
                FileStream fsBLOBFile = new FileStream(sBmpFilePath, FileMode.Open, FileAccess.Read);
                byte[] bytBLOBData = new byte[fsBLOBFile.Length];
                buffer = new byte[fsBLOBFile.Length];
                fsBLOBFile.Read(bytBLOBData, 0, bytBLOBData.Length);
                fsBLOBFile.Close();
                buffer = bytBLOBData;
                ShowPicSize(buffer);
            }
        }

        /// <summary>
        /// 展示图片的大小
        /// </summary>
        /// <param name="buffer"></param>
        private void ShowPicSize(byte[] buffer)
        {
            MemoryStream stmBLOBData = new MemoryStream(buffer);
            System.Drawing.Image img = System.Drawing.Image.FromStream(stmBLOBData);
            Bitmap bmpobj = (Bitmap)img;
            lblPicSize.Text = string.Format("图像宽:{0}, 图像高:{1}", bmpobj.Width, bmpobj.Height);
        }

        /// <summary>
        /// 加载初始曲线
        /// </summary>
        private void LoadCurve()
        {
            GraphPane mypane = zedGraphcontrol.GraphPane;
            mypane.XAxis.Title.Text = "X轴";
            mypane.YAxis.Title.Text = "Y轴";
            mypane.Title.Text = "曲线对比";

            for (double i = -2 * Math.PI; i <= 2 * Math.PI; i = i + Math.PI/18.0)
            {
                list1.Add(i,Math.Sin(i));
                list2.Add(i,Math.Cos(i));
            }

            mypane.AddCurve("正弦曲线", list1, Color.Red, SymbolType.None);
            mypane.AddCurve("余弦曲线", list2, Color.Purple, SymbolType.None);

            zedGraphcontrol.AxisChange();
            this.tabPage1.Controls.Add(zedGraphcontrol);
        }

        /// <summary>
        /// 让control随着父容器变化而自动变化大小
        /// </summary>
        /// <param name="control"></param>
        private void SetAnchor(Control control)
        {
            control.Width = this.tabPage1.Width;
            control.Height = this.tabPage1.Height;
            control.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom | AnchorStyles.Top;
        }

        public List<System.Drawing.Color> GrayByPixels(Bitmap bmpobj, int nLine)
        {
            int i;
            List<System.Drawing.Color> colorList = new List<Color>();
            for (i = 0; i < bmpobj.Height; i++)
            {
                if (nLine != i)
                    continue;

                for (int j = 0; j < bmpobj.Width; j++)
                {
                    colorList.Add(bmpobj.GetPixel(j, i));
                }
                break;
            }

            return colorList;
        }

        /// <summary>
        /// 用来计算灰度值的私有方法
        /// </summary>
        /// <param name="posClr"></param>
        /// <returns></returns>
        private int GetGrayNumColor(System.Drawing.Color posClr)
        {
            return (posClr.R * 19595 + posClr.G * 38469 + posClr.B * 7472) >> 16;
        }

        private void btnLoadNewCurve_Click(object sender, EventArgs e)
        {
            int lineNumber1;
            int lineNumber2;
            if (buffer != null)
            {
                try
                {
                    lineNumber1 = int.Parse(this.textBox1.Text);
                    lineNumber2 = int.Parse(this.textBox2.Text);
                }
                catch
                {
                    MessageBox.Show("错误", "请输入正确的行号", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                MemoryStream stmBLOBData = new MemoryStream(buffer);
                System.Drawing.Image img = System.Drawing.Image.FromStream(stmBLOBData);
                Bitmap bmpobj = (Bitmap)img;

                List<System.Drawing.Color> retList1 = GrayByPixels(bmpobj, lineNumber1);
                list1.Clear();
                for (int i = 0; i < retList1.Count; i++)
                {
                    int tmpValue = GetGrayNumColor(retList1[i]);//计算灰度值
                    list1.Add(i, tmpValue);
                }

                List<System.Drawing.Color> retList2 = GrayByPixels(bmpobj, lineNumber2);
                list2.Clear();
                for (int i = 0; i < retList2.Count; i++)
                {
                    int tmpValue = GetGrayNumColor(retList2[i]);//计算灰度值
                    list2.Add(i, tmpValue);
                }

                zedGraphcontrol.GraphPane.CurveList.Clear();
                LineItem curve1 = zedGraphcontrol.GraphPane.AddCurve(string.Format("{0}行数据的灰度值曲线",lineNumber1), list1, Color.Red, SymbolType.Circle);
                curve1.Line.IsSmooth = true;
                curve1.Line.SmoothTension = 0.5F;

                LineItem curve2 = zedGraphcontrol.GraphPane.AddCurve(string.Format("{0}行数据的灰度值曲线", lineNumber2), list2, Color.Blue, SymbolType.Square);
                curve2.Line.IsSmooth = true;
                curve2.Line.SmoothTension = 0.5F;

                zedGraphcontrol.AxisChange();
                this.tabPage1.Controls.Clear();
                this.tabPage1.Controls.Add(zedGraphcontrol);
            }
            else
            {
                MessageBox.Show("请先选择图片", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
         
        }



    }
    
}
