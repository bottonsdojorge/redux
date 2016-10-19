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
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" />
                <asp:BoundField DataField="id" HeaderText="id" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="nome" HeaderText="nome" SortExpression="nome" />
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:pedroPcConnectionString %>" SelectCommand="SELECT id, nome FROM Usuario" DeleteCommand="DELETE FROM Usuario WHERE id = @id" UpdateCommand="UPDATE Usuario SET nome = @nome WHERE id = @id">
            <DeleteParameters>
                <asp:Parameter Name="id" />
            </DeleteParameters>
            <UpdateParameters>
                <asp:Parameter Name="nome" />
                <asp:Parameter Name="id" />
            </UpdateParameters>
        </asp:SqlDataSource>

    </div>
    </form>
</body>
</html>
