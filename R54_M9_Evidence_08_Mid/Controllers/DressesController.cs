using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using R54_M9_Evidence_08_Mid.Models;
using R54_M9_Evidence_08_Mid.ViewModels;
using R54_M9_Evidence_08_Mid.ViewModels.Input;

namespace R54_M9_Evidence_08_Mid.Controllers
{
    public class DressesController : Controller
    {
        private readonly DressDbContext db;
        private readonly IWebHostEnvironment env;
        public DressesController(DressDbContext db, IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env; 
        }
        public async Task<IActionResult> Index()
        {
            return View(await db.Dresses.ToListAsync());
        }
        public async Task<IActionResult> Aggregates() {
            var data = await db.Sales.Include(x => x.Dress)
                .ToListAsync();
            return View(data);
        }
        public IActionResult Grouping() 
        { 
            return View();
        }
        [HttpPost]
        public  IActionResult Grouping(string groupby)
        {
            
            if(groupby == "dressname")
            {
                var data = db.Sales.Include(x => x.Dress)
               .ToList()
               .GroupBy(x => x.Dress?.DressName)
               .Select(g => new GroupedData { Key = g.Key, Data = g })
               .ToList();
                
                return View("GroupingResult", data);
            }
            if (groupby == "year month")
            {
                var data = db.Sales.Include(x => x.Dress)
                    .OrderByDescending(x=> x.Date)
               .ToList()
               .GroupBy(x => $"{x.Date:MMM, yyyy}")
               .Select(g => new GroupedData { Key = g.Key, Data = g })
               .ToList();

                return View("GroupingResult", data);
            }
            if (groupby == "count")
            {
                var data = db.Sales.Include(x => x.Dress)
                    .OrderByDescending(x => x.Date)
               .ToList()
               .GroupBy(x => x.Dress?.DressName)
               .Select(g => new GroupedDataPrimitve<int> { Key = g.Key, Data = g.Count() })
               .ToList();

                return View("GroupingResultPrimitive", data);
            }

            return RedirectToAction("Grouping");
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(DressInputModel model)
        {
            if(ModelState.IsValid)
            {
                var Dress = new Dress
                {
                    DressName = model.DressName,
                    Price = model.Price,
                    Size = model.Size,
                    OnSale = model.OnSale
                };
                string ext = Path.GetExtension(model.Picture.FileName);
                string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                string savePath = Path.Combine(env.WebRootPath, "Pictures", fileName);
                FileStream fs = new FileStream(savePath, FileMode.Create);
                await model.Picture.CopyToAsync(fs);
                Dress.Picture = fileName;
                fs.Close();
                db.Database.ExecuteSqlInterpolated($"EXEC InsertDress {Dress.DressName}, {Dress.Price}, {(int)Dress.Size}, {Dress.Picture}, {(model.OnSale ? 1 : 0)}");
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var data = await db.Dresses.FirstOrDefaultAsync(x => x.DressId == id);
            if (data == null) return NotFound();
            return View(new DressEditModel
            {
                DressId = data.DressId,
                DressName = data.DressName,
                Price = data.Price,
                Size = data.Size ?? Size.S,
                OnSale = data.OnSale ?? false

            });
        }
        [HttpPost]
        public async Task<IActionResult> Edit(DressEditModel model)
        {
            if (ModelState.IsValid)
            {
                var Dress = await db.Dresses.FirstOrDefaultAsync(x => x.DressId == model.DressId);
                if (Dress == null) return NotFound();
                Dress.DressId = model.DressId;
                Dress.DressName = model.DressName;
                Dress.Price = model.Price;
                Dress.Size = model.Size;
                Dress.OnSale = model.OnSale;

                if (model.Picture != null)
                {
                    string ext = Path.GetExtension(model.Picture.FileName);
                    string fileName = Path.GetFileNameWithoutExtension(Path.GetRandomFileName()) + ext;
                    string savePath = Path.Combine(env.WebRootPath, "Pictures", fileName);
                    FileStream fs = new FileStream(savePath, FileMode.Create);
                    await model.Picture.CopyToAsync(fs);
                    Dress.Picture = fileName;
                    fs.Close();
                }
                db.Database.ExecuteSqlInterpolated($"EXEC UpdateDress {Dress.DressId}, {Dress.DressName}, {Dress.Price}, {(int)Dress.Size}, {Dress.Picture}, {(model.OnSale ? 1 : 0)}");
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public  IActionResult Delete(int id)
        {
            db.Database.ExecuteSqlInterpolated($"EXEC DeleteDress {id}");
            return Json(new { success=true, id });
        }
    }
}
