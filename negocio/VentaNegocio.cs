using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class VentaNegocio
    {
        public int registrar(Venta venta)
        {
            decimal total = 0;
            foreach (DetalleVenta d in venta.Detalles)
                total += d.Subtotal;
            venta.Total = total;

            int idVenta = agregarVenta(venta);

            foreach (DetalleVenta d in venta.Detalles)
            {
                agregarDetalle(idVenta, d);
                restarStock(d.Producto.Id, d.Cantidad);
            }

            return idVenta;
        }

        private int agregarVenta(Venta venta)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("storedAgregarVenta");
                datos.setearParametro("@idCliente", venta.Cliente.Id);
                datos.setearParametro("@idUsuario", venta.Usuario.Id);
                datos.setearParametro("@total", venta.Total);
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

        private void agregarDetalle(int idVenta, DetalleVenta detalle)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Insert into DetalleVenta (cantidad, precioUnitario, subtotal, idVenta, idProducto) values (@cantidad, @precio, @subtotal, @idVenta, @idProducto)");
                datos.setearParametro("@cantidad", detalle.Cantidad);
                datos.setearParametro("@precio", detalle.PrecioUnitario);
                datos.setearParametro("@subtotal", detalle.Subtotal);
                datos.setearParametro("@idVenta", idVenta);
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

        private void restarStock(int idProducto, int cantidad)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Update Producto set stockActual = stockActual - @cantidad Where idProducto = @idProducto");
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

        public Venta obtener(int idVenta)
        {
            Venta venta = null;
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearConsulta("Select v.idVenta, v.numeroFactura, v.fecha, v.total, c.nombre, c.apellido, c.documento, d.cantidad, d.precioUnitario, p.nombre as producto From Venta v Inner Join Cliente c On c.idCliente = v.idCliente Inner Join DetalleVenta d On d.idVenta = v.idVenta Inner Join Producto p On p.idProducto = d.idProducto Where v.idVenta = @id");
                datos.setearParametro("@id", idVenta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    if (venta == null)
                    {
                        venta = new Venta();
                        venta.Id = (int)datos.Lector["idVenta"];
                        venta.NumeroFactura = (string)datos.Lector["numeroFactura"];
                        venta.Fecha = (DateTime)datos.Lector["fecha"];
                        venta.Total = (decimal)datos.Lector["total"];
                        venta.Cliente.Nombre = (string)datos.Lector["nombre"];
                        venta.Cliente.Apellido = (string)datos.Lector["apellido"];
                        venta.Cliente.Documento = (string)datos.Lector["documento"];
                    }

                    DetalleVenta linea = new DetalleVenta();
                    linea.Cantidad = (int)datos.Lector["cantidad"];
                    linea.PrecioUnitario = (decimal)datos.Lector["precioUnitario"];
                    linea.Producto.Nombre = (string)datos.Lector["producto"];
                    venta.Detalles.Add(linea);
                }
                return venta;
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