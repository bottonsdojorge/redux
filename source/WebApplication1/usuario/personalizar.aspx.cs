using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;
using System.Collections.Specialized;

namespace redux.usuario
{
    public partial class personalizar : System.Web.UI.Page
    {
        private System.Drawing.Image _imagem;
        public System.Drawing.Image imagem
        {
            get { return _imagem; }
            set { _imagem = value; }
        }
        

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnupload_Click(object sender, EventArgs e)
        {
            try
            {
                imagem = System.Drawing.Image.FromStream(fileProduto.PostedFile.InputStream);
                int tamanhoArquivo = fileProduto.PostedFile.ContentLength;
                string tipoArquivo = fileProduto.PostedFile.ContentType;

                if (!(tipoArquivo != "image/jpg" && tipoArquivo != "image/jpeg" && tipoArquivo != "image/png"))
                {
                    Modelo.Produto produto = new Modelo.Produto(0, nomeupload.Value, imagem, new List<Modelo.Marcador>(), true);
                    produto.id = DAL.DALProduto.Insert(produto);

                    Modelo.Item item = new Modelo.Item(produto, DAL.DALTamanho.Select(Convert.ToInt32(Request.Form["tid"])));
                    DAL.DALItem.Insert(item);

                    NameValueCollection query = new NameValueCollection()
                {
                    {"addtid", item.tamanho.id.ToString()},
                    {"addpid", item.produto.id.ToString()},
                    {"addq", Request.Form["q"]}
                };

                    MetodosExtensao.Redirecionar("usuario/cart", query);
                }
                else
                {
                    Response.Write("Algo aconteceu. Tente novamente");
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex.Message);
                throw;
            }
        }
    }
}