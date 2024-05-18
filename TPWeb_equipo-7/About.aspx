<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TPWeb_equipo_7.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">
        <%if (_articulo != null)
            {  %>
            <h1><%: _articulo.Nombre %></h1>
        <%} else {  %>
        <h1 id="title">About</h1>
        <p>Use this area to provide additional information.</p>
        <%} %>
        <asp:TextBox runat="server" ID="txtCantidad" Text="1"/>
        <asp:Button runat="server"  ID="AgregarCarrito" Text="Agregar al Carrito" CssClass="btn btn-primary btn-lg" OnClick="AgregarCarritoClick" />

        <div id="carouselExample" class="carousel slide">
            <div class="carousel-inner">
                <%if (_articulo.Imagenes.Count > 0)
                    {
                        for (int i=0; i<_articulo.Imagenes.Count; i++)
                        {
                %>
                <div class="carousel-item <%: i==0?"active": "" %>">
                    <img src="<%:_articulo.Imagenes[i] %>" onerror="this.onerror=null;this.src='https://via.placeholder.com/150';" class="d-block w-100" alt="...">
                </div>
                <%}
                    }
                    else
                    {  %><div class="carousel-item active">
                  <img src="https://via.placeholder.com/150" class="d-block w-100" alt="...">
              </div>
                <%} %>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExample" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExample" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
    </main>
</asp:Content>
