using LMS.EFCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LMS.Service.Interfaces
{
    //系统登录接口
    public interface ILoginService
    {
        //管理员登录
        Manager ManagerLogin(string username, string password);

        //读者登录
        Reader ReaderLogin(string username, string password);
    }
}