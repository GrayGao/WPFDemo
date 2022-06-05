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
using System.Windows.Media.Animation;

namespace WpfApp13
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

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            //创建一个双精度的动画
            DoubleAnimation animation = new DoubleAnimation();
            animation.By = -30;
            //animation.From = btn.Width; //设置动画的初始值
            //animation.To = btn.Width - 30;//设置动画的结束值
            animation.Duration = TimeSpan.FromSeconds(2);//设置动画的持续时间
            animation.AutoReverse = true;//是否往返执行
            animation.RepeatBehavior = new RepeatBehavior(5); //RepeatBehavior.Forever;//执行周期

            animation.Completed += Animation_Completed;
            //在当前按钮上执行该动画
            btn.BeginAnimation(Button.WidthProperty, animation);
        }

        private void Animation_Completed(object sender, EventArgs e)
        {
            btn.Content = "动画已完成";
        }
    }
}
