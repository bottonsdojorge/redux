<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRUDProdutoSelect.aspx.cs" Inherits="WebApplication1.CRUDProdutoSelect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    Listagem de produtos<hr />
        <asp:GridView ID="grvProdutos" runat="server" AutoGenerateColumns="False" DataSourceID="dataSourceProduto" AllowPaging="True" AllowSorting="True">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                <asp:BoundField DataField="descricao" HeaderText="Descrição" SortExpression="descricao" />
                <asp:BoundField DataField="imagem" HeaderText="URL Imagem" SortExpression="imagem" />
                <asp:ImageField DataImageUrlField="imagem" HeaderText="Preview Imagem">
                    <ItemStyle CssClass="img-responsive" />
                </asp:ImageField>
            </Columns>
        </asp:GridView>

    </div>
        <asp:ObjectDataSource ID="dataSourceProduto" runat="server" DataObjectTypeName="WebApplication1.Modelo.Produto" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="SelectAll" TypeName="WebApplication1.DAL.DALProduto" UpdateMethod="Update"></asp:ObjectDataSource>
    </form>
</body>
</html>
