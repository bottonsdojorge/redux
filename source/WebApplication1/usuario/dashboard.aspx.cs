using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace redux.usuario
{
    public partial class dashboard : System.Web.UI.Page
    {
        private List<Modelo.Encomenda> _encomendas;
        public List<Modelo.Encomenda> encomendas
        {
            get { return _encomendas; }
            set { _encomendas = value; }
        }
                
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] funcoes = Roles.GetRolesForUser();
            if (funcoes.Contains("adm"))
                MetodosExtensao.Redirecionar("admin/dashboard");
            if (!IsPostBack)
            {
                int idUsuario = App_Code.Global.uid;
                encomendas = DAL.DALEncomenda.SelectFromUsuario(idUsuario);
            }
        }

        protected void srcsDashboard_Selecting(object sender, ObjectDataSourceSelectingEventArgs e)
        {
            e.InputParameters["idUsuario"] = App_Code.Global.uid;
        }

        protected void grvEncomendas_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "mensagem")
            {
                MetodosExtensao.Redirecionar("usuario/escrever", null, this.Page, new NameValueCollection { { "eid", e.CommandArgument.ToString() } });
            }
            else if (e.CommandName == "detalhar")
            {
                Response.Write("detalhar");
                Response.Write(e.CommandArgument);
                MetodosExtensao.Redirecionar("usuario/detalhar", new NameValueCollection { { "eid", e.CommandArgument.ToString() } });
            }
        }

        protected void grvMensagens_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "responder")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                var row = grvMensagens.Rows[index];
                string mid = grvMensagens.DataKeys[index].Value.ToString();
                NameValueCollection data = new NameValueCollection();
                data.Add("mid", mid);
                MetodosExtensao.Redirecionar("usuario/escrever", null, this.Page, data);
            }
        }
    }
}