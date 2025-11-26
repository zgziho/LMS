using LMS.ReaderModule.Views;
using Prism.Ioc;
using Prism.Modularity;
using Prism.Regions;

namespace LMS.ReaderModule
{
    public class ReaderModuleModule : IModule
    {
        public void OnInitialized(IContainerProvider containerProvider)
        {
            var regionManager = containerProvider.Resolve<IRegionManager>();
            regionManager.RegisterViewWithRegion("ReaderRegion", typeof(ViewA));
        }

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }
    }
}