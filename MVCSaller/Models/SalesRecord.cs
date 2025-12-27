using MVCSaller.Models.Enums;

namespace MVCSaller.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public SalesStatus Status { get; set; }
        public Seller Seller { get; set; } = new();

        public SalesRecord() { }

        public SalesRecord(int id, DateTime date, decimal amount, SalesStatus status, Seller seller)
        {
            Id = id;
            Date = date;
            Amount = amount;
            Status = status;
            Seller = seller;
        }
    }
}
