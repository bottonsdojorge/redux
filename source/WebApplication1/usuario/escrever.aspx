<%@ Page Title="Escrever mensagem | Bottons do Jorge" Language="C#" MasterPageFile="~/mainMaster.Master" AutoEventWireup="true" CodeBehind="escrever.aspx.cs" Inherits="redux.usuario.escrever" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div class="container">
    	<div class="row">
    		<div class="col-xs-12">
    			<h3>Escreva sua mensagem. <small>Responderemos em, no máximo, 48 horas.</small></h3>
                 <div class="form">
                     <p>Mensagem referente à encomenda de número <%= eid %></p>
                     <div class="form-group">
                         <label for="textoMensagem">Escreva sua mensagem:</label>
                         <textarea class="form-control" rows="10" id="corpoMensagem" name="corpoMensagem" required runat="server"></textarea>
                         <asp:RequiredFieldValidator ID="validateCorpo" runat="server" ControlToValidate="corpoMensagem" ErrorMessage="Preencha o corpo da sua mensagem"></asp:RequiredFieldValidator>
                     </div>
                     <asp:Button ID="submitMensagem" runat="server" CssClass="btn btn-warning pull-right" Text="Enviar" OnClick="submitMensagem_Click" />
                 </div>
    		</div>
    	</div>
    </div>
</asp:Content>
