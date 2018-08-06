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
        [Route("Index")]
        public IActionResult Index()
        {
            return View();
            //Producto producto = new Producto();
            //ViewBag.lista_productos = producto.getLista_productos();
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