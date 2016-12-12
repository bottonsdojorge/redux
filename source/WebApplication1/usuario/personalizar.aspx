<%@ Page Title="Personalize seu Produto | Bottons do Jorge" Language="C#" MasterPageFile="~/mainMaster.Master" AutoEventWireup="true" CodeBehind="personalizar.aspx.cs" Inherits="redux.usuario.personalizar" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12 center">
                <h1>Personalize seu Produto</h1>
                <h3>Basta selecionar a imagem.</h3>

                <input id="fileProduto" type="file" name="imagem" onchange="gerarPreview()" runat="server" />
                <div id="preview-wrapper" class="hidden">
                    <b>Preview:</b>
                    <img src="" id="imgPreview" class="img-responsive img-circle" style="width: 300px; height: 300px;" />
                </div>
                <div class="row">
                    <div class="col-md-6" style="padding: 0px;">
                        <br />
                        <div class="input-group">
                            <span class="input-group-addon" id="sizing-addon1">Dê um nome</span>
                            <input type="text" name="nomeupload" id="nomeupload" runat="server" class="form-control">
                        </div>
                        <br />
                        <div class="input-group">
                            <span class="input-group-addon" id="Span1">Quantidade</span>
                            <input type="number" name="q" value="1" class="form-control" />
                        </div>
                    </div>
                </div><br />
                <%
                    List<redux.Modelo.Tamanho> tamanhos;

                    tamanhos = redux.DAL.DALTamanho.SelectAll();

                    foreach (var tamanho in tamanhos)
                    { %>
                <label>
                    <input type="radio" name="tid" value="<%= tamanho.id %>"><%= tamanho.descricao %></label>
                <%}
            
                %>
                <br />
                <asp:Button ID="btnupload" CssClass="btn btn-default" runat="server" Text="Adicionar ao Carrinho" OnClick="btnupload_Click" />
            </div>
        </div>
    </div>

    <script>
        function gerarPreview() {
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
            document.getElementById("preview-wrapper").className = "show";
        }
    </script>
</asp:Content>
