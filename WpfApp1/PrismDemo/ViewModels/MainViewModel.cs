using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using PrismDemo.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrismDemo.ViewModels
{
    public class MainViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        public DelegateCommand<string> OpenCommand { get; private set; }
        public MainViewModel()
        {
            OpenCommand = new DelegateCommand<string>(Open);
        }

        public MainViewModel(IRegionManager regionManager)
        {
            OpenCommand = new DelegateCommand<string>(Open);
            this.regionManager = regionManager;
        }

        //private object body;

        //public object Body
        //{
        //    get { return body; }
        //    set { body = value; RaisePropertyChanged(); }
        //}

        private void Open(string obj)
        {
            //首先通过IRegionManager获取到全局定义的可用区域
            //往这个区域动态的去设置内容
            //设置内容得方式通过依赖注入的形式
            this.regionManager.Regions["ContentRegion"].RequestNavigate(obj);
            //switch (obj)
            //{
            //    case "ViewA":
            //        Body = new ViewA();
            //        break;
            //    case "ViewB":
            //        Body = new ViewB();
            //        break;
            //    case "ViewC":
            //        Body = new ViewC();
            //        break;
            //}
        }
    }
}
