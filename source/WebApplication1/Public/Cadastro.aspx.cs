using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace redux
{
    public partial class CRUDUsuarioInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            Roles.AddUserToRole(wiz_criarUsuario.UserName, "cliente");
            string aSQLConecStr;

            // Lendo a conexão de dados do Web.Config
            aSQLConecStr = ConfigurationManager.ConnectionStrings["pedroPcConnectionString"].ConnectionString;

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();

            // Relaciona tabela usuários do projeto com a tabela do ASP.
            SqlCommand aSQL = new SqlCommand("INSERT INTO Usuario(nome, aspnet_id) VALUES (@nome, @id)", aSQLCon);
            aSQL.Parameters.AddWithValue("@nome", wiz_criarUsuario.UserName);
            aSQL.Parameters.AddWithValue("@id", Membership.GetUser(wiz_criarUsuario.UserName).ProviderUserKey);
            aSQL.ExecuteNonQuery();
            Response.Redirect("~/CRUDUsuarioSelect.aspx");

        }
    }
}