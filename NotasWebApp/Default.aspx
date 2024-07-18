<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="NotasWebApp._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="jumbotron">
        <h1>Cuaderno de Notas</h1>
    </div>

    <div class="row">
        <div>
            <h1>Lista de Notas</h1>
            <asp:GridView ID="NotasGridView" runat="server" AutoGenerateColumns="False" DataKeyNames="Id" OnRowCommand="NotasGridView_RowCommand">
                <Columns>
                    <asp:BoundField DataField="Id" HeaderText="Id" />
                    <asp:BoundField DataField="Titulo" HeaderText="Título" />
                    <asp:BoundField DataField="Contenido" HeaderText="Contenido" />
                    <asp:BoundField DataField="FechaCreacion" HeaderText="Fecha de Creación" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:ButtonField ButtonType="Link" CommandName="Editar" Text="Editar" />
                    <asp:ButtonField ButtonType="Link" CommandName="Eliminar" Text="Eliminar" />
                </Columns>
            </asp:GridView>
        </div>
        <asp:Button ID="CrearNotaButton" runat="server" Text="Crear Nota" OnClick="CrearNotaButton_Click" />
    </div>
</asp:Content>
