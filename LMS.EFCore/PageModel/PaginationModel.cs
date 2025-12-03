using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.EFCore.PageModel
{
    /// <summary>
    /// 分页
    /// </summary>
    public class PaginationModel<T>
    {
        public int TotalRecords { get; set; } // 总记录数
        public int TotalPages { get; set; } // 总页数
        public int PageSize { get; set; } = 10; // 每页显示数
        public int CurrentPage { get; set; } = 1; // 当前页
        public List<T>? Rows { get; set; } // 每页显示数据集合

        public PaginationModel()
        {
        }

        public PaginationModel(int totalRecords, int pageSize, int currentPage, List<T>? rows)
        {
            TotalRecords = totalRecords;
            PageSize = pageSize;
            // 计算总页数
            TotalPages = (int)Math.Ceiling(totalRecords * 1.0 / pageSize);
            CurrentPage = currentPage;
            Rows = rows;
        }
    }
}