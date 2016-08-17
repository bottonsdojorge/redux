<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Logado como <asp:LoginName ID="lblUsername" runat="server" />
        <br />
        <asp:LoginStatus ID="lblLoginstatus" runat="server" />
        <br />
        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Adms/CRUDUsuarioSelect.aspx">Vizualização de Usuario</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Adms/CRUDProdutoInsert.aspx">Cadastro de Produto</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Adms/CRUDProdutoSelect.aspx">Vizualização de Produto</asp:HyperLink>
    </div>
    </form>
</body>
</html>
