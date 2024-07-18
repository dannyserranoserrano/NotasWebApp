<%@ Page Title="Crear Nota" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="CrearNota.aspx.cs" Inherits="NotasWebApp.CrearNota" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
       <h1>Crear Nota</h1>
            <asp:Label ID="TituloLabel" runat="server" Text="Título"></asp:Label>
            <asp:TextBox ID="TituloTextBox" runat="server"></asp:TextBox>
            <br />
            <asp:Label ID="ContenidoLabel" runat="server" Text="Contenido"></asp:Label>
            <asp:TextBox ID="ContenidoTextBox" runat="server" TextMode="MultiLine"></asp:TextBox>
            <br />
            <asp:Button ID="GuardarButton" runat="server" Text="Guardar" OnClick="GuardarButton_Click" />
   
</asp:Content>
