using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_razor.Models
{
    public class Producto
    {
        public double precio { get; set; }
        public int id { get; set; }
        public string nombre { get; set; }
        public double cantidad { get; set; }
        public bool Status { get; set; }
        private List<Producto> lista_productos;

        public Producto()
        {
            this.lista_productos = new List<Producto>()
            {
                new Producto
                {
                    precio=23.50,
                    id=1,
                    nombre="cargador extra XCELL"
                },
                new Producto
                {
                    precio=360,
                    id=2,
                    nombre="Xiaomi Mi A6"
                }
            };
        }
        public List<Producto> getLista_productos()
        {
            return this.lista_productos;
        }
        public Producto find(string nombre)
        {
            return this.lista_productos.Single(p => p.nombre.Equals(nombre));
        }

    }
}
