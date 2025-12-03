using LMS.Controls;
using LMS.Desktop.Views;
using LMS.EFCore;
using LMS.ReaderModule;
using LMS.Service;
using LMS.Service.Interfaces;
using LMS.SystemModule;
using LMS.SystemModule.ViewModels.Books;
using LMS.SystemModule.Views.Books;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Prism.Ioc;
using Prism.Modularity;
using System;
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
            //注册LMSDBContext到容器中
            containerRegistry.Register<LMSDbContext>();
            //注册Service到容器中
            containerRegistry.Register<ILoginService, LoginService>();
            containerRegistry.Register<IBookService, BookService>();
            containerRegistry.Register<IReaderService, ReaderService>();

            //注册对话框的视图
            containerRegistry.RegisterDialog<UpdateBookView, UpdateBookViewModel>();
            //注册对话框
            containerRegistry.RegisterDialogWindow<DiaologWindow>();
        }

        protected override void ConfigureModuleCatalog(IModuleCatalog moduleCatalog)
        {
            base.ConfigureModuleCatalog(moduleCatalog);
            // 注册后在显示使用的时候生效
            Type sysType = typeof(SystemModuleModule);
            Type readerType = typeof(ReaderModuleModule);

            var sysModule = new ModuleInfo
            {
                ModuleType = sysType.AssemblyQualifiedName,
                ModuleName = sysType.Name,
                InitializationMode = InitializationMode.OnDemand
            };

            var readerModule = new ModuleInfo
            {
                ModuleType = readerType.AssemblyQualifiedName,
                ModuleName = readerType.Name,
                InitializationMode = InitializationMode.OnDemand
            };

            moduleCatalog.AddModule(sysModule);
            moduleCatalog.AddModule(readerModule);
        }
    }
}