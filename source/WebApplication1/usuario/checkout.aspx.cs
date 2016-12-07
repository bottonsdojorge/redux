using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace redux.usuario
{
    public partial class checkout : System.Web.UI.Page
    {
        private List<Modelo.localEntrega> _locaisEntrega;
        public List<Modelo.localEntrega> locaisEntrega
        {
            get { return _locaisEntrega; }
            set { _locaisEntrega = value; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            InitLocaisEntrega();
        }

        private void InitLocaisEntrega()
        {
            locaisEntrega = DAL.DALLocalEntrega.SelectAll();
        }

        protected void RegistrarEncomenda(object sender, EventArgs e)
        {
            int leid = Convert.ToInt32(Request.Form["leid"]);
            int uid = Convert.ToInt32(Session["uid"]);
            DAL.DALEncomenda.RegistrarEncomenda(uid, leid);
            MetodosExtensao.Redirecionar("usuario/dashboard", new System.Collections.Specialized.NameValueCollection {{"tab","encomendas"}});
        }
    }
}