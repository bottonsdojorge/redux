<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Vitrine.aspx.cs" Inherits="WebApplication1.Vitrine" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Vitrine - Bottons do Jorge</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <h1>Vitrine Botões do Jorge</h1>
            </div>
        </div>
        <div class="row">
            <% foreach (WebApplication1.Modelo.Item item in itens){ %>
                <div class="col-xs-12 col-sm-4">
                    <img class="img-responsive" src="/Upload/imagem-produto/<% Response.Write(item.produto.imagem); %>" />
                    <p><% Response.Write(item.produto.descricao); %>, Tamanho <% Response.Write(item.tamanho.descricao); %></p>
                    <a href="/Cliente/carrinho.aspx?addpid=<% Response.Write(item.produto.id);%>&&addtid=<% Response.Write(item.tamanho.id); %>">Adicionar ao Carrinho</a>
                </div>       
            <% } %>
        </div>
    </div>
    </form>
</body>
</html>
