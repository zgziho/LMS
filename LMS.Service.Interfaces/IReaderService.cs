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
    /// 读者业务接口
    /// </summary>
    public interface IReaderService
    {
        int AddReader(Reader reader);
        int DeleteReader(string readerId);
        int UpdateReader(Reader reader);
        Reader GetReaderById(string readerId);
        PaginationModel<Reader> PaginationReader(Reader reader, PaginationModel<Reader> pagination);
    }
}
