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
    </main>
</asp:Content>
