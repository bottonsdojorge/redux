<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="produto-insert.aspx.cs" Inherits="WebApplication1.CRUDProdutoInsert" %>

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
        A imagem:        
        <br />
        <asp:FileUpload ID="fileProduto" runat="server" />
        <asp:RequiredFieldValidator ID="validateImagem" runat="server" ErrorMessage="Preencha este campo" ControlToValidate="fileProduto"></asp:RequiredFieldValidator>
            <br />
        Tamanhos:
        <br />
        <%
            WebApplication1.DAL.DALTamanho dalTamanho = new WebApplication1.DAL.DALTamanho();
            List<WebApplication1.Modelo.Tamanho> tamanhos;

            tamanhos = dalTamanho.SelectAll();

            foreach (var tamanho in tamanhos)
            { %>
              <label><input type="checkbox" name="tid" value="<%= tamanho.id %>"><%= tamanho.descricao %></label>  
            <%}
            
        %>
        <br />
        <asp:Button ID="btnCadastrarProduto" runat="server" Text="Cadastrar" OnClick="btnCadastrarProduto_Click" />    
    </div>
    </form>
</body>
</html>
