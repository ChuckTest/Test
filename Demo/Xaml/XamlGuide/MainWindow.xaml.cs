using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace XamlGuide
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(this.Resources["message"] as string);//资源是用窗口定义的，所以使用windows类的resources属性的索引器访问该资源

            //FindResource方法以层次结构的方式来搜索资源 逐层搜索，直到能找到为止button-->grid-->window-->application[mainwindows.cs]
            MessageBox.Show(this.FindResource("message") as string);

        }
    }
}
