using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace TPWeb_equipo_7
{
    public partial class Carrito1 : System.Web.UI.Page
    {
        public List<ArticuloCarrito> carrito = new List<ArticuloCarrito>();
        public Articulo _articulo;
        public decimal importeTotal;
        protected void Bind()
        {
            dgvArticulos.DataSource = Session["carrito"];
            dgvArticulos.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Bind();
            }
            ActualizarTotal();            
        }

        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvArticulos.SelectedDataKey.Value.ToString();

            carrito = (List<ArticuloCarrito>)Session["carrito"];

            for (int i = carrito.Count - 1; i >= 0; i--)
            {
                if (carrito[i].Id.ToString() == id)
                {
                    carrito.RemoveAt(i);
                }
            }

            Session["carrito"] = carrito;
            ((SiteMaster)Master).ActualizarCarrito();
            ActualizarTotal();
            Bind();
        }

        protected void BtnUpDown_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            TextBox txtCantidad = (TextBox)row.FindControl("txtCantidad");

            int cantidad = int.Parse(txtCantidad.Text);

            int idArticulo = Convert.ToInt32(btn.CommandArgument);

            List<ArticuloCarrito> carrito = (List<ArticuloCarrito>)Session["carrito"];

            ArticuloCarrito articulo = carrito.Find(a => a.Id == idArticulo);

            if (articulo != null)
            {
                if (btn.CommandName == "Increase")
                {
                    articulo.Cantidad++;
                }
                else if (btn.CommandName == "Decrease" && articulo.Cantidad > 1)
                {
                    articulo.Cantidad--;
                }

                Session["carrito"] = carrito;
                ((SiteMaster)Master).ActualizarCarrito();
                ActualizarTotal();
                Bind();
            }
        }

        protected void ActualizarTotal()
        {
            List<ArticuloCarrito> carrito = (List<ArticuloCarrito>)Session["carrito"];
            if (carrito != null)
            {
                importeTotal = 0m;
                foreach (var articulo in carrito)
                {
                    importeTotal += articulo.PrecioTotal;
                }
            }
        }
    }
}