using CakeShop.Models;
using Microsoft.AspNetCore.Components;

namespace CakeShop.App.Pages
{
    public partial class CakeCard
    {
        [Parameter]
        public Cake? Cake { get; set; }
    }
}
