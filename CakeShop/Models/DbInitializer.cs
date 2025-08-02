namespace CakeShop.Models
{
    public static class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            CakeShopDbContext context = applicationBuilder.ApplicationServices.CreateScope().ServiceProvider.GetRequiredService<CakeShopDbContext>();

            if (!context.Categories.Any())
            {
                context.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!context.Cakes.Any())
            {
                context.AddRange
                (
                    new Cake
                    {
                        //CakeId = 1,
                        Name = "Strawberry Delight Cake",
                        ShortDescription = "A soft sponge cake filled with fresh strawberries.",
                        LongDescription = "Our Strawberry Delight Cake is a delicious blend of sweet and tangy strawberries layered with soft vanilla sponge and whipped cream. Perfect for summer celebrations or as a refreshing treat.",
                        AllerdyInfo = "Contains dairy, eggs, and gluten.",
                        Price = 19.99M,
                        ImageUrl = "/images/cakes/strawberry-delight.jpg",
                        ImageThumbnailUrl = "/Images/Cakes/Thumbnails/StrawberryCake.png",
                        IsCakeOfTheWeek = true,
                        InStock = true,
                        Category = Categories["Fruit Cake"],
                    },
                    new Cake
                    {
                        //CakeId = 2,
                        Name = "Classic New York Cheesecake",
                        ShortDescription = "Rich and creamy cheesecake with a buttery graham cracker crust.",
                        LongDescription = "Our Classic New York Cheesecake features a dense, smooth cream cheese filling on top of a perfectly crisp graham cracker base. Baked to perfection and topped with a light glaze — a timeless dessert favorite.",
                        AllerdyInfo = "Contains dairy, eggs, and gluten.",
                        Price = 24.99M,
                        ImageUrl = "/images/cakes/newyork-cheesecake.jpg",
                        ImageThumbnailUrl = "/Images/Cakes/Thumbnails/CheeseCake.png",
                        IsCakeOfTheWeek = false,
                        InStock = true,
                        Category = Categories["Cheese Cake"]
                    },
                new Cake
                {
                    //CakeId = 3,
                    Name = "Blueberry Bliss Cake",
                    ShortDescription = "A moist vanilla cake packed with fresh blueberries.",
                    LongDescription = "Blueberry Bliss Cake is a light and fluffy vanilla sponge loaded with juicy blueberries and layered with blueberry compote and whipped cream. A refreshing seasonal treat perfect for spring and summer.",
                    AllerdyInfo = "Contains dairy, eggs, and gluten.",
                    Price = 22.49M,
                    ImageUrl = "/images/cakes/blueberry-bliss.jpg",
                    ImageThumbnailUrl = "/Images/Cakes/Thumbnails/BlueberryCake.png",
                    IsCakeOfTheWeek = false,
                    InStock = true,
                    Category = Categories["Fruit Cake"] // index 2 = "Seasonal Cakes"
                },
                new Cake
                {
                    //CakeId = 4,
                    Name = "Black Forest Cake",
                    ShortDescription = "A rich chocolate sponge cake layered with cherries and whipped cream.",
                    LongDescription = "Our Black Forest Cake combines moist layers of chocolate sponge, sweet cherry filling, and fluffy whipped cream, topped with chocolate shavings and fresh cherries. A timeless European dessert.",
                    AllerdyInfo = "Contains dairy, eggs, gluten, and may contain traces of nuts.",
                    Price = 25.99M,
                    ImageUrl = "/images/cakes/blackforest-cake.jpg",
                    ImageThumbnailUrl = "/Images/Cakes/Thumbnails/BlackForest.png",
                    IsCakeOfTheWeek = true,
                    InStock = true,
                    Category = Categories["Seasonal Cakes"]  // index 0 = "Fruit Cake"
                }
                );
            }
            
            context.SaveChanges();
        }

        private static Dictionary<string, Category>? categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (categories == null)
                {
                    var generList = new Category[]
                    {
                        new Category{CategoryName="Fruit Cake" },
                        new Category{CategoryName="Cheese Cake" },
                        new Category{CategoryName="Seasonal Cakes" }
                    };
                    categories = new Dictionary<string, Category>();

                    foreach (Category genre in generList)
                    {
                        categories.Add(genre.CategoryName, genre);
                    }
                }
                return categories;
            }
        }
    }
}