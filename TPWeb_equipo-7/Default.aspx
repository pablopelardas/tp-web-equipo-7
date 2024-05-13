<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWeb_equipo_7._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

 <div class="container" style="margin-top: 30px;">

     <div class="row">
         <div class="col-3">
             <h4>Filtros</h4>
             <div>
                 <div class="badge rounded-pill text-bg-secondary" id="divCat" Visible="false" runat="server">
                     <asp:Label Text="" ID="catBuscado" runat="server" />
                 </div>
                 <div class="badge rounded-pill text-bg-secondary" id="divMrc" Visible="false" runat="server">
                     <asp:Label Text="" ID="mrcBuscado" runat="server" />
                 </div>
             </div>
             <div class="mb-3">
                 <label for="filtroCategoria">Categoría</label>
                 <asp:DropDownList ID="filtroCategoria" CssClass="form-select h-1" runat="server" AutoPostBack="false"></asp:DropDownList>
             </div>
             <div class="mb-3">
                 <label for="filtroCategoria">Marca</label>
                 <asp:DropDownList ID="filtroMarca" CssClass="form-select h-1" runat="server" AutoPostBack="false"></asp:DropDownList>
             </div>
             <asp:Button ID="btnFiltro" Text="Aplicar filtro" OnClick="btnFiltro_Click" CssClass="btn btn-primary" runat="server" />
         </div>
         <div class="col-9">
             <%
                foreach (Dominio.Categoria item in ListaCategorias)
                {
             %>
                <div class="row">
                    <div class="categoria-container">
                        <h3><%: item.Nombre %></h3>
                        <div class="items-container">
                            <%
                                foreach (Dominio.Articulo art in ListaArticulos.FindAll(a => a.Categoria.Nombre == item.Nombre))
                                {
                            %>
                            <div class="card">
                                <%if (art.Imagenes.Count > 0)
                                    {  %>
                                <img src="<%:art.Imagenes[0] %>" class="card-img-top" alt="...">
                                <% }
                                else
                                {  %>
                                <img src="https://via.placeholder.com/150" class="card-img-top" alt="...">
                                <% }  %>
                                <div class="card-body">
                                    <h5 class="card-title"><%: art.Nombre %></h5>
                                    <p class="card-text">$<%: art.Precio %></p>
                                    <a href="About.aspx?id=<%: art.Id %>" class="btn btn-outline-dark">Ver Detalle</a>
                                </div>
                            </div>
                            <%  } %>
                        </div>

                    </div>
                </div>
                <%  } %>
         </div>
     </div>

     
 </div>

    <style>
    .categoria-container {
        display: flex;
        flex-direction: column;
        -ms-flex-wrap: wrap;
        -webkit-flex-wrap: wrap;
        flex-wrap: wrap;
    }

    .items-container {
        display: flex;
        flex-direction: row;
        flex-wrap: wrap;
    }

    .categoria-container .card {
        width: 20%;
        height: 500px;
        margin: 10px 0px;
    }

    .categoria-container .card img {
        height: 300px;
    }

    .categoria-container .card .card-body {
        display: flex;
        flex-direction: column;
        justify-content: space-between;
        height: 150px;
    }
    </style>

</asp:Content>
