<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="carrinho.aspx.cs" Inherits="WebApplication1.carrinho" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Carrinho - Bottons do Jorge</title>
    <link href="https://maxcdn.bootstrapcdn.com/bootstrap/3.3.7/css/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <h1>Seu carrinho</h1>
            </div>
            <!-- Items -->
            <div class="col-xs-12">
                <table class="table">
                    <thead>
                        <tr>
                            <th>Item</th>
                            <th>Quantidade</th>
                            <th>Preço</th>
                        </tr>
                    </thead>
                    <tbody>
                        <% foreach (WebApplication1.Modelo.itemCarrinho item in itens){ %>
                        <tr>
                            <th><% Response.Write(String.Format("{0}, {1}", item.item.produto.descricao, item.item.tamanho.descricao)); %></th>
                            <th><% Response.Write(item.quantidade); %></th>
                            <th><% Response.Write(String.Format("{0:C2}", item.quantidade * item.item.tamanho.precoUnitario)); %></th>
                        </tr>
                        <% } %>
                    </tbody>
                </table>
            </div>
            <!-- Fim Items -->
        </div>        
    </div>
    </form>
</body>
</html>
