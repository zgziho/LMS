using LMS.SystemModule.Models;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace LMS.SystemModule.Views.Menus
{
    /// <summary>
    /// UserControlMenuItem.xaml 的交互逻辑
    /// </summary>
    public partial class UserControlMenuItem : UserControl
    {
        private IRegionManager _regionManager;

        public UserControlMenuItem(MyMenuItem menuItem, IRegionManager RegionManager)
        {
            InitializeComponent();
            this._regionManager = RegionManager;
            //如果展开了，就显示子菜单，否则就显示单个菜单项
            ExpanderMenu.Visibility = menuItem.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = menuItem.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

            DataContext = menuItem;
        }

        /// <summary>
        /// 菜单视图切换事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBlock_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            var view = ((sender as TextBlock).Tag as SubItem).View;
            if (view != null)
            {
                //先清空区域内的视图，再注册新的视图
                _regionManager.Regions["ManagerContentRegion"].RemoveAll();
                _regionManager.RegisterViewWithRegion("ManagerContentRegion", view.GetType());
            }
        }
    }
}