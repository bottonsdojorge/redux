using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.usuario
{
    public partial class dashboard : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] funcoes = Roles.GetRolesForUser();
            if (funcoes.Contains("adm"))
                MetodosExtensao.Redirecionar("admin/dashboard");
        }
    }
}