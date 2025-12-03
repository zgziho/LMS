using LMS.Controls;
using LMS.EFCore.Models;
using LMS.EFCore.PageModel;
using LMS.Service.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace LMS.SystemModule.ViewModels.Books
{
    public class QueryBookViewModel : BindableBase
    {
        public IBookService bookService;

        private IDialogService dialogService;
        public DelegateCommand QueryBookCommand { get; set; }

        public ICommand DeleteBookCommand { get; set; }

        public ICommand InitUpdateBookCommand { get; set; }

        private int currentPage = 1;

        /// <summary>
        /// 创建分页对象
        /// </summary>
        public PaginationModel PagModel { get; set; } = new PaginationModel();

        public ObservableCollection<Book> bookList;

        public ObservableCollection<Book> BookList
        {
            get { return bookList; }
            set { SetProperty(ref bookList, value); }
        }

        private string bookId;
        private string bookName;
        private string bookWriter;

        public string BookId
        {
            get { return bookId; }
            set { SetProperty(ref bookId, value); }
        }

        public string BookName
        {
            get { return bookName; }
            set { SetProperty(ref bookName, value); }
        }

        public string BookWriter
        {
            get { return bookWriter; }
            set { SetProperty(ref bookWriter, value); }
        }

        public QueryBookViewModel(IBookService bookService, IDialogService dialogService)
        {
            this.bookService = bookService;
            this.dialogService = dialogService;

            QueryBookCommand = new DelegateCommand(QueryAction);
            DeleteBookCommand = new DelegateCommand<string>(DeleteAction);
            InitUpdateBookCommand = new DelegateCommand<string>(InitUpdateDataAction);

            PagModel.NavCommand = new DelegateCommand<object>(Index =>
            {
                currentPage = int.Parse(Index.ToString());
                RefreshData();
            });

            PagModel.CountPerPageChangeCommand = new DelegateCommand(() =>
            {
                currentPage = 1;
                RefreshData();
            });

            LoadBookData();
        }

        private void InitUpdateDataAction(string bookId)
        {
            // 创建对话框的参数对象
            var parameters = new DialogParameters();
            // 添加参数key和value
            parameters.Add("bookId", bookId);
            // 打开修改图书的对话框
            dialogService.ShowDialog("UpdateBookView", parameters, CloseDialogAction);
        }

        /// <summary>
        /// 修改图书信息的对话框关闭的回调方法
        /// </summary>
        /// <param name="obj"></param>
        /// <exception cref="NotImplementedException"></exception>
        private void CloseDialogAction(IDialogResult result)
        {
            if (result.Result == ButtonResult.Yes)
            {
                RefreshData();
            }
        }

        private void DeleteAction(string bookId)
        {
            // 判断是否确认删除
            var messageResult = MessageBox.Show("确认删除该条信息吗？", "删除提示", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (messageResult == MessageBoxResult.Yes)
            {
                // 执行删除操作
                var result = bookService.DeleteBook(bookId);
                if (result > 0)
                {
                    MessageBox.Show("删除成功", "删除提示");
                    RefreshData();
                }
            }
        }

        private void RefreshData()
        {
            var bookInfo = new Book
            {
                BookId = BookId,
                BookName = BookName,
                BookWriter = BookWriter
            };
            LoadBookData(bookInfo);
        }

        private void QueryAction()
        {
            currentPage = 1;
            RefreshData();
        }

        private void LoadBookData(Book book = null)
        {
            var pageBean = new PaginationModel<Book>
            {
                CurrentPage = currentPage,
                PageSize = PagModel.CountPerPage
            };

            PaginationModel<Book> pagEntity = default;

            if (book == null)
            {
                pagEntity = bookService.QueryBooksPagination(pageBean);
                BookList = new ObservableCollection<Book>(pagEntity.Rows);
            }
            else
            {
                pagEntity = bookService.QueryBooksPagination(pageBean, book);
                BookList = new ObservableCollection<Book>(pagEntity.Rows);
            }

            PagModel.FillPages(pagEntity.TotalRecords, pagEntity.CurrentPage);
        }
    }
}