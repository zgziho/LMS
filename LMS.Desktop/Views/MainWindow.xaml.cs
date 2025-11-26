using LMS.Desktop.ViewModels;
using Prism.Ioc;
using System.Windows;

namespace LMS.Desktop.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public object Parameter { get; set; }

        public MainWindow(object parameter, IContainerProvider containerProvider)
        {
            InitializeComponent();
            // 从容器中获取MinWindowViewModel对象
            Parameter = parameter;
            var vm = containerProvider.Resolve<MainWindowViewModel>();
            vm.TypeParmeter = parameter;
            // 加载Moudule
            vm.LoadModule();
        }
    }
}