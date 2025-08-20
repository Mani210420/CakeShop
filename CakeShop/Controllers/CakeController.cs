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

        /*public IActionResult List()
        {
            //ViewBag.CurrentCategory = "Cheese Cake";
            //return View(_cakerepository.AllCakes);
            CakeListViewModel cakeListViewModel = new CakeListViewModel(_cakerepository.AllCakes, "All Cakes");
            return View(cakeListViewModel);

        }*/

        public ViewResult List(string category)
        {
            IEnumerable<Cake> cakes;
            string? currentCategory;

            if (string.IsNullOrEmpty(category))
            {
                cakes = _cakerepository.AllCakes.OrderBy(c => c.CakeId);
                currentCategory = "All Cakes";
            }
            else
            {
                cakes = _cakerepository.AllCakes.Where(c => c.Category.CategoryName == category).OrderBy(c => c.CakeId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }
            return View(new CakeListViewModel(cakes, category));
        }

        public IActionResult Details(int id)
        {
            var cake = _cakerepository.GetCakeById(id);
            if (cake == null) 
                return NotFound();
            return View(cake);
        }

        public IActionResult Search()
        {
            return View();
        }
    }
}
