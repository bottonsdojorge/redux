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
        
        
        protected void Page_Load(object sender, EventArgs e)
        {
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
            this.itens = dalItem.SelectAll();

        }
    }
}