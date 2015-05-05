using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UseComponent
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_LoadCompleted(object sender, AsyncCompletedEventArgs e)
        {
            try
            {
                if (e.Error != null)
                {
                    MessageBox.Show(e.Error.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if (e.Cancelled)
                {
                    MessageBox.Show("操作取消", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Image image = pictureBox1.Image;
                    MessageBox.Show(
                        string.Format("操作成功,下载图片的长={0},宽={1}", image.Width, image.Height), 
                        "提示", 
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            pictureBox1.LoadAsync("http://imgsrc.baidu.com/forum/pic/item/169884c379310a55d15f6213b34543a983261008.jpg");
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            //PictureBox只有一个基于事件的异步操作方法LoadAsync，所以取消异步操作的方法直接是CancelAsync(无需添加方法名)
            pictureBox1.CancelAsync();
        }
    }
}
