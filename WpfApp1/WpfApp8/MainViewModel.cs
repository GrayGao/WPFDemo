using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp8
{
    public class MainViewModel
    {
        public MyCommand ShowCommand { get; set; }

        public string Name { get; set; }

        public MainViewModel()
        {
            Name = "Hello";
            ShowCommand = new MyCommand(Show);
        }

        public void Show()
        {
            Name = "点击了按钮!";
            MessageBox.Show("点击了按钮!");
        }
    }
}
