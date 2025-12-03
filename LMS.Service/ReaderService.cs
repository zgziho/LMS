using LMS.EFCore;
using LMS.EFCore.Models;
using LMS.EFCore.PageModel;
using LMS.Service.Interfaces;

namespace LMS.Service
{
    /// <summary>
    /// 读者业务实现类
    /// </summary>
    public class ReaderService : IReaderService
    {
        private LMSDbContext dbContext;

        public ReaderService(LMSDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public int AddReader(Reader reader)
        {
            dbContext.Readers.Add(reader);
            return dbContext.SaveChanges();
        }

        public int DeleteReader(string readerId)
        {
            var reader = GetReaderById(readerId);
            dbContext.Readers.Remove(reader);
            return dbContext.SaveChanges();
        }

        public int UpdateReader(Reader reader)
        {
            dbContext.Update(reader);
            return dbContext.SaveChanges();
        }

        public Reader GetReaderById(string readerId)
        {
            return dbContext.Readers.Find(readerId)!;
        }

        public PaginationModel<Reader> PaginationReader(Reader reader, PaginationModel<Reader> pagination)
        {
            var query = dbContext.Readers.AsQueryable();

            // 添加判断
            if (reader != null)
            {
            }

            // 获取总记录数
            int totalRecords = query.Count();
            // 获取每页显示数据合集
            var rows = query.Skip((pagination.CurrentPage - 1) * pagination.PageSize)
                .Take(pagination.PageSize)
                .OrderBy(r => r.ReaderId)
                .ToList();
            // 封装分页对象
            var paginationModel = new PaginationModel<Reader>(totalRecords, pagination.PageSize, pagination.CurrentPage, rows);
            return paginationModel;
        }
    }
}