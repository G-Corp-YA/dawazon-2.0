using dawazon2._0.Models;
using Microsoft.AspNetCore.Mvc;

namespace dawazon2._0.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var model = new ProductPageViewModel { 
            Content = new List<Product>(), 
            PageNumber = 0 
        };
            
        return View(model); 
    }
}
