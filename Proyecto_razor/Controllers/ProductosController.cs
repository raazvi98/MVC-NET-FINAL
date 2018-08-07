using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_razor.Models;
namespace Proyecto_razor.Controllers
{
    public class ProductosController
    {
        [Route("Productos")]
        public class ProductController : Controller
        {
            //private DataContext db = new DataContext();
            [Route("~/Productos")]
            public IActionResult Productos()
            {
                DataContext db = HttpContext.RequestServices.GetService(typeof(DataContext)) as DataContext;

                ViewBag.products = db.GetAllProducts();
                return View();
            }
        }
    }
}
