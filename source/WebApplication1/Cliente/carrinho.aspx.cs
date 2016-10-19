using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class carrinho : System.Web.UI.Page
    {
        private Modelo.Carrinho _carro;
        public Modelo.Carrinho carro
        {
            get { return _carro; }
            set { _carro = value; }
        }
        
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
            this.getUsuarioId();
            this.initCarrinho();
            this.inserirItem();
        }

        /*
         * Apenas paleativo. Mover isto para o DAL usuario.
         */
        protected void getUsuarioId()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["BottonsDoJorgeConnectionString"].ConnectionString);
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
                            this.usuarioId = Convert.ToInt32(drUsuario["id"]);
                        }
                    }
                }
            }
            catch (SystemException)
            {
                throw;
            }
        }

        /*
         * O que está fazendo:
         * 1. Verifica se há algum item para adicionar ao carrinho
         * 2. Instancia itemCarrinho a partir da query stirng
         * 3. Insere item Carrinho.
         * 
         * O que tem que fazer:
         * 3. Verifica se o item já está inserido. Se sim, altera a quantidade.
         * 4. Se não, insere item.
         * 
         * Vai adicionar um item duplicaod se ele já estiver no carrinho.
         * Tem que verificar o Add.
         */
        protected void inserirItem()
        {
            int idProduto = Convert.ToInt32(Request.QueryString["addpid"]);
            int idTamanho = Convert.ToInt32(Request.QueryString["addtid"]);

            if (idProduto != 0 && idTamanho != 0)
            {
                DAL.DALCarrinho dalCarrinho = new DAL.DALCarrinho();
                DAL.DALItemCarrinho dalItemCarrinho = new DAL.DALItemCarrinho();
                DAL.DALItem dalItem = new DAL.DALItem();

                Modelo.itemCarrinho itemCarrinho;
                Modelo.Item item;

                item = dalItem.Select(idProduto, idTamanho);
                itemCarrinho = new Modelo.itemCarrinho(this.usuarioId, item, 1);
                dalItemCarrinho.Insert(itemCarrinho);

                initCarrinho();
            }
        }

        protected void initCarrinho()
        {
            DAL.DALCarrinho dalCarrinho = new DAL.DALCarrinho();
            this.carro = dalCarrinho.Select(usuarioId);
        }
    }
}