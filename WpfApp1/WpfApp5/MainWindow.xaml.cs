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

namespace WpfApp5
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            List<Color> test = new List<Color>();
            test.Add(new Color() { Code = "#FFC0CB", Name = "粉红" });
            test.Add(new Color() { Code = "#DC143C", Name = "深红" });
            test.Add(new Color() { Code = "#FFF0F5", Name = "淡紫红" });
            test.Add(new Color() { Code = "#DB7093", Name = "弱紫罗兰红" });
            test.Add(new Color() { Code = "#FF69B4", Name = "热情的粉红" });
            test.Add(new Color() { Code = "#FF1493", Name = "深粉红" });
            grid.ItemsSource = test;
        }
    }

    public class Color
    {
        public string Code { get; set; }

        public string Name { get; set; }
    }
}
