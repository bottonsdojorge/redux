<%@ Page Title="Login | Bottons do Jorge" MasterPageFile="~/mainMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="WebApplication1.Login" Theme="main" %>
<asp:Content ID="contentHead" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">

</asp:Content>

<asp:Content ID="contentBody" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
<div>
	<asp:Login ID="Login1" runat="server" BackColor="#F7F7DE" BorderColor="#CCCC99" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" Font-Size="10pt">
		<TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
	</asp:Login>
	<a href="/Public/Cadastro.aspx">Não tem uma conta? Cadastre-se</a>
</div>
</asp:Content>