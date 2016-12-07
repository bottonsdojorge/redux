<%@ Page Title="" Language="C#" MasterPageFile="~/mainMaster.Master" AutoEventWireup="true" CodeBehind="produto-select.aspx.cs" Inherits="WebApplication1.admin.crud.produto_select" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <h1>Listagem de produtos</h1>
                <asp:GridView ID="grvProdutos" runat="server" AutoGenerateColumns="False" DataSourceID="dataSourceProduto" AllowPaging="True" AllowSorting="True" CssClass="table table-striped table-bordered" CellSpacing="-1">
                <Columns>
                    <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" HeaderText="Ações" />
                    <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                    <asp:BoundField DataField="descricao" HeaderText="Descrição" SortExpression="descricao" />
                    <asp:HyperLinkField DataNavigateUrlFields="imagem" DataNavigateUrlFormatString="~/upload/imagem-produto/{0}" DataTextField="imagem" HeaderText="URL imagem" />
                </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
    <asp:ObjectDataSource ID="dataSourceProduto" runat="server" DataObjectTypeName="WebApplication1.Modelo.Produto" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="SelectAll" TypeName="WebApplication1.DAL.DALProduto" UpdateMethod="Update"></asp:ObjectDataSource>
</asp:Content>
