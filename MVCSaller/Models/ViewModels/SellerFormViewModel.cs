namespace MVCSaller.Models.ViewModels
{
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; } = new();

        public ICollection<Department> Departments { get; set; } = new List<Department>();
    }
}
