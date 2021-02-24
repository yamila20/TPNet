using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Persistence.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBase.Config
{
    public class PizzaConfig
    {
        public PizzaConfig(EntityTypeBuilder<Pizza> entityBuilder)

        {

            entityBuilder.HasKey(x => x.id);
            entityBuilder.Property(x => x.nombre).HasMaxLength(50).IsRequired();
            entityBuilder.Property(x => x.precio).HasMaxLength(50).IsRequired();

        }
    }
}
