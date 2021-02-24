using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBase.Models
{
    public class Factura
    {
        public int id { get; set; }
        public string formaPago { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
    }
}
