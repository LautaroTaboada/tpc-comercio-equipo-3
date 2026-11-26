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
        public void registrar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("INSERT INTO Usuario (nombreUsuario, password, nombre, apellido, email, activo, idPerfil) VALUES (@nombreUsuario, @password, @nombre, @apellido, @email, 1, 2)");

                datos.setearParametro("@nombreUsuario", usuario.NombreUsuario);
                datos.setearParametro("@password", usuario.Password);
                datos.setearParametro("@nombre", usuario.Nombre);
                datos.setearParametro("@apellido", usuario.Apellido);
                datos.setearParametro("@email", usuario.Email);

                datos.ejecutarAccion();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool existeUsuario(string nombreUsuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Usuario WHERE nombreUsuario = @nombreUsuario");
                datos.setearParametro("@nombreUsuario", nombreUsuario);

                return datos.ejecutarAccionScalar() > 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool verificarUsuarioEmail(string nombreUsuario, string email)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT COUNT(*) FROM Usuario WHERE nombreUsuario = @nombreUsuario AND email = @email AND activo = 1");

                datos.setearParametro("@nombreUsuario", nombreUsuario);
                datos.setearParametro("@email", email);

                return datos.ejecutarAccionScalar() > 0;
            }
            catch (Exception)
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