using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.usuario
{
    public partial class checkout : System.Web.UI.Page
    {
        private List<Modelo.localEntrega> _locaisEntrega;
        public List<Modelo.localEntrega> locaisEntrega
        {
            get { return _locaisEntrega; }
            set { _locaisEntrega = value; }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            InitLocaisEntrega();
        }

        private void InitLocaisEntrega()
        {
            DAL.DALLocalEntrega dalLocalEntrega = new DAL.DALLocalEntrega();
            locaisEntrega = dalLocalEntrega.SelectAll();
        }
    }
}