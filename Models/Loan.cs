//using System;

namespace Models
{
    public class Loan
    {
        public required Book Book { get; set; }
        public required User User { get; set; }
        public required DateTime LoanDate { get; set; }
        public DateTime? ReturnDate { get; set; }

        public override string ToString()
        {
            string returnDate = ReturnDate.HasValue ? ReturnDate.Value.ToString("yyyy-MM-dd") : "Not returned";
            return $"{Book.Title} -> {User.Name}, Loaned: {LoanDate:yyyy-MM-dd}, Returned: {returnDate}";
        }
    }
}