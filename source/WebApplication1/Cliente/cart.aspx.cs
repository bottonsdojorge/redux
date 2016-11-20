using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.Cliente
{
    public partial class cart : System.Web.UI.Page
    {
        private Modelo.Carrinho _carro;
        public Modelo.Carrinho carro
        {
            get { return _carro; }
            set { _carro = value; }
        }

        protected DAL.DALCarrinho dalCarrinho;

        private List<Modelo.itemCarrinho> _itens;
        public List<Modelo.itemCarrinho> itens
        {
            get { return _itens; }
            set { _itens = value; }
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
                dalCarrinho = new DAL.DALCarrinho();
                getUsuarioId();
            }
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

        protected void checkAcoes()
        {
            if (Request.QueryString["addpid"] != null && Request.QueryString["addtid"] != null)
                inserirItem();
            else if (Request.QueryString["rpid"] != null && Request.QueryString["rtid"] != null)
                removerItem();
            
            initCarrinho();
            carro.calcularPrecoTotal();

            dalCarrinho.Update(carro);
        }

        protected void inserirItem()
        {
            /*
             * Definitivamente, esse método pra pegar da querystring está uma bosta.
             * O que tem que fazer de verdade?
             * O carrinho tem que ter um modo de adicionar o item.
             * Então.. Deveria adicionar o item ao carrinho (variavel), e depois usar um metodo do dal carrinho para atualizar?
             * Não pode, por que vai adicionar na lista, de forma a ficar duplicado
             * 
             * 
             */
            if (Request.QueryString.Count != 0)
            {
                int idProduto = MetodosExtensao.GetValor(Request.QueryString["addpid"]),
                    idTamanho = MetodosExtensao.GetValor(Request.QueryString["addtid"]),
                    quantidade = MetodosExtensao.GetValor(Request.QueryString["addq"]);
            
                if (idProduto != 0 && idTamanho != 0)
                {
                    DAL.DALItemCarrinho dalItemCarrinho = new DAL.DALItemCarrinho();
                    DAL.DALItem dalItem = new DAL.DALItem();

                    Modelo.itemCarrinho itemCarrinho;
                    Modelo.Item item;

                    item = dalItem.Select(idProduto, idTamanho);
                    itemCarrinho = new Modelo.itemCarrinho(usuarioId, item, quantidade);
                   
                    dalItemCarrinho.Insert(itemCarrinho);
                }
            }
        }

        protected void removerItem()
        {
            int idProduto = MetodosExtensao.GetValor(Request.QueryString["rpid"]);
            int idTamanho = MetodosExtensao.GetValor(Request.QueryString["rtid"]);

            if (idProduto != 0 && idTamanho != 0)
            {
                DAL.DALItemCarrinho dalItemCarrinho = new DAL.DALItemCarrinho();
                DAL.DALItem dalItem = new DAL.DALItem();

                Modelo.itemCarrinho itemCarrinho;
                Modelo.Item item;

                item = dalItem.Select(idProduto, idTamanho);
                itemCarrinho = new Modelo.itemCarrinho(usuarioId, item, 0);

                dalItemCarrinho.Delete(itemCarrinho);
            }
        }

        protected void initCarrinho()
        {
            this.carro = dalCarrinho.Select(usuarioId);
        }
    }
}