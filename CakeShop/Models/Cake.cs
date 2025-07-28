namespace CakeShop.Models
{
    public class Cake
    {
        public int CakeId { get; set; }
        public string Name { get; set; } = String.Empty;
        public string? ShortDescription { get; set; }
        public string? LongDescription { get; set; }
        public string? AllerdyInfo { get; set; }
        public decimal Price { get; set; }
        public string? ImageUrl { get; set; }
        public string? ImageThumbnailUrl { get; set; }
        public bool IsCakeOfTheWeek { get; set; }
        public bool InStock {  get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; } = default!;
    }
}
