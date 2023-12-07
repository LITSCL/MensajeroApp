using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MensajeroModel.DAL;
using MensajeroModel.DTO;

namespace MensajeroApp
{
    public partial class Program
    {
        static IMensajeDAL dalIMensaje = MensajeDALFactory.CreateDal();

        static void IngresarMensaje()
        {
            string nombre, descripcion;
            do
            {
                Console.WriteLine("Ingrese nombre: ");
                nombre = Console.ReadLine().Trim();
            } while (nombre == string.Empty);

            do
            {
                Console.WriteLine("Ingrese mensaje: ");
                descripcion = Console.ReadLine().Trim();
            } while (descripcion == string.Empty || descripcion.Length > 20);

            Mensaje m = new Mensaje()
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Tipo = "Aplicacion"
            };
            lock (dalIMensaje)
            {
                dalIMensaje.Save(m);
            }
        }

        static void MostrarMensajes()
        {
            List<Mensaje> mensajes = dalIMensaje.GetAll();
            mensajes.ForEach(m =>
            {
                Console.WriteLine("Nombre: {0} Detalle: {1} Tipo: {2}", m.Nombre, m.Descripcion, m.Tipo);
            });
        }

        static bool Menu()
        {
            bool continuar = true;
            Console.WriteLine("1. Ingresar Mensaje");
            Console.WriteLine("2. Mostrar Mensajes");
            Console.WriteLine("0. Salir");
            string opcion = Console.ReadLine().Trim();
            switch (opcion)
            {
                case "1":
                    IngresarMensaje();
                    break;
                case "2":
                    MostrarMensajes();
                    break;
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("No has ingresado una opción válida");
                    break;
            }
            return continuar;
        }
    }
}
