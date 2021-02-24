using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBase.Config
{
    public class PedidoConfig
    {
        public PedidoConfig(EntityTypeBuilder<Pedido> entityBuilder)

        {

            entityBuilder.HasKey(x => x.id);

            entityBuilder.Property(x => x.nombreCliente).HasMaxLength(50).IsRequired();
            entityBuilder.Property(x => x.fecha).HasMaxLength(50).IsRequired();
            entityBuilder.Property(x => x.estado).HasMaxLength(100).IsRequired();
            entityBuilder.Property(x => x.demora).HasMaxLength(50).IsRequired();

        }
    }
}
