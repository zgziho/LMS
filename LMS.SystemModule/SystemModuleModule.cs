using LMS.SystemModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace LMS.SystemModule
{
    public class SystemModuleModule : IModule
    {
        /// <summary>
        /// 模块加载后的初始化
        /// </summary>
        /// <param name="containerProvider"></param>
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ContentRegion", typeof(MangerMainView));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}