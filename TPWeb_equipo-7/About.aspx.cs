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
        public List<ArticuloCarrito> carrito = new List<ArticuloCarrito>();
        public ArticuloCarrito articuloCarrito = new ArticuloCarrito();
        protected void Page_Load(object sender, EventArgs e)
        {
            string id = Request.QueryString["id"];
            if (id == null)
            {
                Response.Redirect("Default.aspx");
            }
            _articulo = ((List<Articulo>)Session["articulos"]).Find(x => x.Id == Convert.ToInt32(id));
            if (_articulo == null)
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void AgregarCarritoClick(object sender, EventArgs e)
        {
            //obtiene la lista actual del carrito
            carrito = (List<ArticuloCarrito>)Session["carrito"];

            string id = Request.QueryString["id"];
            _articulo = ((List<Articulo>)Session["articulos"]).Find(x => x.Id == Convert.ToInt32(id));

            if (carrito.Find(x => x.Id == _articulo.Id) != null)
            {
                articuloCarrito = carrito.Find(x => x.Id == _articulo.Id);
                articuloCarrito.Cantidad += Convert.ToInt32(txtCantidad.Text);
            }
            else
            {
                articuloCarrito.AgregarArticulo(_articulo);
                articuloCarrito.Cantidad = Convert.ToInt32(txtCantidad.Text);
                carrito.Add(articuloCarrito);
            }


            //agrega el articulo actual al carrito
            Session.Add("carrito", carrito);
            ((SiteMaster)Master).ActualizarCarrito();
        }
    }
}