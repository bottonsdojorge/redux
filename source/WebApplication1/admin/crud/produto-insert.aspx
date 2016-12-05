<%@ Page Title="Visualização de Produtos | Bottons do Jorge" Language="C#" MasterPageFile="~/mainMaster.Master" AutoEventWireup="true" CodeBehind="produto-insert.aspx.cs" Inherits="WebApplication1.admin.crud.produto_insert2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <h3>Descrição</h3>
                <asp:TextBox ID="txtDescricao" runat="server"></asp:TextBox>
                <asp:RequiredFieldValidator ID="validateDescricao" runat="server" ErrorMessage="Preencha este campo" ControlToValidate="txtDescricao"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator Display = "Dynamic" ControlToValidate = "txtDescricao" ID="validateDescricaoLength" ValidationExpression = "^[\s\S]{2,20}$" runat="server" ErrorMessage="Máximo de 20 chars, minimo de 2"></asp:RegularExpressionValidator>
                <h3>A imagem:</h3>
                <asp:FileUpload ID="fileProduto" runat="server" />
                <h3>Tamanhos:</h3>
                <%
                    WebApplication1.DAL.DALTamanho dalTamanho = new WebApplication1.DAL.DALTamanho();
                    List<WebApplication1.Modelo.Tamanho> tamanhos;

                    tamanhos = dalTamanho.SelectAll();

                    foreach (var tamanho in tamanhos)
                    { %>
                <label>
                    <input type="checkbox" name="tid" value="<%= tamanho.id %>"><%= tamanho.descricao %></label>
                <%}
            
                %>
                <h3>Marcadores:</h3>
                <%
                    WebApplication1.DAL.DALMarcador dalMarcador = new WebApplication1.DAL.DALMarcador();
                    List<WebApplication1.Modelo.Marcador> marcadores;

                    marcadores = dalMarcador.SelectAll();

                    foreach (var marcador in marcadores)
                    { %>
                <label>
                    <input type="checkbox" name="mid" value="<%= marcador.id %>"><%= marcador.descricao %></label>
                <%}
            
                %>
                <asp:Button ID="btnCadastrarProduto" runat="server" CssClass="btn btn-info" Text="Cadastrar" OnClick="btnCadastrarProduto_Click" />
            </div>
        </div>
    </div>
</asp:Content>
