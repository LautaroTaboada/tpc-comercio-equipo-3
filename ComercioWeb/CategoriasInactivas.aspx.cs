using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace ComercioWeb
{
    public partial class CategoriasInactivas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CategoriaNegocio negocio = new CategoriaNegocio();

                dgvCategoriasInactivas.DataSource = negocio.listarInactivas();
                dgvCategoriasInactivas.DataBind();
            }
        }
        protected void dgvCategoriasInactivas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvCategoriasInactivas.SelectedDataKey.Value);

            CategoriaNegocio negocio = new CategoriaNegocio();

            negocio.reactivar(id);

            dgvCategoriasInactivas.DataSource = negocio.listarInactivas();
            dgvCategoriasInactivas.DataBind();
        }
    }
}