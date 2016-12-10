<%@ Page Title="Dashboard | Bottons do Jorge" Language="C#" MasterPageFile="~/mainMaster.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="redux.usuario.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div class="container">
        <div class="row">
        	<div class="col-xs-12">
        		<h1>Dashboard do <asp:LoginName runat="server" /></h1>
                <ul class="nav nav-tabs">
                    <li class="active"><a data-toggle="tab" href="#encomendas">Encomendas</a></li>
                    <li><a data-toggle="tab" href="#mensagens">Mensagens</a></li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active table-responsive" id="encomendas">
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
                        	        <td>
                                        <a class="btn btn-warning" href="<%= redux.MetodosExtensao.GetLink("usuario/detalhar", new NameValueCollection { {"eid", encomenda.id.ToString()} }) %>"><i class="fa fa-search" aria-hidden="true"></i></a>
                                        <a class="btn btn-info"><i class="fa fa-paper-plane" aria-hidden="true"></i></a>
                        	        </td>
                                </tr>                          
                            <% } %>
                            </tbody>
                         </table>
                    </div>
                    <div class="tab-pane" id="mensagens">
                        Nada aqui
                    </div>
                </div>
                
        	</div>
        </div>
    </div>
</asp:Content>
