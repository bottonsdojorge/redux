<%@ Page Title="Vitrine | Bottons do Jorge" MasterPageFile="~/mainMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="Vitrine.aspx.cs" Inherits="redux.Vitrine" Theme="main" %>
<asp:Content ID="contentHead" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">

</asp:Content>

<asp:Content ID="contentBody" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <h1>Vitrine Botões do Jorge</h1>
            </div>
        </div>
        <div class="row">
                <div class="col-xs-12">
                        <% foreach (redux.Modelo.Marcador marcador in marcadores){ %>
                            <label class="checkbox-inline">
                                <input type="checkbox" name="marcadores" id="marcador<%= marcador.id %>" value="<%= marcador.id %>" <% if ((string[])Session["marcadores"] != null && ((string[])Session["marcadores"]).Contains(marcador.id.ToString())) { Response.Write("checked"); } %>> <%= marcador.descricao %>
                            </label>     
                        <% } %>
                    <asp:Button ID="btnBusca" CssClass="btn btn-default" runat="server" PostBackUrl="~/public/Vitrine.aspx" Text="Buscar" UseSubmitBehavior="True" />
                </div>
        </div>
        <div class="row">
            <% foreach (redux.Modelo.Item item in itens){ %>
                <div class="col-xs-12 col-sm-4" style="text-align:center; padding:25px 0px 25px 0px;">
                    <img class="img-circle" src="/produtos/<% Response.Write(item.produto.imagem); %>" width="200px" style="margin:auto; margin-bottom:20px;"/>
                    <p><% Response.Write(item.produto.descricao); %>, Tamanho <% Response.Write(item.tamanho.descricao); %></p>
                    <p>Preço: R$<% Response.Write(item.tamanho.precoUnitario); %></p>
                    <a href="/usuario/cart.aspx?addq=1&addpid=<% Response.Write(item.produto.id);%>&addtid=<% Response.Write(item.tamanho.id); %>">Adicionar ao Carrinho <i class="fa fa-cart-plus" aria-hidden="true"></i></a>
                </div>       
            <% } %>
        </div>
        <div class="row">
            <div class="col-xs-12">
                <nav aria-label="Navegação">
                  <ul class="pagination">
                    <%= paginacao %>
                  </ul>
                </nav>
            </div>
        </div>
    </div>
</asp:Content>
