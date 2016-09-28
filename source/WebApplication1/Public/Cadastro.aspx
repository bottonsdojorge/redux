<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Cadastro.aspx.cs" Inherits="WebApplication1.CRUDUsuarioInsert" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:CreateUserWizard ID="wiz_criarUsuario" ContinueDestinationPageURL="~/index.aspx" runat="server" OnCreatedUser="CreateUserWizard1_CreatedUser" AnswerLabelText="Resposta secreta:" AnswerRequiredErrorMessage="A pergunta secreta é necessária." BackColor="#F7F6F3" BorderColor="#E6E2D8" BorderStyle="Solid" BorderWidth="1px" CancelButtonText="Cancelar" CompleteSuccessText="Sua conta foi criada com sucesso." ConfirmPasswordCompareErrorMessage="As senhas devem coincidir." ConfirmPasswordLabelText="Confirme a senha:" ConfirmPasswordRequiredErrorMessage="É necessário confirmar a senha." CreateUserButtonText="Cadastrar" DuplicateEmailErrorMessage="O e-mail inserido já está sendo usado. Por favor, escolha outro." DuplicateUserNameErrorMessage="Nome de usuário já cadastrado." EmailRegularExpressionErrorMessage="Por favor, digite um e-mail válido." EmailRequiredErrorMessage="Por favor, digite um e-mail válido." Font-Names="Verdana" Font-Size="0.8em" InvalidAnswerErrorMessage="Por favor, digite uma resposta diferente." InvalidEmailErrorMessage="Por favor, digite um e-mail válido." InvalidQuestionErrorMessage="Por favor, digite uma pergunta secreta diferente." PasswordLabelText="Senha" PasswordRegularExpressionErrorMessage="A senha contém caracteres inválidos." PasswordRequiredErrorMessage="Digite uma senha." QuestionLabelText="Pergunta secreta:" UnknownErrorMessage="Ocorreu um erro. Por favor, tente novamente." UserNameLabelText="Usuário" UserNameRequiredErrorMessage="Digite um usuário.">
            <ContinueButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
            <CreateUserButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
            <TitleTextStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
            <WizardSteps>
                <asp:CreateUserWizardStep ID="CreateUserWizardStep1" runat="server">
                    <ContentTemplate>
                        <table style="font-family:Verdana;font-size:100%;">
                            <tr>
                                <td align="center" colspan="2" style="color:White;background-color:#5D7B9D;font-weight:bold;">Cadastre sua conta</td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">Usuário</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ControlToValidate="UserName" ErrorMessage="Digite um usuário." ToolTip="Digite um usuário." ValidationGroup="wiz_criarUsuario">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">Senha</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Password" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ControlToValidate="Password" ErrorMessage="Digite uma senha." ToolTip="Digite uma senha." ValidationGroup="wiz_criarUsuario">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="ConfirmPasswordLabel" runat="server" AssociatedControlID="ConfirmPassword">Confirme a senha:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="ConfirmPassword" runat="server" TextMode="Password"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequired" runat="server" ControlToValidate="ConfirmPassword" ErrorMessage="É necessário confirmar a senha." ToolTip="É necessário confirmar a senha." ValidationGroup="wiz_criarUsuario">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="EmailLabel" runat="server" AssociatedControlID="Email">E-mail:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Email" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="EmailRequired" runat="server" ControlToValidate="Email" ErrorMessage="Por favor, digite um e-mail válido." ToolTip="Por favor, digite um e-mail válido." ValidationGroup="wiz_criarUsuario">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="QuestionLabel" runat="server" AssociatedControlID="Question">Pergunta secreta:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Question" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="QuestionRequired" runat="server" ControlToValidate="Question" ErrorMessage="Security question is required." ToolTip="Security question is required." ValidationGroup="wiz_criarUsuario">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="right">
                                    <asp:Label ID="AnswerLabel" runat="server" AssociatedControlID="Answer">Resposta secreta:</asp:Label>
                                </td>
                                <td>
                                    <asp:TextBox ID="Answer" runat="server"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="AnswerRequired" runat="server" ControlToValidate="Answer" ErrorMessage="A pergunta secreta é necessária." ToolTip="A pergunta secreta é necessária." ValidationGroup="wiz_criarUsuario">*</asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2">
                                    <asp:CompareValidator ID="PasswordCompare" runat="server" ControlToCompare="Password" ControlToValidate="ConfirmPassword" Display="Dynamic" ErrorMessage="As senhas devem coincidir." ValidationGroup="wiz_criarUsuario"></asp:CompareValidator>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" colspan="2" style="color:Red;">
                                    <asp:Literal ID="ErrorMessage" runat="server" EnableViewState="False"></asp:Literal>
                                </td>
                            </tr>
                        </table>
                    </ContentTemplate>
                </asp:CreateUserWizardStep>
                <asp:CompleteWizardStep ID="CompleteWizardStep1" runat="server">
                </asp:CompleteWizardStep>
            </WizardSteps>
            <HeaderStyle BackColor="#5D7B9D" BorderStyle="Solid" Font-Bold="True" Font-Size="0.9em" ForeColor="White" HorizontalAlign="Center" />
            <NavigationButtonStyle BackColor="#FFFBFF" BorderColor="#CCCCCC" BorderStyle="Solid" BorderWidth="1px" Font-Names="Verdana" ForeColor="#284775" />
            <SideBarButtonStyle BorderWidth="0px" Font-Names="Verdana" ForeColor="White" />
            <SideBarStyle BackColor="#5D7B9D" BorderWidth="0px" Font-Size="0.9em" VerticalAlign="Top" />
            <StepStyle BorderWidth="0px" />
        </asp:CreateUserWizard>
    </div>
    </form>
</body>
</html>
