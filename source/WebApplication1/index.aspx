<%@ Page Title="Home | Bottons do Jorge" Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="redux.WebForm1" MasterPageFile="~/mainMaster.Master" Theme="main" %>

<asp:Content ID="contentHead" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">
</asp:Content>

<asp:Content ID="contentBody" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div id="myCarousel" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner" role="listbox">
            <div class="item active">
                <img src="/App_Themes/main/carrossel-got-descontos.png" class="img-responsive center-block" width="100%" alt="GameOfBottons">
            </div>

            <div class="item">
                <img src="/App_Themes/main/carrossel-8bit-personalizacao.png" class="img-responsive center-block" width="100%" alt="SelectYourBotton">
            </div>

            <div class="item">
                <img src="/App_Themes/main/carrossel-harry-potter.png" class="img-responsive center-block" width="100%" alt="Placeholder">
            </div>

        </div>

        <!-- Left and right controls -->
        <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
            <span class="fa fa-chevron-left fa-5x" aria-hidden="true" style="margin-top:175px"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
            <span class="fa fa-chevron-right fa-5x" aria-hidden="true" style="margin-top:175px"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>
    <h2 style="margin-left:50px; color:#e68100;">Bottons adicionados recentemente:</h2>
    <hr />
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
</asp:Content>
