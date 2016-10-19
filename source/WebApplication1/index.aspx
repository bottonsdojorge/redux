<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="WebApplication1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 169px;
        }
        .auto-style3 {
            height: 59px;
            width: 169px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>

    </div>
            <table style="width:100%; height: 277px;">
        <tr>
            <td class="auto-style1">Logado como <asp:LoginName ID="lblUsername" runat="server" /><br />
                <asp:LoginStatus ID="LoginStatus1" runat="server" />
            </td>
            <td>        <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/Adms/CRUDUsuarioSelect.aspx">Vizualização de Usuario</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/Adms/CRUDProdutoInsert.aspx">Cadastro de Produto</asp:HyperLink>
        <br />
        <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/Adms/CRUDProdutoSelect.aspx">Vizualização de Produto</asp:HyperLink>
        <br />
         <asp:HyperLink ID="linkVitrine" runat="server" NavigateUrl="~/Vitrine.aspx">Vitrine</asp:HyperLink>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>

            <td class="auto-style3">
                <table style="width:552%; height: 21px;">
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td class="auto-style1">&nbsp;</td>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>

    </form>

</body>
</html>
