using CURD_ASPCORE.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;

namespace CURD_ASPCORE.Controllers;

public class HomeController : Controller {
  public class Product {
    public int productId { get; set; }
    public string productName { get; set; }
    public double productPrice { get; set; }
  }
  public IActionResult Index() {
    return View();
  }

  [HttpPost]
  public IActionResult Index(int x) {
    var obj = Request.Form["productData"];

    Product y = JsonSerializer.Deserialize<Product>(obj);

    return View();
  }
}


