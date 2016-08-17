<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CRUDProdutoInsert.aspx.cs" Inherits="WebApplication1.CRUDProdutoInsert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
        Descrição:
        <br />
        <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox><asp:RequiredFieldValidator ID="validateDescricao" runat="server" ErrorMessage="Preencha este campo" ControlToValidate="txtDescricao"></asp:RequiredFieldValidator>
        <br />
        Preço:
        <br />
        <asp:TextBox ID="txtPreco" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validatePreco" runat="server" ErrorMessage="Preencha este campo" ControlToValidate="txtPreco"></asp:RequiredFieldValidator>
            <asp:RegularExpressionValidator ID="regexPreco" runat="server" ErrorMessage="Formato incorreto" ControlToValidate="txtPreco" ValidationExpression="^(?!\.$)\d{0,10}(?:\.(?:\d\d?)?)?$"></asp:RegularExpressionValidator>
            <br />
        Endereço da Imagem:        
        <br />
        <asp:TextBox ID="txtEnderecoImg" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validateImagem" runat="server" ErrorMessage="Preencha este campo" ControlToValidate="txtEnderecoImg"></asp:RequiredFieldValidator>
            <br />
        Tamanho:
        <br />
        <asp:TextBox ID="txtTamanho" runat="server"></asp:TextBox>
        <asp:RequiredFieldValidator ID="validateTamanho" runat="server" ErrorMessage="Preencha este campo" ControlToValidate="txtTamanho"></asp:RequiredFieldValidator>
        <br />
        <asp:Button ID="btnCadastrarProduto" runat="server" Text="Cadastrar" OnClick="btnCadastrarProduto_Click" />    
    </div>
    </form>
</body>
</html>
