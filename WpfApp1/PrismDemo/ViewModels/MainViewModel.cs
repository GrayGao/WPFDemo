using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
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
        private readonly IDialogService dialogService;
        private readonly IRegionManager regionManager;
        //导航日志
        private IRegionNavigationJournal journal;

        public DelegateCommand<string> OpenCommand { get; private set; }
        public DelegateCommand BackCommand { get; private set; }
        public DelegateCommand<string> ShowCommand { get; private set; }


        public MainViewModel()
        {
            OpenCommand = new DelegateCommand<string>(Open);
        }

        public MainViewModel(IDialogService dialogService, IRegionManager regionManager)
        {
            OpenCommand = new DelegateCommand<string>(Open);
            BackCommand = new DelegateCommand(Back);
            ShowCommand = new DelegateCommand<string>(Show);
            this.dialogService = dialogService;
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
        private void Show(string obj)
        {
            //new ViewD().ShowDialog();
            DialogParameters keys = new DialogParameters();
            keys.Add("Title", "测试弹窗");
            dialogService.ShowDialog(obj, keys, callback => {
                if (callback.Result == ButtonResult.OK)
                {
                    string value = callback.Parameters.GetValue<string>("Value");
                }
            });
        }

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
