<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRUDUsuarioSelect.aspx.cs" Inherits="WebApplication1.CRUDUsuarioSelect" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Lista de Usuários <hr />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="dataSourceUsuario">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                <asp:BoundField DataField="aspnet_id" HeaderText="aspnet_id" SortExpression="aspnet_id" />
                <asp:BoundField DataField="nome" HeaderText="nome" SortExpression="nome" />
            </Columns>
        </asp:GridView>
    </div>
        <asp:ObjectDataSource ID="dataSourceUsuario" runat="server" DataObjectTypeName="WebApplication1.Modelo.Usuario" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="SelectAll" TypeName="WebApplication1.DAL.DALUsuario" UpdateMethod="Update"></asp:ObjectDataSource>
    </form>
</body>
</html>
