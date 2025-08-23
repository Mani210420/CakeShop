using CakeShop.Models;
using Microsoft.AspNetCore.Components;

namespace CakeShop.App.Pages
{
    public partial class SearchBlazor
    {
        public string SearchText = "";
        public List<Cake> FilteredCakes { get; set; } = new List<Cake>();

        [Inject]
        public ICakeRepository? CakeRepository { get; set; }

        private void Search()
        {
            FilteredCakes.Clear();
            if (CakeRepository != null)
            {
                if (SearchText.Length >= 3)
                    FilteredCakes = CakeRepository.SearchCake(SearchText).ToList();
            }
        }
    }
}
