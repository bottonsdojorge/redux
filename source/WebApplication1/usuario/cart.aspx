<%@ Page Title="Carrinho | Bottons do Jorge" Language="C#" MasterPageFile="~/mainMaster.Master" AutoEventWireup="true" CodeBehind="cart.aspx.cs" Inherits="WebApplication1.usuario.cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <h1>Seu carrinho</h1>
            </div>
            <!-- Items -->
            <div class="col-xs-12">
                <table class="table table-bordered">
                    <thead>
                        <tr>
                            <th>Item</th>
                            <th>Quantidade</th>
                            <th>Preço</th>
                        </tr>
                    </thead>
                    <tbody>
                        <% foreach (WebApplication1.Modelo.itemCarrinho item in carro.itens){ %>
                        <tr>
                            <th>
                                <% Response.Write(String.Format("{0}, {1}", item.item.produto.descricao, item.item.tamanho.descricao)); %>
                                <a href="<%= String.Format("http://{0}/upload/imagem-produto/{1}", HttpContext.Current.Request.Url.Authority, item.item.produto.imagem) %>"><i class="fa fa-search" aria-hidden="true"></i></a>
                            </th>
                            <th>
                                <% Response.Write(item.quantidade); %> 
                                <a href="?addpid=<%= item.item.produto.id %>&addtid=<%= item.item.tamanho.id %>&addq=1"><i class="fa fa-plus-square" aria-hidden="true" style="color: green"></i></a> 
                                <a href="?addpid=<%= item.item.produto.id %>&addtid=<%= item.item.tamanho.id %>&addq=-1"><i class="fa fa-minus-square" style="color: orange" aria-hidden="true"></i></a>
                                <a href="?rpid=<%= item.item.produto.id %>&rtid=<%= item.item.tamanho.id %>"><i class="fa fa-times-circle" style="color: red" aria-hidden="true"></i></a>
                            </th>
                            <th><% Response.Write(String.Format("{0:C2}", item.quantidade * item.item.tamanho.precoUnitario)); %></th>
                        </tr>
                        <% } %>
                        <tr class="info">
                            <th colspan="2">Total dos produtos</th>
                            <th><%= String.Format("{0:C2}", carro.precoTotal) %></th>
                        </tr>
                    </tbody>
                </table>
                <% if (carro.itens.Count > 0) {  %>
                    <a href="<%= WebApplication1.MetodosExtensao.GetLink("usuario/checkout") %>" class="btn btn-warning">Fazer encomenda</a>
                    <asp:Button ID="btnLimparCarrinho" runat="server" Text="Limpar carrinho" CssClass="btn btn-default" UseSubmitBehavior="True" OnClick="btnLimparCarrinho_Click"/>
                <% } %>
                <a href="<%= WebApplication1.MetodosExtensao.GetLink("Vitrine") %>">Continuar comprando</a>
            </div>
            <!-- Fim Items -->
        </div>        
    </div>
</asp:Content>
