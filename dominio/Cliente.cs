using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Documento { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public bool Activo { get; set; }

        public string NombreCompleto
        {
            get { return Apellido + ", " + Nombre; }
        }

        public override string ToString()
        {
            return NombreCompleto;
        }
    }
}
