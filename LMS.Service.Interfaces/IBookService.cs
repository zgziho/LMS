using LMS.EFCore.Models;
using LMS.EFCore.PageModel;
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

        /// <summary>
        /// 查询图书
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        List<Book> QueryBooks(Book book = null!);

        /// <summary>
        /// 根据条件实现分页
        /// </summary>
        /// <param name="pagination"></param>
        /// <param name="book"></param>
        /// <returns></returns>
        PaginationModel<Book> QueryBooksPagination(PaginationModel<Book> pagination, Book book = null!);

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        int UpdateBook(Book book);

        /// <summary>
        /// 根据id删除
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        int DeleteBook(string bookId);

        /// <summary>
        /// 根据id查询图书详情
        /// </summary>
        /// <param name="bookId"></param>
        /// <returns></returns>
        Book GetBookByBookId(string bookId);
    }
}