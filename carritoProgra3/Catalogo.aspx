<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCarrito.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="carritoProgra3.Catalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Catalogo de Artículos</h1>
    <asp:GridView runat="server" ID ="dgvCatalogo" OnSelectedIndexChanged="dgvCatalogo_SelectedIndexChanged" CssClass="table" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="Articulo" DataField="Nombre" />
             <asp:BoundField HeaderText="Precio" DataField="Precio" />
             <asp:BoundField HeaderText="Descripcion" DataField="Descripcion" />
             <asp:BoundField HeaderText="Marca" DataField="Marca" />
            <asp:CommandField ShowSelectButton="true"  SelectText="Comprar" HeaderText="Accion" />
        </Columns>

    </asp:GridView>

    <asp:Button Text="Agregar"  CssClass="btn btn-primary" ID="btnAgregar" OnClick="btnAgregar_Click1" runat="server" />
    
</asp:Content>
