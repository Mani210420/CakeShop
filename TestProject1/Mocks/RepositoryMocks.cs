using CakeShop.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CakeShopTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<ICakeRepository> GetCakeRepository()
        {
            var cakes = new List<Cake>
            {
                new Cake
                {
                    CakeId = 14,
                    Name = "Strawberry Delight Cake",
                    ShortDescription = "A soft sponge cake filled with fresh strawberries.",
                    LongDescription = "Our Strawberry Delight Cake is a delicious blend of sweet and tangy strawberries layered with soft vanilla sponge and whipped cream. Perfect for summer celebrations or as a refreshing treat.",
                    AllerdyInfo = "Contains dairy, eggs, and gluten.",
                    Price = 19.99m,
                    ImageUrl = "/images/cakes/strawberry-delight.jpg",
                    ImageThumbnailUrl = "/Images/Cakes/Thumbnails/StrawberryCake.png",
                    IsCakeOfTheWeek = true,
                    InStock = true,
                    Category = Categories["Fruit Cake"],
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
                    ImageThumbnailUrl = "/Images/Cakes/Thumbnails/CheeseCake.png",
                    IsCakeOfTheWeek = false,
                    InStock = true,
                    Category = Categories["Cheese Cake"]
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
                    ImageThumbnailUrl = "/Images/Cakes/Thumbnails/BlueberryCake.png",
                    IsCakeOfTheWeek = false,
                    InStock = true,
                    Category = Categories["Fruit Cake"] // index 2 = "Seasonal Cakes"
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
                    ImageThumbnailUrl = "/Images/Cakes/Thumbnails/BlackForest.png",
                    IsCakeOfTheWeek = true,
                    InStock = true,
                    Category = Categories["Seasonal Cakes"]  // index 0 = "Fruit Cake"
                }

            };
            var mockCakeRepository = new Mock<ICakeRepository>();
            mockCakeRepository.Setup(repo => repo.AllCakes).Returns(cakes);
            mockCakeRepository.Setup(repo => repo.CakeOfTheWeek).Returns(cakes.Where(c => c.IsCakeOfTheWeek));
            mockCakeRepository.Setup(repo => repo.GetCakeById(It.IsAny<int>())).Returns(cakes[0]);
            return mockCakeRepository;
        }

        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = new List<Category>
            {
                new Category{CategoryId=1, CategoryName="Fruit Cake", Description="All- fruit Cakes" },
                new Category{CategoryId=2, CategoryName="Cheese Cake", Description="Cheesey all the way" },
                new Category{CategoryId=3, CategoryName="Seasonal Cakes", Description="Get in mood of a season" }
            };
            var mockCategoryRepository = new Mock<ICategoryRepository>();
            mockCategoryRepository.Setup(repo => repo.AllCategories).Returns(categories);
            return mockCategoryRepository;

        }

        private static Dictionary<string, Category>? _categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (_categories == null)
                {
                    var generList = new Category[]
                    {
                        new Category{CategoryName="Fruit Cake" },
                        new Category{CategoryName="Cheese Cake" },
                        new Category{CategoryName="Seasonal Cakes" }
                    };
                    _categories = new Dictionary<string, Category>();

                    foreach (Category genre in generList)
                    {
                        _categories.Add(genre.CategoryName, genre);
                    }
                }
                return _categories;
            }
        }
    }
}
