using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CompraNegocio
    {
        public void registrar(Compra compra)
        {
            decimal total = 0;
            foreach (DetalleCompra d in compra.Detalles)
                total += d.Subtotal;
            compra.Total = total;

            int idCompra = agregarCompra(compra);

            foreach (DetalleCompra d in compra.Detalles)
            {
                agregarDetalle(idCompra, d);
                sumarStock(d.Producto.Id, d.Cantidad);
            }
        }

        private int agregarCompra(Compra compra)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into Compra (total, idProveedor, idUsuario) values (@total, @idProveedor, @idUsuario); Select SCOPE_IDENTITY()");
                datos.setearParametro("@total", compra.Total);
                datos.setearParametro("@idProveedor", compra.Proveedor.Id);
                datos.setearParametro("@idUsuario", compra.Usuario.Id);
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

        private void agregarDetalle(int idCompra, DetalleCompra detalle)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into DetalleCompra (cantidad, precioCompra, idCompra, idProducto) values (@cantidad, @precio, @idCompra, @idProducto)");
                datos.setearParametro("@cantidad", detalle.Cantidad);
                datos.setearParametro("@precio", detalle.PrecioCompra);
                datos.setearParametro("@idCompra", idCompra);
                datos.setearParametro("@idProducto", detalle.Producto.Id);
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

        private void sumarStock(int idProducto, int cantidad)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update Producto set stockActual = stockActual + @cantidad Where idProducto = @idProducto");
                datos.setearParametro("@cantidad", cantidad);
                datos.setearParametro("@idProducto", idProducto);
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