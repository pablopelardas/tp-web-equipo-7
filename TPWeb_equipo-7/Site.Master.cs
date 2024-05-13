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
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["listaMarcas"] == null)
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                Session.Add("listaMarcas", marcaNegocio.ListarMarcas());
            }
            if (Session["listaCategorias"] == null)
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                Session.Add("listaCategorias", categoriaNegocio.ListarCategorias());
            }
            if (Session["listaArticulos"] == null)
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                Session.Add("listaArticulos", articuloNegocio.ListarArticulos());
            }

            if (Session["carrito"] == null)
            {
                List<ArticuloCarrito> carrito = new List<ArticuloCarrito>();
                Session["carrito"] = carrito;
            }
        }
    }
}