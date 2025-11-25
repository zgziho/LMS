using System;
using System.Collections.Generic;

namespace LMS.EFCore.Models
{
    public partial class Reader
    {
        public string ReaderName { get; set; } = null!;
        public string ReaderId { get; set; } = null!;
        public string Sex { get; set; } = null!;
        public string Telephone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
    }
}
