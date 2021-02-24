using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBase.Config
{
    public class DetallePedidoConfig
    {
        public DetallePedidoConfig(EntityTypeBuilder<DetallePedido> entityBuilder)

        {

            entityBuilder.HasKey(x => x.id);
            entityBuilder.Property(x => x.PedidoId).HasMaxLength(50).IsRequired();
            entityBuilder.Property(x => x.PizzaId).HasMaxLength(50).IsRequired();
            entityBuilder.Property(x => x.cantidad).HasMaxLength(50).IsRequired();
            entityBuilder.Property(x => x.tipo).HasMaxLength(50).IsRequired();
            entityBuilder.Property(x => x.tamaño).HasMaxLength(50).IsRequired();
            entityBuilder.Property(x => x.subTotal).HasMaxLength(50).IsRequired();

        }
    }
}
