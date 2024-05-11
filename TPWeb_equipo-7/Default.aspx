<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TPWeb_equipo_7._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
       HOLA MUNDO
        <div class="container">
            <h1 id="title">PRODUCTOS</h1>
            <div class="row">
                <% foreach (Dominio.Articulo art in ArticuloList  ) { %>
                    <a href="about?id=<%: art.Id %>"><%: art.Nombre %></a>
                <%} %>
            </div>
        </div>
    </main>

</asp:Content>
