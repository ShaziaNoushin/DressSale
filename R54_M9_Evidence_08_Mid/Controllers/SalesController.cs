using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using R54_M9_Evidence_08_Mid.Models;

namespace R54_M9_Evidence_08_Mid.Controllers
{
    public class SalesController : Controller
    {
        private readonly DressDbContext db;
        public SalesController(DressDbContext db)
        {
            this.db = db;
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Sales.Include(x => x.Dress).ToListAsync());
        }
        public IActionResult Create()
        {
            ViewBag.Products = db.Dresses.ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Create(Sale model)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlInterpolated($"EXEC InsertSale {model.Date}, {model.Quantity}, {model.DressId}");
                return RedirectToAction("Index");

            }
            ViewBag.Products = db.Dresses.ToList();
            return View(model);
        }


        public IActionResult Edit(int id)
        {
            var data = db.Sales.FirstOrDefault(x=> x.SaleId == id);
            if(data== null) { return NotFound(); }
            ViewBag.Products = db.Dresses.ToList();
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(Sale model)
        {
            if (ModelState.IsValid)
            {
                db.Database.ExecuteSqlInterpolated($"EXEC UpdateSale {model.SaleId}, {model.Date}, {model.Quantity}, {model.DressId}");
                return RedirectToAction("Index");

            }
            ViewBag.Products = db.Dresses.ToList();
            return View(model);
        }
        [HttpPost]
        public IActionResult Delete(int id)
        {
            db.Database.ExecuteSqlInterpolated($"EXEC DeleteSale {id}");
            return Json(new { success = true, id });
        }

    }
}
