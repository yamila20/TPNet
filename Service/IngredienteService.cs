using Microsoft.EntityFrameworkCore;
using Persistence.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Service
{
    public class IngredienteService
    {
        //crea o modifica Ingrediente
        public static void Save(Ingrediente Ingrediente)
        {
            using (var ctx = new ApplicationDbContext())
            {
                try
                {
                    if (Ingrediente.id != 0)
                    {
                        ctx.Entry(Ingrediente).State = EntityState.Modified;
                    }
                    else
                    {
                        ctx.Ingrediente.Add(Ingrediente);
                    }
                    ctx.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("Error al guardar. " + ex.Message);
                }
            }
        }

        //consultar Ingrediente
        public static Ingrediente Get(int Id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                Ingrediente Ingrediente = ctx.Ingrediente.Where(t => t.id == Id)
                    .Include(t => t.Pizza).FirstOrDefault();
                return Ingrediente;
            }
        }

        //Mostrar datos
        public static List<Ingrediente> GetAll()
        {
            using (var ctx = new ApplicationDbContext())
            {
                List<Ingrediente> ingrediente = ctx.Ingrediente.ToList();

                return ingrediente;
            }
        }
    }
}
