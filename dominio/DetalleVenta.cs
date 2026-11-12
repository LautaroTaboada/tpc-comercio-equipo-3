using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class DetalleVenta
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        // Precio al momento de la venta (no cambia si después cambia el precio)
        public decimal PrecioUnitario { get; set; }
        public Producto Producto { get; set; }

        public decimal Subtotal
        {
            get { return Cantidad * PrecioUnitario; }
        }

        public DetalleVenta()
        {
            Producto = new Producto();
        }
    }
}
