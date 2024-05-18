<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="TPWeb_equipo_7.Carrito1" enableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Carrito</h1>
    <asp:GridView ID="dgvArticulos" CssClass="table gridview-style" AutoGenerateColumns="false" runat="server" OnSelectedIndexChanged="dgvArticulos_SelectedIndexChanged" DataKeyNames="Id">
        <Columns>
            <asp:BoundField HeaderText="Articulo" DataField="Nombre" />
            <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
            <asp:BoundField HeaderText="Precio" DataField="PrecioUnitario" />
            <asp:TemplateField HeaderText="Cantidad">
                <ItemTemplate>
                    <div style="display: flex; align-items: center;">
                        <asp:TextBox ID="txtCantidad" runat="server" Text='<%# Eval("Cantidad") %>' CssClass="txtCantidad" ReadOnly="true" Style="width: 50px; text-align: center;" />
                        <asp:Button ID="btnUp" runat="server" Text="▲" CommandName="Increase" CommandArgument='<%# Eval("Id") %>' CssClass="btnUpDown" OnClick="BtnUpDown_Click" />
                        <asp:Button ID="btnDown" runat="server" Text="▼" CommandName="Decrease" CommandArgument='<%# Eval("Id") %>' CssClass="btnUpDown" OnClick="BtnUpDown_Click" />
                    </div>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField HeaderText="Total" DataField="PrecioTotal" />
            <asp:CommandField ShowSelectButton="true" ButtonType="Button" ControlStyle-CssClass="btn-close" SelectText=""/>


        </Columns>

    </asp:GridView>
    <asp:Label runat="server">Total: <%: Session["importeTotal"] %></asp:Label>


</asp:Content>


