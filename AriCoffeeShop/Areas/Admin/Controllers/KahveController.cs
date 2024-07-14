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
            var kahveler = _context.Kahve.Include(k => k.Kategori).Include(f=>f.Fotograf).ToList();

            return View(kahveler);
        }

        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "Name");

            return View();
        }

        [HttpPost]
        public IActionResult Create(Kahve kahve,List<IFormFile> file)
        {

            if (ModelState.IsValid)
            {

                _context.Add(kahve);
                _context.SaveChanges();

                if (file!=null && file.Count > 0)
                {
                    foreach (var item in file)
                    {

                        var filename = Path.GetFileName(item.FileName);
                        var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", filename);

                        using (var stream = new FileStream(filepath, FileMode.Create))
                        {
                            item.CopyTo(stream);

                        }

                        var fotograf = new Fotograf
                        {
                            Url = "/images/" + filename,
                            KahveId = kahve.Id

                        };

                        _context.Fotograf.Add(fotograf);
                    }
                    _context.SaveChanges();
                }

                return RedirectToAction("Index");


            }
  
            var kahveler = _context.Kahve.Include(k => k.Kategori).ToList();
            return View(kahveler);
        }



        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();

            }

            var kahve= _context.Kahve.Include(f=>f.Fotograf).FirstOrDefault(m=>m.Id==id);
            
            if(kahve== null)
            {
                return NotFound();
            }

            
            ViewData["KategoriId"] = new SelectList(_context.Kategori, "Id", "Name");

            return View(kahve);
        }

        [HttpPost]
        public IActionResult Edit(int id,Kahve kahve, List<IFormFile> file)
        {

            if(id!=kahve.Id)
            {
                return NotFound();
            }


            if (ModelState.IsValid)
            {

                try
                {
                    _context.Update(kahve);
                    _context.SaveChanges();

                    if (file != null && file.Count > 0)
                    {
                        foreach (var item in file)
                        {

                            var filename = Path.GetFileName(item.FileName);
                            var filepath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", filename);

                            using (var stream = new FileStream(filepath, FileMode.Create))
                            {
                                item.CopyTo(stream);

                            }

                            var fotograf = new Fotograf
                            {
                                Url = "/images/" + filename,
                                KahveId = kahve.Id

                            };

                            _context.Fotograf.Add(fotograf);
                        }
                        _context.SaveChanges();
                    }
                }
                catch (DbUpdateConcurrencyException)
                {
                    if(!KahveExists(kahve.Id))
                    {
                        return NotFound();

                    }
                    else
                    { 
                        throw; 
                    }

                }

                

                return RedirectToAction("Index");


            }

            var kahveler = _context.Kahve.Include(k => k.Kategori).ToList();
            return View(kahveler);
        }

        private bool KahveExists(int id)
        {

            return _context.Kahve.Any(e=>e.Id==id);
        }

    }
}
