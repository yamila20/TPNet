using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBase.Models
{
    public class DetallePedido
    {
        public int id { get; set; }
        public int cantidad { get; set; }
        public int tipo { get; set; }
        public int tamaño { get; set; }
        public double subTotal { get; set; }
        public int PedidoId { get; set; }
        public Pedido Pedido { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
    }
}
