using Microsoft.AspNetCore.Mvc;
using asp.net_mysql_crud.Models;
using System.Collections.Generic;
using System.Linq;


namespace asp.net_mysql_crud.Controllers
{
  [Route("product")]
  public class ProductController : Controller
  {
    private DataContext db = new DataContext();

    [Route("")]
    [Route("index")]
    [Route("~/")]

    public IActionResult Index()
    {
      // Require system.linq 
      ViewBag.products = db.Products.ToList();
      return View();
    }

    [Route("Add")]
    public IActionResult Add()
    {
      // Require system.linq 
      ViewBag.products = db.Products.ToList();
      return View();
    }

    [HttpPost]
    [Route("Add")]
    public IActionResult Add(Product product)
    {
      // Require system.linq 
      db.Products.Add(product);
      db.SaveChanges();
      return RedirectToAction("Index");

    }

    // Require httpGet to delete
    [HttpGet]
    [Route("delete/{id}")]
    public IActionResult Delete(string id)
    {
      db.Products.Remove(db.Products.Find(id));
      db.SaveChanges();
      return RedirectToAction("Index");
    }

    [HttpGet]
    [Route("edit/{id}")]
    public IActionResult Edit(string id)
    {
      return View("Edit", db.Products.Find(id));
    }

    [HttpPost]
    [Route("edit/{id}")]
    public IActionResult Edit(string id, Product product)
    {
      db.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
      db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}