using dominio;
using System;
using System.Collections.Generic;
using System.Linq;


namespace negocio
{
    public class ProveedorNegocio
    {
        public List<Proveedor> listar()
        {
            List<Proveedor> lista = new List<Proveedor>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("SELECT idProveedor, razonSocial, cuit, email, telefono, activo FROM Proveedor WHERE activo = 1 ORDER BY razonSocial");
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
    }
}