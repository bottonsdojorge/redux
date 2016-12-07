using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace redux.admin.crud
{
    public partial class produto_insert2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            Modelo.Produto produto;
            Modelo.Item item;
            Modelo.Tamanho tamanho;
            Modelo.Marcador marcador;
            List<Modelo.Marcador> marcadores = new List<Modelo.Marcador>();

            try
            {
                foreach (string mid in Request.Form.GetValues("mid"))
                {
                    marcador = DAL.DALMarcador.Select(Convert.ToInt32(mid));
                    marcadores.Add(marcador);
                }
                System.Drawing.Image imagem = System.Drawing.Image.FromStream(fileProduto.PostedFile.InputStream);
                produto = new Modelo.Produto(0, txtDescricao.Text, imagem, marcadores);
                int idProduto = DAL.DALProduto.Insert(produto);
                produto = DAL.DALProduto.Select(idProduto);
                foreach (string tid in Request.Form.GetValues("tid"))
                {
                    tamanho = DAL.DALTamanho.Select(Convert.ToInt32(tid));
                    item = new Modelo.Item(produto, tamanho);
                    DAL.DALItem.Insert(item);
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