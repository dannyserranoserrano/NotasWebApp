<%@ Page Title="Editar Nota" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditarNota.aspx.cs" Inherits="NotasWebApp.EditarNota" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h1>Editar Nota</h1>
    <asp:Label ID="IdLabel" runat="server" Text="Id"></asp:Label>
    <asp:TextBox ID="IdTextBox" runat="server" ReadOnly="true"></asp:TextBox>
    <br />
    <asp:Label ID="TituloLabel" runat="server" Text="Título"></asp:Label>
    <asp:TextBox ID="TituloTextBox" runat="server"></asp:TextBox>
    <br />
    <asp:Label ID="ContenidoLabel" runat="server" Text="Contenido"></asp:Label>
    <asp:TextBox ID="ContenidoTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
    <br />
    <asp:Button ID="ActualizarButton" runat="server" Text="Actualizar" OnClick="ActualizarButton_Click" />
</asp:Content>
