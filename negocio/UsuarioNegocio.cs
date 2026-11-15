using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;


namespace negocio
{
    public class UsuarioNegocio
    {
        public bool loguear(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("SELECT idUsuario, nombre, apellido, activo, idPerfil FROM Usuario WHERE nombreUsuario = @nombreUsuario AND password = @password AND activo = 1");
                datos.setearParametro("@nombreUsuario", usuario.NombreUsuario);
                datos.setearParametro("@password", usuario.Password);

                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["idUsuario"];
                    usuario.Nombre = (string)datos.Lector["nombre"];
                    usuario.Apellido = (string)datos.Lector["apellido"];
                    usuario.Activo = (bool)datos.Lector["activo"];


                    int idPerfil = (int)datos.Lector["idPerfil"];
                    usuario.TipoUsuario = idPerfil == 1 ? TipoUsuario.ADMINISTRADOR : TipoUsuario.VENDEDOR;

                    return true;
                }
                return false;
            }
            catch (Exception )
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}