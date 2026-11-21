using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
        public class CategoriaNegocio
        {
            public List<Categoria> listar()
            {
                List<Categoria> lista = new List<Categoria>();
                AccesoDatos datos = new AccesoDatos();

                try
                {
                    datos.setearConsulta("Select idCategoria, nombre, activo From Categoria Where activo = 1 Order By nombre");
                    datos.ejecutarLectura();

                    while (datos.Lector.Read())
                    {
                        Categoria aux = new Categoria();
                        aux.Id = (int)datos.Lector["idCategoria"];
                        aux.Nombre = (string)datos.Lector["nombre"];
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

