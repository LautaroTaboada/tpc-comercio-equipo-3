using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class DetalleCompra
    {
        public int Id { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioCompra { get; set; }
        public Producto Producto { get; set; }

        public decimal Subtotal
        {
            get { return Cantidad * PrecioCompra; }
        }

        public DetalleCompra()
        {
            Producto = new Producto();
        }
    }
}
