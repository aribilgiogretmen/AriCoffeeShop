namespace AriCoffeeShop.Models
{
    public class Kategori
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        public ICollection<Kahve> Kahve { get; set; }
    }
}
