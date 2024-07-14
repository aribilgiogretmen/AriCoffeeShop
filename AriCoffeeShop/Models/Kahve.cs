namespace AriCoffeeShop.Models
{
    public class Kahve
    {
        public int Id { get; set; }
        public string Name { get; set; } = "";

        public int KategoriId { get; set; }
        public Kategori? Kategori { get; set; }
        public Decimal Price { get; set; }
     
        public string Description { get; set; } = "";
        
        public decimal Weight { get; set; } = 0;

        public ICollection<Fotograf>? Fotograf { get; set; }

        public int IsActive { get; set; }=1;

    }
}
