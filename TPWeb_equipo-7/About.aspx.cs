using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWeb_equipo_7
{
    public partial class About : Page
    {
        public Articulo _articulo;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["articulos"] == null)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Session.Add("articulos", negocio.ListarArticulos());
                }
                // query id
                string id = Request.QueryString["id"];

                _articulo = ((List<Articulo>)Session["articulos"]).Find(x => x.Id == Convert.ToInt32(id));
                // si no encuentra el articulo, redirige a la pagina principal
                if (_articulo == null)
                {
                    Response.Redirect("Default.aspx");
                }
            }
           

        }
    }
}