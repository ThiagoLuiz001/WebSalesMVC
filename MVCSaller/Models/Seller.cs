using System.ComponentModel.DataAnnotations;

namespace MVCSaller.Models
{
    public class Seller
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="{0} Required")]
        [StringLength(60, MinimumLength = 3, ErrorMessage ="{0} size should be between {2} and {1}.")]
        public string Name { get; set; } = string.Empty;

        [DataType(DataType.EmailAddress)]
        [Required(ErrorMessage = "{0} Required")]
        [EmailAddress(ErrorMessage = "Enter a valid email")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")]
        [Range(100, 50000, ErrorMessage = "{0} must be from {1} to {2}")]
        public decimal BaseSalary { get; set; }

        [Required(ErrorMessage = "{0} Required")]
        [Display(Name = "Birth Date")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        public int DepartmentId { get; set; }
        public Department Department { get; set; } = new Department();
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>();

        public Seller() { }

        public Seller(int id, string name, string email, decimal baseSalary, DateTime birthDate, Department department)
        {
            Id = id;
            Name = name;
            Email = email;
            BaseSalary = baseSalary;
            BirthDate = birthDate;
            Department = department;
        }



        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        public double TotalSales(DateTime initial, DateTime final)
        {
            return Convert.ToDouble(Sales.Where(x=> x.Date >= initial && x.Date <= final).Sum(x => x.Amount));
        }
    }
}
