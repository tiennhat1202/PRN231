using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObject.DTO.BookDTO
{
    public class BookRequestDTO
    {
        public string? Title { get; set; }
        public string? Type { get; set; }
        public int PubId { get; set; }
        public double? Price { get; set; }
        public double? Advance { get; set; }
        public double? Royalty { get; set; }
        public double? YtdSales { get; set; }
        public string? Notes { get; set; }
        public DateTime? PublishedDate { get; set; }
    }
}
