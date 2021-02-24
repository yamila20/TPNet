using Microsoft.EntityFrameworkCore;
using Persistence.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service
{
    public class PizzaService
    {
        //crea o modifica datos
        public static void Save(Pizza Pizza)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    if (Pizza.id!=0) 
                    {
                        ctx.Entry(Pizza).State = EntityState.Modified;
                    }
                    else 
                    {
                        ctx.Pizza.Add(Pizza);
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
        public static Pizza Get(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Pizza pizza = ctx.Pizza.Where(p => p.id == Id)
                    .Include(t => t.Ingrediente).FirstOrDefault();
                return pizza;
            }
        }

        //Mostrar datos
        public static List<Pizza> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Pizza> pizza = ctx.Pizza.ToList();

                return pizza;
            }
        }

        //buscar datos
        public static List<Pizza> BuscarPorContenido(string contenido)
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Pizza> ListaPizza = ctx.Pizza.Where(p => p.nombre.Contains(contenido)).ToList();

                return ListaPizza;
            }
        }

        //Borrar datos
        public static bool Delete(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Pizza resultado = Get(Id);

                if (resultado != null)
                {
                    ctx.Pizza.Remove(resultado);

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
