using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.usuario
{
    public partial class cart : System.Web.UI.Page
    {
        private Modelo.Carrinho _carro;
        public Modelo.Carrinho carro
        {
            get { return _carro; }
            set { _carro = value; }
        }

        protected DAL.DALCarrinho dalCarrinho = new DAL.DALCarrinho();

        private int _usuarioId;
        public int usuarioId
        {
            get { return _usuarioId; }
            set { _usuarioId = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            getUsuarioId();
            initCarrinho();
            checkAcoes();
        }

        /*
         * Apenas paleativo. Mover isto para o DAL usuario.
         */
        protected void getUsuarioId()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["pedroPcConnectionString"].ConnectionString);
            try
            {
                MembershipUser usuario = Membership.GetUser();
                string usuarioAspnet_id = Convert.ToString(usuario.ProviderUserKey);
                using (conn)
                {
                    conn.Open();
                    // O SQL do id do usuario.
                    string sqlUsuario = "SELECT id FROM Usuario WHERE aspnet_id = @aspnet_id";
                    SqlCommand cmdUsuario = new SqlCommand(sqlUsuario, conn);
                    cmdUsuario.Parameters.Add("@aspnet_id", System.Data.SqlDbType.VarChar).Value = usuarioAspnet_id;
                    SqlDataReader drUsuario;

                    using (drUsuario = cmdUsuario.ExecuteReader())
                    {
                        if (drUsuario.HasRows)
                        {
                            drUsuario.Read();
                            usuarioId = Convert.ToInt32(drUsuario["id"]);
                        }
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }

        protected void initCarrinho()
        {
            this.carro = dalCarrinho.Select(usuarioId);
        }

        protected void checkAcoes()
        {
            int idProduto = MetodosExtensao.GetValor(Request.QueryString["addpid"]),
                    idTamanho = MetodosExtensao.GetValor(Request.QueryString["addtid"]),
                    quantidade = MetodosExtensao.GetValor(Request.QueryString["addq"]),
                    ridProduto = MetodosExtensao.GetValor(Request.QueryString["rpid"]),
                    ridTamanho = MetodosExtensao.GetValor(Request.QueryString["rtid"]);

            if (idProduto != 0 && idTamanho != 0)
            {
                dalCarrinho.InserirItem(idProduto, idTamanho, quantidade, carro);
            }
            else if (ridProduto != 0 && ridTamanho != 0)
            {
                dalCarrinho.RemoverItem(ridProduto, ridTamanho, carro);
            }
            initCarrinho();
        }

        protected void btnLimparCarrinho_Click(object sender, EventArgs e)
        {
            dalCarrinho.Limpar(carro);
            initCarrinho();
        }
    }
}