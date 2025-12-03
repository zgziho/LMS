using LMS.SystemModule.Models;
using LMS.SystemModule.Views.Books;
using LMS.SystemModule.Views.Menus;
using LMS.SystemModule.Views.Readers;
using MaterialDesignThemes.Wpf;
using Prism.Ioc;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Windows.Controls;

namespace LMS.SystemModule.Views
{
    /// <summary>
    /// Interaction logic for MangerMainView
    /// </summary>
    public partial class MangerMainView : UserControl
    {
        private IRegionManager _regionManager;
        private IContainerProvider _containerProvider;

        public MangerMainView(IContainerProvider containerProvider, IRegionManager RegionManager)
        {
            this._regionManager = RegionManager;
            this._containerProvider = containerProvider;
            InitializeComponent();
            InitializeMenus();
        }

        /// <summary>
        /// 初始化菜单
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void InitializeMenus()
        {
            //创建图书管理子菜单
            var bookSubMens = new List<SubItem>();
            bookSubMens.Add(new SubItem("图书列表", _containerProvider.Resolve<QueryBookView>()));
            bookSubMens.Add(new SubItem("新增图书", _containerProvider.Resolve<AddBookView>()));
            //创建图书管理菜单
            var bookMainMenu = new MyMenuItem("图书管理", PackIconKind.SafeSquareOutline, bookSubMens);

            var readerSubMenus = new List<SubItem>();
            readerSubMenus.Add(new SubItem("读者列表", _containerProvider.Resolve<ReaderListView>()));
            readerSubMenus.Add(new SubItem("添加读者", _containerProvider.Resolve<AddReaderView>()));
            var readerMainMenu = new MyMenuItem("读者管理", PackIconKind.FiberNew, readerSubMenus);

            var borrowSubMenus = new List<SubItem>();
            borrowSubMenus.Add(new SubItem("借阅列表"));
            var borrowMainMenu = new MyMenuItem("借阅管理", PackIconKind.FileAccountOutline, borrowSubMenus);

            var personalSubMenus = new List<SubItem>();
            personalSubMenus.Add(new SubItem("修改个人资料"));
            var personalMainMenu = new MyMenuItem("个人中心", PackIconKind.Person, personalSubMenus);

            //把对应菜单放到用户控件对应菜单
            Menu.Children.Add(new UserControlMenuItem(bookMainMenu, _regionManager));
            Menu.Children.Add(new UserControlMenuItem(readerMainMenu, _regionManager));
            Menu.Children.Add(new UserControlMenuItem(borrowMainMenu, _regionManager));
            Menu.Children.Add(new UserControlMenuItem(personalMainMenu, _regionManager));
        }
    }
}