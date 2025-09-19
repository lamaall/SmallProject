//using System;

namespace Models
{
    public class Book
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string ISBN { get; set; }
        public required int YearPublished { get; set; }
    }
}