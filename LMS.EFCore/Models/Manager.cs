using System;
using System.Collections.Generic;

namespace LMS.EFCore.Models
{
    public partial class Manager
    {
        public string ManagerName { get; set; } = null!;
        public string ManagerId { get; set; } = null!;
        public int? Age { get; set; }
        public string Sex { get; set; } = null!;
        public string Telephone { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
