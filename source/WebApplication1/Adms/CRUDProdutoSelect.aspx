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
        <asp:GridView ID="grvProdutos" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" AllowPaging="True" AllowSorting="True">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="Código" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="descricao" HeaderText="Produto" SortExpression="descricao" />
                <asp:BoundField DataField="preco" DataFormatString="{0:C2}" HeaderText="Preço" SortExpression="preco" />
                <asp:BoundField DataField="imagem" HeaderText="Endereço da imagem" SortExpression="imagem" />
                <asp:BoundField DataField="tamanho" HeaderText="Tamanho" SortExpression="tamanho" />
                <asp:CommandField CancelText="Cancelar" DeleteText="Deletar" EditText="Editar" InsertText="Inserir" ShowDeleteButton="True" ShowEditButton="True" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:BottonsDoJorgeConnectionString %>" SelectCommand="SELECT * FROM [Produto]" DeleteCommand="DELETE FROM Produto WHERE id = @id" UpdateCommand="UPDATE Produto SET descricao = @descricao, preco = @preco, imagem = @imagem, tamanho = @tamanho WHERE id = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="descricao" />
                <asp:Parameter Name="preco" Type="Double" />
                <asp:Parameter Name="imagem" />
                <asp:Parameter Name="tamanho" />
                <asp:Parameter Name="id" />
            </UpdateParameters>
        </asp:SqlDataSource>

    </div>
    </form>
</body>
</html>
