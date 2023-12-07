using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MensajeroModel.DAL;
using MensajeroModel.DTO;
using SocketUtil;

namespace MensajeroApp.Hilos
{
    public class HiloCliente
    {
        private ClienteSocket clienteSocket;
        private static IMensajeDAL dalIMensaje = MensajeDALFactory.CreateDal();

        public HiloCliente(ClienteSocket clienteSocket)
        {
            this.clienteSocket = clienteSocket;
        }

        public void Ejecutar()
        {
            string nombre, descripcion;
            do
            {
                clienteSocket.Escribir("Ingrese nombre: ");
                nombre = clienteSocket.Leer().Trim();
            } while (nombre == string.Empty);

            do
            {
                clienteSocket.Escribir("Ingrese mensaje: ");
                descripcion = clienteSocket.Leer().Trim();
            } while (descripcion == string.Empty || descripcion.Length > 20);

            Mensaje m = new Mensaje()
            {
                Nombre = nombre,
                Descripcion = descripcion,
                Tipo = "TCP"
            };

            lock (dalIMensaje)
            {
                dalIMensaje.Save(m);
            }

            clienteSocket.CerrarConexion();
        }
    }
}
