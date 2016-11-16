<%@ Page Title="Vitrine | Bottons do Jorge" MasterPageFile="~/mainMaster.Master" Language="C#" AutoEventWireup="true" CodeBehind="Vitrine.aspx.cs" Inherits="WebApplication1.Vitrine" Theme="main" %>
<asp:Content ID="contentHead" ContentPlaceHolderID="contentPlaceHolderHead" runat="server">

</asp:Content>

<asp:Content ID="contentBody" ContentPlaceHolderID="contentPlaceHolderCorpo" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <h1>Vitrine Botões do Jorge</h1>
            </div>
        </div>
        <div class="row">
                <div class="col-xs-12">
                        <% foreach (WebApplication1.Modelo.Marcador marcador in marcadores){ %>
                            <label class="checkbox-inline">
                                <input type="checkbox" name="marcadores" id="marcador<%= marcador.id %>" value="<%= marcador.id %>" <% if ((string[])Session["marcadores"] != null && ((string[])Session["marcadores"]).Contains(marcador.id.ToString())) { Response.Write("checked"); } %>> <%= marcador.descricao %>
                            </label>     
                        <% } %>
                    <asp:Button ID="btnBusca" CssClass="btn btn-default" runat="server" PostBackUrl="~/Vitrine.aspx" Text="Buscar" UseSubmitBehavior="True" />
                </div>
            <% foreach (WebApplication1.Modelo.Item item in itens){ %>
                <div class="col-xs-12 col-sm-4">
                    <img class="img-responsive" src="/Upload/imagem-produto/<% Response.Write(item.produto.imagem); %>" />
                    <p><% Response.Write(item.produto.descricao); %>, Tamanho <% Response.Write(item.tamanho.descricao); %></p>
                    <a href="/Cliente/carrinho.aspx?addpid=<% Response.Write(item.produto.id);%>addtid=<% Response.Write(item.tamanho.id); %>">Adicionar ao Carrinho</a>
                </div>       
            <% } %>
            <div class="col-xs-12">
                <nav aria-label="Navegação">
                  <ul class="pagination">
                    <% if (pagina != 1) { %>
                      <li>
                      <a href="#" aria-label="Anterior">
                        <span aria-hidden="true">&laquo;</span>
                      </a>
                    </li>
                    <% } %>
                    <% if (numPaginas <= 6)
                       {
                           for (int i = 1; i <= numPaginas; i++)
                           {
                               %>
                                    <li <% if (i == pagina) Response.Write("class='active'");  %>><a href="<%= String.Format("http://{0}/Vitrine.aspx?p={1}", HttpContext.Current.Request.Url.Authority, i) %>" ><%= i %></a></li>
                               <%
                           }
                       }
                       else
                       {
                           for (int i = 1; i < 4; i++)
                           {
                               %>
                                    <li <% if (i == pagina) Response.Write("class='active'");  %>><a href="<%= String.Format("http://{0}/Vitrine.aspx?p={1}", HttpContext.Current.Request.Url.Authority, i) %>" ><%= i %></a></li>
                               <%
                           }
                           %>
                           <li><a>...</a></li>
                           <%
                           for (int i = numPaginas - 2; i <= numPaginas; i++)
                           {
                               %>
                                    <li <% if (i == pagina) Response.Write("class='active'");  %>><a href="<%= String.Format("http://{0}/Vitrine.aspx?p={1}", HttpContext.Current.Request.Url.Authority, i) %>" ><%= i %></a></li>
                               <%
                           }
                       } 
                       
                    if (pagina != numPaginas){%>
                    <li>
                      <a href="<%= String.Format("http://{0}/Vitrine.aspx?p={1}", HttpContext.Current.Request.Url.Authority, pagina+1) %>" aria-label="Próximo">
                        <span aria-hidden="true">&raquo;</span>
                      </a>  
                    </li>
                    <% } %>
                  </ul>
                </nav>
            </div>
        </div>
    </div>
</asp:Content>
