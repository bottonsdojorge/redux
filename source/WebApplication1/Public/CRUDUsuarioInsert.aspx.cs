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

namespace WebApplication1
{
    public partial class CRUDUsuarioInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void CreateUserWizard1_CreatedUser(object sender, EventArgs e)
        {
            Roles.AddUserToRole(CreateUserWizard1.UserName, "cliente");
            string aSQLConecStr;
            // Lendo a conexão de dados do Web.Config
            aSQLConecStr = ConfigurationManager.ConnectionStrings["BottonsDoJorgeConnectionString"].ConnectionString;

            // Abrindo a Conexão com o banco de dados
            SqlConnection aSQLCon = new SqlConnection(aSQLConecStr);
            aSQLCon.Open();

            // Executando o comando
            SqlCommand aSQL = new SqlCommand("INSERT INTO Usuario(id, nome, userLogin, userSenha, dataRegistro) VALUES (@id, @nome, @userLogin, @userSenha, @dataRegistro)", aSQLCon);
            aSQL.Parameters.AddWithValue("@id", Membership.GetUser(CreateUserWizard1.UserName).ProviderUserKey);
            aSQL.Parameters.AddWithValue("@nome", CreateUserWizard1.UserName);
            aSQL.Parameters.AddWithValue("@userLogin", CreateUserWizard1.UserName);
            aSQL.Parameters.AddWithValue("@userSenha", CreateUserWizard1.Password);
            aSQL.Parameters.AddWithValue("@dataRegistro", DateTime.Now);
            aSQL.ExecuteNonQuery();

            Response.Redirect("~/CRUDUsuarioSelect.aspx");

        }
    }
}