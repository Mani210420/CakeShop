
namespace CakeShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly CakeShopDbContext _cakeShopDbContext;

        public CategoryRepository(CakeShopDbContext cakeShopDbContext)
        {
            _cakeShopDbContext = cakeShopDbContext;
        }

        public IEnumerable<Category> AllCategories => _cakeShopDbContext.Categories.OrderBy(c => c.CategoryName);
    }
}
