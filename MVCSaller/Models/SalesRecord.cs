using System.ComponentModel.DataAnnotations;
using MVCSaller.Models.Enums;

namespace MVCSaller.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:F2}")]
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
