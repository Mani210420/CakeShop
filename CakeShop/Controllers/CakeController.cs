using CakeShop.Models;
using CakeShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers
{
    public class CakeController : Controller
    {
        private readonly ICakeRepository _cakerepository;
        private readonly ICategoryRepository _categoryRepository;

        public CakeController(ICakeRepository cakerepository, ICategoryRepository categoryRepository)
        {
            _cakerepository = cakerepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            //ViewBag.CurrentCategory = "Cheese Cake";
            //return View(_cakerepository.AllCakes);
            CakeListViewModel cakeListViewModel = new CakeListViewModel(_cakerepository.AllCakes, "Cheese Cake");
            return View(cakeListViewModel);

        }
    }
}
