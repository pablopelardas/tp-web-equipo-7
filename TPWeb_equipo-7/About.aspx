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

        <%--<div id="carouselExample" class="carousel carousel-dark slide">
            <h4><%: _articulo.Descripcion %></h4>
            <h3 class="carousel-inner">$<%: _articulo.Precio %></h3>
            <h5><%: _articulo.Categoria %> <%: _articulo.Marca %></h5>
            <h6> <%: _articulo.Codigo %></h6>

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
        </div>--%>

        <div id="carouselExampleIndicators" class="carousel carousel-dark slide">
            <h2><%: _articulo.Descripcion %></h2>
            <h3 class="carousel-inner">$<%: _articulo.Precio %></h3>
            <h5><%: _articulo.Categoria %> <%: _articulo.Marca %></h5>
            <h6><%: _articulo.Codigo %></h6>
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>
            <div class="carousel-inner">
                <%if (_articulo.Imagenes.Count > 0)
                    {
                        for (int i = 0; i < _articulo.Imagenes.Count; i++)
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
                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Previous</span>
                </button>
                <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                    <span class="carousel-control-next-icon" aria-hidden="true"></span>
                    <span class="visually-hidden">Next</span>
                </button>
            </div>
    </main>
</asp:Content>
