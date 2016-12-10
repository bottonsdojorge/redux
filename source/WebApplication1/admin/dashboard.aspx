<%@ Page Title="Admin Dashboard | Bottons do Jorge" Language="C#" MasterPageFile="~/mainMaster.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="redux.admin.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <h3>Admin Dashboard - logado como <%= User.Identity.Name %></h3>
                <div class="list-group">
                    <a href="<%= redux.MetodosExtensao.GetLink("admin/crud/produto-insert") %>" class="list-group-item">Inserir produto</a>
                    <a href="<%= redux.MetodosExtensao.GetLink("admin/crud/produto-select") %>" class="list-group-item">Visualizar produtos</a>
                    <a href="<%= redux.MetodosExtensao.GetLink("admin/crud/usuario-select") %>" class="list-group-item">Visualizar usuários</a>
                </div>
                <h3>Encomendas</h3>
                <asp:GridView ID="grdEncomendas" CssClass="table table-bordered" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="dsrcEncomendas">
                    <Columns>
                        <asp:CommandField ShowEditButton="True" />
                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" ReadOnly="True" />
                        <asp:BoundField DataField="precoTotal" HeaderText="$$" SortExpression="precoTotal" ReadOnly="True" />
                        <asp:BoundField DataField="dataEntrega" HeaderText="Data para entrega" SortExpression="dataEntrega" />
                        <asp:BoundField DataField="Usuario.nome" HeaderText="Usuario" SortExpression="Usuario" ReadOnly="True" />
                        <asp:TemplateField HeaderText="Status" SortExpression="Status">
                            <EditItemTemplate>
                                <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("Status.descricao") %>'></asp:TextBox>
                            </EditItemTemplate>
                            <ItemTemplate>
                                <asp:Label ID="Label1" runat="server" Text='<%# Bind("Status.descricao") %>'></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="dsrcEncomendas" runat="server" DataObjectTypeName="redux.Modelo.Encomenda" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="SelectAll" TypeName="redux.DAL.DALEncomenda" UpdateMethod="Update"></asp:ObjectDataSource>
            </div>
        </div>
    </div>
</asp:Content>
