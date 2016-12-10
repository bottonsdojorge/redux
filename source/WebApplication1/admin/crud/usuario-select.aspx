<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/mainMaster.Master" CodeBehind="usuario-select.aspx.cs" Inherits="redux.CRUDUsuarioSelect" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <h1>Lista de Usuários</h1>
                <hr />
                <asp:GridView ID="grvProdutos" runat="server" AutoGenerateColumns="False" DataSourceID="dataSourceUsuario" AllowPaging="True" CssClass="table table-striped table-bordered" CellSpacing="-1">
                    <Columns>
                        <asp:CommandField HeaderText="Ações" ShowDeleteButton="True" ShowEditButton="True" />
                        <asp:BoundField DataField="id" HeaderText="ID" SortExpression="id" ReadOnly="True" />
                        <asp:BoundField DataField="aspnet_id" HeaderText="ASP ID" SortExpression="aspnet_id" ReadOnly="True" />
                        <asp:BoundField DataField="nome" HeaderText="Nome de Usuário" SortExpression="nome" />
                    </Columns>
                </asp:GridView>
                <asp:ObjectDataSource ID="dataSourceUsuario" runat="server" DataObjectTypeName="redux.Modelo.Usuario" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="SelectAll" TypeName="redux.DAL.DALUsuario" UpdateMethod="Update"></asp:ObjectDataSource>
            </div>
        </div>
    </div>
</asp:Content>
