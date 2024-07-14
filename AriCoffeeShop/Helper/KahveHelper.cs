using AriCoffeeShop.Data;
using Microsoft.EntityFrameworkCore;

namespace AriCoffeeShop.Helper
{
    public static class KahveHelper
    {
       

        public static bool KahveExistsByName(ApplicationDbContext context, string Name, int? id = null)
        {
        if (id.HasValue)
        {
            return context.Kahve.Any(K => K.Name == Name && K.Id == id.Value);
        }
        else
        {
            return context.Kahve.Any(k => k.Name == Name);
        }


        }
    }
}
