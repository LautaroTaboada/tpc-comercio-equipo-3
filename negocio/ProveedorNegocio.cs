using dominio;
using System;
using System.Collections.Generic;
using System.Linq;


using dominio;
using System;
using System.Collections.Generic;

namespace negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> listar()
        {
            return leer("Select idProveedor, razonSocial, cuit, email, telefono, activo From Proveedor Where activo = 1 Order By razonSocial", 0);
        }

        public List<Proveedor> listarInactivos()
        {
            return leer("Select idProveedor, razonSocial, cuit, email, telefono, activo From Proveedor Where activo = 0 Order By razonSocial", 0);
        }

        public List<Proveedor> listar(string id)
        {
            return leer("Select idProveedor, razonSocial, cuit, email, telefono, activo From Proveedor Where idProveedor = @id", int.Parse(id));
        }

        private List<Proveedor> leer(string consulta, int id)
        {
            List<Proveedor> lista = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta(consulta);
                if (id != 0)
                    datos.setearParametro("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Proveedor aux = new Proveedor();
                    aux.Id = (int)datos.Lector["idProveedor"];
                    aux.RazonSocial = (string)datos.Lector["razonSocial"];
                    aux.Cuit = (string)datos.Lector["cuit"];
                    aux.Email = datos.Lector["email"] == DBNull.Value ? "" : (string)datos.Lector["email"];
                    aux.Telefono = datos.Lector["telefono"] == DBNull.Value ? "" : (string)datos.Lector["telefono"];
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

        public bool existe(string cuit, int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Select idProveedor From Proveedor Where cuit = @cuit And idProveedor <> @id");
                datos.setearParametro("@cuit", cuit);
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

        public void agregar(Proveedor nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert Into Proveedor (razonSocial, cuit, email, telefono, activo) Values (@razonSocial, @cuit, @email, @telefono, 1)");
                datos.setearParametro("@razonSocial", nuevo.RazonSocial);
                datos.setearParametro("@cuit", nuevo.Cuit);
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

        public void modificar(Proveedor proveedor)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Update Proveedor Set razonSocial = @razonSocial, cuit = @cuit, email = @email, telefono = @telefono Where idProveedor = @id");
                datos.setearParametro("@razonSocial", proveedor.RazonSocial);
                datos.setearParametro("@cuit", proveedor.Cuit);
                datos.setearParametro("@email", (object)proveedor.Email ?? DBNull.Value);
                datos.setearParametro("@telefono", (object)proveedor.Telefono ?? DBNull.Value);
                datos.setearParametro("@id", proveedor.Id);
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
                datos.setearConsulta("Update Proveedor Set activo = @activo Where idProveedor = @id");
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