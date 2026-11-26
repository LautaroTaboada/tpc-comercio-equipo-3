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

        public int agregar(Producto nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into Producto (nombre, descripcion, stockMinimo, porcentajeGanancia, idMarca, idCategoria) values (@nombre, @descripcion, @stockMinimo, @ganancia, @idMarca, @idCategoria); Select SCOPE_IDENTITY()");
                datos.setearParametro("@nombre", nuevo.Nombre);
                datos.setearParametro("@descripcion", nuevo.Descripcion);
                datos.setearParametro("@stockMinimo", nuevo.StockMinimo);
                datos.setearParametro("@ganancia", nuevo.PorcentajeGanancia);
                datos.setearParametro("@idMarca", nuevo.Marca.Id);
                datos.setearParametro("@idCategoria", nuevo.Categoria.Id);
                return datos.ejecutarAccionScalar();
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

        public void modificar(Producto producto)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update Producto set nombre = @nombre, descripcion = @descripcion, stockMinimo = @stockMinimo, porcentajeGanancia = @ganancia, idMarca = @idMarca, idCategoria = @idCategoria Where idProducto = @id");
                datos.setearParametro("@nombre", producto.Nombre);
                datos.setearParametro("@descripcion", producto.Descripcion);
                datos.setearParametro("@stockMinimo", producto.StockMinimo);
                datos.setearParametro("@ganancia", producto.PorcentajeGanancia);
                datos.setearParametro("@idMarca", producto.Marca.Id);
                datos.setearParametro("@idCategoria", producto.Categoria.Id);
                datos.setearParametro("@id", producto.Id);
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

        public void eliminarLogico(int id, bool activo = false)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update Producto set activo = @activo Where idProducto = @id");
                datos.setearParametro("@id", id);
                datos.setearParametro("@activo", activo);
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

        public List<int> listarIdsProveedores(int idProducto)
        {
            List<int> lista = new List<int>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select idProveedor From ProductoProveedor Where idProducto = @id");
                datos.setearParametro("@id", idProducto);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                    lista.Add((int)datos.Lector["idProveedor"]);

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

        public void guardarProveedores(int idProducto, List<int> idsProveedores)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Delete From ProductoProveedor Where idProducto = @id");
                datos.setearParametro("@id", idProducto);
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


            foreach (int idProveedor in idsProveedores)
            {
                AccesoDatos aux = new AccesoDatos();
                try
                {
                    aux.setearConsulta("Insert Into ProductoProveedor (idProducto, idProveedor) Values (@idProducto, @idProveedor)");
                    aux.setearParametro("@idProducto", idProducto);
                    aux.setearParametro("@idProveedor", idProveedor);
                    aux.ejecutarAccion();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    aux.cerrarConexion();
                }
            }
        }
    }
}
