using AriCoffeeShop.Data;
using AriCoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AriCoffeeShop.Areas.Admin.Controllers
{
    public class KahveController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KahveController(ApplicationDbContext context)
        {

            _context = context;

        }
        public IActionResult Index()
        {
            var kahveler = _context.Kahve.Include(k => k.Kategori).ToList();

            return View(kahveler);
        }

        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Kahve kahve,IFormFile file)
        {

            if (ModelState.IsValid)
            {
                if (file!=null && file.Length > 0)
                {
                    var filename=Path.GetFileName(file.FileName);
                    var filepath=Path.Combine(Directory.GetCurrentDirectory(),"wwwroot/images", filename);

                    using (var stream=new FileStream(filepath,FileMode.Create))
                    {
                        file.CopyTo(stream);

                    }
                   

                }




            }




            
            var kahveler = _context.Kahve.Include(k => k.Kategori).ToList();
            return View();
        }


    }
}
