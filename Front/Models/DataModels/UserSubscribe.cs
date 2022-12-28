using System;
using System.Collections.Generic;

namespace Front.Models
{
    public class UserSubscribe
    {
        public string? Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public List<Book> Books { get; set; } = null!;

        public string ImageLink { get; set; } = null!;

        public decimal? Price { get; set; } = null!;

        public DateTime? Expires { get; set; } = null!;
    }
}
