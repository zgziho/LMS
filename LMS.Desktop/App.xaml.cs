using LMS.Desktop.Views;
using LMS.SystemModule;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

namespace LMS.Desktop
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            // 注册子Moudule
            moduleCatalog.AddModule<SystemModuleModule>();
        }
    }
}