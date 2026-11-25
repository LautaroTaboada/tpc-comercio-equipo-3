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
    public partial class MarcasInactivas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MarcaNegocio negocio = new MarcaNegocio();

                gvMarcasInactivas.DataSource = negocio.listarInactivas();
                gvMarcasInactivas.DataBind();
            }
        }

        protected void gvMarcasInactivas_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(gvMarcasInactivas.SelectedDataKey.Value);

            MarcaNegocio negocio = new MarcaNegocio();

            negocio.reactivar(id);

            gvMarcasInactivas.DataSource = negocio.listarInactivas();
            gvMarcasInactivas.DataBind();
        }
    }
}