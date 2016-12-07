<%@ Page Title="Home | Bottons do Jorge" Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="redux.WebForm1" MasterPageFile="~/mainMaster.Master" Theme="main" %>

<asp:Content ID="contentHead" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">

</asp:Content>

<asp:Content ID="contentBody" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
	<table style="width:100%; height: 277px;">
		<tr>
			<td>
				Logado como 
				<asp:LoginName ID="lblUsername" runat="server" />
				<br />
				<asp:LoginStatus ID="LoginStatus1" runat="server" />
			</td>
			<td>
				<asp:HyperLink ID="HyperLink2"  runat="server" NavigateUrl="~/admin/crud/usuario-select.aspx">Visualização de Usuario</asp:HyperLink>
				<br />
				<asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="~/admin/crud/produto-insert.aspx">Cadastro de Produto</asp:HyperLink>
				<br />
				<asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="~/admin/crud/produto-select.aspx">Visualização de Produto</asp:HyperLink>
				<br />
				<asp:HyperLink ID="linkVitrine" runat="server" NavigateUrl="~/Vitrine.aspx">Vitrine</asp:HyperLink>
			</td>
		</tr>	
	</table>
</asp:Content>
