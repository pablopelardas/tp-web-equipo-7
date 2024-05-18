<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPWeb_equipo_7.Carrito1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Carrito</h1>
    <asp:GridView ID="dgvArticulos" CssClass="table gridview-style" AutoGenerateColumns="false" runat="server">
        <Columns>
            <asp:BoundField HeaderText="Articulo" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="PrecioUnitario" />
            <asp:BoundField HeaderText="Cantidad" DataField="Cantidad" />
            <asp:BoundField HeaderText="Total" DataField="PrecioTotal" />
            <asp:TemplateField>
                <ItemTemplate>
                    <asp:Button ID="btnEliminar" runat="server" CssClass="btn-close" OnClick="btnEliminar_Click"/>
                </ItemTemplate>
            </asp:TemplateField>
        </Columns>

    </asp:GridView>
    <asp:Label runat="server">Total: <%: Session["importeTotal"] %></asp:Label>


</asp:Content>
