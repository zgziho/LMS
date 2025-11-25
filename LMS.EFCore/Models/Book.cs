using System;
using System.Collections.Generic;

namespace LMS.EFCore.Models
{
    public partial class Book
    {
        public string BookId { get; set; } = null!;
        public string BookName { get; set; } = null!;
        public string? BookWriter { get; set; }
        public DateTime? PublishTime { get; set; }
        public decimal? BookPrice { get; set; }
        public int BookCount { get; set; }
        public int? BookSurplus { get; set; }
    }
}
