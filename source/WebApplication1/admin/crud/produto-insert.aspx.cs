using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

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
            Modelo.Produto produto;
            DAL.DALItem dalItem = new DAL.DALItem();
            Modelo.Item item;
            DAL.DALTamanho dalTamanho = new DAL.DALTamanho();
            Modelo.Tamanho tamanho;
            try
            {
                System.Drawing.Image imagem = System.Drawing.Image.FromStream(fileProduto.PostedFile.InputStream);
                produto = new Modelo.Produto(0, txtDescricao.Text, imagem, null);
                int idProduto = dalProduto.Insert(produto);
                produto = dalProduto.Select(idProduto);
                foreach (string tid in Request.Form.GetValues("tid"))
                {
                    tamanho = dalTamanho.Select(Convert.ToInt32(tid));
                    item = new Modelo.Item(produto, tamanho);
                    dalItem.Insert(item);
                }
                MetodosExtensao.Redirecionar("admin/crud/produto-select");
            }
            catch (ArgumentException)
            {
                Response.Write("Deu merda ai");
                throw;
            }
        }
    }
}