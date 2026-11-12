using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Activo { get; set; }
        public Perfil Perfil { get; set; }

        public bool EsAdministrador
        {
            get { return Perfil != null && Perfil.Nombre == "Administrador"; }
        }

        public Usuario()
        {
            Perfil = new Perfil();
        }
    }
}
