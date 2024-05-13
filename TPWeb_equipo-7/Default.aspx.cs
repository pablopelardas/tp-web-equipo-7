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
        public List<Articulo> ListaArticulos { get; set; }
        public List<Categoria> ListaCategorias { get; set; }
        public List<Marca> ListaMarcas { get; set; }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            ListaArticulos = (List<Articulo>)Session["articulos"];
            ListaCategorias = (List<Categoria>)Session["categorias"];
            ListaMarcas = (List<Marca>)Session["marcas"];

            if (!IsPostBack)
            {
                filtroCategoria.DataSource = Session["listaCategorias"];
                filtroCategoria.DataBind();
                filtroCategoria.Items.Insert(0, "Seleccionar..");
                filtroMarca.DataSource = Session["listaMarcas"];
                filtroMarca.DataBind();
                filtroMarca.Items.Insert(0, "Seleccionar..");
            }

            if (Session["filtroCategoria"] != null)
            {
                filtroCategoria.SelectedValue = Session["filtroCategoria"].ToString();
                catBuscado.Text = filtroCategoria.SelectedItem.Text;
                divCat.Visible = true;
                ListaArticulos = ListaArticulos.FindAll(x => x.Categoria.Nombre == Session["filtroCategoria"].ToString());
                
            }

            if (Session["filtroMarca"] != null)
            {
                filtroMarca.SelectedValue = Session["filtroMarca"].ToString();
                mrcBuscado.Text = filtroMarca.SelectedItem.Text;
                divMrc.Visible = true;
                ListaArticulos = ListaArticulos.FindAll(x => x.Marca.Nombre == Session["filtroMarca"].ToString());
            }
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            Session.Remove("filtroCategoria");
            Session.Remove("filtroMarca");
        }

        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            // not implemented    
            if (filtroCategoria.SelectedIndex != 0)
            {
                Session["filtroCategoria"] = filtroCategoria.SelectedValue;
            }
            if (filtroMarca.SelectedIndex != 0)
            {
                Session["filtroMarca"] = filtroMarca.SelectedValue;
            }
        }
    }
}
