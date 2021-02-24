using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBase.Models
{
    public class Ingrediente
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public List<Pizza> Pizza { get; set; }
    }
}
