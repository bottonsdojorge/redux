using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication1.admin.crud
{
    public partial class produto_insert2 : System.Web.UI.Page
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
            DAL.DALMarcador dalMarcador = new DAL.DALMarcador();
            Modelo.Marcador marcador;
            List<Modelo.Marcador> marcadores = new List<Modelo.Marcador>();

            try
            {
                foreach (string mid in Request.Form.GetValues("mid"))
                {
                    marcador = dalMarcador.Select(Convert.ToInt32(mid));
                    marcadores.Add(marcador);
                }
                System.Drawing.Image imagem = System.Drawing.Image.FromStream(fileProduto.PostedFile.InputStream);
                produto = new Modelo.Produto(0, txtDescricao.Text, imagem, marcadores);
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