<%@ Page Title="Admin Dashboard | Bottons do Jorge" Language="C#" MasterPageFile="~/mainMaster.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="WebApplication1.admin.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <h3>Admin Dashboard - logado como <%= User.Identity.Name %></h3>
                <div class="list-group">
                    <a href="<%= WebApplication1.MetodosExtensao.GetLink("admin/crud/produto-insert") %>" class="list-group-item">Inserir produto</a>
                    <a href="<%= WebApplication1.MetodosExtensao.GetLink("admin/crud/produto-select") %>" class="list-group-item">Visualizar produtos</a>
                    <a href="<%= WebApplication1.MetodosExtensao.GetLink("admin/crud/usuario-select") %>" class="list-group-item">Visualizar usuários</a>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
