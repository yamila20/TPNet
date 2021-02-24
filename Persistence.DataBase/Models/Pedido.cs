using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBase.Models
{
    public class Pedido
    {
        public int id { get; set; }
        public string nombreCliente { get; set; }
        public DateTime fecha { get; set; }
        public string estado { get; set; }
        public string demora { get; set; }
        public List<DetallePedido> DetallePedidos { get; set; }
        public Factura Factura { get; set; }
    }
}
