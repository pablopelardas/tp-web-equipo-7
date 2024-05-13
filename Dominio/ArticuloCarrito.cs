using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ArticuloCarrito
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        //[DisplayName("Descripción")]
        public string Descripcion { get; set; }
        public List<string> Imagenes = new List<string>();
        public decimal PrecioUnitario { get; set; }
        public int Cantidad {  get; set; }
        public decimal PrecioTotal
        {
            get { return PrecioUnitario * Cantidad; }
        }
        public void AgregarArticulo(Articulo art)
        {
            this.Id = art.Id;
            this.Nombre = art.Nombre;
            this.Descripcion = art.Descripcion;
            this.Imagenes = art.Imagenes;
            this.PrecioUnitario = art.Precio;
        }
    }
}
