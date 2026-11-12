using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Venta
    {
        public int Id { get; set; }
        public string NumeroFactura { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Total { get; set; }
        public Cliente Cliente { get; set; }
        public Usuario Usuario { get; set; }
        public List<DetalleVenta> Detalles { get; set; }

        public Venta()
        {
            Cliente = new Cliente();
            Usuario = new Usuario();
            Detalles = new List<DetalleVenta>();
        }
    }
}
