using LMS.Desktop.Views;
using LMS.EFCore.Models;
using LMS.Service;
using LMS.Service.Interfaces;
using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LMS.Desktop.ViewModels
{
    public class LoginWindowViewModels : BindableBase
    {
        private IContainerProvider _containerProvider;
        private ILoginService _loginService;

        //定义一个登录的命令对象
        public DelegateCommand<Window> LoginCommand { get; set; }

        public LoginWindowViewModels(ILoginService loginService, IContainerProvider containerProvider)
        {
            _containerProvider = containerProvider;
            _loginService = loginService;
            // 初始化命令对象
            LoginCommand = new DelegateCommand<Window>(LoginAction);
        }

        public LoginWindowViewModels()
        {
            //初始化命令
            LoginCommand = new DelegateCommand<Window>(LoginAction);
        }

        /// <summary>
        /// 处理登录核心的方法
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void LoginAction(Window window)
        {
            if (!isManager && !isReader)
            {
                MessageBox.Show("请选择角色", "提示", MessageBoxButton.OK);
                return;
            }

            if (isManager)
            {
                // 管理员登录
                var manger = _loginService.ManagerLogin(username, password);
                if (manger != null)
                {
                    // 创建一个创建窗体对象
                    var mainWindow = new MainWindow(manger, _containerProvider);
                    mainWindow.Show();
                    window.Close();
                }
                else
                {
                    MessageBox.Show("输入的账号和密码是错误的", "提示", MessageBoxButton.OK);
                }
            }
            else if (isReader)
            {
                // 读者登录
                var reader = _loginService.ReaderLogin(username, password);
                if (reader != null)
                {
                    // 创建一个创建窗体对象
                    var mainWindow = new MainWindow(reader, _containerProvider);
                    mainWindow.Show();
                    window.Close();
                }
                else
                {
                    MessageBox.Show("输入的账号和密码是错误的", "提示", MessageBoxButton.OK);
                }
            }
        }

        /// <summary>
        /// 用户名
        /// </summary>
        private string username;

        public string UserName
        {
            get { return username; }
            set { SetProperty(ref username, value); }
        }

        /// <summary>
        /// 密码
        /// </summary>
        private string password;

        public string Password
        {
            get { return password; }
            set { SetProperty(ref password, value); }
        }

        /// <summary>
        /// 是否是管理员
        /// </summary>
        private bool isManager;

        public bool IsManager
        {
            get { return isManager; }
            set { SetProperty(ref isManager, value); }
        }

        /// <summary>
        /// 是否是读者
        /// </summary>
        private bool isReader;

        public bool IsReader
        {
            get { return isReader; }
            set { SetProperty(ref isReader, value); }
        }
    }
}