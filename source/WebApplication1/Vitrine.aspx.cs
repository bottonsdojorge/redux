using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class Vitrine : System.Web.UI.Page
    {
        private List<Modelo.Item> _itens;
        public List<Modelo.Item> itens
        {
            get { return _itens; }
            set { _itens = value; }
        }

        private List<Modelo.Marcador> _marcadores;
        public List<Modelo.Marcador> marcadores
        {
            get { return _marcadores; }
            set { _marcadores = value; }
        }

        private List<int> _filtro;
        public List<int> filtro
        {
            get { return _filtro; }
            set { _filtro = value; }
        }

        private int _numPaginas;
        public int numPaginas
        {
            get { return _numPaginas; }
            set { _numPaginas = value; }
        }
        
        private int _pagina;
        public int pagina
        {
            get { return _pagina; }
            set { _pagina = value; }
        }
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
            // Vai dar erro se o bobão colocar uma string
            if (IsPostBack)
            {
                Session["marcadores"] = null;
            }
            if (Request.QueryString["p"] != null)
            {
                try
                {
                    this.pagina = Convert.ToInt32(Request.QueryString["p"]);
                }
                catch (FormatException)
                {
                    this.pagina = 1;
                }
            }

            if (pagina < 1)
                pagina = 1;

            this.initMarcadores();
            this.getVitrine();
        }

        /*
         * Faz um select de todos os produtos na vitrine e cospe o html para htmlVitrine
         * Alterar isso depois, absolutamente não é a melhor forma de se fazer.
         * Apenas paleativo
         */
        protected void getVitrine()
        {
            DAL.DALItem dalItem = new DAL.DALItem();
            this.numPaginas = dalItem.SelectNumPaginas(this.filtro);
            this.itens = dalItem.SelectToVitrine(this.filtro, this.pagina);
        }

        /*
         * Vai iniciar os marcadores selecionados (filtro) e os gerais também.
         * Não funciona com paginação.
         * Para funcionar:
         * 1 - Verifica se existe post 
         * 2 - Se não existir post, pode ser:
         *  A) Primeiro Acesso
         *  B) O usuario navegou.
         * 3 - Se existir POST, usuario pesquisou. Ai deveria salvar na sessão.
         * 4 - Definir a partir da sessão os marcadores.
         */
        protected void initMarcadores()
        {
            DAL.DALMarcador dalMarcador = new DAL.DALMarcador();
            this.marcadores = dalMarcador.SelectAll();
            this.filtro = new List<int>();

            if (Request.Form["marcadores"] != null)
            {
                Session["marcadores"] = Request.Form.GetValues("marcadores");
            }
            if (Session["marcadores"] != null)
            { 
                foreach (string marcador in (string[])Session["marcadores"])
                {
                    this.filtro.Add(Convert.ToInt32(marcador));
                }
            }
        }
    }
}