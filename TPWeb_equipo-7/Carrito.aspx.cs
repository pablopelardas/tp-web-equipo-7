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
        public decimal importeTotal = 0m;
        protected void ActualizarGrilla()
        {
            if (carrito.Count == 0)
            {
                Response.Redirect("Default.aspx", false);
                Context.ApplicationInstance.CompleteRequest();

            }
            dgvArticulos.DataSource = carrito;
            dgvArticulos.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            carrito = (List<ArticuloCarrito>)Session["carrito"];
            if (carrito == null)
            {
                carrito = new List<ArticuloCarrito>();
            }
            ActualizarGrilla();
            SumarTotalCarrito((decimal)carrito.Sum(x => x.PrecioTotal));            
        }

        protected void SumarTotalCarrito(decimal importe)
        {
            importeTotal += importe;
        }


        protected void dgvArticulos_SelectedIndexChanged(object sender, EventArgs e)
        {
            var id = dgvArticulos.SelectedDataKey?.Value.ToString();
            if (id == null) return;
            int cantidad = 0;
            decimal precioTotal = 0;

            for (int i = carrito.Count - 1; i >= 0; i--)
            {
                if (carrito[i].Id.ToString() == id)
                {
                    cantidad = carrito[i].Cantidad;
                    precioTotal = carrito[i].PrecioTotal;
                    carrito.RemoveAt(i);

                }
            }

            ((SiteMaster)Master).SumarCantidadCarrito(- cantidad);
            SumarTotalCarrito(- precioTotal);
            ActualizarGrilla();

        }

        protected void BtnUpDown_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int idArticulo = Convert.ToInt32(btn.CommandArgument);

            ArticuloCarrito articulo = carrito.Find(a => a.Id == idArticulo);

            if (articulo != null)
            {
                if (btn.CommandName == "Increase")
                {
                    articulo.Cantidad++;
                    ((SiteMaster)Master).SumarCantidadCarrito(1);
                    SumarTotalCarrito(articulo.PrecioUnitario);
                }
                else if (btn.CommandName == "Decrease" && articulo.Cantidad > 1)
                {
                    articulo.Cantidad--;
                    ((SiteMaster)Master).SumarCantidadCarrito(-1);
                    SumarTotalCarrito(-articulo.PrecioUnitario);
                }

            }
            ActualizarGrilla();
        }



    }
}