using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp9
{
    public class MainViewModel : ViewModelBase //INotifyPropertyChanged
    {
        public MyCommand ShowCommand { get; set; }

        private string name;

        public string Name
        {
            get { return name; }
            set { name = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Name"));
                //OnPropertyChanged("Name");
                OnPropertyChanged2();
            }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Title"));
                //OnPropertyChanged("Title");
                OnPropertyChanged2();
            }
        }

        public MainViewModel()
        {
            Name = "Hello";
            ShowCommand = new MyCommand(Show);
        }
        public void Show()
        {
            Name = "点击了按钮!";
            Title = "我是标题";
            MessageBox.Show("点击了按钮!");
        }

        public event PropertyChangedEventHandler PropertyChanged;

    }
}
