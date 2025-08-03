using CakeShop.Models;
using CakeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICakeRepository _cakeRepository;

        public HomeController(ICakeRepository cakeRepository)
        {
            _cakeRepository = cakeRepository;
        }
        public IActionResult Index()
        {
            var cakesOfTheweek = _cakeRepository.CakeOfTheWeek;
            HomeViewModel homeViewModel = new HomeViewModel(cakesOfTheweek);
            return View(homeViewModel);
        }
    }
}
