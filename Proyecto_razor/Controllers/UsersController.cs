﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Proyecto_razor.Helpers;
using Proyecto_razor.Models;
using Proyecto_razor.Controllers;
using MySql.Data.MySqlClient;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_razor.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Iniciar_Sesion()
        {
            // html formulario login
            return View("Login");
        }
        [Route("~/Nuevo_usuario")]
        public IActionResult New_user()
        {
            // html formulario de registro
            return View("Nuevo_usuario");
        }
        //[HttpPost]
        [Route("/Check")]
        [HttpGet("../Index")]
        public IActionResult Check_login(string email, string password)
        {
            DataContext dataConn= HttpContext.RequestServices.GetService(typeof(DataContext)) as DataContext;
            // connectionstring a piñon
            dataConn.ConnectionString = "Server=127.0.0.1;port=3306;Database=web_moviles_razor;user=root;password=;Ssl Mode=None";
            bool connection_success=dataConn.check(email, password);

            if (connection_success)
            {
                HttpContext.Session.SetString("usuario1", "1234");
                HttpContext.Session.SetInt32("username", 22);
                var active_user = HttpContext.User;
                //var url = Url.Action("Index", "Platform");
                //return Content(url);
                return View("Index");
            }
            else
            {
                string error = "ERROR: DATOS ERRONEOS";
                ViewBag.error = error;
                return View("Login");
            }
        }
        [HttpPost]
        [Route("Save")]
        public IActionResult Save(string nombre, string apellidos, string email, string password, bool isSuperUser )
        {
            // corregir cuando demos algo de base de datos
            if(password !="" && nombre!="" && apellidos !="" && email!="")
            {
                Users u = new Users(nombre, apellidos, email, password);
                //u.nombre = nombre;
                //u.apellidos = apellidos;
                //u.email = email;
                //u.password = password;

                DataContext dataContext = new DataContext("Server=localhost; port=3306; Database=web_moviles_razor; user=root; password=\"\"; SslMode=none");
                dataContext.add(u);
                return View("Success");
            }
            else
            {
                string error = "ERROR: Algun campo no se ha rellenado correctamente";
                ViewBag.error = error;
                return View("Nuevo_usuario");
            }
        }
    }
}
