using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Rocky.Data;
using Rocky.Models;

namespace Rocky.Controllers
{

  public class ProductController : Controller
  {
    private readonly ILogger<ProductController> _logger;
    private readonly ApplicationDbContext _db;

    public ProductController(ApplicationDbContext db)
    {
      _db = db;
    }


    public IActionResult Index()
    {
      return View(_db.Product);
    }

    [HttpGet]
    public IActionResult Create()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Product product)
    {
      await _db.Product.AddAsync(product);
      await _db.SaveChangesAsync();
      return RedirectToAction("Index");
    }
  }
}