using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1
{
    public partial class CRUDProdutoInsert : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            DAL.DALProduto dalProduto = new DAL.DALProduto();
            Modelo.Produto produto = new Modelo.Produto();

            produto = new Modelo.Produto(0, txtDescricao.Text, txtEnderecoImg.Text, null);
            dalProduto.Insert(produto);           

            Response.Redirect("~/admin/CRUDProdutoSelect.aspx");
        }
    }
}