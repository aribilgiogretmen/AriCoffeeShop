namespace AriCoffeeShop.Models
{
    public class Fiyat
    {
        public int Id { get; set; }
        public decimal? Price { get; set; }
        public ICollection<Kahve>Kahve { get; set; }
    }
}
