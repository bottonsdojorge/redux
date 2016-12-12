<%@ Page Title="Dashboard | Bottons do Jorge" Language="C#" MasterPageFile="~/mainMaster.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="redux.usuario.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div class="container">
        <div class="row">
        	<div class="col-xs-12">
        		<h1>Dashboard do <asp:LoginName runat="server" /></h1>
                <ul class="nav nav-tabs">
                    <li class="active"><a data-toggle="tab" href="#encomendas">Encomendas</a></li>
                    <li><a data-toggle="tab" href="#mensagens">Mensagens</a></li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="encomendas">
                        <div class="table-responsive">
                            <asp:GridView ID="grvEncomendas" runat="server" AutoGenerateColumns="False" DataSourceID="srcEncomendas" CssClass="table table-bordered table-striped" OnRowCommand="grvEncomendas_RowCommand">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="Pedido" SortExpression="id" />
                                    <asp:BoundField DataField="precoTotal" HeaderText="Preço" SortExpression="precoTotal" DataFormatString="{0:C2}" />
                                    <asp:BoundField DataField="localEntrega.enderecoFormatado" HeaderText="Local de entrega" />
                                    <asp:BoundField DataField="dataEntrega" HeaderText="Data de entrega" SortExpression="dataEntrega" />
                                    <asp:BoundField DataField="Status.descricao" HeaderText="Status" SortExpression="Status" />
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton CommandName="detalhar" CommandArgument='<%# Eval("id") %>' ID="Button1" CssClass="btn btn-warning" text="<i class='fa fa-search' aria-hidden='true'></i>" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ShowHeader="False">
                                        <ItemTemplate>
                                            <asp:LinkButton CommandName="mensagem" CommandArgument='<%# Eval("id") %>' CssClass="btn btn-info" Text="<i class='fa fa-share-square-o' aria-hidden='true'></i>" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:ObjectDataSource ID="srcEncomendas" runat="server" SelectMethod="SelectFromUsuario" TypeName="redux.DAL.DALEncomenda" OnSelecting="srcsDashboard_Selecting">
                                <SelectParameters>
                                    <asp:Parameter Name="idUsuario" Type="Int32" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
                        </div>
                    </div>
                    <div class="tab-pane" id="mensagens">
                        <asp:GridView ID="grvMensagens" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" DataSourceID="srcMensagens" OnRowCommand="grvMensagens_RowCommand">
                            <Columns>
                                <asp:BoundField DataField="idEncomenda" HeaderText="Nº Encomenda" SortExpression="idEncomenda" />
                                <asp:BoundField DataField="data" HeaderText="Data" SortExpression="data" />
                                <asp:TemplateField HeaderText="Mensagem" SortExpression="corpo">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# (Eval("corpo").ToString().Length > 80) ? Eval("corpo").ToString().Substring(0,80) : Eval("corpo").ToString() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# (Convert.ToBoolean(Eval("visualizada").ToString())) ? "Visualizada" : "Enviada" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Enviada/Recebida">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# (Eval("remetente.id").ToString() == ConfigurationManager.AppSettings["idAdmin"]) ? "<i class=\"fa fa-download\" aria-hidden=\"true\"></i>" : "<i class=\"fa fa-upload\" aria-hidden=\"true\"></i>"%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ações">
                                    <ItemTemplate>
                                        <asp:LinkButton Text='<i class="fa fa-reply" aria-hidden="true"></i>' CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning" Visible='<%# (Eval("remetente.id").ToString() == ConfigurationManager.AppSettings["idAdmin"]) ? true : false %>' CommandName="responder" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="srcMensagens" runat="server" DataObjectTypeName="redux.Modelo.Mensagem" OnSelecting="srcsDashboard_Selecting" SelectMethod="SelectFromUsuario" TypeName="redux.DAL.DALMensagem" UpdateMethod="Update">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="0" Name="idUsuario" Type="Int32" />
                            </SelectParameters>
                        </asp:ObjectDataSource>
                    </div>
                </div>
                
        	</div>
        </div>
    </div>
</asp:Content>
