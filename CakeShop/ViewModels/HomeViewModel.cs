using CakeShop.Models;

namespace CakeShop.ViewModels
{
    public class HomeViewModel
    {
        public IEnumerable<Cake> CakesOfTheWeek { get; }
        public HomeViewModel(IEnumerable<Cake> cakesofTheWeek) 
        {
            CakesOfTheWeek = cakesofTheWeek;
        }
    }
}
