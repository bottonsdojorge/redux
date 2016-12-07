using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace redux.usuario
{
    public partial class cart : System.Web.UI.Page
    {
        private Modelo.Carrinho _carro;
        public Modelo.Carrinho carro
        {
            get { return _carro; }
            set { _carro = value; }
        }

        private int _usuarioId;
        public int usuarioId
        {
            get { return _usuarioId; }
            set { _usuarioId = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                usuarioId = DAL.DALUsuario.GetCurrentUserId(Membership.GetUser().ProviderUserKey.ToString());
                Session["uid"] = usuarioId;
            }
            initCarrinho();
            checkAcoes();
        }

        protected void initCarrinho()
        {
            carro = DAL.DALCarrinho.Select(usuarioId);
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
                DAL.DALCarrinho.InserirItem(idProduto, idTamanho, quantidade, carro);
            }
            else if (ridProduto != 0 && ridTamanho != 0)
            {
                DAL.DALCarrinho.RemoverItem(ridProduto, ridTamanho, carro);
            }
            initCarrinho();
        }

        protected void btnLimparCarrinho_Click(object sender, EventArgs e)
        {
            DAL.DALCarrinho.Limpar(carro);
            initCarrinho();
        }
    }
}