<%@ Page Title="Dashboard | Bottons do Jorge" Language="C#" MasterPageFile="~/mainMaster.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="redux.usuario.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div class="container">
        <div class="row">
        	<div class="col-xs-12">
        		<h1>Dashboard do <asp:LoginName runat="server" /></h1>
                <h3>Encomendas</h3>
                <table class="table table-bordered table-striped">
                    <thead>
                        <tr class="info">
                    	    <th>Pedido</th>
                    	    <th>Local de entrega</th>
                    	    <th>Status</th>
                    	    <th>Data de entrega</th>
                    	    <th></th>
                        </tr>
                    </thead>
                    <tbody>
                    <% foreach (var encomenda in encomendas)
                       { %>
                        <tr>
                        	<td><%= encomenda.id %></td>
                        	<td><%= encomenda.localEntrega.enderecoFormatado %></td>
                        	<td><%= encomenda.Status.descricao %></td>
                        	<td><%= encomenda.dataEntrega %></td>
                        	<td><a class="btn btn-warning">Detalhar</a></td>
                        </tr>                          
                    <% } %>
                    </tbody>
                </table>
        	</div>
        </div>
    </div>
</asp:Content>
