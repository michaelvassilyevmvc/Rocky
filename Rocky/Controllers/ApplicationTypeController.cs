using Microsoft.AspNetCore.Mvc;
using Rocky.Data;
using Rocky.Models;

namespace Rocky.Controllers
{
  public class ApplicationTypeController : Controller
  {
    private readonly ApplicationDbContext _db;

    public ApplicationTypeController(ApplicationDbContext db)
    {
      _db = db;
    }

    public IActionResult Index()
    {
      return View(_db.ApplicationType);
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(ApplicationType applicationType)
    {
      _db.ApplicationType.Add(applicationType);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}