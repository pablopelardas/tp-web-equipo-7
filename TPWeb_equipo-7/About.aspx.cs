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
        public int cantidadArticulo;
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

                cantidadArticulo = TextBox1.Text == "" ? 1 : Convert.ToInt32(TextBox1.Text);
        }


        protected void AgregarCarritoClick(object sender, EventArgs e)
        {
            //obtiene la lista actual del carrito
            carrito = (List<ArticuloCarrito>)Session["carrito"];

            string id = Request.QueryString["id"];
            _articulo = ((List<Articulo>)Session["articulos"]).Find(x => x.Id == Convert.ToInt32(id));
            ArticuloCarrito articuloCarrito = carrito.Find(x => x.Id == _articulo.Id);

            if (articuloCarrito != null)
            {
                articuloCarrito.Cantidad += cantidadArticulo;
            }
            else
            {
                articuloCarrito = new ArticuloCarrito(_articulo);
                articuloCarrito.Cantidad = cantidadArticulo;
                carrito.Add(articuloCarrito);
            }

            ((SiteMaster)Master).SumarCantidadCarrito(cantidadArticulo);
            Response.Redirect("Default.aspx", false);
            Context.ApplicationInstance.CompleteRequest();

        }

        protected void BtnUpDown_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            if (btn.CommandName == "Increase")
            {
                cantidadArticulo += 1;
            }
            else if (btn.CommandName == "Decrease" && cantidadArticulo > 1)
            {
                cantidadArticulo -= 1;
            }
            TextBox1.Text = cantidadArticulo.ToString();
        }
    }
}