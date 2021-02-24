using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistence.DataBase.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult crearPizza(string nombre, double precio)
        {
            Pizza pizza = new Pizza();
            pizza.nombre = nombre;
            pizza.precio = precio;
            PizzaService.Save(pizza);
            return Ok();
        }

        [HttpGet]
        public List<Pizza> listaPizza()
        {
            var list = PizzaService.GetAll();
            return list;

        }

        [HttpGet]
        public List<Ingrediente> listaIngrediente()
        {
            var list = IngredienteService.GetAll();
            return list;

        }

        [HttpGet]
        public List<Pedido> listaPedido()
        {
            var list = PedidoService.GetAll();
            return list;

        }
        [HttpGet]
        public List<DetallePedido> listaDeallePedido()
        {
            var list = DetallePedidoService.GetAll();
            return list;

        }
        [HttpGet]
        public List<Factura> listaFactura()
        {
            var list = FacturaService.GetAll();
            return list;

        }
        
    }
}
