using CakeShop.Models;

namespace CakeShop.ViewModels
{
    public class CakeListViewModel
    {
        public IEnumerable<Cake> Cakes { get; }
        public string? CurrentCategory { get; }

        public CakeListViewModel(IEnumerable<Cake> cakes, string? category)
        {
            Cakes = cakes;
            CurrentCategory = category;
        }
    }
}
