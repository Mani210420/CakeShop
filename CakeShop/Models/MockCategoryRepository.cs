
namespace CakeShop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories =>
            new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Fruit Cake", Description="All- fruit Cakes" },
                new Category{CategoryId=2, CategoryName="Cheese Cake", Description="Cheesey all the way" },
                new Category{CategoryId=3, CategoryName="Seasonal Cakes", Description="Get in mood of a season" }
            };
    }
}
