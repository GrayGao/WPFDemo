using ModuleA.Event;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ModuleA.ViewModels
{
    //INavigationAware
    public class ViewCCViewModel : IDialogAware
    {
        private readonly IEventAggregator aggregator;

        public DelegateCommand CancelCommand { get; set; }
        public DelegateCommand SaveCommand { get; set; }

        public ViewCCViewModel(IEventAggregator aggregator)
        {
            CancelCommand = new DelegateCommand(Cancel);
            SaveCommand = new DelegateCommand(Save);
            this.aggregator = aggregator;
        }

        private void Save()
        {
            DialogParameters keys = new DialogParameters();
            keys.Add("Value", "Hello");
            RequestClose?.Invoke(new DialogResult(ButtonResult.OK, keys));
        }

        private void Cancel()
        {
            //向MessageEvent 发布一个Hello
            aggregator.GetEvent<MessageEvent>().Publish("Hello");

            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }

        public string Title { get; set; }

        public event Action<IDialogResult> RequestClose;

        public bool CanCloseDialog()
        {
            return true;
        }

        /// <summary>
        /// 请求关闭
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void OnDialogClosed()
        {
           
        }

        /// <summary>
        /// 弹框过来，接收要传递的参数
        /// </summary>
        /// <param name="parameters"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void OnDialogOpened(IDialogParameters parameters)
        {
            Title = parameters.GetValue<string>("Title");
        }
    }
}
