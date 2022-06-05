using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp11
{
    public class MainViewModel : ViewModelBase //INotifyPropertyChanged
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
            set { name = value; RaisePropertyChanged(); }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged(); }
        }

        public void Show(string content)
        {
            Name = "点击了按钮!";
            Title = "我是标题";
            //MessageBox.Show(content);
            //我给Token1的地址发送一个string类型的值 content
            Messenger.Default.Send(content, "Token1");
        }
    }
}
