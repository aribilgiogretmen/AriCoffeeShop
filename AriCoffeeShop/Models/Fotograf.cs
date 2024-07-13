namespace AriCoffeeShop.Models
{
    public class Fotograf
    {
        public int Id { get; set; }
        public string Url { get; set; }
        public string OnlineUrl { get; set; }

        public int KahveId { get; set; }
        public Kahve Kahve { get; set; }

        public bool IsActive { get; set; }
    }

}
