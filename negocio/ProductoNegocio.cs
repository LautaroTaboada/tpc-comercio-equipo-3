using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ProductoNegocio
    {
        public List<Producto> listar()
        {
            List<Producto> lista = new List<Producto>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("storedListarProductos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto aux = new Producto();
                    aux.Id = (int)datos.Lector["idProducto"];
                    aux.Nombre = (string)datos.Lector["nombre"];
                    if (!(datos.Lector["descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["descripcion"];
                    aux.StockActual = (int)datos.Lector["stockActual"];
                    aux.StockMinimo = (int)datos.Lector["stockMinimo"];
                    aux.PorcentajeGanancia = (decimal)datos.Lector["porcentajeGanancia"];
                    aux.Activo = (bool)datos.Lector["activo"];

                    aux.Marca.Id = (int)datos.Lector["idMarca"];
                    aux.Marca.Nombre = (string)datos.Lector["marca"];
                    aux.Categoria.Id = (int)datos.Lector["idCategoria"];
                    aux.Categoria.Nombre = (string)datos.Lector["categoria"];

                    if (!(datos.Lector["precioCompra"] is DBNull))
                        aux.UltimoPrecioCompra = (decimal)datos.Lector["precioCompra"];

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
