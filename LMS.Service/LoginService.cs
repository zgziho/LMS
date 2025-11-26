using LMS.EFCore;
using LMS.EFCore.Models;
using LMS.Service.Interfaces;

namespace LMS.Service
{
    public class LoginService : ILoginService
    {
        private LMSDbContext _dbContext;

        public LoginService(LMSDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Manager ManagerLogin(string username, string password)
        {
            return _dbContext.Managers.Where(m => Equals(m.Telephone.ToLower(), username.ToLower()) &&
                Equals(m.Password.ToLower(), password.ToLower())).FirstOrDefault()!;
        }

        public Reader ReaderLogin(string username, string password)
        {
            return _dbContext.Readers.Where(m => Equals(m.Telephone.ToLower(), username.ToLower())
                   && Equals(m.Password.ToLower(), password.ToLower())).FirstOrDefault()!;
        }
    }
}