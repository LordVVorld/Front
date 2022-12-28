using System.Collections.Generic;

namespace Front.Models
{
    public class Book
    {
        public string? Id { get; set; }

        public List<string> Names { get; set; } = null!;

        public List<Author> Authors { get; set; } = null!;

        public List<Genre> Genres { get; set; } = null!;

        public string OriginalLang { get; set; } = null!;

        public int? FistPublished { get; set; } = null!;

        public string ISBN { get; set; } = null!;

        public string ImageLink { get; set; } = null!;

        public string Content { get; set; } = null!;
    }
}
