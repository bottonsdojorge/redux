using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace redux
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void frmLogin_LoggedIn(object sender, EventArgs e)
        {
            MembershipUser user = Membership.GetUser(frmLogin.UserName);
            GenericIdentity identity = new GenericIdentity(user.UserName);
            RolePrincipal principal = new RolePrincipal(identity);
            System.Threading.Thread.CurrentPrincipal = principal;
            HttpContext.Current.User = principal;
            App_Code.Global.uid = DAL.DALUsuario.GetCurrentUserId();
        }
    }
}