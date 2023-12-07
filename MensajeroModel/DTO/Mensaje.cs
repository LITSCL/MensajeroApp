using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MensajeroModel.DTO
{
    public class Mensaje
    {
        private string nombre;
        private string descripcion;
        private string tipo;

        public string Nombre { get => nombre; set => nombre = value; }
        public string Descripcion { get => descripcion; set => descripcion = value; }
        public string Tipo { get => tipo; set => tipo = value; }

        public override string ToString()
        {
            return Nombre + ";" + Descripcion + ";" + Tipo;
        }
    }
}
