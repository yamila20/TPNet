using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBase.Models
{
    public class Pizza
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public double precio { get; set; }
        public DetallePedido DetallePedido { get; set; }
        public List<Ingrediente> Ingrediente { get; set; }
    }
}
