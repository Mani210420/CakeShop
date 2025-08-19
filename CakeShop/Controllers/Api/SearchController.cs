using CakeShop.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CakeShop.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ICakeRepository _cakeRepository;
        public SearchController(ICakeRepository cakeRepository)
        {
            _cakeRepository = cakeRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allCakes = _cakeRepository.AllCakes;
            return Ok(allCakes);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if(!_cakeRepository.AllCakes.Any(c => c.CakeId == id))
                return NotFound();
            return Ok(_cakeRepository.AllCakes.Where(c => c.CakeId == id));
        }

        [HttpPost]
        public IActionResult SearchCake([FromBody]string searchQuery)
        {
            IEnumerable<Cake> cakes = new List<Cake>();
            if(!String.IsNullOrEmpty(searchQuery))
            {
                cakes = _cakeRepository.SearchCake(searchQuery);
            }
            return new JsonResult(cakes);
        }
    }
}
