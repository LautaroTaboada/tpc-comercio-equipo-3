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
            return leer("Select idCliente, nombre, apellido, documento, email, telefono, activo From Cliente Where activo = 1 Order By apellido, nombre", 0);
        }

        public List<Cliente> listarInactivos()
        {
            return leer("Select idCliente, nombre, apellido, documento, email, telefono, activo From Cliente Where activo = 0 Order By apellido, nombre", 0);
        }

        public List<Cliente> listar(string id)
        {
            return leer("Select idCliente, nombre, apellido, documento, email, telefono, activo From Cliente Where idCliente = @id", int.Parse(id));
        }

        // Lee la consulta y arma la lista (lo usan los 3 listar)
        private List<Cliente> leer(string consulta, int id)
        {
            List<Cliente> lista = new List<Cliente>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(consulta);
                if (id != 0)
                    datos.setearParametro("@id", id);
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

        // id = 0 para un alta; en una modificación pasamos el id para no compararlo consigo mismo
        public bool existe(string documento, int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select idCliente From Cliente Where documento = @documento And idCliente <> @id");
                datos.setearParametro("@documento", documento);
                datos.setearParametro("@id", id);
                datos.ejecutarLectura();
                return datos.Lector.Read();
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

        public void agregar(Cliente nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert Into Cliente (nombre, apellido, documento, email, telefono, activo) Values (@nombre, @apellido, @documento, @email, @telefono, 1)");
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@apellido", nuevo.Apellido);
                datos.setearParametro("@documento", nuevo.Documento);
                datos.setearParametro("@email", (object)nuevo.Email ?? DBNull.Value);
                datos.setearParametro("@telefono", (object)nuevo.Telefono ?? DBNull.Value);
                datos.ejecutarAccion();
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

        public void modificar(Cliente cliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Cliente Set nombre = @nombre, apellido = @apellido, documento = @documento, email = @email, telefono = @telefono Where idCliente = @id");
                datos.setearParametro("@nombre", cliente.Nombre);
                datos.setearParametro("@apellido", cliente.Apellido);
                datos.setearParametro("@documento", cliente.Documento);
                datos.setearParametro("@email", (object)cliente.Email ?? DBNull.Value);
                datos.setearParametro("@telefono", (object)cliente.Telefono ?? DBNull.Value);
                datos.setearParametro("@id", cliente.Id);
                datos.ejecutarAccion();
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

        // Baja lógica: no se borra, queda activo = 0
        public void eliminar(int id)
        {
            cambiarActivo(id, 0);
        }

        public void reactivar(int id)
        {
            cambiarActivo(id, 1);
        }

        private void cambiarActivo(int id, int valor)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Cliente Set activo = @activo Where idCliente = @id");
                datos.setearParametro("@activo", valor);
                datos.setearParametro("@id", id);
                datos.ejecutarAccion();
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
