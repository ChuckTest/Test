using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContextMenuStripDemo
{
    /// <summary>
    /// 右键菜单的使用方法  直接从工具箱拖一个contextMenuStrip1  然后设置控件的ContextMenuStrip=contextMenuStrip1
    /// 通过操作contextMenuStrip1来增加菜单选项  需要注意的是，如果填写的菜单选项是中文的话，生成的ToolStripMenuItem的名字也是中文开头的
    /// 所以，建议先写英文的名字，等控件名字自动生成后，再改为中文的(或者直接设置中文的，然后去修改控件名字)
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void AddToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("新增", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("删除", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
