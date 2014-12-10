using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Steema.TeeChart.Styles;
using Steema.TeeChart;
namespace TeeChartDemo
{
    public partial class Form1 : Form
    {
        Line line1 = new Line();
        public Form1()
        {
            InitializeComponent();
        }

        private void tChart1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tChart1.ShowEditor();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tChart1.Page.Previous();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tChart1.Page.Next();
        }

        private void tChart1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tChart1.Page.MaxPointsPerPage = 10;
            tChart1.Series.Add(line1);
            line1.Smoothed = false;
            if (line1 != null)
            {
                Random rnd = new Random();
                if (line1.Count > 0)
                {
                    line1.Clear();//Removes all points, texts and Colors from the Series.
                }
                DataTable table = CreateDataTable();
                for (int i = 1; i <= 100; i++)
                {
                    table.Rows.Add();
                    table.Rows[i-1]["X"] = i;
                    table.Rows[i-1]["Y"] = rnd.Next(10);
                }
                line1.DataSource = table;
                line1.XValues.DataMember = "X";
                line1.YValues.DataMember = "Y";
            }
            line1.Pointer.Visible = true;
            //line1.Smoothed = true;
        }

        public DataTable CreateDataTable()
        {
            DataTable dt = new DataTable();
            DataColumn cl;

            cl = new DataColumn();
            cl.DataType = System.Type.GetType("System.Int32");
            cl.ColumnName = "X";
            dt.Columns.Add(cl);

            cl = new DataColumn();
            cl.DataType = System.Type.GetType("System.Int32");
            cl.ColumnName = "Y";
            dt.Columns.Add(cl);

            return dt;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            line1.Smoothed = checkBox1.Checked;
        }
    }
}
