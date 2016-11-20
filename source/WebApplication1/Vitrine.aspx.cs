using System;
using System.Collections.Generic;
using System.Collections.Specialized;
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

        private string _paginacao;
        public string paginacao
        {
            get { return _paginacao; }
            set { _paginacao = value; }
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

            initMarcadores();
            getVitrine();
            paginar();
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

        protected void paginar()
        {
            string urlVitrine = WebApplication1.MetodosExtensao.GetLink("Vitrine") + "?p=";
            bool ativo;
            string classeAtivo = "class='active'";

            string btnAnterior = (pagina != 1) ? String.Format(@"<li>
                                                    <a href='{0}' aria-label='Anterior'>
                                                        <span aria-hidden='true'>&laquo;</span>
                                                    </a>
                                                   </li>", urlVitrine, pagina - 1) : "";

            string btnProx = (pagina != numPaginas) ? String.Format(@"<li>
                                                    <a href='{0}{1}' aria-label='Próximo'>
                                                        <span aria-hidden='true'>&raquo;</span>
                                                    </a>
                                                   </li>", urlVitrine, pagina + 1) : "";

            paginacao += btnAnterior;
            if (numPaginas <= 10 || pagina < 5)
            {
                for (int i = 1; i <= numPaginas; i++)
                {
                    ativo = (i == pagina) ? true : false;
                    paginacao += String.Format(@"<li {2}>
                                                    <a href='{0}{1}'>{1}</a>
                                                </li>
                                                ", urlVitrine, i, (ativo) ? classeAtivo : "");
                }
            }
            else
            {
                for (int i = pagina - 5; i < pagina; i++)
                {
                    if (i > 0)
                    {
                        paginacao += String.Format(@"<li>
                                                    <a href='{0}{1}'>{1}</a>
                                                </li>
                                                ", urlVitrine, i);

                    }
                }
                paginacao += String.Format(@"<li {2}>
                                                    <a href='{0}{1}'>{1}</a>
                                                </li>
                                                ", urlVitrine, pagina, classeAtivo);
                for (int i = 1; i < 6; i++)
                {
                    if (pagina + i <= numPaginas)
                    {
                        paginacao += String.Format(@"<li>
                                                    <a href='{0}{1}'>{1}</a>
                                                </li>
                                                ", urlVitrine, pagina+i);
                    }
                }
                    
            }
            paginacao += btnProx;
        }
    }
}