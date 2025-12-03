using LMS.EFCore.Models;
using LMS.Service.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Unity;

namespace LMS.SystemModule.ViewModels.Books
{
    /// <summary>
    /// 修改视图的模型类
    /// // 实现接口快捷键: alt+enter
    /// </summary>
    public class UpdateBookViewModel : BindableBase, IDialogAware
    {
        public string Title => "修改图书信息";

        public event Action<IDialogResult> RequestClose;

        [Dependency] // 把IOC容器中对应IBookService类型的实例注入到该类的实例中
        public IBookService BookService { get; set; }

        public ICommand UpdateBookCommand
        {
            get => new DelegateCommand(UpdateAction);
        }

        /// <summary>
        /// 修改图书信息的方法
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void UpdateAction()
        {
            // 直接调用业务方法更新数据
            var result = BookService.UpdateBook(_book);
            if (result > 0)
            {
                MessageBox.Show("修改成功", "图书信息修改");
                // 关闭修改图书对话框窗口
                RequestClose?.Invoke(new DialogResult(ButtonResult.Yes));
            }
            else
            {
                MessageBox.Show("修改失败", "图书信息修改");
            }
        }

        /// <summary>
        /// 定义一个Book通知的属性
        /// </summary>
        private Book _book;

        public Book Book
        {
            get { return _book; }
            set { SetProperty(ref _book, value); }
        }

        public bool CanCloseDialog()
        {
            return true;
        }

        /// <summary>
        /// 关闭窗体方法
        /// </summary>
        public void OnDialogClosed()
        {
        }

        /// <summary>
        /// 打开视图的方法
        /// </summary>
        /// <param name="parameters"></param>
        public void OnDialogOpened(IDialogParameters parameters)
        {
            // 获取传递bookId
            string bookId = parameters.GetValue<string>("bookId");
            // 根据图书ID获取图书信息
            Book = BookService.GetBookByBookId(bookId);
        }
    }
}