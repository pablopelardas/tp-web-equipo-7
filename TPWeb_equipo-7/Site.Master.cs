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
            if (Session["marcas"] == null)
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                Session.Add("marcas", marcaNegocio.ListarMarcas());
            }
            if (Session["categorias"] == null)
            {
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                Session.Add("categorias", categoriaNegocio.ListarCategorias());
            }
            if (Session["articulos"] == null)
            {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();
                Session.Add("articulos", articuloNegocio.ListarArticulos());
            }

            if (Session["carrito"] == null)
            {
                List<ArticuloCarrito> carrito = new List<ArticuloCarrito>();
                Session["carrito"] = carrito;
            }
        }
    }
}