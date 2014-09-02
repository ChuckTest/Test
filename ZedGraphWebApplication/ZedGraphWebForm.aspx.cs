using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ZedGraph;
using System.Drawing;
namespace ZedGraphWebApplication
{
    public partial class ZedGraphWebForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ZedGraphWeb1.Width = 1800;
            ZedGraphWeb1.Height = 800;
        }

        protected void ZedGraphWeb1_RenderGraph(ZedGraph.Web.ZedGraphWeb webObject, System.Drawing.Graphics g, ZedGraph.MasterPane pane)
        {
            //Console.WriteLine(pane.PaneList.Count);//默认只有一个pane
            GraphPane mypane = pane[0];
            mypane.Title.Text = "测试图表";
            mypane.XAxis.Title.Text = "X轴";
            mypane.YAxis.Title.Text = "Y轴";
            PointPairList list = new PointPairList();
            LineItem l = mypane.AddCurve("随机曲线",list,Color.Blue,SymbolType.None);
            l.Line.IsSmooth = true;
            l.Line.SmoothTension = 0.5f;
            Random r = new Random();
            for (int i = 0; i < 100; i++)
            {
                list.Add(i,r.Next(100));
            }
        }
    }
}