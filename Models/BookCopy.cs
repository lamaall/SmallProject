using Enums;

namespace Models
{
    public class BookCopy
    {
        public required int CopyId { get; set; }
        public required Book Book { get; set; }
        public BookStatus Status { get; set; } = BookStatus.Available;
    }
}