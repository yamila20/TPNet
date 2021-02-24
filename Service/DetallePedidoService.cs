using Microsoft.EntityFrameworkCore;
using Persistence.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class DetallePedidoService
    {
        //crea o modifica datos
        public static void Save(DetallePedido DetallePedido)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    if (DetallePedido.id != 0)
                    {
                        ctx.Entry(DetallePedido).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.DetallePedido.Add(DetallePedido);
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
        public static DetallePedido Get(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                DetallePedido detallePedido = ctx.DetallePedido.Where(p => p.id == Id).FirstOrDefault();
                return detallePedido;
            }
        }

        //Mostrar datos
        public static List<DetallePedido> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<DetallePedido> detallePedido = ctx.DetallePedido.ToList();

                return detallePedido;
            }
        }

        //Borrar datos
        public static bool Delete(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                DetallePedido resultado = Get(Id);

                if (resultado != null)
                {
                    ctx.DetallePedido.Remove(resultado);

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
