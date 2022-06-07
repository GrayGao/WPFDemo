using ModuleA.ViewModels;
using ModuleA.Views;
using Prism.Ioc;
using Prism.Modularity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleA
{
    public class ModuleAProfile : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            //注册弹窗
            containerRegistry.RegisterDialog<ViewCC, ViewCCViewModel>();

            //注册导航
            containerRegistry.RegisterForNavigation<ViewAA, ViewAAViewModel>();
        }
    }
}
