using LMS.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service.Interfaces
{
    /// <summary>
    /// 新增图书接口
    /// </summary>
    public interface IBookService
    {
        /// <summary>
        /// 新增图书的方法声明
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        int AddBook(Book book);
    }
}
