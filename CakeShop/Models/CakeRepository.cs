
using Microsoft.EntityFrameworkCore;

namespace CakeShop.Models
{
    public class CakeRepository : ICakeRepository
    {
        private readonly CakeShopDbContext _cakeShopDbContext;

        public CakeRepository(CakeShopDbContext cakeShopDbContext)
        {
            _cakeShopDbContext = cakeShopDbContext;
        }

        public IEnumerable<Cake> AllCakes => _cakeShopDbContext.Cakes.Include(c => c.Category) ;

        public IEnumerable<Cake> CakeOfTheWeek
        {
            get
            {
                return _cakeShopDbContext.Cakes.Include(c => c.Category).Where(i => i.IsCakeOfTheWeek) ;
            }
        }

        public Cake? GetCakeById(int Cakeid) => _cakeShopDbContext.Cakes.FirstOrDefault(c => c.CakeId == Cakeid);

        public IEnumerable<Cake> SearchCake(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
