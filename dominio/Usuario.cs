using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public enum TipoUsuario
    {
        ADMIN = 1,
        NORMAL = 2,
    }
    public class Usuario
    {
        public int Id { get; set; }
        public string NombreUsuario { get; set; }
        public string Password { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public bool Activo { get; set; }
        public TipoUsuario TipoUsuario { get; set; }



        public Usuario(string user, string pass, bool admin)
        {
            NombreUsuario = user;
            Password = pass;
            TipoUsuario = admin ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
        }
        public Usuario()
        {

        }
    }
}
