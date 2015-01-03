using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

using DevExpress.Skins;

using ChuckLu.UI;

namespace ChuckLu
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            SkinManager.EnableFormSkins();//DevExpress.Utils.v11.1.dll中的方法

            Application.Run(new MainForm());
        }
    }
}
