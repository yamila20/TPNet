using Microsoft.EntityFrameworkCore;
using Persistence.DataBase.Config;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.DataBase.Models
{
    public class ApplicationDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

        {

            optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog = Pizzeria; Integrated Security = True");
        }
        public virtual DbSet<DetallePedido> DetallePedido { get; set; }
        public virtual DbSet<Factura> Factura { get; set; }
        public virtual DbSet<Ingrediente> Ingrediente { get; set; }
        public virtual DbSet<Pedido> Pedido { get; set; }
        public virtual DbSet<Pizza> Pizza { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            new PedidoConfig(modelBuilder.Entity<Pedido>());
            new DetallePedidoConfig(modelBuilder.Entity<DetallePedido>());
            new FacturaConfig(modelBuilder.Entity<Factura>());
            new IngredienteConfig(modelBuilder.Entity<Ingrediente>());
            new PizzaConfig(modelBuilder.Entity<Pizza>());

            base.OnModelCreating(modelBuilder);

        }
    }
}
