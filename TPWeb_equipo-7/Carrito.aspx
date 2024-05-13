<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPWeb_equipo_7.Carrito1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Carrito</h1>
    <asp:GridView ID="dgvArticulos" CssClass="table gridview-style" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Articulo" DataField="Nombre"/>
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion"/>
            <asp:BoundField HeaderText="Precio" DataField="PrecioUnitario"/>
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad"/>
            <asp:BoundField HeaderText="Total" DataField="PrecioTotal"/>
        </Columns>

    </asp:GridView>



</asp:Content>
