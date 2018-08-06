using Microsoft.AspNetCore.Server.Kestrel.Internal.System.Collections.Sequences;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Proyecto_razor.Models
{
    public class Carrito
    {
        public ArrayList<Producto> productos_carrito{ get; set; }
        public Producto producto { get; set; }
        public int cantidad { get; set; }
    }
}
