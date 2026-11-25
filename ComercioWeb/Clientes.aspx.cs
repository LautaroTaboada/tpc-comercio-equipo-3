using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ComercioWeb
{
    public partial class Clientes : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ClienteNegocio negocio = new ClienteNegocio();
                Session["listaClientes"] = negocio.listar();
                gvClientes.DataSource = Session["listaClientes"];
                gvClientes.DataBind();
            }
        }

        protected void txtFiltro_TextChanged(object sender, EventArgs e)
        {
            List<Cliente> lista = (List<Cliente>)Session["listaClientes"];
            string filtro = txtFiltro.Text.ToUpper();

            List<Cliente> listaFiltrada = lista.FindAll(x =>
                x.Apellido.ToUpper().Contains(filtro) ||
                x.Nombre.ToUpper().Contains(filtro) ||
                x.Documento.Contains(filtro));

            gvClientes.DataSource = listaFiltrada;
            gvClientes.DataBind();
        }

        protected void gvClientes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string id = gvClientes.SelectedDataKey.Value.ToString();
            Response.Redirect("FormularioCliente.aspx?id=" + id);
        }

        protected void gvClientes_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int id = Convert.ToInt32(gvClientes.DataKeys[e.RowIndex].Value);

            ClienteNegocio negocio = new ClienteNegocio();
            negocio.eliminar(id);

            Session["listaClientes"] = negocio.listar();
            txtFiltro.Text = "";
            gvClientes.DataSource = Session["listaClientes"];
            gvClientes.DataBind();
        }
    }
}