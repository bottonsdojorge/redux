using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace redux.usuario
{
    public partial class detalhar : System.Web.UI.Page
    {
        private Modelo.Encomenda _encomenda;
        public Modelo.Encomenda encomenda
        {
            get { return _encomenda; }
            set { _encomenda = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            int idEncomenda = MetodosExtensao.GetValor(Request.QueryString["eid"]);
            encomenda = DAL.DALEncomenda.Select(idEncomenda);
            if (encomenda.Usuario.id != DAL.DALUsuario.GetCurrentUserId())
            {
                encomenda = new Modelo.Encomenda();
            }
        }
    }
}