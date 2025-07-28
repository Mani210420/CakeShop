
namespace CakeShop.Models
{
    public class MockCakeRepository : ICakeRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();
        public IEnumerable<Cake> AllCakes =>
            new List<Cake>
            {
                new Cake
                {
                    CakeId = 10,
                    Name = "Strawberry Delight Cake",
                    ShortDescription = "A soft sponge cake filled with fresh strawberries.",
                    LongDescription = "Our Strawberry Delight Cake is a delicious blend of sweet and tangy strawberries layered with soft vanilla sponge and whipped cream. Perfect for summer celebrations or as a refreshing treat.",
                    AllerdyInfo = "Contains dairy, eggs, and gluten.",
                    Price = 19.99m,  
                    ImageUrl = "/images/cakes/strawberry-delight.jpg",
                    ImageThumbnailUrl = "/images/cakes/thumbnails/strawberry-delight-thumb.jpg",
                    IsCakeOfTheWeek = true,
                    InStock = true,
                    Category = _categoryRepository.AllCategories.ToList()[0],
                },

                new Cake
                {
                    CakeId = 2,
                    Name = "Classic New York Cheesecake",
                    ShortDescription = "Rich and creamy cheesecake with a buttery graham cracker crust.",
                    LongDescription = "Our Classic New York Cheesecake features a dense, smooth cream cheese filling on top of a perfectly crisp graham cracker base. Baked to perfection and topped with a light glaze — a timeless dessert favorite.",
                    AllerdyInfo = "Contains dairy, eggs, and gluten.",
                    Price = 24.99m,
                    ImageUrl = "/images/cakes/newyork-cheesecake.jpg",
                    ImageThumbnailUrl = "/images/cakes/thumbnails/newyork-cheesecake-thumb.jpg",
                    IsCakeOfTheWeek = false,
                    InStock = true,
                    Category = _categoryRepository.AllCategories.ToList()[1]
                },
                new Cake
                {
                    CakeId = 3,
                    Name = "Blueberry Bliss Cake",
                    ShortDescription = "A moist vanilla cake packed with fresh blueberries.",
                    LongDescription = "Blueberry Bliss Cake is a light and fluffy vanilla sponge loaded with juicy blueberries and layered with blueberry compote and whipped cream. A refreshing seasonal treat perfect for spring and summer.",
                    AllerdyInfo = "Contains dairy, eggs, and gluten.",
                    Price = 22.49m,
                    ImageUrl = "/images/cakes/blueberry-bliss.jpg",
                    ImageThumbnailUrl = "/images/cakes/thumbnails/blueberry-bliss-thumb.jpg",
                    IsCakeOfTheWeek = false,
                    InStock = true,
                    Category = _categoryRepository.AllCategories.ToList()[2] // index 2 = "Seasonal Cakes"
                },
                new Cake
                {
                    CakeId = 4,
                    Name = "Black Forest Cake",
                    ShortDescription = "A rich chocolate sponge cake layered with cherries and whipped cream.",
                    LongDescription = "Our Black Forest Cake combines moist layers of chocolate sponge, sweet cherry filling, and fluffy whipped cream, topped with chocolate shavings and fresh cherries. A timeless European dessert.",
                    AllerdyInfo = "Contains dairy, eggs, gluten, and may contain traces of nuts.",
                    Price = 25.99m,
                    ImageUrl = "/images/cakes/blackforest-cake.jpg",
                    ImageThumbnailUrl = "/images/cakes/thumbnails/blackforest-cake-thumb.jpg",
                    IsCakeOfTheWeek = true,
                    InStock = true,
                    Category = _categoryRepository.AllCategories.ToList()[0]  // index 0 = "Fruit Cake"
                }

            };

        public IEnumerable<Cake> CakeOfTheWeek
        {
            get
            {
                return AllCakes.Where(c => c.IsCakeOfTheWeek);
            }
        }

        public Cake? GetCakeById(int Cakeid) => AllCakes.FirstOrDefault(c => c.CakeId == Cakeid);

        public IEnumerable<Cake> SearchCake(string searchQuery)
        {
            throw new NotImplementedException();
        }
    }
}
