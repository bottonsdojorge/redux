<%@ Page Title="Admin Dashboard | Bottons do Jorge" Language="C#" MasterPageFile="~/mainMaster.Master" AutoEventWireup="true" CodeBehind="dashboard.aspx.cs" Inherits="redux.admin.dashboard" %>
<asp:Content ID="Content1" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <h3>Admin Dashboard - logado como <%= User.Identity.Name %></h3>
                <div class="list-group">
                    <a href="<%= redux.MetodosExtensao.GetLink("admin/crud/produto-insert") %>" class="list-group-item">Inserir produto</a>
                    <a href="<%= redux.MetodosExtensao.GetLink("admin/crud/produto-select") %>" class="list-group-item">Visualizar produtos</a>
                    <a href="<%= redux.MetodosExtensao.GetLink("admin/crud/usuario-select") %>" class="list-group-item">Visualizar usuários</a>
                </div>
                <ul class="nav nav-tabs">
                    <li class="active"><a data-toggle="tab" href="#encomendas">Encomendas</a></li>
                    <li><a data-toggle="tab" href="#mensagens">Mensagens</a></li>
                </ul>
                <div class="tab-content">
                    <div class="tab-pane active" id="encomendas">
                        <asp:GridView ID="grdEncomendas" CssClass="table table-bordered table-striped" runat="server" AllowPaging="True" AutoGenerateColumns="False" DataSourceID="dsrcEncomendas">
                            <Columns>
                            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" />
                                <asp:TemplateField HeaderText="Usuário">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Usuario.id") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("Usuario.nome") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Preço" SortExpression="precoTotal">
                                    <EditItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Eval("precoTotal") %>'></asp:Label>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Label2" runat="server" Text='<%# Bind("precoTotal", "{0:C2}") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Data de Entrega" SortExpression="dataEntrega">
                                    <EditItemTemplate>
                                        <asp:TextBox ID="selectData" TextMode="Date" runat="server" Text='<%# Bind("dataEntrega") %>'></asp:TextBox>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="Data" runat="server" Text='<%# Bind("dataEntrega") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Local de Entrega">
                                    <EditItemTemplate>
                                        <asp:DropDownList runat="server" ID="selectLocal" DataSourceID="dsrcLocalEntrega" DataTextField="descricao" DataValueField="id"></asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="localEntrega" runat="server" Text='<%# Bind("localEntrega.descricao") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <EditItemTemplate>
                                        <asp:DropDownList ID="selectStatus" runat="server" DataSourceID="dsrcStatus" DataTextField="descricao" DataValueField="id"></asp:DropDownList>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:Label ID="status" runat="server" Text='<%# Bind("Status.descricao") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField ShowHeader="False">
                                    <EditItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="True" CommandName="Update" Text="Update"></asp:LinkButton>
                                        &nbsp;<asp:LinkButton ID="LinkButton2" runat="server" CausesValidation="False" CommandName="Cancel" Text="Cancel"></asp:LinkButton>
                                    </EditItemTemplate>
                                    <ItemTemplate>
                                        <asp:LinkButton ID="LinkButton1" runat="server" CausesValidation="False" CommandName="Edit" Text="Edit"></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                        </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="dsrcStatus" runat="server" SelectMethod="SelectAll" TypeName="redux.DAL.DALStatus"></asp:ObjectDataSource>
                        <asp:ObjectDataSource ID="dsrcLocalEntrega" runat="server" SelectMethod="SelectAll" TypeName="redux.DAL.DALLocalEntrega"></asp:ObjectDataSource>

                        <asp:ObjectDataSource  ID="dsrcEncomendas" runat="server" DataObjectTypeName="redux.Modelo.Encomenda" DeleteMethod="Delete" InsertMethod="Insert" SelectMethod="SelectAll" TypeName="redux.DAL.DALEncomenda" UpdateMethod="UpdateWithParam">
                            <UpdateParameters>
                                <asp:Parameter Name="encomenda" Type="Object" />
                                <asp:Parameter Name="status" Type="Int32" />
                                <asp:Parameter Name="localEntrega" Type="Int32" />
                            </UpdateParameters>
                        </asp:ObjectDataSource>
                    </div>
                    <div class="tab-pane" id="mensagens">
                        <asp:GridView ID="grvMensagens" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered table-striped" DataSourceID="srcMensagens" OnRowCommand="grvMensagens_RowCommand" DataKeyNames="id">
                            <Columns>
                                <asp:BoundField DataField="idEncomenda" HeaderText="Nº Encomenda" SortExpression="idEncomenda" />
                                <asp:BoundField DataField="data" HeaderText="Data" SortExpression="data" />
                                <asp:TemplateField HeaderText="Mensagem" SortExpression="corpo">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# (Eval("corpo").ToString().Length > 80) ? Eval("corpo").ToString().Substring(0,80) : Eval("corpo").ToString() %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Nome do cliente">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# Eval("remetente.nome") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# (Convert.ToBoolean(Eval("visualizada").ToString())) ? "Visualizada" : "Enviada" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Enviada/Recebida">
                                    <ItemTemplate>
                                        <asp:Label runat="server" Text='<%# (Eval("remetente.id").ToString() == ConfigurationManager.AppSettings["idAdmin"]) ? "<i class=\"fa fa-upload\" aria-hidden=\"true\"></i>" : "<i class=\"fa fa-download\" aria-hidden=\"true\"></i>"%>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ações">
                                    <ItemTemplate>
                                        <asp:LinkButton CommandName="responder" CommandArgument='<%# Container.DataItemIndex %>' CssClass="btn btn-warning" runat="server" Visible='<%# (Eval("remetente.id").ToString() != ConfigurationManager.AppSettings["idAdmin"]) ? true : false %>' Text='<i class="fa fa-reply" aria-hidden="true"></i>'></asp:LinkButton>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <asp:ObjectDataSource ID="srcMensagens" runat="server" DataObjectTypeName="redux.Modelo.Mensagem" SelectMethod="SelectAll" TypeName="redux.DAL.DALMensagem" UpdateMethod="Update">
                        </asp:ObjectDataSource>
                    </div>
                </div>
                
            </div>
        </div>
    </div>
</asp:Content>
