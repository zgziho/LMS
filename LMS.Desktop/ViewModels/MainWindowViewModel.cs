using LMS.EFCore.Models;
using LMS.ReaderModule;
using LMS.SystemModule;
using Prism.Modularity;
using Prism.Mvvm;

namespace LMS.Desktop.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IModuleManager _mouduleManager;

        public object TypeParmeter { set; get; }

        public MainWindowViewModel(IModuleManager moduleManager)
        {
            _mouduleManager = moduleManager;
        }

        public void LoadModule()
        {
            if (TypeParmeter is Manager)
            {
                // 加载管理员视图
                _mouduleManager.LoadModule(nameof(SystemModuleModule));
            }
            else if (TypeParmeter is Reader)
            {
                // 加载读者视图
                _mouduleManager.LoadModule(nameof(ReaderModuleModule));
            }
        }
    }
}