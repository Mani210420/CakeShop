namespace CakeShop.Models
{
    public interface ICakeRepository
    {
        IEnumerable<Cake> AllCakes { get; }
        IEnumerable<Cake> CakeOfTheWeek { get; }
        Cake? GetCakeById (int Cakeid);
        IEnumerable<Cake> SearchCake(string searchQuery);
    }
}
