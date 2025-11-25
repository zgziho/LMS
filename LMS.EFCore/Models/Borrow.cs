using System;
using System.Collections.Generic;

namespace LMS.EFCore.Models
{
    public partial class Borrow
    {
        public string ReaderId { get; set; } = null!;
        public string BookId { get; set; } = null!;
        public DateTime BorrowTime { get; set; }
        public DateTime? ReturnTime { get; set; }
    }
}
