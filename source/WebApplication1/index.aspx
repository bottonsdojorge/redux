<%@ Page Title="Home | Bottons do Jorge" Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="redux.WebForm1" MasterPageFile="~/mainMaster.Master" Theme="main" %>

<asp:Content ID="contentHead" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">
</asp:Content>

<asp:Content ID="contentBody" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div id="myCarousel" class="carousel slide" data-ride="carousel">
        <!-- Indicators -->
        <ol class="carousel-indicators">
            <li data-target="#myCarousel" data-slide-to="0" class="active"></li>
            <li data-target="#myCarousel" data-slide-to="1"></li>
            <li data-target="#myCarousel" data-slide-to="2"></li>
        </ol>

        <!-- Wrapper for slides -->
        <div class="carousel-inner" role="listbox">
            <div class="item active">
                <img src="/App_Themes/main/carrossel-got-descontos.png" class="img-responsive center-block" width="100%" alt="GameOfBottons">
            </div>

            <div class="item">
                <img src="/App_Themes/main/carrossel-8bit-personalizacao.png" class="img-responsive center-block" width="100%" alt="SelectYourBotton">
            </div>

            <div class="item">
                <img src="/App_Themes/main/carrossel-got-descontos.png" class="img-responsive center-block" width="100%" alt="Placeholder">
            </div>

        </div>

        <!-- Left and right controls -->
        <a class="left carousel-control" href="#myCarousel" role="button" data-slide="prev">
            <span class="fa fa-chevron-left fa-5x" aria-hidden="true" style="margin-top:175px"></span>
            <span class="sr-only">Previous</span>
        </a>
        <a class="right carousel-control" href="#myCarousel" role="button" data-slide="next">
            <span class="fa fa-chevron-right fa-5x" aria-hidden="true" style="margin-top:175px"></span>
            <span class="sr-only">Next</span>
        </a>
    </div>
    <table style="width: 100%; height: 277px;">
        <tr>
            <td>Logado como 
				<asp:LoginName ID="lblUsername" runat="server" />
                <br />
                <asp:LoginStatus ID="LoginStatus1" runat="server" />
            </td>
            <td>
                <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="~/admin/crud/usuario-select.aspx">Visualização de Usuario</asp:HyperLink>
                <br />
                <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/admin/crud/produto-insert.aspx">Cadastro de Produto</asp:HyperLink>
                <br />
                <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/admin/crud/produto-select.aspx">Visualização de Produto</asp:HyperLink>
                <br />
                <asp:HyperLink ID="linkVitrine" runat="server" NavigateUrl="~/public/Vitrine.aspx">Vitrine</asp:HyperLink>
            </td>
        </tr>
    </table>
</asp:Content>
