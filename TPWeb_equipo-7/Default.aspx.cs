using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TPWeb_equipo_7
{
    public partial class _Default : Page
    {
        public List<Articulo> ListaArticulos { get; set; }
        public List<Categoria> ListaCategorias { get; set; }
        public List<Marca> ListaMarcas { get; set; }

        private string filterCategoria = "";
        private string filterMarca = "";
        private string searchTerm = "";

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ListaArticulos = (List<Articulo>)Session["articulos"];
            ListaCategorias = (List<Categoria>)Session["categorias"];
            ListaMarcas = (List<Marca>)Session["marcas"];

            if (!IsPostBack)
            {
                filtroCategoria.DataSource = ListaCategorias;
                filtroCategoria.DataBind();
                filtroCategoria.Items.Insert(0, "Seleccionar..");
                filtroMarca.DataSource = ListaMarcas;
                filtroMarca.DataBind();
                filtroMarca.Items.Insert(0, "Seleccionar..");
            }

            string finalMessage = "";
            
            string queryCategoria = Request.QueryString["Categoria"];
            string queryMarca = Request.QueryString["Marca"];
            string queryBusqueda = Request.QueryString["Busqueda"];

            if (queryCategoria != null)
            {
                filtroCategoria.SelectedValue = queryCategoria;
                filterCategoria = queryCategoria;
                ListaArticulos = ListaArticulos.FindAll(x => x.Categoria.Nombre == filterCategoria);
                
            }

            if (queryMarca != null)
            {
                filtroMarca.SelectedValue = queryMarca;
                filterMarca = queryMarca;
                ListaArticulos = ListaArticulos.FindAll(x => x.Marca.Nombre == queryMarca);
            }

            if (queryBusqueda != null)
            {
                searchTerm = queryBusqueda;
            }

            if (filterCategoria != "" || filterMarca != "" || searchTerm != "")
            {
                finalMessage = "Filtrado por: <br>";
                if (filterCategoria != "")
                {
                    finalMessage += "Categoria: " + filterCategoria + " <br>";
                    ListaArticulos = ListaArticulos.FindAll(x => x.Categoria.Nombre == filterCategoria);
                }
                if (filterMarca != "")
                {
                    finalMessage += "Marca: " + filterMarca + " <br>";
                    ListaArticulos = ListaArticulos.FindAll(x => x.Marca.Nombre == filterMarca);
                }
                if (searchTerm != "")
                {
                    finalMessage += "Busqueda: " + searchTerm + " <br>";
                    ListaArticulos = ListaArticulos.FindAll(x => x.Nombre.ToLower().Contains(searchTerm.ToLower()));
                }

                filtroSeleccionado.Text = finalMessage;
                filtroSeleccionado.Visible = true;
            }



        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            // not implemented    
            string query = "";
            if (Request.QueryString["Busqueda"] != "")
            {
                query += "&Busqueda=" + Request.QueryString["Busqueda"];
            }
            if (filtroCategoria.SelectedIndex != 0)
            {
                query += "&Categoria=" + filtroCategoria.SelectedValue;

            }
            if (filtroMarca.SelectedIndex != 0)
            {
                query += "&Marca=" + filtroMarca.SelectedValue;
            }

            Response.Redirect("Default.aspx?" + query);
        }
    }
}
