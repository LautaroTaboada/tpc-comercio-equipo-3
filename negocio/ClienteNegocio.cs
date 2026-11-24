using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ClienteNegocio
    {
        public List<Cliente> listar()
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select idCliente, nombre, apellido, documento, email, telefono, activo From Cliente Where activo = 1 Order By apellido, nombre");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Cliente aux = new Cliente();
                    aux.Id = (int)datos.Lector["idCliente"];
                    aux.Nombre = (string)datos.Lector["nombre"];
                    aux.Apellido = (string)datos.Lector["apellido"];
                    aux.Documento = (string)datos.Lector["documento"];
                    if (!(datos.Lector["email"] is DBNull))
                        aux.Email = (string)datos.Lector["email"];
                    if (!(datos.Lector["telefono"] is DBNull))
                        aux.Telefono = (string)datos.Lector["telefono"];
                    aux.Activo = (bool)datos.Lector["activo"];
                    lista.Add(aux);
                }
                return lista;
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
    }
}
