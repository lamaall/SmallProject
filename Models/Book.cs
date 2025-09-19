//using System;
using SmallProject.Enums;

namespace SmallProject.Models
{
    public class Book
    {
        public required string Title { get; set; }
        public required string Author { get; set; }
        public required string ISBN { get; set; }
        public required int YearPublished { get; set; }
        public BookStatus Status { get; set; } = BookStatus.Available;
    }
}