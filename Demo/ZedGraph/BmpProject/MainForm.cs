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

        /// <summary>
        /// 曲线1
        /// </summary>
        private PointPairList list1;

        /// <summary>
        /// 曲线2
        /// </summary>
        private PointPairList list2;

        private string sBmpFilePath;
        private byte[] buffer;
        private Image myImage;

        private List<LineItem> lineitemList;
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
            zedGraphcontrol.IsShowHScrollBar = true;//显示水平滑动条
            zedGraphcontrol.IsShowVScrollBar = true;//显示垂直滑动条
            zedGraphcontrol.IsEnableVZoom = false;//禁用垂直缩放功能
            zedGraphcontrol.IsAutoScrollRange = true;//保证可以水平拖动滑动条,且滑动条不会消失
            zedGraphcontrol.MouseClick += ZedGraphControl_MouseClick;
            zedGraphcontrol.ZoomEvent += zedGraphcontrol_ZoomEvent;
            SetAnchor(zedGraphcontrol);
            list1 = new PointPairList();
            list2 = new PointPairList();
            lineitemList = new List<LineItem>();
        }

        /// <summary>
        /// 缩放的时候,将单击的时候生成的坐标ZedGraph.TextObj和垂直线清除掉
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="oldState"></param>
        /// <param name="newState"></param>
        private void zedGraphcontrol_ZoomEvent(ZedGraphControl sender, ZoomState oldState, ZoomState newState)
        {
            ClearCoordinateVerticalLine();
        }

        /// <summary>
        /// 清除坐标和垂线
        /// </summary>
        private void ClearCoordinateVerticalLine()
        {  
            //清除显示的坐标
            zedGraphcontrol.GraphPane.GraphObjList.Clear();
            //清除竖线
            foreach (LineItem l in lineitemList)
            {
                zedGraphcontrol.GraphPane.CurveList.Remove(l);
            }
        }


        /// <summary>
        /// 鼠标在画板上的单击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ZedGraphControl_MouseClick(object sender, MouseEventArgs e)
        {
            PointPairList list = new PointPairList();
            double x;
            double y;
            zedGraphcontrol.GraphPane.ReverseTransform(e.Location, out x, out y);
            if (x > 0)
            {
                if (x <= list1.Count || x <= list2.Count)
                {
                    //画垂直的线
                    list.Add(Convert.ToInt32(x), zedGraphcontrol.GraphPane.YAxis.Scale.Max);
                    list.Add(Convert.ToInt32(x), zedGraphcontrol.GraphPane.YAxis.Scale.Min);
                    LineItem lineItem = zedGraphcontrol.GraphPane.AddCurve("", list, Color.Black, SymbolType.None);
                    lineitemList.Add(lineItem);
                }
                if (x <= list1.Count)
                {
                    AddCoordinate(Convert.ToInt32(x),list1,Color.Green);
                }
                if (x <= list2.Count)
                {
                    AddCoordinate(Convert.ToInt32(x),list2,Color.Purple);
                }
                zedGraphcontrol.Refresh();
            }
        }

        /// <summary>
        /// 添加坐标点
        /// </summary>
        /// <param name="x">横坐标</param>
        /// <param name="list">坐标list</param>
        /// <param name="color">坐标颜色</param>
        private void AddCoordinate(int x,IPointList list,Color color)
        {
            ZedGraph.PointPair pt;
            ZedGraph.TextObj text;
            pt = list[x];
            text = new ZedGraph.TextObj(string.Format("({0},{1})", pt.X, pt.Y), pt.X, pt.Y,
               ZedGraph.CoordType.AxisXYScale, ZedGraph.AlignH.Left, ZedGraph.AlignV.Center);
            text.FontSpec.FontColor = color;
            text.ZOrder = ZedGraph.ZOrder.A_InFront;
            // Hide the border and the fill
            text.FontSpec.Border.IsVisible = false;
            text.FontSpec.Fill.IsVisible = false;
            text.FontSpec.Size = 8f;
            text.FontSpec.Angle = 45;
            zedGraphcontrol.GraphPane.GraphObjList.Add(text);
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
                pictureBox1.Image = Image.FromFile(open.FileName);//将图片加载到picturebox上面
                myImage = pictureBox1.Image;
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

            //for (double i = -2 * Math.PI; i <= 2 * Math.PI; i = i + Math.PI/18.0)
            //{
            //    list1.Add(i,Math.Sin(i));
            //    list2.Add(i,Math.Cos(i));
            //}

            //mypane.AddCurve("正弦曲线", list1, Color.Red, SymbolType.None);
            //mypane.AddCurve("余弦曲线", list2, Color.Purple, SymbolType.None);

            RefreshZedGraphControl();
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoadNewCurve_Click(object sender, EventArgs e)
        {
            zedGraphcontrol.GraphPane.GraphObjList.Clear();
            int lineNumber1;
            int lineNumber2;
            if (buffer != null)
            {
                MemoryStream stmBLOBData = new MemoryStream(buffer);
                System.Drawing.Image img = System.Drawing.Image.FromStream(stmBLOBData);
                Bitmap bmpobj = (Bitmap)img;

                zedGraphcontrol.GraphPane.CurveList.Clear();
                if (checkBox1.Checked)
                {
                    try
                    {
                        lineNumber1 = int.Parse(this.textBox1.Text);
                    }
                    catch
                    {
                        MessageBox.Show("请输入正确的行号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    List<System.Drawing.Color> retList1 = GrayByPixels(bmpobj, lineNumber1);
                    list1.Clear();
                    for (int i = 0; i < retList1.Count; i++)
                    {
                        int tmpValue = GetGrayNumColor(retList1[i]);//计算灰度值
                        list1.Add(i, tmpValue);
                    }
                    LineItem curve1 = zedGraphcontrol.GraphPane.AddCurve(string.Format("{0}行数据的灰度值曲线", lineNumber1), list1, Color.Red, SymbolType.None);
                    curve1.Line.IsSmooth = true;
                    curve1.Line.SmoothTension = 0.5F;
                }

                if (checkBox2.Checked)
                {
                    try
                    {
                        lineNumber2 = int.Parse(this.textBox2.Text);
                    }
                    catch
                    {
                        MessageBox.Show("请输入正确的行号", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    List<System.Drawing.Color> retList2 = GrayByPixels(bmpobj, lineNumber2);
                    list2.Clear();
                    for (int i = 0; i < retList2.Count; i++)
                    {
                        int tmpValue = GetGrayNumColor(retList2[i]);//计算灰度值
                        list2.Add(i, tmpValue);
                    }
                    LineItem curve2 = zedGraphcontrol.GraphPane.AddCurve(string.Format("{0}行数据的灰度值曲线", lineNumber2), list2, Color.Blue, SymbolType.None);
                    curve2.Line.IsSmooth = true;
                    curve2.Line.SmoothTension = 0.5F;
                }
                RefreshZedGraphControl();
            }
            else
            {
                MessageBox.Show("请先选择图片", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
         
        }

        /// <summary>
        /// Zoom模式换算坐标,将当前点坐标(基于picturebox的)转换为基于图片的坐标
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        private Point TranslateZoomMousePosition(Point coordinates)
        {
            int Width = this.pictureBox1.Width;
            int Height = this.pictureBox1.Height;
            // test to make sure our image is not null
            if (myImage == null) return coordinates;
            // Make sure our control width and height are not 0 and our 
            // image width and height are not 0
            if (Width == 0 || Height == 0 || myImage.Width == 0 || myImage.Height == 0) return coordinates;
            // This is the one that gets a little tricky. Essentially, need to check 
            // the aspect ratio of the image to the aspect ratio of the control
            // to determine how it is being rendered
            float imageAspect = (float)myImage.Width / myImage.Height;
            float controlAspect = (float)Width / Height;
            float newX = coordinates.X;
            float newY = coordinates.Y;
            if (imageAspect > controlAspect)
            {
                // This means that we are limited by width, 
                // meaning the image fills up the entire control from left to right
                float ratioWidth = (float)myImage.Width / Width;
                newX *= ratioWidth;
                float scale = (float)Width / myImage.Width;
                float displayHeight = scale * myImage.Height;
                float diffHeight = Height - displayHeight;
                diffHeight /= 2;
                newY -= diffHeight;
                newY /= scale;
            }
            else
            {
                // This means that we are limited by height, 
                // meaning the image fills up the entire control from top to bottom
                float ratioHeight = (float)myImage.Height / Height;
                newY *= ratioHeight;
                float scale = (float)Height / myImage.Height;
                float displayWidth = scale * myImage.Width;
                float diffWidth = Width - displayWidth;
                diffWidth /= 2;
                newX -= diffWidth;
                newX /= scale;
            }
            return new Point((int)newX, (int)newY);
        }

        /// <summary>
        /// centerImage模式换算坐标
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns></returns>
        private Point TranslateCenterImageMousePosition(Point coordinates)
        {
            int Width = this.pictureBox1.Width;
            int Height = this.pictureBox1.Height;
            // Test to make sure our image is not null
            if (myImage == null) return coordinates;
            // First, get the top location (relative to the top left of the control) 
            // of the image itself
            // To do this, we know that the image is centered, so we get the difference in size 
            // (width and height) of the image to the control
            int diffWidth = Width - myImage.Width;
            int diffHeight = Height - myImage.Height;
            // We now divide in half to accommodate each side of the image
            diffWidth /= 2;
            diffHeight /= 2;
            // Finally, we subtract this number from the original coordinates
            // In the case that the image is larger than the picture box, this still works
            coordinates.X -= diffWidth;
            coordinates.Y -= diffHeight;
            return coordinates;
        }  

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            ClearCoordinateVerticalLine();
            Point p = new Point(e.X,e.Y);
            if (pictureBox1.SizeMode == PictureBoxSizeMode.Zoom)
            {
                p = TranslateZoomMousePosition(p);
            }
            else if(pictureBox1.SizeMode==PictureBoxSizeMode.CenterImage)
            {
                p = TranslateCenterImageMousePosition(p);
            }
            if (p.X >= 0 && p.Y >= 0 && p.X <= myImage.Width && p.Y <= myImage.Height)
            {
                lblCoordinate.Text = string.Format("坐标(第{0}行,第{1}列)", p.Y, p.X);

                MemoryStream stmBLOBData = new MemoryStream(buffer);
                System.Drawing.Image img = System.Drawing.Image.FromStream(stmBLOBData);
                Bitmap bmpobj = (Bitmap)img;

                List<System.Drawing.Color> retList1 = GrayByPixels(bmpobj, p.Y);
                list1.Clear();
                for (int i = 0; i < retList1.Count; i++)
                {
                    int tmpValue = GetGrayNumColor(retList1[i]);//计算灰度值
                    list1.Add(i, tmpValue);
                }
                zedGraphcontrol.GraphPane.CurveList.Clear();
                LineItem curve1 = zedGraphcontrol.GraphPane.AddCurve(string.Format("{0}行数据的灰度值曲线", p.Y), list1, Color.Red, SymbolType.None);
                curve1.Line.IsSmooth = true;
                curve1.Line.SmoothTension = 0.5F;
                RefreshZedGraphControl();
            }
        }

        private void RefreshZedGraphControl()
        {
            SetAxisRange();
            zedGraphcontrol.AxisChange();
            this.tabPage1.Controls.Clear();
            this.tabPage1.Controls.Add(zedGraphcontrol);
        }

        /// <summary>
        /// 如果已经加载了图片,做坐标轴的最大和最小值根据图片来设置
        /// </summary>
        private void SetAxisRange()
        {
            if (myImage != null)
            {
                zedGraphcontrol.GraphPane.XAxis.Scale.Max = myImage.Width;
                zedGraphcontrol.GraphPane.YAxis.Scale.Max = 255;
                zedGraphcontrol.GraphPane.XAxis.Scale.MinGrace = 0;
                zedGraphcontrol.GraphPane.XAxis.Scale.MaxGrace = 0;
                zedGraphcontrol.GraphPane.XAxis.Scale.Min = 0;
            }
        }

        private void btnAnalysis_Click(object sender, EventArgs e)
        {
            //list1曲线1
            //list2曲线2
        }

    }
    
}
