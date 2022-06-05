using GalaSoft.MvvmLight.Messaging;
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

namespace WpfApp11
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();

            //注册消息 注册一个接收string类型参数的消息，地址是Token1
            Messenger.Default.Register<string>(this, "Token1", Show);
        }

        void Show(string value)
        {
            MessageBox.Show(value);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("点击了按钮");
        }
    }
}
