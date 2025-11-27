using LMS.EFCore.Models;
using LMS.Service.Interfaces;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace LMS.SystemModule.ViewModels.Books
{
    public class AddBookViewModel : BindableBase
    {
        private string bookId;
        private string bookName;
        private string bookWriter;
        private decimal bookPrice;
        private int bookCount;
        private int bookSurplus;
        private DateTime publishTime = DateTime.Now;
        private IBookService _bookService;

        public DelegateCommand AddBookCommand { get; private set; }

        public AddBookViewModel(IBookService bookService)
        {
            this._bookService = bookService;
            AddBookCommand = new DelegateCommand(AddBookAction);
        }

        /// <summary>
        ///
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        private void AddBookAction()
        {
            //创建一个Book对象
            var book = new Book
            {
                BookId = bookId,
                BookName = bookName,
                BookWriter = bookWriter,
                PublishTime = publishTime,
                BookSurplus = bookSurplus,
                BookPrice = bookPrice,
                BookCount = bookCount
            };

            var result = _bookService.AddBook(book);
            if (result > 0)
            {
                MessageBox.Show("新增成功");
            }
        }

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

        public decimal BookPrice
        {
            get { return bookPrice; }
            set { SetProperty(ref bookPrice, value); }
        }

        public DateTime PublishTime
        {
            get { return publishTime; }
            set { SetProperty(ref publishTime, value); }
        }

        public int BookCount
        {
            get { return bookCount; }
            set { SetProperty(ref bookCount, value); }
        }

        public int BookSurplus
        {
            get { return bookSurplus; }
            set { SetProperty(ref bookSurplus, value); }
        }
    }
}