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
    public partial class _Default : Page
    {
        public List<Articulo> ArticuloList;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["articulos"] == null)
                {
                    ArticuloNegocio negocio = new ArticuloNegocio();
                    Session.Add("articulos", negocio.ListarArticulos());
                }
                ArticuloList = (List<Articulo>)Session["articulos"];
                if (Session["carrito"] == null)
                {
                    List<Articulo> carrito = new List<Articulo>();
                    Session["carrito"] = carrito;
                }
            }

        }
    }
}