using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Proyecto_razor.Models
{
    public class Users 
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string apellidos { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        //public bool isSuperUser { get; set; }
        public Users()
        {
            
        }
        public Users(string nombre, string apellidos, string email, string password)
        {
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.email = email;
            this.password = password;
        }
    }
}
