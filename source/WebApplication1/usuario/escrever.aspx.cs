using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace redux.usuario
{
    public partial class escrever : System.Web.UI.Page
    {
        private static int _eid;
        public static int eid
        {
            get { return _eid; }
            set { _eid = value; }
        }
        private static Modelo.Mensagem _original;
        public static Modelo.Mensagem original
        {
            get { return _original; }
            set { _original = value; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Form.AllKeys.Contains("eid") && eid == 0)
                eid = Convert.ToInt32(Request.Form.GetValues("eid")[0]);
            else if (Request.Form.AllKeys.Contains("mid") && original == null)
                original = DAL.DALMensagem.Select(Convert.ToInt32(Request.Form.GetValues("mid")[0]));
            else if (!Request.Form.AllKeys.Contains("eid") && eid == 0 && !Request.Form.AllKeys.Contains("mid") && original == null)
                MetodosExtensao.Redirecionar("usuario/dashboard");
        }

        protected void submitMensagem_Click(object sender, EventArgs e)
        {
            string corpo = corpoMensagem.Value;
            Modelo.Mensagem mensagem;
            int did, rid;
            if (original == null)
            {
                did = Convert.ToInt32(ConfigurationManager.AppSettings["idAdmin"]);
                rid = App_Code.Global.uid;
            }
            else
            {
                did = original.remetente.id;
                eid = original.idEncomenda;
                rid = original.destinatario.id;
                original.visualizada = true;
                DAL.DALMensagem.Update(original);
            }
            mensagem = new Modelo.Mensagem(0, DateTime.Now, corpo, false, DAL.DALUsuario.Select(did), DAL.DALUsuario.Select(rid), eid);
            DAL.DALMensagem.Insert(mensagem);
            eid = 0;
            original = null;
            MetodosExtensao.Redirecionar("usuario/dashboard#mensagens");
        }
    }
}