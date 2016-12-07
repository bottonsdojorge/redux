<%@ Page Title="Encomendar | Bottons do Jorge" Language="C#" MasterPageFile="~/mainMaster.Master" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="redux.usuario.checkout" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div class="container">
        <div class="row">
        	<div class="col-xs-12">
                <h3>Estamos quase lá.</h3>
                <h4>Escolha onde você deseja receber sua encomenda.</h4>
                <select name="leid">
                    <% foreach (redux.Modelo.localEntrega localEntrega in locaisEntrega) { %>
                    <option value="<%= localEntrega.id %>"><%= String.Format("{4} - {0}, número {1}, {2}, {3}", localEntrega.rua, localEntrega.numero, localEntrega.complemento, localEntrega.bairro, localEntrega.descricao) %></option><% } %>
                </select>
                <asp:Button Text="Confirmar" CssClass="btn btn-info" runat="server" OnClick="RegistrarEncomenda" />
        	</div>
        </div>
    </div>
</asp:Content>
