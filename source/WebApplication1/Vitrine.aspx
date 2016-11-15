﻿<%@ Page Title="Vitrine | Bottons do Jorge" MasterPageFile="~/mainMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="Vitrine.aspx.cs" Inherits="WebApplication1.Vitrine" Theme="main" %>
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
                        <% foreach (WebApplication1.Modelo.Marcador marcador in marcadores){ %>
                            <label class="checkbox-inline">
                                <input type="checkbox" name="marcadores" id="marcador<%= marcador.id %>" value="<%= marcador.id %>" <% if (Request.Form["marcadores"] != null && Request.Form["marcadores"].Contains(marcador.id.ToString())) { Response.Write("checked"); } %>> <%= marcador.descricao %>
                            </label>     
                        <% } %>
                        <button type="submit" class="btn btn-default"><i class="fa fa-search" aria-hidden="true"></i>
 Buscar</button>
                </div>
            <% foreach (WebApplication1.Modelo.Item item in itens){ %>
                <div class="col-xs-12 col-sm-4">
                    <img class="img-responsive" src="/Upload/imagem-produto/<% Response.Write(item.produto.imagem); %>" />
                    <p><% Response.Write(item.produto.descricao); %>, Tamanho <% Response.Write(item.tamanho.descricao); %></p>
                    <a href="/Cliente/carrinho.aspx?addpid=<% Response.Write(item.produto.id);%>addtid=<% Response.Write(item.tamanho.id); %>">Adicionar ao Carrinho</a>
                </div>       
            <% } %>
        </div>
    </div>
</asp:Content>
