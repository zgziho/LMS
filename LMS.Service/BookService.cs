using LMS.EFCore;
using LMS.EFCore.Models;
using LMS.EFCore.PageModel;
using LMS.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service
{
    public class BookService : IBookService
    {
        private LMSDbContext _dbContext;

        /// <summary>
        /// 注入LMSDBContext对象
        /// </summary>
        public BookService(LMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 新增图书业务方法
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int AddBook(Book book)
        {
            _dbContext.Books.Add(book);
            return _dbContext.SaveChanges();
        }

        //删除图书信息
        public int DeleteBook(string bookId)
        {
            var book = _dbContext.Books.Find(bookId);
            if (book != null)
            {
                _dbContext.Books.Remove(book);
                return _dbContext.SaveChanges();
            }
            return 0;
        }

        /// <summary>
        /// 修改图书信息
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public int UpdateBook(Book book)
        {
            _dbContext.Update(book);
            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// 查询图书
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        public List<Book> QueryBooks(Book book = null!)
        {
            var query = _dbContext.Books.AsQueryable();
            //根据条件查询
            if (book != null)
            {
                if (!string.IsNullOrEmpty(book.BookId))
                {
                    query = query.Where(b => b.BookId == book.BookId);
                }

                if (!string.IsNullOrEmpty(book.BookName))
                {
                    query = query.Where(b => b.BookName.Contains(book.BookName));
                }

                if (!string.IsNullOrEmpty(book.BookWriter))
                {
                    query = query.Where(b => b.BookWriter!.Contains(book.BookWriter));
                }
            }
            //查询所有图书
            return query.ToList();
        }

        public PaginationModel<Book> QueryBooksPagination(PaginationModel<Book> pagination, Book book = null!)
        {
            var query = _dbContext.Books.AsQueryable();
            //根据条件查询
            if (book != null)
            {
                if (!string.IsNullOrEmpty(book.BookId))
                {
                    query = query.Where(b => b.BookId == book.BookId);
                }

                if (!string.IsNullOrEmpty(book.BookName))
                {
                    query = query.Where(b => b.BookName.Contains(book.BookName));
                }

                if (!string.IsNullOrEmpty(book.BookWriter))
                {
                    query = query.Where(b => b.BookWriter!.Contains(book.BookWriter));
                }
            }
            // 获取总记录数
            var totalRecords = query.Count();
            // 获取每页显示数
            var pageSize = pagination.PageSize;
            // 获取当前页
            var currentPage = pagination.CurrentPage;
            // 获取当前页需要显示的合集
            var rows = query.ToList().Skip((currentPage - 1) * pageSize)
                .Take(pageSize)
                .OrderBy(b => b.BookId)
                .ToList()
                ;
            // 构建一个分页对象
            var pageBean = new PaginationModel<Book>(totalRecords, pageSize, currentPage, rows);

            return pageBean;
        }

        /// <summary>
        /// 根据图书编号查询
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public Book GetBookByBookId(string bookId)
        {
            return _dbContext.Books.Find(bookId)!;
        }
    }
}