<%@ Page Title="Cadastro | Bottons do Jorge" Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="redux.CRUDUsuarioInsert" MasterPageFile="~/mainMaster.Master" Theme="main" %>
﻿

<asp:Content ID="contentHead" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">
</asp:Content>

<asp:Content ID="contentBody" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-5" style="border-right: 3px solid; border-color: #808080;">
                <asp:CreateUserWizard  ID="wiz_criarUsuario" ContinueDestinationPageUrl="~/index.aspx" runat="server" OnCreatedUser="CreateUserWizard1_CreatedUser" AnswerLabelText="Resposta secreta:" AnswerRequiredErrorMessage="A pergunta secreta é necessária." CancelButtonText="Cancelar" CompleteSuccessText="Sua conta foi criada com sucesso." ConfirmPasswordCompareErrorMessage="As senhas devem coincidir." ConfirmPasswordLabelText="Confirme a senha:" ConfirmPasswordRequiredErrorMessage="É necessário confirmar a senha." CreateUserButtonText="Cadastrar" DuplicateEmailErrorMessage="O e-mail inserido já está sendo usado. Por favor, escolha outro." DuplicateUserNameErrorMessage="Nome de usuário já cadastrado." EmailRegularExpressionErrorMessage="Por favor, digite um e-mail válido." EmailRequiredErrorMessage="Por favor, digite um e-mail válido." Font-Names="Verdana" Font-Size="0.8em" InvalidAnswerErrorMessage="Por favor, digite uma resposta diferente." InvalidEmailErrorMessage="Por favor, digite um e-mail válido." InvalidQuestionErrorMessage="Por favor, digite uma pergunta secreta diferente." PasswordLabelText="Senha" PasswordRegularExpressionErrorMessage="A senha contém caracteres inválidos." PasswordRequiredErrorMessage="Digite uma senha." QuestionLabelText="Pergunta secreta:" UnknownErrorMessage="Ocorreu um erro. Por favor, tente novamente." UserNameLabelText="Usuário" UserNameRequiredErrorMessage="Digite um usuário.">
                    <CreateUserButtonStyle CssClass="btn btn-warning" />
                    <WizardSteps>
                        <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                            <ContentTemplate>
                                <h2>Cadastre-se</h2>
                                <div class="form-group">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuário</asp:Label>
                                    <asp:TextBox ID="UserName" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Digite um usuário." ToolTip="Digite um usuário." ValidationGroup="wiz_criarUsuario">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha</asp:Label>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Digite uma senha." ToolTip="Digite uma senha." ValidationGroup="wiz_criarUsuario">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirme a senha:</asp:Label>
                                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword" ErrorMessage="É necessário confirmar a senha." ToolTip="É necessário confirmar a senha." ValidationGroup="wiz_criarUsuario">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                    <asp:TextBox ID="Email" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ErrorMessage="Por favor, digite um e-mail válido." ToolTip="Por favor, digite um e-mail válido." ValidationGroup="wiz_criarUsuario">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Pergunta secreta:</asp:Label>
                                    <asp:TextBox ID="Question" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question" ErrorMessage="Security question is required." ToolTip="Security question is required." ValidationGroup="wiz_criarUsuario">*</asp:RequiredFieldValidator>
                                </div>
                                <div class="form-group">
                                    <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Resposta secreta:</asp:Label>
                                    <asp:TextBox ID="Answer" runat="server" CssClass="form-control"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer" ErrorMessage="A pergunta secreta é necessária." ToolTip="A pergunta secreta é necessária." ValidationGroup="wiz_criarUsuario">*</asp:RequiredFieldValidator>
                                </div>
                                <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                </div>
                            </ContentTemplate>
                        </asp:CreateUserWizardStep>
                        <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                        </asp:CompleteWizardStep>
                    </WizardSteps>
                </asp:CreateUserWizard>
            </div>
            <div class="col-md-7">
                <h1>Inscreva-se para participar do melhor comércio de botton do Brasil</h1>
                <asp:Image ID="Image1" runat="server" imageUrl="\App_Themes\main\imagem-cadastro.png" Width="600px"/>
            </div>
    </div>

</asp:Content>
