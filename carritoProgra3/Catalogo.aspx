<%@ Page Title="" Language="C#" MasterPageFile="~/MasterCarrito.Master" AutoEventWireup="true" CodeBehind="Catalogo.aspx.cs" Inherits="carritoProgra3.Catalogo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

<h1>Catalogo de Artículos</h1>
<div class="row row-cols-3 row-cols-md-4 g-4">
    <asp:ListView ID="dgvArticulos" runat="server" ItemPlaceholderID="itemPlaceholder">
        <LayoutTemplate>
            <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
        </LayoutTemplate>
        <ItemTemplate>
            <div class="col">
                <div class="card">
                    <asp:Image runat="server" ID="imgArticulo" CssClass="card-img-top" />
                    <img class="card-img-top" src='<%# Eval("iman.ImagenUrl") %>' alt="Imagen del artículo">
                    <div class="card-body">
                        <h5 class="card-title"><%# Eval("Nombre") %></h5>
                        <p class="card-text"><%# Eval("Descripcion") %></p>
                        <p class="card-text">Precio: $<%# Eval("Precio") %></p>
                        
                    </div>
                </div>
            </div>
        </ItemTemplate>
    </asp:ListView>
</div>


    
</asp:Content>
