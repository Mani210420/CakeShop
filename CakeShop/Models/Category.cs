namespace CakeShop.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; } = String.Empty;
        public string? Description { get; set; }
        public List<Cake>? Cakes { get; set; }
    }
}
