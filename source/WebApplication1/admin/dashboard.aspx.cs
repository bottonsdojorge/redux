using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace redux.admin
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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