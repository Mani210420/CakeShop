using CakeShop.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICakeRepository, CakeRepository>();

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<CakeShopDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration["ConnectionStrings:CakeShopDbContextConnection"]);
});

var app = builder.Build();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapDefaultControllerRoute();
//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}//{action=Index}//{id}");
DbInitializer.Seed(app);
app.Run();
