<%@ Page Title="Detalhe do Pedido | Bottons do Jorge" Language="C#" MasterPageFile="~/mainMaster.Master" AutoEventWireup="true" CodeBehind="detalhar.aspx.cs" Inherits="redux.usuario.detalhar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div class="container">
    	<section>
    		<div class="row">
    			<div class="col-xs-12">
    				<h3>Detalhes do Pedido</h3>
    				<table class="table table-bordered">
                        <tr>
                        	<th>Nº do pedido</th>
                        	<td><%= encomenda.id %></td>
                        </tr>
                        <tr>
                        	<th>Local de entrega</th>
                        	<td><%= encomenda.localEntrega.enderecoFormatado %></td>
                        </tr>
                        <tr>
                        	<th>Status</th>
                        	<td><%= encomenda.Status.descricao %></td>
                        </tr>
                        <tr>
                        	<th>Data de entrega</th>
                        	<td><%= encomenda.dataEntrega %></td>
                        </tr>
                        <tr>
                        	<th>Emissão do Pedido</th>
                        	<td></td>
                        </tr>
                        <tr>
                        	<th>Sub Total</th>
                        	<td><%= String.Format("{0:C2}", encomenda.subTotal) %></td>
                        </tr>
                        <tr>
                        	<th>Preço total</th>
                        	<td><%= String.Format("{0:C2}", encomenda.precoTotal) %></td>
                        </tr>
                        <tr>
                        	<th>Desconto</th>
                        	<td><%= String.Format("{0:C2}", encomenda.desconto) %></td>
                        </tr>
                        <tr>
                        	<th>Itens</th>
                        	<td>
                                <table class="table table-striped">
                                    <% foreach (var item in encomenda.itens)
                                       { %>
                                    <tr>
                                    	<td><%= item.quantidade %></td>
                                    	<td><%= String.Format("{0}, {1}", item.item.produto.descricao, item.item.tamanho.descricao) %></td>
                                    	<td><%= String.Format("{0:C2}", item.subTotal) %></td>
                                    </tr>
                                           
                                    <% }
                                         %>
                                </table>
                        	</td>
                        </tr>
    				</table>
                    <a href="<%= redux.MetodosExtensao.GetLink("usuario/dashboard#encomendas") %>" class="btn btn-warning">Voltar às encomendas</a>
    			</div>
    		</div>
    	</section>
    </div>
</asp:Content>
