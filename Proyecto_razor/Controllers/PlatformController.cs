using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Proyecto_razor.Models;

namespace Proyecto_razor.Controllers
{
    public class PlatformController : Controller
    {
        [Route("")]
        [Route("~/Index")]
        public IActionResult Index()
        {
            DataContext db = HttpContext.RequestServices.GetService(typeof(DataContext)) as DataContext;
            db.ConnectionString = "Server=127.0.0.1;port=3306;Database=web_moviles_razor;user=danieles;password=1234;Ssl Mode=None";
            ViewData["lista_productos"] = db.GetAllProducts();
            return View();
        }
        [Route("~/Carrito")]
        public IActionResult Ver_Carrito()
        {
            return View("Carrito");
        }
        public IActionResult Search()
        {
            return null;
        }
        //[Route("~/Carrito")]
        //public IActionResult Carrito()
        //{
        //    return View("Carrito");
        //}
    }
    
}