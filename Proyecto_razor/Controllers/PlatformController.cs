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
        [Route("Platform/Index")]
        //[Route("~/")]
        public IActionResult Index()
        {
            //Producto producto = new Producto();
            //ViewBag.lista_productos = producto.getLista_productos();
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