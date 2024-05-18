<%@ Page Title="About" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="TPWeb_equipo_7.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <main aria-labelledby="title">

        <h1><%: _articulo.Nombre %></h1>
        <asp:TextBox ID="TextBox1" runat="server" Text="1" CssClass="txtCantidad" ReadOnly="true" Style="width: 50px; text-align: center;" />
        <asp:Button ID="btnUp" runat="server" Text="▲" CommandName="Increase" CommandArgument="<%: _articulo.Id %>" CssClass="btnUpDown" OnClick="BtnUpDown_Click" />
        <asp:Button ID="btnDown" runat="server" Text="▼" CommandName="Decrease" CommandArgument="<%: _articulo.Id %>" CssClass="btnUpDown" OnClick="BtnUpDown_Click" />

        <asp:Button runat="server" ID="AgregarCarrito" Text="Agregar al Carrito" CssClass="btn btn-primary btn-lg" OnClick="AgregarCarritoClick" />

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
        </div>
    </main>
</asp:Content>
