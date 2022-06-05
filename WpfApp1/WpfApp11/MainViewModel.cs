using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using Microsoft.Toolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp10
{
    public class MainViewModel : ObservableObject //INotifyPropertyChanged
    {
        public MainViewModel()
        {
            Name = "Hello";
            ShowCommand = new RelayCommand<string>(Show);
        }

        public RelayCommand<string> ShowCommand { get; }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged(); }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; OnPropertyChanged(); }
        }

        public void Show(string content)
        {
            Name = "点击了按钮!";
            Title = "我是标题";
            //MessageBox.Show(content);
            //我给Token1的地址发送一个string类型的值 content
            WeakReferenceMessenger.Default.Send(content, "Token1");
        }
    }
}
