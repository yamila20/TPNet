using Persistence.DataBase.Models;
using Service;
using System;
using System.Collections.Generic;

namespace TPNet
{
    class Program
    {
        static void Main(string[] args)
        {
            menu();   
        }
        static void menu()
        {
            bool ejecucion = true;
            Pizza Pizza;
            Ingrediente Ingrediente;
            Pedido Pedido;
            DetallePedido DetallePedido;
            Factura Factura;

            while (ejecucion)
            {
                Console.WriteLine("Elija una opcion:");
                Console.WriteLine("1- Guardar Nuevas Pizzas");
                Console.WriteLine("2- Guardar Nuevos Ingredientes");
                Console.WriteLine("3- Crear Pedido");
                Console.WriteLine("4- Crear Factura");
                Console.WriteLine("5- Modificar Pizza");
                Console.WriteLine("6- Mostrar todas las Pizzas");
                Console.WriteLine("7- Modificar Pedido");
                Console.WriteLine("8- Modificar Factura");
                Console.WriteLine("9- Eliminar Pizza");
                Console.WriteLine("10- Buscar Pedido por nombre del Cliente");
                Console.WriteLine("0- Salir");
                var opcion = Convert.ToInt32(Console.ReadLine());
                switch(opcion)
                {
                    case 0:
                        ejecucion = false;
                        break;
                    case 1:
                        Console.WriteLine("Escriba el Nombre de la Pizza");
                        var nombre = Console.ReadLine();
                        Console.WriteLine("Escriba el Precio");
                        var precio =Convert.ToDouble( Console.ReadLine());
                        var NuevaPizza = new Pizza { nombre = nombre, precio = precio };
                        Console.WriteLine("Desea agregar Ingredientes 1-Si 2-No");
                        var opcion1 = Convert.ToInt16(Console.ReadLine());
                        List<Ingrediente> IngList = new List<Ingrediente>();
                        while (opcion1 == 1)
                        {
                            Console.WriteLine("Ingrese id de Ingrediente ");
                            Ingrediente = IngredienteService.Get(Int32.Parse(Console.ReadLine()));
                            if (Ingrediente != null)
                            {
                                IngList.Add(Ingrediente);
                            }

                            Console.WriteLine("Desea agregar otro Ingrediente? (1- SI 2- NO): ");
                            opcion1 = Convert.ToInt16(Console.ReadLine());
                        }

                        if (IngList.Count != 0)
                        {
                            NuevaPizza.Ingrediente = IngList;
                        }

                        PizzaService.Save(NuevaPizza);
                        break;
                    case 2:
                        Console.WriteLine("Escriba el Nombre de la Ingrediente");
                        var nombreI = Console.ReadLine();
                        var NuevoIngrediente = new Ingrediente { nombre = nombreI };
                        Console.WriteLine("Desea agregar Pizza 1-Si 2-No");
                        var opcion2 = Convert.ToInt16(Console.ReadLine());
                        List<Pizza> PizzaList = new List<Pizza>();
                        while (opcion2 == 1)
                        {
                            Console.WriteLine("Ingrese id de Pizza ");
                            Pizza = PizzaService.Get(Int32.Parse(Console.ReadLine()));
                            if (Pizza != null)
                            {
                                PizzaList.Add(Pizza);
                            }

                            Console.WriteLine("Desea agregar otra Pizza? (1- SI  2- NO): ");
                            opcion2 = Convert.ToInt16(Console.ReadLine());
                        }

                        if (PizzaList.Count != 0)
                        {
                            NuevoIngrediente.Pizza = PizzaList;
                        }

                        IngredienteService.Save(NuevoIngrediente);
                        Console.WriteLine("Ver todos los ingrediente 1- Si 2-No");
                        var op2 = Convert.ToInt16(Console.ReadLine());
                        if (op2 == 1)
                        {
                            List<Ingrediente> ingrediente = IngredienteService.GetAll();
                            foreach (var i in ingrediente)
                            {
                                Console.WriteLine("- " + i.nombre);
                            }
                        }
                        break;
                    case 3:
                        Console.WriteLine("Escriba el nombre del Cliente:");
                        var nombreCliente = Console.ReadLine();
                        Console.WriteLine("Escriba fecha:");
                        var fecha = Console.ReadLine();
                        Console.WriteLine("Escriba el estado");
                        var estado = Console.ReadLine();
                        Console.WriteLine("Escriba la demora");
                        var demora = Console.ReadLine();
                        var pedidoNuevo = new Pedido { nombreCliente = nombreCliente , fecha=Convert.ToDateTime(fecha),estado=estado,demora=demora};
                        Console.WriteLine("Desea Continuar 1-Si 2-No");
                        var op3 = Convert.ToInt16(Console.ReadLine());
                        while (op3==1) 
                        {
                            pedidoNuevo.DetallePedidos = new List<DetallePedido>();
                            double tipo=0, tamaño=0;
                            Console.WriteLine("Escriba id Pizza");
                            var idPizza = Convert.ToInt16(Console.ReadLine());
                            Pizza = PizzaService.Get(idPizza);
                            var pre = Pizza.precio;
                            Console.WriteLine("Escriba la cantidad");
                            var cantidad =Convert.ToInt16( Console.ReadLine());
                            Console.WriteLine("Seleccione tipo: 1- A la Piedra 2- A la Parrilla 3- Al Molde");
                            var seleccion =Convert.ToInt16(Console.ReadLine());
                            if (seleccion == 1)
                            {
                                tipo = 0.5;
                            }
                            else
                            {
                                if (seleccion == 2)
                                {
                                    tipo = 0.4;
                                }
                                else
                                {
                                    if (seleccion == 3)
                                    {
                                        tipo = 0.3;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opcion incorrecta");
                                    }
                                }
                            }
                            Console.WriteLine("Seleccione tamaño: 1- 8 Porciones 2- 10 Porciones 3- 12 Porciones");
                            var seleccion1 =Convert.ToInt16( Console.ReadLine());
                            if (seleccion1 == 1)
                            {
                                tamaño = 0.2;
                            }
                            else
                            {
                                if (seleccion1 == 2)
                                {
                                    tamaño = 0.3;
                                }
                                else
                                {
                                    if (seleccion1 == 3)
                                    {
                                        tamaño = 0.6;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Opcion incorrecta");
                                    }
                                }
                            }
                            var subtotal = pre + cantidad + tipo + tamaño;
                            var detallepedidonuevo = new DetallePedido {PizzaId=idPizza, cantidad=cantidad,tipo=seleccion,tamaño=seleccion1};
                            pedidoNuevo.DetallePedidos.Add(detallepedidonuevo);
                            Console.WriteLine("Desea agregar algo mas 1-Si 2-No");
                            op3 = Convert.ToInt16(Console.ReadLine());
                        }
                        
                        PedidoService.Save(pedidoNuevo);
                        break;
                    case 4:
                        Console.WriteLine("Escriba la forma de pago");
                        var formaPago = Console.ReadLine();
                        Console.WriteLine("Escriba id pedido");
                        var idPedido = Convert.ToInt16(Console.ReadLine());
                        var facturaNueva= new Factura { formaPago = formaPago, PedidoId=idPedido };
                        FacturaService.Save(facturaNueva);
                        break;
                    case 5:
                        Console.WriteLine("Ingrese ID de Pizza a modificar:");
                        var id = Int32.Parse(Console.ReadLine());
                        Pizza = PizzaService.Get(id);
                        if (Pizza != null)
                        {
                            Console.WriteLine("Precio anterior: " + Pizza.precio);

                            Console.WriteLine("Ingrese el nuevo Precio:");
                            var nuevoPrecio = Console.ReadLine();

                            if (nuevoPrecio != "")
                            {
                                Pizza.precio = Convert.ToDouble(nuevoPrecio);
                            }
                            PizzaService.Save(Pizza);
                        }
                        else
                        {
                            Console.WriteLine("No se encontró Pizza");
                        }
                        break;
                    case 6:
                        List<Pizza> pizza = PizzaService.GetAll();
                        foreach (var p in pizza)
                        {
                            Console.WriteLine("- " + p.nombre +" $"+ p.precio);
                        }
                        break;
                    case 7:
                        Console.WriteLine("Ingrese ID de Pedido a modificar:");
                        var idPed = Int32.Parse(Console.ReadLine());
                        Pedido = PedidoService.Get(idPed);
                        if (Pedido != null)
                        {
                            Console.WriteLine("Estado anterior: " + Pedido.estado);
                            Console.WriteLine("Demora anterior: " + Pedido.demora);

                            Console.WriteLine("Ingrese el nuevo estado:");
                            var nuevoEstado = Console.ReadLine();
                            Console.WriteLine("Ingrese el nueva demora:");
                            var nuevaDemora = Console.ReadLine();

                            if (nuevoEstado != ""&&nuevaDemora!="")
                            {
                                Pedido.estado = nuevoEstado;
                                Pedido.demora = nuevaDemora;
                            }
                            PedidoService.Save(Pedido);
                        }
                        else
                        {
                            Console.WriteLine("No se encontró Pedido");
                        }
                        break;
                    case 8:
                        Console.WriteLine("Ingrese ID de Factura a modificar:");
                        var idfac = Int32.Parse(Console.ReadLine());
                        Factura = FacturaService.Get(idfac);
                        if (Factura != null)
                        {
                            Console.WriteLine("Forma de Pago anterior: " + Factura.formaPago);

                            Console.WriteLine("Ingrese la nueva forma de pago:");
                            var nuevaFormaPago = Console.ReadLine();

                            if (nuevaFormaPago != "")
                            {
                                Factura.formaPago = nuevaFormaPago;
                            }
                            FacturaService.Save(Factura);
                        }
                        else
                        {
                            Console.WriteLine("No se encontró Factura");
                        }
                        break;
                    case 9:
                        Console.WriteLine("Indique id post a eliminar:");
                        var b = PizzaService.Delete(Int32.Parse(Console.ReadLine()));
                        if (b)
                        {
                            Console.WriteLine("Se eliminó la Pizza Seleccionada");
                        }
                        else
                        {
                            Console.WriteLine("No se encontró la Pizza seleccionada");
                        }
                        break;
                    case 10:
                        Console.WriteLine("Ingresa nombre del cliente a buscar");
                        var frase = Console.ReadLine();
                        List<Pedido> listaPedido = PedidoService.BuscarPorContenido(frase);
                        if (listaPedido.Count != 0)
                        {
                            Console.WriteLine("Clientes encontrados:");
                            foreach (var p in listaPedido)
                            {
                                Console.WriteLine("- " + p.nombreCliente+ " estado"+p.estado);
                            }
                        }
                        else
                        {
                            Console.WriteLine("No se encontro el cliente");
                        }
                        break;
                    default:
                        Console.WriteLine("La opcion seleccionada no existe");
                        break;
                }


            }
        }
    }
}
