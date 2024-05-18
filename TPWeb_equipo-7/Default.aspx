<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWeb_equipo_7._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container" style="margin-top: 30px;">

        <div class="row">
            <div class="d-flex flex-column justify-content-start">
                <asp:Label ID="filtroSeleccionado" Text="" Visible="false" runat="server" />
                <div class="filtros d-flex justify-content-start align-items-center" style="<%: filtroSeleccionado.Visible == true ?"display: none": "" %>">
                    <div class="mb-3 me-4">
                        <label for="filtroCategoria">Categoría</label>
                        <asp:DropDownList ID="filtroCategoria" CssClass="form-select h-1" runat="server" AutoPostBack="false"></asp:DropDownList>
                    </div>
                    <div class="mb-3 me-4">
                        <label for="filtroCategoria">Marca</label>
                        <asp:DropDownList ID="filtroMarca" CssClass="form-select h-1" runat="server" AutoPostBack="false"></asp:DropDownList>
                    </div>
                    <asp:Button ID="btnFiltro" Text="Aplicar filtro" OnClick="btnFiltro_Click" CssClass="btn btn-primary me-4" runat="server" Height="50px" />
                    <%if (filtroSeleccionado.Visible == true)
                        {  %>
                    <a href="Default.aspx" class="btn btn-danger d-flex align-items-center" style="height: 50px;">Eliminar filtros</a>
                    <% } %>
                </div>
            </div>
        </div>
        <div class="row gx-4 gx-lg-5 row-cols-2 row-cols-md-3 row-cols-xl-4 justify-content-center">
            <%
                foreach (Dominio.Articulo art in ListaArticulos)
                {
            %>
            <div class="col mb-5">
                <div class="card h-100">
                    <%if (art.Imagenes.Count > 0)
                        {  %>
                    <img src="<%:art.Imagenes[0] %>" onerror="this.onerror=null;this.src='https://via.placeholder.com/150';" class="card-img-top" alt="...">
                    <% }
                        else
                        {  %>
                    <img src="https://via.placeholder.com/150" class="card-img-top" alt="...">
                    <% }  %>
                    <div class="card-body p-4">
                        <div class="text-center">
                            <h5 class="fw-bolder"><%: art.Nombre %></h5>
                            <!-- Product price-->
                            $<%: art.Precio %>
                        </div>
                    </div>
                    <div class="card-footer p-4 pt-0 border-top-0 bg-transparent">
                        <div class="text-center"><a class="btn btn-outline-dark mt-auto" href="About.aspx?id=<%: art.Id %>">Ver Detalle</a></div>
                    </div>
                </div>
            </div>
            <%  } %>
        </div>

        <style>

            .card-img-top {
                height: 300px;
                object-fit: cover;
            }

        </style>

    </div>

</asp:Content>
