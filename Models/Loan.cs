//using System;

namespace Models
{
    public class Loan
    {
        public required BookCopy BookCopy { get; set; }
        public required User User { get; set; }
        public required DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public override string ToString()
        {
            string returnDate = ReturnDate.HasValue ? ReturnDate.Value.ToString("yyyy-MM-dd") : "Not returned";
            return $"{BookCopy.Book.Title} (Copy {BookCopy.CopyId}) -> {User.Name}, Loaned: {LoanDate:yyyy-MM-dd}, Returned: {returnDate}";
        }
    }
}