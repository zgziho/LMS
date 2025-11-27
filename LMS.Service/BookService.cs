using LMS.EFCore;
using LMS.EFCore.Models;
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
    }
}
