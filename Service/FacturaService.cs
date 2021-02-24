using Microsoft.EntityFrameworkCore;
using Persistence.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class FacturaService
    {
        //crea o modifica Pizza
        public static void Save(Factura Factura)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    if (Factura.id != 0)
                    {
                        ctx.Entry(Factura).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Factura.Add(Factura);
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
        public static Factura Get(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Factura factura = ctx.Factura.Where(p => p.id == Id).FirstOrDefault();
                return factura;
            }
        }

        //Mostrar datos
        public static List<Factura> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Factura> factura = ctx.Factura.ToList();

                return factura;
            }
        }

        //buscar datos
        public static List<Factura> BuscarPorContenido(string contenido)
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Factura> ListaFactura = ctx.Factura.Where(p => p.formaPago.Contains(contenido)).ToList();

                return ListaFactura;
            }
        }
    }
}
