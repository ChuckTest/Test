using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Pen p=new Pen(Color.Blue);
            Rectangle r = new Rectangle(0,0,450,450);
            e.Graphics.DrawRectangle(p, r);
            r.Height = 100; r.Width = 100;
            for (int i = 0; i < 4; i++)
            {
                r.X = 110 * i + 10;
                for (int j = 0; j < 4; j++)
                {
                    r.Y = 110 * j + 10;
                    e.Graphics.DrawRectangle(p, r);
                }
            }
        }
    }
}
