using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBase.Config
{
    public class FacturaConfig
    {
        public FacturaConfig(EntityTypeBuilder<Factura> entityBuilder)

        {
            entityBuilder.HasKey(x => x.id);
            entityBuilder.Property(x => x.formaPago).HasMaxLength(50).IsRequired();
            entityBuilder.Property(x => x.PedidoId).HasMaxLength(50).IsRequired();

        }
    }
}
