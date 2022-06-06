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
        //导航日志
        private IRegionNavigationJournal journal;

        public DelegateCommand<string> OpenCommand { get; private set; }
        public DelegateCommand BackCommand { get; private set; }
        
        public MainViewModel()
        {
            OpenCommand = new DelegateCommand<string>(Open);
        }

        public MainViewModel(IRegionManager regionManager)
        {
            OpenCommand = new DelegateCommand<string>(Open);
            BackCommand = new DelegateCommand(Back);
            this.regionManager = regionManager;
        }

        private void Back()
        {
            if (journal.CanGoBack)
                journal.GoBack();
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
            NavigationParameters keys = new NavigationParameters();
            keys.Add("Title", "Hello");

            this.regionManager.Regions["ContentRegion"].RequestNavigate(obj,
                callBack => { 
                    if ((bool)callBack.Result)
                    {
                        //导航服务的上下文
                        journal = callBack.Context.NavigationService.Journal;
                    }
                }, keys);
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
