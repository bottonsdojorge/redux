using System;
using System.Collections.Generic;
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
                int idUsuario = DAL.DALUsuario.GetCurrentUserId();
                encomendas = DAL.DALEncomenda.SelectFromUsuario(idUsuario);
            }
        }
    }
}