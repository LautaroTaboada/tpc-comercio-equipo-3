using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Producto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int StockActual { get; set; }
        public int StockMinimo { get; set; }
        public decimal PorcentajeGanancia { get; set; }
        public bool Activo { get; set; }

        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }

        // Relación N a N con Proveedor
        public List<Proveedor> Proveedores { get; set; }

        // Precio de la compra más reciente (viene de la base)
        public decimal UltimoPrecioCompra { get; set; }

        // Precio de venta = último precio de compra x (1 + % ganancia / 100)
        public decimal PrecioVenta
        {
            get { return Math.Round(UltimoPrecioCompra * (1 + PorcentajeGanancia / 100m), 2); }
        }

        // Alerta de stock bajo
        public bool StockBajo
        {
            get { return StockActual < StockMinimo; }
        }

        public Producto()
        {
            Marca = new Marca();
            Categoria = new Categoria();
            Proveedores = new List<Proveedor>();
        }
    }
}
