<%@ Page Title="Personalize seu Produto | Bottons do Jorge" Language="C#" MasterPageFile="~/mainMaster.Master" AutoEventWireup="true" CodeBehind="personalizar.aspx.cs" Inherits="WebApplication1.usuario.personalizar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div class="container">
        <h1>Personalize seu Produto</h1>
        <h3>Basta selecionar a imagem.</h3>

        <input id="fileProduto" type="file" name="imagem" onchange="gerarPreview()" runat="server"/>
        
        <p>Preview:</p>
        <img src="" id="imgPreview" class="img-responsive img-circle" style="width: 300px; height: 300px;"/>
        <label>Dê um nome: <input type="text" name="nomeupload" id="nomeupload" runat="server"></label>
        <input type="number" name="q" value="1" />
        <%
            WebApplication1.DAL.DALTamanho dalTamanho = new WebApplication1.DAL.DALTamanho();
            List<WebApplication1.Modelo.Tamanho> tamanhos;

            tamanhos = dalTamanho.SelectAll();

            foreach (var tamanho in tamanhos)
            { %>
              <label><input type="radio" name="tid" value="<%= tamanho.id %>"><%= tamanho.descricao %></label>  
            <%}
            
        %>
        <asp:Button ID="btnupload" CssClass="btn btn-default" runat="server" Text="Adicionar ao Carrinho" OnClick="btnupload_Click" />
    </div>

    <script>
        function gerarPreview(){
            var preview = document.getElementById("imgPreview");
            var arquivo = document.getElementById("<%= fileProduto.ClientID %>").files[0];
            var reader = new FileReader();

            reader.onloadend = function () {
                preview.src = reader.result;
            }

            if (arquivo) {
                reader.readAsDataURL(arquivo);
            } else {
                preview.src = "";
            }
        }
    </script>
</asp:Content>
