using Microsoft.EntityFrameworkCore;
using Persistence.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class PedidoService
    {
        //crea o modifica datos
        public static void Save(Pedido Pedido)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    if (Pedido.id != 0)
                    {
                        ctx.Entry(Pedido).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Pedido.Add(Pedido);
                    }
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error al guardar. " + ex.Message);
                }
            }
        }

        //Consultar
        public static Pedido Get(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Pedido pedido = ctx.Pedido.Where(p => p.id == Id)
                    .Include(t => t.DetallePedidos).FirstOrDefault();
                return pedido;
            }
        }

        //Mostrar datos
        public static List<Pedido> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Pedido> pedido = ctx.Pedido.ToList();

                return pedido;
            }
        }

        //buscar datos
        public static List<Pedido> BuscarPorContenido(string contenido)
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Pedido> ListaPedido = ctx.Pedido.Where(p => p.nombreCliente.Contains(contenido)).ToList();

                return ListaPedido;
            }
        }

        //Borrar datos
        public static bool Delete(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Pedido resultado = Get(Id);

                if (resultado != null)
                {
                    ctx.Pedido.Remove(resultado);

                    ctx.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }

            }
        }
    }
}
