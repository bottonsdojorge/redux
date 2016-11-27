<%@ Page Title="Encomendar | Bottons do Jorge" Language="C#" MasterPageFile="~/mainMaster.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="WebApplication1.usuario.checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div class="container">
        <div class="row">
        	<div class="col-xs-12">
                <h3>Escolha o local de entrega, zé ruela</h3>
                <select>
                    <% foreach (WebApplication1.Modelo.localEntrega localEntrega in locaisEntrega) { %>
                    <option value="<%= localEntrega.id %>"><%= String.Format("{4} - {0}, número {1}, {2}, {3}", localEntrega.rua, localEntrega.numero, localEntrega.complemento, localEntrega.bairro, localEntrega.descricao) %></option><% } %>
                </select>
        	</div>
        </div>
    </div>
</asp:Content>
