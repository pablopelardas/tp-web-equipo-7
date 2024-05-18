using Dominio;
using Negocio;
using System;
using System.Collections;
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
            if (!IsPostBack)
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
                if (Session["cantidadTotal"] == null)
                {
                    Session.Add("cantidadTotal", 0);
                }
            }

        }
        protected void ClickCarrito(object sender, EventArgs e)
        {
            // Redirigir a la página del carrito de compras
            Response.Redirect("~/Carrito");
        }

        public void SumarCantidadCarrito(int cantidad)
        {
            Session["cantidadTotal"] = (int)Session["cantidadTotal"] + cantidad;
        }

        protected void ClickBusqueda(object sender, EventArgs e)
        {
            string query = "?";
            string busqueda = txtBusqueda.Text;

            query += "Busqueda=" + busqueda;

            if (Request.QueryString["Categoria"] != null)
            {
                query += "&Categoria=" + Request.QueryString["Categoria"];

            }
            if (Request.QueryString["Marca"] != null)
            {
                query += "&Marca=" + Request.QueryString["Marca"];
            }

            Response.Redirect("~/" + query);


        }
    }
}