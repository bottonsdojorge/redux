<%@ Page Title="Login | Bottons do Jorge" MasterPageFile="~/mainMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="redux.Login" Theme="main" %>
<asp:Content ID="contentHead" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">
</asp:Content>

<asp:Content ID="contentBody" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-4"></div>
            <div class="col-md-2" style="border-right: 3px solid; border-color: #808080;">
                <asp:Login ID="frmLogin" runat="server">
                    <LayoutTemplate>
                        <h2>Login</h2>
                        <div class="form-group">
                            <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuário:</asp:Label>
                            <asp:TextBox ID="UserName" runat="server" CssClass="form-control" placeholder="Usuário"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="User Name is required." ToolTip="User Name is required." ValidationGroup="frmLogin">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="form-group">
                            <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Password:</asp:Label>
                            <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control" placeholder="Senha"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Password is required." ToolTip="Password is required." ValidationGroup="frmLogin">*</asp:RequiredFieldValidator>
                        </div>
                        <div class="form-check">
                            <label class="form-check-label">
                                <asp:CheckBox ID="RememberMe" runat="server" Text="Manter-me logado." CssClass="form-check-input" />
                            </label>
                        </div>
                        <asp:Literal ID="FailureText" runat="server" EnableViewState="False"></asp:Literal>
                        <asp:Button ID="LoginButton" CssClass="btn btn-primary" runat="server" CommandName="Login" Text="Log In" ValidationGroup="frmLogin" />
                    </LayoutTemplate>
                    <TitleTextStyle BackColor="#6B696B" Font-Bold="True" ForeColor="#FFFFFF" />
                </asp:Login>
            </div>
            <div class="col-md-2">
                <h2>Cadastro</h2>
                <p>
                    Não tem conta ainda? O que está esperando? cadatre-se agora e faça parte do melhor comércio de bottons de todo Brasil
                </p>
                <a href="<%= redux.MetodosExtensao.GetLink("public/Cadastro")%>" class="btn btn-primary">Cadastre-se</a>
            </div>
            <div class="col-md-4"></div>
        </div>
    </div>
</asp:Content>
