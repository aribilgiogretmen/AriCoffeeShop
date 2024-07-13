using AriCoffeeShop.Data;
using AriCoffeeShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace AriCoffeeShop.Areas.Admin.Controllers
{
    [Area("Admin")]
   
    public class KategoriController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KategoriController (ApplicationDbContext context)
        {

            _context = context;
           
        }

        public IActionResult Index()
        {


            return View(_context.Kategori.ToList());
        }

        public IActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public IActionResult Create(Kategori kategori)
        {

           

                _context.Add(kategori);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            
            

            
        }


        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kategori = _context.Kategori.Find(id);
            if(kategori==null)
            {
                return NotFound();
            }

            return View(kategori);
        }
        [HttpPost]
        public IActionResult Edit(int id,Kategori kategori)
        {

            if (id != kategori.Id)
            {

                return NotFound();
            }

            if (ModelState.IsValid)
            {

                _context.Update(kategori);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));

            }

            return View(kategori);
        }


    }
}
