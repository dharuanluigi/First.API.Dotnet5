using System;

namespace First.API.Dotnet5.Data.VO
{
    public class BookVO
    {
        public long Id { get; set; }

        public string Author { get; set; }

        public DateTime ReleaseDate { get; set; }

        public double Price { get; set; }

        public string Title { get; set; }
    }
}
