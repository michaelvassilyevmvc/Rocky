using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;

namespace Rocky.Controllers
{
  public class CategoryController : Controller
  {

    private readonly ApplicationDbContext _db;

    public CategoryController(ApplicationDbContext db)
    {
      _db = db;
    }

    public IActionResult Index()
    {
      var objList = _db.Category;
      return View(objList);
    }


    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Category obj)
    {
      await _db.Category.AddAsync(obj);
      await _db.SaveChangesAsync();
      return RedirectToAction("Index");
    }
  }
}